namespace OptimizationImages
{
    partial class RadForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.startBtn = new Telerik.WinControls.UI.RadButton();
            this.siteDdl = new Telerik.WinControls.UI.RadDropDownList();
            this.affectationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.masterDataSet1 = new OptimizationImages.GetDatabasesList();
            this.siteLbl = new Telerik.WinControls.UI.RadLabel();
            this.affectationTableAdapter = new OptimizationImages.masterDataSet1TableAdapters.affectationTableAdapter();
            this.srcLbl = new Telerik.WinControls.UI.RadLabel();
            this.destLbl = new Telerik.WinControls.UI.RadLabel();
            this.radProgressBar1 = new Telerik.WinControls.UI.RadProgressBar();
            this.dstTbox = new Telerik.WinControls.UI.RadButtonTextBox();
            this.dstBtn = new Telerik.WinControls.UI.RadButtonElement();
            this.srcTbox = new Telerik.WinControls.UI.RadButtonTextBox();
            this.srcBtn = new Telerik.WinControls.UI.RadButtonElement();
            ((System.ComponentModel.ISupportInitialize)(this.startBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteDdl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.affectationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.srcLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.destLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstTbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.srcTbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(275, 227);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(110, 24);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "Commencer";
            this.startBtn.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // siteDdl
            // 
            this.siteDdl.DataSource = this.affectationBindingSource;
            this.siteDdl.DisplayMember = "Site";
            this.siteDdl.Location = new System.Drawing.Point(154, 28);
            this.siteDdl.Name = "siteDdl";
            this.siteDdl.Size = new System.Drawing.Size(231, 20);
            this.siteDdl.TabIndex = 1;
            this.siteDdl.ValueMember = "name";
            // 
            // affectationBindingSource
            // 
            this.affectationBindingSource.DataMember = "affectation";
            this.affectationBindingSource.DataSource = this.masterDataSet1;
            // 
            // masterDataSet1
            // 
            this.masterDataSet1.DataSetName = "masterDataSet1";
            this.masterDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // siteLbl
            // 
            this.siteLbl.Location = new System.Drawing.Point(11, 28);
            this.siteLbl.Name = "siteLbl";
            this.siteLbl.Size = new System.Drawing.Size(25, 18);
            this.siteLbl.TabIndex = 2;
            this.siteLbl.Text = "Site";
            // 
            // affectationTableAdapter
            // 
            this.affectationTableAdapter.ClearBeforeFill = true;
            // 
            // srcLbl
            // 
            this.srcLbl.Location = new System.Drawing.Point(10, 74);
            this.srcLbl.Name = "srcLbl";
            this.srcLbl.Size = new System.Drawing.Size(95, 18);
            this.srcLbl.TabIndex = 2;
            this.srcLbl.Text = "Repertoire source";
            // 
            // destLbl
            // 
            this.destLbl.Location = new System.Drawing.Point(10, 120);
            this.destLbl.Name = "destLbl";
            this.destLbl.Size = new System.Drawing.Size(117, 18);
            this.destLbl.TabIndex = 2;
            this.destLbl.Text = "Repertoire destination";
            // 
            // radProgressBar1
            // 
            this.radProgressBar1.Location = new System.Drawing.Point(12, 180);
            this.radProgressBar1.Name = "radProgressBar1";
            this.radProgressBar1.Size = new System.Drawing.Size(375, 28);
            this.radProgressBar1.Step = 1;
            this.radProgressBar1.TabIndex = 4;
            // 
            // dstTbox
            // 
            this.dstTbox.Location = new System.Drawing.Point(154, 120);
            this.dstTbox.Name = "dstTbox";
            this.dstTbox.RightButtonItems.AddRange(new Telerik.WinControls.RadItem[] {
            this.dstBtn});
            this.dstTbox.Size = new System.Drawing.Size(231, 23);
            this.dstTbox.TabIndex = 6;
            // 
            // dstBtn
            // 
            this.dstBtn.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.dstBtn.Name = "dstBtn";
            this.dstBtn.Text = " ... ";
            this.dstBtn.ToolTipText = "Ouvrir le dossier destination";
            this.dstBtn.Click += new System.EventHandler(this.dstBtn_Click);
            // 
            // srcTbox
            // 
            this.srcTbox.Location = new System.Drawing.Point(154, 74);
            this.srcTbox.Name = "srcTbox";
            this.srcTbox.RightButtonItems.AddRange(new Telerik.WinControls.RadItem[] {
            this.srcBtn});
            this.srcTbox.Size = new System.Drawing.Size(231, 23);
            this.srcTbox.TabIndex = 7;
            this.srcTbox.Text = "Z:";
            // 
            // srcBtn
            // 
            this.srcBtn.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.srcBtn.Name = "srcBtn";
            this.srcBtn.Text = " ... ";
            this.srcBtn.ToolTipText = "Ouvrir le chemin source qui contient les images";
            this.srcBtn.Click += new System.EventHandler(this.srcBtn_Click);
            // 
            // RadForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 271);
            this.Controls.Add(this.srcTbox);
            this.Controls.Add(this.dstTbox);
            this.Controls.Add(this.radProgressBar1);
            this.Controls.Add(this.destLbl);
            this.Controls.Add(this.srcLbl);
            this.Controls.Add(this.siteLbl);
            this.Controls.Add(this.siteDdl);
            this.Controls.Add(this.startBtn);
            this.Name = "RadForm1";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Optimization images";
            this.Load += new System.EventHandler(this.RadForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.startBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteDdl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.affectationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.srcLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.destLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstTbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.srcTbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton startBtn;
        private Telerik.WinControls.UI.RadDropDownList siteDdl;
        private Telerik.WinControls.UI.RadLabel siteLbl;
        private GetDatabasesList masterDataSet1;
        private System.Windows.Forms.BindingSource affectationBindingSource;
        private masterDataSet1TableAdapters.affectationTableAdapter affectationTableAdapter;
        private Telerik.WinControls.UI.RadLabel srcLbl;
        private Telerik.WinControls.UI.RadLabel destLbl;
        private Telerik.WinControls.UI.RadProgressBar radProgressBar1;
        private Telerik.WinControls.UI.RadButtonTextBox dstTbox;
        private Telerik.WinControls.UI.RadButtonElement dstBtn;
        private Telerik.WinControls.UI.RadButtonTextBox srcTbox;
        private Telerik.WinControls.UI.RadButtonElement srcBtn;
    }
}
