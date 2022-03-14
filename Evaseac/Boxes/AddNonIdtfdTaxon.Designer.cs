namespace Evaseac
{
    partial class frmAddNonIdtfdTaxon
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
            this.cboTaxon = new System.Windows.Forms.ComboBox();
            this.lblTaxon = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboTaxon
            // 
            this.cboTaxon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboTaxon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboTaxon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTaxon.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F);
            this.cboTaxon.FormattingEnabled = true;
            this.cboTaxon.Location = new System.Drawing.Point(120, 60);
            this.cboTaxon.Name = "cboTaxon";
            this.cboTaxon.Size = new System.Drawing.Size(200, 25);
            this.cboTaxon.TabIndex = 14;
            this.cboTaxon.SelectedIndexChanged += new System.EventHandler(this.cboTaxon_SelectedIndexChanged);
            // 
            // lblTaxon
            // 
            this.lblTaxon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTaxon.AutoSize = true;
            this.lblTaxon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblTaxon.Location = new System.Drawing.Point(66, 64);
            this.lblTaxon.Name = "lblTaxon";
            this.lblTaxon.Size = new System.Drawing.Size(46, 16);
            this.lblTaxon.TabIndex = 13;
            this.lblTaxon.Text = "Taxón";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(145, 120);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 28);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmAddNonIdtfdTaxon
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cboTaxon);
            this.Controls.Add(this.lblTaxon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddNonIdtfdTaxon";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Escoger Taxón";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTaxon;
        private System.Windows.Forms.Label lblTaxon;
        private System.Windows.Forms.Button btnAdd;
    }
}