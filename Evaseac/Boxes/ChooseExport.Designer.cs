
namespace Evaseac.Boxes
{
    partial class ChooseExport
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
            this.btnXLExport = new System.Windows.Forms.Button();
            this.btnCSVExport = new System.Windows.Forms.Button();
            this.grpXL = new System.Windows.Forms.GroupBox();
            this.lblXLDesc = new System.Windows.Forms.Label();
            this.grpCSV = new System.Windows.Forms.GroupBox();
            this.lnkUpdate = new System.Windows.Forms.LinkLabel();
            this.lblCSVDesc = new System.Windows.Forms.Label();
            this.grpXL.SuspendLayout();
            this.grpCSV.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnXLExport
            // 
            this.btnXLExport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXLExport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnXLExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXLExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXLExport.Location = new System.Drawing.Point(77, 30);
            this.btnXLExport.Name = "btnXLExport";
            this.btnXLExport.Size = new System.Drawing.Size(100, 28);
            this.btnXLExport.TabIndex = 2;
            this.btnXLExport.Text = "Exportar .xlsx";
            this.btnXLExport.UseVisualStyleBackColor = true;
            // 
            // btnCSVExport
            // 
            this.btnCSVExport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCSVExport.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnCSVExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCSVExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCSVExport.Location = new System.Drawing.Point(202, 30);
            this.btnCSVExport.Name = "btnCSVExport";
            this.btnCSVExport.Size = new System.Drawing.Size(100, 28);
            this.btnCSVExport.TabIndex = 4;
            this.btnCSVExport.Text = "Exportar .csv";
            this.btnCSVExport.UseVisualStyleBackColor = true;
            // 
            // grpXL
            // 
            this.grpXL.Controls.Add(this.lblXLDesc);
            this.grpXL.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.grpXL.Location = new System.Drawing.Point(17, 87);
            this.grpXL.Name = "grpXL";
            this.grpXL.Size = new System.Drawing.Size(160, 110);
            this.grpXL.TabIndex = 6;
            this.grpXL.TabStop = false;
            this.grpXL.Text = "xlsx";
            // 
            // lblXLDesc
            // 
            this.lblXLDesc.AutoSize = true;
            this.lblXLDesc.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXLDesc.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblXLDesc.Location = new System.Drawing.Point(6, 16);
            this.lblXLDesc.Name = "lblXLDesc";
            this.lblXLDesc.Size = new System.Drawing.Size(151, 85);
            this.lblXLDesc.TabIndex = 0;
            this.lblXLDesc.Text = "Permite exportar a un\r\narchivo excel la info.\r\nperteneciente a diversos\r\nsitios q" +
    "ue se tengan\r\nescogidos";
            this.lblXLDesc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grpCSV
            // 
            this.grpCSV.Controls.Add(this.lnkUpdate);
            this.grpCSV.Controls.Add(this.lblCSVDesc);
            this.grpCSV.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.grpCSV.Location = new System.Drawing.Point(202, 87);
            this.grpCSV.Name = "grpCSV";
            this.grpCSV.Size = new System.Drawing.Size(160, 110);
            this.grpCSV.TabIndex = 8;
            this.grpCSV.TabStop = false;
            this.grpCSV.Text = "csv";
            // 
            // lnkUpdate
            // 
            this.lnkUpdate.AutoSize = true;
            this.lnkUpdate.Location = new System.Drawing.Point(50, 88);
            this.lnkUpdate.Name = "lnkUpdate";
            this.lnkUpdate.Size = new System.Drawing.Size(65, 13);
            this.lnkUpdate.TabIndex = 1;
            this.lnkUpdate.TabStop = true;
            this.lnkUpdate.Text = "en la página";
            this.lnkUpdate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lnkUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUpdate_LinkClicked);
            // 
            // lblCSVDesc
            // 
            this.lblCSVDesc.AutoSize = true;
            this.lblCSVDesc.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCSVDesc.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblCSVDesc.Location = new System.Drawing.Point(11, 16);
            this.lblCSVDesc.Name = "lblCSVDesc";
            this.lblCSVDesc.Size = new System.Drawing.Size(143, 68);
            this.lblCSVDesc.TabIndex = 0;
            this.lblCSVDesc.Text = "Exporta un archivo csv\r\nque contendrá toda la\r\ninformación recopilada\r\npara poder" +
    " actualizar\r\n";
            this.lblCSVDesc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ChooseExport
            // 
            this.AcceptButton = this.btnXLExport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.grpCSV);
            this.Controls.Add(this.grpXL);
            this.Controls.Add(this.btnCSVExport);
            this.Controls.Add(this.btnXLExport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseExport";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Escoger exportación";
            this.grpXL.ResumeLayout(false);
            this.grpXL.PerformLayout();
            this.grpCSV.ResumeLayout(false);
            this.grpCSV.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnXLExport;
        private System.Windows.Forms.Button btnCSVExport;
        private System.Windows.Forms.GroupBox grpXL;
        private System.Windows.Forms.GroupBox grpCSV;
        private System.Windows.Forms.Label lblXLDesc;
        private System.Windows.Forms.LinkLabel lnkUpdate;
        private System.Windows.Forms.Label lblCSVDesc;
    }
}