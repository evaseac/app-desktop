namespace Evaseac
{
    partial class frmEditParam
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
            this.btnNext = new System.Windows.Forms.Button();
            this.lblParam = new System.Windows.Forms.Label();
            this.txtParameter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTest = new System.Windows.Forms.Label();
            this.txtRepetitions = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnNext.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(145, 145);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 28);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "Siguiente";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblParam
            // 
            this.lblParam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblParam.AutoSize = true;
            this.lblParam.Font = new System.Drawing.Font("Microsoft MHei", 9.75F);
            this.lblParam.Location = new System.Drawing.Point(12, 90);
            this.lblParam.Name = "lblParam";
            this.lblParam.Size = new System.Drawing.Size(111, 17);
            this.lblParam.TabIndex = 23;
            this.lblParam.Text = "Parámetro (nn/nn)";
            // 
            // txtParameter
            // 
            this.txtParameter.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F);
            this.txtParameter.Location = new System.Drawing.Point(129, 88);
            this.txtParameter.Name = "txtParameter";
            this.txtParameter.Size = new System.Drawing.Size(179, 28);
            this.txtParameter.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft MHei", 9.75F);
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Prueba";
            // 
            // lblTest
            // 
            this.lblTest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTest.AutoSize = true;
            this.lblTest.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTest.Location = new System.Drawing.Point(126, 47);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(51, 17);
            this.lblTest.TabIndex = 23;
            this.lblTest.Text = "Prueba";
            // 
            // txtRepetitions
            // 
            this.txtRepetitions.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F);
            this.txtRepetitions.Location = new System.Drawing.Point(314, 88);
            this.txtRepetitions.Name = "txtRepetitions";
            this.txtRepetitions.Size = new System.Drawing.Size(58, 28);
            this.txtRepetitions.TabIndex = 2;
            this.txtRepetitions.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRepetitions_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft MHei", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(311, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "Repeticiones";
            // 
            // frmEditParam
            // 
            this.AcceptButton = this.btnNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.txtRepetitions);
            this.Controls.Add(this.txtParameter);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblParam);
            this.Controls.Add(this.btnNext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditParam";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar parámetros";
            this.Load += new System.EventHandler(this.frmEditParam_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblParam;
        private System.Windows.Forms.TextBox txtParameter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.TextBox txtRepetitions;
        private System.Windows.Forms.Label label2;
    }
}