namespace Evaseac
{
    partial class frmEditMode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditMode));
            this.radParams = new System.Windows.Forms.RadioButton();
            this.radSites = new System.Windows.Forms.RadioButton();
            this.chkAsk = new System.Windows.Forms.CheckBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // radParams
            // 
            this.radParams.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radParams.AutoSize = true;
            this.radParams.Checked = true;
            this.radParams.Location = new System.Drawing.Point(70, 23);
            this.radParams.Name = "radParams";
            this.radParams.Size = new System.Drawing.Size(111, 21);
            this.radParams.TabIndex = 0;
            this.radParams.TabStop = true;
            this.radParams.Text = "Por parámetros";
            this.radParams.UseVisualStyleBackColor = true;
            // 
            // radSites
            // 
            this.radSites.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radSites.AutoSize = true;
            this.radSites.Location = new System.Drawing.Point(195, 23);
            this.radSites.Name = "radSites";
            this.radSites.Size = new System.Drawing.Size(75, 21);
            this.radSites.TabIndex = 1;
            this.radSites.Text = "Por sitios";
            this.radSites.UseVisualStyleBackColor = true;
            // 
            // chkAsk
            // 
            this.chkAsk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkAsk.AutoSize = true;
            this.chkAsk.Location = new System.Drawing.Point(95, 53);
            this.chkAsk.Name = "chkAsk";
            this.chkAsk.Size = new System.Drawing.Size(149, 21);
            this.chkAsk.TabIndex = 2;
            this.chkAsk.Text = "No volver a preguntar";
            this.chkAsk.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft NeoGothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(115, 98);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(107, 27);
            this.btnAccept.TabIndex = 13;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 50);
            this.panel1.TabIndex = 14;
            // 
            // frmEditMode
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(339, 136);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.chkAsk);
            this.Controls.Add(this.radSites);
            this.Controls.Add(this.radParams);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft MHei", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditMode";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Escoja el método para ingresar los parámetros";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radParams;
        private System.Windows.Forms.RadioButton radSites;
        private System.Windows.Forms.CheckBox chkAsk;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Panel panel1;
    }
}