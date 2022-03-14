namespace Evaseac
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlMainButtons = new System.Windows.Forms.Panel();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnTests = new System.Windows.Forms.Button();
            this.btnMacro = new System.Windows.Forms.Button();
            this.btnParam = new System.Windows.Forms.Button();
            this.btnProjects = new System.Windows.Forms.Button();
            this.btnSites = new System.Windows.Forms.Button();
            this.btnWorkgroup = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.ucpProjects = new Evaseac.Projects();
            this.ucpParameters = new Evaseac.Parameters();
            this.ucpSites = new Evaseac.Sites();
            this.ucpTests = new Evaseac.Tests();
            this.ucpMacroinvertebrados = new Evaseac.User_Controls.Macroinvertebrados();
            this.ucpWorkgroups = new Evaseac.User_Controls.Workgroup();
            this.btnExport = new System.Windows.Forms.Button();
            this.pnlMenu.SuspendLayout();
            this.pnlMainButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlMenu
            //
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.pnlMenu.Controls.Add(this.pnlMainButtons);
            this.pnlMenu.Controls.Add(this.btnMenu);
            this.pnlMenu.Controls.Add(this.btnConfig);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(235, 511);
            this.pnlMenu.TabIndex = 0;
            //
            // pnlMainButtons
            //
            this.pnlMainButtons.AutoScroll = true;
            this.pnlMainButtons.Controls.Add(this.btnProjects);
            this.pnlMainButtons.Controls.Add(this.btnSites);
            this.pnlMainButtons.Controls.Add(this.btnWorkgroup);
            this.pnlMainButtons.Controls.Add(this.btnExport);
            this.pnlMainButtons.Controls.Add(this.btnParam);
            this.pnlMainButtons.Controls.Add(this.btnTests);
            this.pnlMainButtons.Controls.Add(this.btnMacro);
            this.pnlMainButtons.Location = new System.Drawing.Point(3, 25);
            this.pnlMainButtons.Name = "pnlMainButtons";
            this.pnlMainButtons.Size = new System.Drawing.Size(307, 464);
            this.pnlMainButtons.TabIndex = 5;
            //
            // btnMenu
            //
            this.btnMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu.Location = new System.Drawing.Point(0, 0);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(235, 31);
            this.btnMenu.TabIndex = 4;
            this.btnMenu.TabStop = false;
            this.btnMenu.Text = "≡                    Menú";
            this.btnMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu.UseVisualStyleBackColor = false;
            //
            // btnProjects
            //
            this.btnProjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProjects.BackColor = System.Drawing.Color.Transparent;
            this.btnProjects.FlatAppearance.BorderSize = 0;
            this.btnProjects.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProjects.Font = new System.Drawing.Font("Microsoft YaHei Light", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProjects.ForeColor = System.Drawing.Color.White;
            this.btnProjects.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProjects.Location = new System.Drawing.Point(1, 5);
            this.btnProjects.Margin = new System.Windows.Forms.Padding(4);
            this.btnProjects.Name = "btnProjects";
            this.btnProjects.Size = new System.Drawing.Size(302, 58);
            this.btnProjects.TabIndex = 2;
            this.btnProjects.TabStop = false;
            this.btnProjects.Text = "      Proyectos";
            this.btnProjects.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProjects.UseVisualStyleBackColor = false;
            this.btnProjects.Click += new System.EventHandler(this.btn_Click);
            this.btnProjects.MouseEnter += new System.EventHandler(this.btnHover_MouseEnter);
            this.btnProjects.MouseLeave += new System.EventHandler(this.btnHover_MouseLeave);
            //
            // btnSites
            //
            this.btnSites.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSites.BackColor = System.Drawing.Color.Transparent;
            this.btnSites.FlatAppearance.BorderSize = 0;
            this.btnSites.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSites.Font = new System.Drawing.Font("Microsoft YaHei Light", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSites.ForeColor = System.Drawing.Color.White;
            this.btnSites.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSites.Location = new System.Drawing.Point(1, 71);
            this.btnSites.Margin = new System.Windows.Forms.Padding(4);
            this.btnSites.Name = "btnSites";
            this.btnSites.Size = new System.Drawing.Size(302, 58);
            this.btnSites.TabIndex = 2;
            this.btnSites.TabStop = false;
            this.btnSites.Text = "      Sitios";
            this.btnSites.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSites.UseVisualStyleBackColor = false;
            this.btnSites.Click += new System.EventHandler(this.btn_Click);
            this.btnSites.MouseEnter += new System.EventHandler(this.btnHover_MouseEnter);
            this.btnSites.MouseLeave += new System.EventHandler(this.btnHover_MouseLeave);
            //
            // btnParam
            //
            this.btnParam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParam.BackColor = System.Drawing.Color.Transparent;
            this.btnParam.Enabled = false;
            this.btnParam.FlatAppearance.BorderSize = 0;
            this.btnParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParam.Font = new System.Drawing.Font("Microsoft YaHei Light", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParam.ForeColor = System.Drawing.Color.White;
            this.btnParam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParam.Location = new System.Drawing.Point(1, 137);
            this.btnParam.Margin = new System.Windows.Forms.Padding(4);
            this.btnParam.Name = "btnParam";
            this.btnParam.Size = new System.Drawing.Size(302, 58);
            this.btnParam.TabIndex = 2;
            this.btnParam.TabStop = false;
            this.btnParam.Text = "      Parámetros";
            this.btnParam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParam.UseVisualStyleBackColor = false;
            this.btnParam.EnabledChanged += new System.EventHandler(this.btnParam_EnabledChanged);
            this.btnParam.Click += new System.EventHandler(this.btn_Click);
            this.btnParam.MouseEnter += new System.EventHandler(this.btnHover_MouseEnter);
            this.btnParam.MouseLeave += new System.EventHandler(this.btnHover_MouseLeave);
            //
            // btnMacro
            //
            this.btnMacro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMacro.BackColor = System.Drawing.Color.Transparent;
            this.btnMacro.FlatAppearance.BorderSize = 0;
            this.btnMacro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMacro.Font = new System.Drawing.Font("Microsoft YaHei Light", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMacro.ForeColor = System.Drawing.Color.White;
            this.btnMacro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMacro.Location = new System.Drawing.Point(1, 203);
            this.btnMacro.Margin = new System.Windows.Forms.Padding(4);
            this.btnMacro.Name = "btnMacro";
            this.btnMacro.Size = new System.Drawing.Size(302, 58);
            this.btnMacro.TabIndex = 3;
            this.btnMacro.TabStop = false;
            this.btnMacro.Text = "      Macroinvertebrados";
            this.btnMacro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMacro.UseVisualStyleBackColor = false;
            this.btnMacro.Click += new System.EventHandler(this.btn_Click);
            this.btnMacro.MouseEnter += new System.EventHandler(this.btnHover_MouseEnter);
            this.btnMacro.MouseLeave += new System.EventHandler(this.btnHover_MouseLeave);
            //
            // btnWorkgroup
            //
            this.btnWorkgroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWorkgroup.BackColor = System.Drawing.Color.Transparent;
            this.btnWorkgroup.FlatAppearance.BorderSize = 0;
            this.btnWorkgroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorkgroup.Font = new System.Drawing.Font("Microsoft YaHei Light", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWorkgroup.ForeColor = System.Drawing.Color.White;
            this.btnWorkgroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWorkgroup.Location = new System.Drawing.Point(1, 401);
            this.btnWorkgroup.Margin = new System.Windows.Forms.Padding(4);
            this.btnWorkgroup.Name = "btnWorkgroup";
            this.btnWorkgroup.Size = new System.Drawing.Size(302, 58);
            this.btnWorkgroup.TabIndex = 3;
            this.btnWorkgroup.TabStop = false;
            this.btnWorkgroup.Text = "      Grupo de trabajo";
            this.btnWorkgroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWorkgroup.UseVisualStyleBackColor = false;
            this.btnWorkgroup.Click += new System.EventHandler(this.btn_Click);
            this.btnWorkgroup.MouseEnter += new System.EventHandler(this.btnHover_MouseEnter);
            this.btnWorkgroup.MouseLeave += new System.EventHandler(this.btnHover_MouseLeave);
            //
            // btnExport
            //
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft YaHei Light", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(1, 335);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(302, 58);
            this.btnExport.TabIndex = 3;
            this.btnExport.TabStop = false;
            this.btnExport.Text = "      Exportar";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            this.btnExport.MouseEnter += new System.EventHandler(this.btnHover_MouseEnter);
            this.btnExport.MouseLeave += new System.EventHandler(this.btnHover_MouseLeave);
            //
            // btnTests
            //
            this.btnTests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTests.BackColor = System.Drawing.Color.Transparent;
            this.btnTests.FlatAppearance.BorderSize = 0;
            this.btnTests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTests.Font = new System.Drawing.Font("Microsoft YaHei Light", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTests.ForeColor = System.Drawing.Color.White;
            this.btnTests.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTests.Location = new System.Drawing.Point(1, 269);
            this.btnTests.Margin = new System.Windows.Forms.Padding(4);
            this.btnTests.Name = "btnTests";
            this.btnTests.Size = new System.Drawing.Size(302, 58);
            this.btnTests.TabIndex = 3;
            this.btnTests.TabStop = false;
            this.btnTests.Text = "      Otras pruebas";
            this.btnTests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTests.UseVisualStyleBackColor = false;
            this.btnTests.Click += new System.EventHandler(this.btn_Click);
            this.btnTests.MouseEnter += new System.EventHandler(this.btnHover_MouseEnter);
            this.btnTests.MouseLeave += new System.EventHandler(this.btnHover_MouseLeave);
            //
            // btnConfig
            //
            this.btnConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.btnConfig.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnConfig.FlatAppearance.BorderSize = 0;
            this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfig.ForeColor = System.Drawing.Color.White;
            this.btnConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfig.Location = new System.Drawing.Point(0, 480);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(235, 31);
            this.btnConfig.TabIndex = 0;
            this.btnConfig.TabStop = false;
            this.btnConfig.Text = "      Configuración";
            this.btnConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfig.UseVisualStyleBackColor = false;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            //
            // ucpProjects
            //
            this.ucpProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucpProjects.Enabled = false;
            this.ucpProjects.Font = new System.Drawing.Font("Microsoft NeoGothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucpProjects.Location = new System.Drawing.Point(241, 11);
            this.ucpProjects.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucpProjects.Name = "ucpProjects";
            this.ucpProjects.Size = new System.Drawing.Size(701, 487);
            this.ucpProjects.TabIndex = 2;
            this.ucpProjects.Visible = false;
            //
            // ucpParameters
            //
            this.ucpParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucpParameters.Enabled = false;
            this.ucpParameters.Font = new System.Drawing.Font("Microsoft NeoGothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucpParameters.idTemps = ((System.Collections.Generic.List<string>)(resources.GetObject("ucpParameters.idTemps")));
            this.ucpParameters.Location = new System.Drawing.Point(241, 11);
            this.ucpParameters.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucpParameters.Name = "ucpParameters";
            this.ucpParameters.sites = ((System.Collections.Generic.List<string>)(resources.GetObject("ucpParameters.sites")));
            this.ucpParameters.Size = new System.Drawing.Size(701, 487);
            this.ucpParameters.TabIndex = 3;
            this.ucpParameters.Visible = false;
            //
            // ucpSites
            //
            this.ucpSites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucpSites.Enabled = false;
            this.ucpSites.Font = new System.Drawing.Font("Microsoft NeoGothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucpSites.idTemps = null;
            this.ucpSites.Location = new System.Drawing.Point(241, 11);
            this.ucpSites.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucpSites.Name = "ucpSites";
            this.ucpSites.Size = new System.Drawing.Size(701, 487);
            this.ucpSites.TabIndex = 1;
            this.ucpSites.Visible = false;
            //
            // ucpTests
            //
            this.ucpTests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucpTests.Font = new System.Drawing.Font("Microsoft NeoGothic", 9F);
            this.ucpTests.idTemps = ((System.Collections.Generic.List<string>)(resources.GetObject("ucpTests.idTemps")));
            this.ucpTests.Location = new System.Drawing.Point(241, 11);
            this.ucpTests.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucpTests.Name = "ucpTests";
            this.ucpTests.Size = new System.Drawing.Size(701, 487);
            this.ucpTests.TabIndex = 4;
            //
            // ucpMacroinvertebrados
            //
            this.ucpMacroinvertebrados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucpMacroinvertebrados.Font = new System.Drawing.Font("Microsoft NeoGothic", 9F);
            this.ucpMacroinvertebrados.idTemps = ((System.Collections.Generic.List<string>)(resources.GetObject("ucpMacroinvertebrados.idTemps")));
            this.ucpMacroinvertebrados.Location = new System.Drawing.Point(241, 11);
            this.ucpMacroinvertebrados.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucpMacroinvertebrados.Name = "ucpMacroinvertebrados";
            this.ucpMacroinvertebrados.Size = new System.Drawing.Size(701, 487);
            this.ucpMacroinvertebrados.TabIndex = 5;
            //
            // ucpWorkgroups
            //
            this.ucpWorkgroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucpWorkgroups.Font = new System.Drawing.Font("Microsoft NeoGothic", 9F);
            this.ucpWorkgroups.Location = new System.Drawing.Point(241, 11);
            this.ucpWorkgroups.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucpWorkgroups.Name = "ucpWorkgroups";
            this.ucpWorkgroups.Size = new System.Drawing.Size(701, 487);
            this.ucpWorkgroups.TabIndex = 6;
            //
            // frmMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(954, 511);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.ucpProjects);
            this.Controls.Add(this.ucpParameters);
            this.Controls.Add(this.ucpSites);
            this.Controls.Add(this.ucpTests);
            this.Controls.Add(this.ucpMacroinvertebrados);
            this.Controls.Add(this.ucpWorkgroups);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(970, 550);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evaseac";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMainButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnParam;
        private System.Windows.Forms.Button btnSites;
        private System.Windows.Forms.Button btnMacro;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnTests;
        private Sites ucpSites;
        private System.Windows.Forms.Button btnProjects;
        private Projects ucpProjects;
        private Parameters ucpParameters;
        private Tests ucpTests;
        private User_Controls.Macroinvertebrados ucpMacroinvertebrados;
        private User_Controls.Workgroup ucpWorkgroups;
        private System.Windows.Forms.Panel pnlMainButtons;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnWorkgroup;
    }
}
