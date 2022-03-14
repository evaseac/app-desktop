namespace Evaseac
{
    partial class frmExport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExport));
            this.lblSites = new System.Windows.Forms.Label();
            this.chkCalculatedPrms = new System.Windows.Forms.CheckBox();
            this.chkMacro = new System.Windows.Forms.CheckBox();
            this.chkOtherTsts = new System.Windows.Forms.CheckBox();
            this.chkRawPrms = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAvailableStsPrms = new System.Windows.Forms.Label();
            this.lblAvailableStsRawPrms = new System.Windows.Forms.Label();
            this.lblAvailableStsMacro = new System.Windows.Forms.Label();
            this.lblAvailableStsOtherTsts = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSites
            // 
            this.lblSites.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSites.AutoSize = true;
            this.lblSites.Font = new System.Drawing.Font("Microsoft NeoGothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSites.Location = new System.Drawing.Point(93, 25);
            this.lblSites.MaximumSize = new System.Drawing.Size(600, 17);
            this.lblSites.Name = "lblSites";
            this.lblSites.Size = new System.Drawing.Size(110, 17);
            this.lblSites.TabIndex = 0;
            this.lblSites.Text = "Sitios escogidos: ";
            // 
            // chkCalculatedPrms
            // 
            this.chkCalculatedPrms.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkCalculatedPrms.AutoSize = true;
            this.chkCalculatedPrms.Location = new System.Drawing.Point(33, 100);
            this.chkCalculatedPrms.Name = "chkCalculatedPrms";
            this.chkCalculatedPrms.Size = new System.Drawing.Size(214, 21);
            this.chkCalculatedPrms.TabIndex = 2;
            this.chkCalculatedPrms.Text = "Exportar parámetros calculados";
            this.chkCalculatedPrms.UseVisualStyleBackColor = true;
            this.chkCalculatedPrms.CheckedChanged += new System.EventHandler(this.chkCalculatedPrms_CheckedChanged);
            // 
            // chkMacro
            // 
            this.chkMacro.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkMacro.AutoSize = true;
            this.chkMacro.Location = new System.Drawing.Point(33, 180);
            this.chkMacro.Name = "chkMacro";
            this.chkMacro.Size = new System.Drawing.Size(268, 21);
            this.chkMacro.TabIndex = 6;
            this.chkMacro.Text = "Exportar macroinvertebrados ingresados";
            this.chkMacro.UseVisualStyleBackColor = true;
            this.chkMacro.CheckedChanged += new System.EventHandler(this.chkMacro_CheckedChanged);
            // 
            // chkOtherTsts
            // 
            this.chkOtherTsts.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkOtherTsts.AutoSize = true;
            this.chkOtherTsts.Location = new System.Drawing.Point(33, 220);
            this.chkOtherTsts.Name = "chkOtherTsts";
            this.chkOtherTsts.Size = new System.Drawing.Size(244, 21);
            this.chkOtherTsts.TabIndex = 8;
            this.chkOtherTsts.Text = "Exportar otras pruebas y parámetros";
            this.chkOtherTsts.UseVisualStyleBackColor = true;
            this.chkOtherTsts.CheckedChanged += new System.EventHandler(this.chkOtherTsts_CheckedChanged);
            // 
            // chkRawPrms
            // 
            this.chkRawPrms.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkRawPrms.AutoSize = true;
            this.chkRawPrms.Location = new System.Drawing.Point(33, 140);
            this.chkRawPrms.Name = "chkRawPrms";
            this.chkRawPrms.Size = new System.Drawing.Size(193, 21);
            this.chkRawPrms.TabIndex = 4;
            this.chkRawPrms.Text = "Exportar parámetros crudos";
            this.chkRawPrms.UseVisualStyleBackColor = true;
            this.chkRawPrms.CheckedChanged += new System.EventHandler(this.chkRawPrms_CheckedChanged);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft NeoGothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(325, 320);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(107, 27);
            this.btnExport.TabIndex = 12;
            this.btnExport.Text = "Exportar";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft MHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Escoja las hojas de excel que desea generar:";
            // 
            // lblAvailableStsPrms
            // 
            this.lblAvailableStsPrms.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAvailableStsPrms.AutoSize = true;
            this.lblAvailableStsPrms.Font = new System.Drawing.Font("Microsoft MHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableStsPrms.Location = new System.Drawing.Point(313, 101);
            this.lblAvailableStsPrms.Name = "lblAvailableStsPrms";
            this.lblAvailableStsPrms.Size = new System.Drawing.Size(103, 16);
            this.lblAvailableStsPrms.TabIndex = 7;
            this.lblAvailableStsPrms.Text = "Sitios Disponibles:";
            // 
            // lblAvailableStsRawPrms
            // 
            this.lblAvailableStsRawPrms.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAvailableStsRawPrms.AutoSize = true;
            this.lblAvailableStsRawPrms.Font = new System.Drawing.Font("Microsoft MHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableStsRawPrms.Location = new System.Drawing.Point(313, 141);
            this.lblAvailableStsRawPrms.Name = "lblAvailableStsRawPrms";
            this.lblAvailableStsRawPrms.Size = new System.Drawing.Size(103, 16);
            this.lblAvailableStsRawPrms.TabIndex = 8;
            this.lblAvailableStsRawPrms.Text = "Sitios Disponibles:";
            // 
            // lblAvailableStsMacro
            // 
            this.lblAvailableStsMacro.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAvailableStsMacro.AutoSize = true;
            this.lblAvailableStsMacro.Font = new System.Drawing.Font("Microsoft MHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableStsMacro.Location = new System.Drawing.Point(313, 184);
            this.lblAvailableStsMacro.Name = "lblAvailableStsMacro";
            this.lblAvailableStsMacro.Size = new System.Drawing.Size(103, 16);
            this.lblAvailableStsMacro.TabIndex = 9;
            this.lblAvailableStsMacro.Text = "Sitios Disponibles:";
            // 
            // lblAvailableStsOtherTsts
            // 
            this.lblAvailableStsOtherTsts.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAvailableStsOtherTsts.AutoSize = true;
            this.lblAvailableStsOtherTsts.Font = new System.Drawing.Font("Microsoft MHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableStsOtherTsts.Location = new System.Drawing.Point(313, 221);
            this.lblAvailableStsOtherTsts.Name = "lblAvailableStsOtherTsts";
            this.lblAvailableStsOtherTsts.Size = new System.Drawing.Size(103, 16);
            this.lblAvailableStsOtherTsts.TabIndex = 10;
            this.lblAvailableStsOtherTsts.Text = "Sitios Disponibles:";
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFileName.Location = new System.Drawing.Point(199, 280);
            this.txtFileName.MaxLength = 25;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(442, 25);
            this.txtFileName.TabIndex = 10;
            this.txtFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft MHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nombre del archivo";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft MHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(647, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = ".xlsx";
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft MHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(438, 326);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 16);
            this.lblProgress.TabIndex = 10;
            // 
            // frmExport
            // 
            this.AcceptButton = this.btnExport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 361);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblAvailableStsOtherTsts);
            this.Controls.Add(this.lblAvailableStsMacro);
            this.Controls.Add(this.lblAvailableStsRawPrms);
            this.Controls.Add(this.lblAvailableStsPrms);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.chkRawPrms);
            this.Controls.Add(this.chkOtherTsts);
            this.Controls.Add(this.chkMacro);
            this.Controls.Add(this.chkCalculatedPrms);
            this.Controls.Add(this.lblSites);
            this.Font = new System.Drawing.Font("Microsoft JhengHei Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1328, 707);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(728, 350);
            this.Name = "frmExport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exportar";
            this.Load += new System.EventHandler(this.frmExport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSites;
        private System.Windows.Forms.CheckBox chkCalculatedPrms;
        private System.Windows.Forms.CheckBox chkMacro;
        private System.Windows.Forms.CheckBox chkOtherTsts;
        private System.Windows.Forms.CheckBox chkRawPrms;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAvailableStsPrms;
        private System.Windows.Forms.Label lblAvailableStsRawPrms;
        private System.Windows.Forms.Label lblAvailableStsMacro;
        private System.Windows.Forms.Label lblAvailableStsOtherTsts;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblProgress;
    }
}