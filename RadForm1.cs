using ImageMagick;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

namespace OptimizationImages
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {

        public RadForm1()
        {
            InitializeComponent();
        }

        private void RadForm1_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'masterDataSet1.affectation'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.affectationTableAdapter.Fill(this.masterDataSet1.affectation);

        }
        //Commencer l’optimisation des images
        private async void radButton1_Click(object sender, EventArgs e)
        {
            if (srcTbox.Text == "" || dstTbox.Text == "")
                return;
            //la Base de données sélectionné
            var db = siteDdl.SelectedValue.ToString();
            var conStr = ConfigurationManager.ConnectionStrings["OptimizationImages.Properties.Settings.masterConnectionString"]
                                             .ConnectionString.Replace("master", db);

            //Filtres des pieces

            var images70kb = new string[]
            {
                "FICHE DE VÉRIFICATION",
                "PAGE DE GARDE",
                "PAGE DE GARDE DU SOUS-DOSSIER"
            };
            var images200_500kb = new string[]
            {
                "CROQUIS DE BORNAGE",
                "CROQUIS DE LEVÉ"
            };
            var image1024_2048kb = "PRÉSENTATION SYNOPTIQUE DE LEVÉ";
            //les images 300kb commence par PLAN
            //et le reste des images à 60kb
            var images_except_60kb = new string[]
            {
                "FICHE DE VÉRIFICATION",
                "PAGE DE GARDE",
                "PAGE DE GARDE DU SOUS-DOSSIER",
                "CROQUIS DE BORNAGE",
                "CROQUIS DE LEVÉ",
                "PRÉSENTATION SYNOPTIQUE DE LEVÉ",
            };

            //Connexion à la base
            using (var con = new SqlConnection(conStr))
            {
                //Sélectionner toutes les images de la tranche
                var requette = "SELECT ID_PIECE,Nature_Acte,CHEMIN_PHYSIQUE,TAILLE FROM PIECE";
                con.Open();
                var da = new SqlDataAdapter(requette, con);
                var dt = new DataTable();
                da.Fill(dt);
                var total = dt.Rows.Count;

                //Démarrer l'optimisation
                var progress = new Progress<int>(percent =>
                {
                    radProgressBar1.Value1 = percent * 100 / total;
                    radProgressBar1.Text = $"{percent}/{total} ({percent * 100 / total}%)";
                });
                await Task.Run(() => StartOptimization(progress, images70kb, images200_500kb, image1024_2048kb, images_except_60kb, dt));

                MessageBox.Show("Done!");
            }
        }

        private void StartOptimization(IProgress<int> progress, string[] images70kb, string[] images200_500kb, string image1024_2048kb, string[] images_except_60kb, DataTable dt)
        {
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                var imgFile = row["CHEMIN_PHYSIQUE"].ToString().Replace("/", "\\");

                //Verifier si la taille est calculé
                row["TAILLE"] = row["TAILLE"] ?? (File.Exists(imgFile) ? new FileInfo(imgFile).Length / 1024 : 0);

                var Taille = int.Parse(row["TAILLE"].ToString());
                var NomPiece = row["Nature_Acte"].ToString();

                //images 70kb
                if (images70kb.Contains(NomPiece) && Taille > 70)
                {
                    OptimizeImage(imgFile, 70);
                }
                //images 300kb
                else if (NomPiece.StartsWith("PLAN") && Taille > 300)
                {
                    OptimizeImage(imgFile, 300);
                }
                //images 200kb
                else if (images200_500kb.Contains(NomPiece) && Taille > 200 && Taille < 500)
                {
                    OptimizeImage(imgFile, 200);
                }
                //images 500kb
                else if (images200_500kb.Contains(NomPiece) && Taille > 500)
                {
                    OptimizeImage(imgFile, 500);
                }
                //images 1024kb
                else if (image1024_2048kb == (NomPiece) && Taille > 1024 && Taille < 2048)
                {
                    OptimizeImage(imgFile, 1024);
                }
                //images 2048kb
                else if (image1024_2048kb == (NomPiece) && Taille > 2048)
                {
                    OptimizeImage(imgFile, 2048);
                }
                //images 60kb
                else if (!images_except_60kb.Contains(NomPiece) && !NomPiece.StartsWith("PLAN") && Taille > 60)
                {
                    OptimizeImage(imgFile, 60);
                }
                //si la taille est bonne copier
                else
                {
                    var destFile = imgFile.Replace(srcTbox.Text, dstTbox.Text);
                    if (File.Exists(imgFile) && !File.Exists(destFile))
                    {
                        var destDir = Path.GetDirectoryName(destFile);
                        if (!Directory.Exists(destDir))
                        {
                            Directory.CreateDirectory(destDir);
                        }
                        File.Copy(imgFile, destFile);
                    }

                }
                if (progress != null)
                    progress.Report(++i);
            }
        }

        private void OptimizeImage(string imgFile, int size)
        {
            var destFile = imgFile.Replace(srcTbox.Text, dstTbox.Text);
            //Si l'image destination n'existe pas
            if (File.Exists(destFile))
                return;
            
            var conversionFile = Path.ChangeExtension(destFile, ".jpg");
            Bitmap bitmap = new Bitmap(imgFile);
            //ouvrir l'image
            using (var image = new MagickImage(bitmap))
            {
                // Définir les option de conversion
                //Format JPEG ne dépassant pas la taille 
                image.Settings.SetDefine(MagickFormat.Jpeg, "extent", $"{size}kb");
                //Qualité
                image.Quality = 100;
                //DPI 
                image.Density = new Density(300);

                //Créer la structure du chemin destination
                var destDir = Path.GetDirectoryName(destFile);
                if (!Directory.Exists(destDir))
                {
                    Directory.CreateDirectory(destDir);
                }

                //Enregistrer
                image.Write(conversionFile);
            }

            //Renommer l'extension de l'image si elle n'est pas '.jpg'
            if (Path.GetExtension(imgFile) != ".jpg")
            {
                File.Move(conversionFile, destFile);
            }
        }

        //Sélectionner le chemin source
        private void srcBtn_Click(object sender, EventArgs e)
        {
            var folderLauncher = new FolderBrowserDialog();
            if (folderLauncher.ShowDialog() == DialogResult.OK)
            {
                srcTbox.Text = folderLauncher.SelectedPath.EndsWith("\\") ? folderLauncher.SelectedPath.TrimEnd('\\') : folderLauncher.SelectedPath;
            }

        }
        //Sélectionner la destination
        private void dstBtn_Click(object sender, EventArgs e)
        {
            var folderLauncher = new FolderBrowserDialog();
            if (folderLauncher.ShowDialog() == DialogResult.OK)
            {
                dstTbox.Text = folderLauncher.SelectedPath;
            }
        }
    }
}
