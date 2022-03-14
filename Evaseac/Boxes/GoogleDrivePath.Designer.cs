namespace Evaseac.Boxes
{
    partial class frmGoogleDrivePath
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGoogleDrivePath));
            this.lblTaxon = new System.Windows.Forms.Label();
            this.btnChoose = new System.Windows.Forms.Button();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.trvDirectories = new System.Windows.Forms.TreeView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtFolderId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTaxon
            // 
            this.lblTaxon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTaxon.AutoSize = true;
            this.lblTaxon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblTaxon.Location = new System.Drawing.Point(12, 15);
            this.lblTaxon.Name = "lblTaxon";
            this.lblTaxon.Size = new System.Drawing.Size(36, 16);
            this.lblTaxon.TabIndex = 13;
            this.lblTaxon.Text = "Ruta";
            // 
            // btnChoose
            // 
            this.btnChoose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnChoose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChoose.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChoose.Location = new System.Drawing.Point(85, 222);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(100, 28);
            this.btnChoose.TabIndex = 4;
            this.btnChoose.Text = "Escoger";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // txtRoute
            // 
            this.txtRoute.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F);
            this.txtRoute.Location = new System.Drawing.Point(54, 12);
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.Size = new System.Drawing.Size(318, 28);
            this.txtRoute.TabIndex = 0;
            // 
            // trvDirectories
            // 
            this.trvDirectories.Location = new System.Drawing.Point(12, 46);
            this.trvDirectories.Name = "trvDirectories";
            this.trvDirectories.Size = new System.Drawing.Size(360, 170);
            this.trvDirectories.TabIndex = 2;
            this.trvDirectories.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvDirectories_AfterSelect);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(201, 222);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtFolderId
            // 
            this.txtFolderId.Enabled = false;
            this.txtFolderId.Location = new System.Drawing.Point(12, 227);
            this.txtFolderId.Name = "txtFolderId";
            this.txtFolderId.Size = new System.Drawing.Size(29, 20);
            this.txtFolderId.TabIndex = 14;
            this.txtFolderId.Visible = false;
            // 
            // frmGoogleDrivePath
            // 
            this.AcceptButton = this.btnChoose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.txtFolderId);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.trvDirectories);
            this.Controls.Add(this.txtRoute);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.lblTaxon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGoogleDrivePath";
            this.Opacity = 0.95D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Escoger archivo";
            this.Load += new System.EventHandler(this.frmGoogleDrivePath_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTaxon;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.TreeView trvDirectories;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtFolderId;
    }
}