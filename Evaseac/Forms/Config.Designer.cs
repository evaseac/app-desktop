namespace Evaseac
{
    partial class frmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.Menu = new System.Windows.Forms.GroupBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnPreference = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.lblCurPass = new System.Windows.Forms.Label();
            this.pnlAdmin = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtConfPass = new System.Windows.Forms.TextBox();
            this.lblConfPass = new System.Windows.Forms.Label();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.txtCurrentPass = new System.Windows.Forms.TextBox();
            this.pnlPreferences = new System.Windows.Forms.Panel();
            this.chkAskParams = new System.Windows.Forms.CheckBox();
            this.pnlImport = new System.Windows.Forms.Panel();
            this.btnImportDatabase = new System.Windows.Forms.Button();
            this.lblFileInstructions = new System.Windows.Forms.Label();
            this.btnSelectSQLFile = new System.Windows.Forms.Button();
            this.lblFileSelected = new System.Windows.Forms.Label();
            this.Menu.SuspendLayout();
            this.pnlAdmin.SuspendLayout();
            this.pnlPreferences.SuspendLayout();
            this.pnlImport.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Controls.Add(this.btnImport);
            this.Menu.Controls.Add(this.btnPreference);
            this.Menu.Controls.Add(this.btnAdmin);
            this.Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.Menu.Location = new System.Drawing.Point(8, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(200, 328);
            this.Menu.TabIndex = 0;
            this.Menu.TabStop = false;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.BackColor = System.Drawing.Color.Transparent;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.DimGray;
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Location = new System.Drawing.Point(1, 200);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(200, 35);
            this.btnImport.TabIndex = 6;
            this.btnImport.TabStop = false;
            this.btnImport.Text = "Importar";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnPreference
            // 
            this.btnPreference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreference.BackColor = System.Drawing.Color.Transparent;
            this.btnPreference.FlatAppearance.BorderSize = 0;
            this.btnPreference.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreference.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreference.ForeColor = System.Drawing.Color.DimGray;
            this.btnPreference.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreference.Location = new System.Drawing.Point(0, 155);
            this.btnPreference.Name = "btnPreference";
            this.btnPreference.Size = new System.Drawing.Size(200, 35);
            this.btnPreference.TabIndex = 5;
            this.btnPreference.TabStop = false;
            this.btnPreference.Text = "Preferencias";
            this.btnPreference.UseVisualStyleBackColor = false;
            this.btnPreference.Click += new System.EventHandler(this.btnPreference_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdmin.BackColor = System.Drawing.Color.Transparent;
            this.btnAdmin.FlatAppearance.BorderSize = 0;
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmin.ForeColor = System.Drawing.Color.DimGray;
            this.btnAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdmin.Location = new System.Drawing.Point(0, 110);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(200, 35);
            this.btnAdmin.TabIndex = 3;
            this.btnAdmin.TabStop = false;
            this.btnAdmin.Text = "Administrador";
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // lblCurPass
            // 
            this.lblCurPass.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCurPass.AutoSize = true;
            this.lblCurPass.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurPass.Location = new System.Drawing.Point(62, 21);
            this.lblCurPass.Name = "lblCurPass";
            this.lblCurPass.Size = new System.Drawing.Size(143, 21);
            this.lblCurPass.TabIndex = 1;
            this.lblCurPass.Text = "Contraseña actual";
            // 
            // pnlAdmin
            // 
            this.pnlAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAdmin.Controls.Add(this.btnSave);
            this.pnlAdmin.Controls.Add(this.txtConfPass);
            this.pnlAdmin.Controls.Add(this.lblConfPass);
            this.pnlAdmin.Controls.Add(this.txtNewPass);
            this.pnlAdmin.Controls.Add(this.lblNewPass);
            this.pnlAdmin.Controls.Add(this.txtCurrentPass);
            this.pnlAdmin.Controls.Add(this.lblCurPass);
            this.pnlAdmin.Location = new System.Drawing.Point(230, 15);
            this.pnlAdmin.Name = "pnlAdmin";
            this.pnlAdmin.Size = new System.Drawing.Size(265, 297);
            this.pnlAdmin.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(78, 266);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 27);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtConfPass
            // 
            this.txtConfPass.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtConfPass.Location = new System.Drawing.Point(36, 204);
            this.txtConfPass.MaxLength = 100;
            this.txtConfPass.Name = "txtConfPass";
            this.txtConfPass.PasswordChar = '•';
            this.txtConfPass.Size = new System.Drawing.Size(195, 22);
            this.txtConfPass.TabIndex = 5;
            this.txtConfPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblConfPass
            // 
            this.lblConfPass.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblConfPass.AutoSize = true;
            this.lblConfPass.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfPass.Location = new System.Drawing.Point(49, 180);
            this.lblConfPass.Name = "lblConfPass";
            this.lblConfPass.Size = new System.Drawing.Size(170, 21);
            this.lblConfPass.TabIndex = 1;
            this.lblConfPass.Text = "Confirmar contraseña";
            // 
            // txtNewPass
            // 
            this.txtNewPass.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNewPass.Location = new System.Drawing.Point(36, 134);
            this.txtNewPass.MaxLength = 100;
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '•';
            this.txtNewPass.Size = new System.Drawing.Size(195, 22);
            this.txtNewPass.TabIndex = 3;
            this.txtNewPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNewPass
            // 
            this.lblNewPass.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNewPass.AutoSize = true;
            this.lblNewPass.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPass.Location = new System.Drawing.Point(60, 110);
            this.lblNewPass.Name = "lblNewPass";
            this.lblNewPass.Size = new System.Drawing.Size(146, 21);
            this.lblNewPass.TabIndex = 1;
            this.lblNewPass.Text = "Contraseña Nueva";
            // 
            // txtCurrentPass
            // 
            this.txtCurrentPass.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCurrentPass.Location = new System.Drawing.Point(36, 45);
            this.txtCurrentPass.MaxLength = 100;
            this.txtCurrentPass.Name = "txtCurrentPass";
            this.txtCurrentPass.PasswordChar = '•';
            this.txtCurrentPass.Size = new System.Drawing.Size(195, 22);
            this.txtCurrentPass.TabIndex = 1;
            this.txtCurrentPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlPreferences
            // 
            this.pnlPreferences.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPreferences.Controls.Add(this.chkAskParams);
            this.pnlPreferences.Location = new System.Drawing.Point(215, 15);
            this.pnlPreferences.Name = "pnlPreferences";
            this.pnlPreferences.Size = new System.Drawing.Size(294, 313);
            this.pnlPreferences.TabIndex = 4;
            // 
            // chkAskParams
            // 
            this.chkAskParams.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkAskParams.AutoSize = true;
            this.chkAskParams.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAskParams.Location = new System.Drawing.Point(19, 25);
            this.chkAskParams.Name = "chkAskParams";
            this.chkAskParams.Size = new System.Drawing.Size(260, 36);
            this.chkAskParams.TabIndex = 0;
            this.chkAskParams.Text = "No volver a preguntar por el método      \r\npara ingresar los parámetros";
            this.chkAskParams.UseVisualStyleBackColor = true;
            this.chkAskParams.CheckedChanged += new System.EventHandler(this.chkAskParams_CheckedChanged);
            // 
            // pnlImport
            // 
            this.pnlImport.Controls.Add(this.btnImportDatabase);
            this.pnlImport.Controls.Add(this.lblFileInstructions);
            this.pnlImport.Controls.Add(this.btnSelectSQLFile);
            this.pnlImport.Controls.Add(this.lblFileSelected);
            this.pnlImport.Location = new System.Drawing.Point(220, 15);
            this.pnlImport.Name = "pnlImport";
            this.pnlImport.Size = new System.Drawing.Size(285, 313);
            this.pnlImport.TabIndex = 5;
            // 
            // btnImportDatabase
            // 
            this.btnImportDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportDatabase.Location = new System.Drawing.Point(108, 134);
            this.btnImportDatabase.Name = "btnImportDatabase";
            this.btnImportDatabase.Size = new System.Drawing.Size(75, 29);
            this.btnImportDatabase.TabIndex = 3;
            this.btnImportDatabase.Text = "Importar";
            this.btnImportDatabase.UseVisualStyleBackColor = true;
            this.btnImportDatabase.Click += new System.EventHandler(this.btnImportDatabase_Click);
            // 
            // lblFileInstructions
            // 
            this.lblFileInstructions.AutoSize = true;
            this.lblFileInstructions.Location = new System.Drawing.Point(13, 34);
            this.lblFileInstructions.Name = "lblFileInstructions";
            this.lblFileInstructions.Size = new System.Drawing.Size(141, 16);
            this.lblFileInstructions.TabIndex = 2;
            this.lblFileInstructions.Text = "Archivo seleccionado:";
            // 
            // btnSelectSQLFile
            // 
            this.btnSelectSQLFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectSQLFile.Location = new System.Drawing.Point(13, 73);
            this.btnSelectSQLFile.Name = "btnSelectSQLFile";
            this.btnSelectSQLFile.Size = new System.Drawing.Size(172, 26);
            this.btnSelectSQLFile.TabIndex = 1;
            this.btnSelectSQLFile.Text = "Seleccionar archivo SQL";
            this.btnSelectSQLFile.UseVisualStyleBackColor = true;
            this.btnSelectSQLFile.Click += new System.EventHandler(this.btnSelectSQLFile_Click);
            // 
            // lblFileSelected
            // 
            this.lblFileSelected.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileSelected.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblFileSelected.Location = new System.Drawing.Point(10, 53);
            this.lblFileSelected.Name = "lblFileSelected";
            this.lblFileSelected.Size = new System.Drawing.Size(263, 17);
            this.lblFileSelected.TabIndex = 0;
            this.lblFileSelected.Text = "Sin ningún archivo seleccionado";
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(514, 336);
            this.Controls.Add(this.pnlImport);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.pnlAdmin);
            this.Controls.Add(this.pnlPreferences);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(530, 375);
            this.Name = "frmConfig";
            this.Opacity = 0.94D;
            this.Padding = new System.Windows.Forms.Padding(8, 0, 0, 8);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.Menu.ResumeLayout(false);
            this.pnlAdmin.ResumeLayout(false);
            this.pnlAdmin.PerformLayout();
            this.pnlPreferences.ResumeLayout(false);
            this.pnlPreferences.PerformLayout();
            this.pnlImport.ResumeLayout(false);
            this.pnlImport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Menu;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Label lblCurPass;
        private System.Windows.Forms.Panel pnlAdmin;
        private System.Windows.Forms.TextBox txtConfPass;
        private System.Windows.Forms.Label lblConfPass;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.TextBox txtCurrentPass;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPreference;
        private System.Windows.Forms.Panel pnlPreferences;
        private System.Windows.Forms.CheckBox chkAskParams;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Panel pnlImport;
        private System.Windows.Forms.Button btnSelectSQLFile;
        private System.Windows.Forms.Label lblFileSelected;
        private System.Windows.Forms.Label lblFileInstructions;
        private System.Windows.Forms.Button btnImportDatabase;
    }
}