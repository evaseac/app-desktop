namespace Evaseac
{
    partial class Projects
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabProject = new System.Windows.Forms.TabControl();
            this.tbpProjects = new System.Windows.Forms.TabPage();
            this.PgrpAddNew = new System.Windows.Forms.GroupBox();
            this.PbtnAdd = new System.Windows.Forms.Button();
            this.PtxtAdd = new System.Windows.Forms.TextBox();
            this.PdgvData = new System.Windows.Forms.DataGridView();
            this.colProject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbpEdit = new System.Windows.Forms.TabPage();
            this.EbtnEliminar = new System.Windows.Forms.Button();
            this.EbtnGuardar = new System.Windows.Forms.Button();
            this.EtxtModifyName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.EcboProject = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EtxtFinancing = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PtxtFinancing = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabProject.SuspendLayout();
            this.tbpProjects.SuspendLayout();
            this.PgrpAddNew.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PdgvData)).BeginInit();
            this.tbpEdit.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabProject
            // 
            this.tabProject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabProject.Controls.Add(this.tbpProjects);
            this.tabProject.Controls.Add(this.tbpEdit);
            this.tabProject.Font = new System.Drawing.Font("Microsoft MHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabProject.Location = new System.Drawing.Point(3, 3);
            this.tabProject.Name = "tabProject";
            this.tabProject.Padding = new System.Drawing.Point(30, 3);
            this.tabProject.SelectedIndex = 0;
            this.tabProject.Size = new System.Drawing.Size(695, 481);
            this.tabProject.TabIndex = 0;
            this.tabProject.SelectedIndexChanged += new System.EventHandler(this.tabProject_SelectedIndexChanged);
            // 
            // tbpProjects
            // 
            this.tbpProjects.Controls.Add(this.PgrpAddNew);
            this.tbpProjects.Controls.Add(this.PdgvData);
            this.tbpProjects.Location = new System.Drawing.Point(4, 26);
            this.tbpProjects.Name = "tbpProjects";
            this.tbpProjects.Padding = new System.Windows.Forms.Padding(3);
            this.tbpProjects.Size = new System.Drawing.Size(687, 451);
            this.tbpProjects.TabIndex = 0;
            this.tbpProjects.Text = "Proyectos";
            this.tbpProjects.UseVisualStyleBackColor = true;
            // 
            // PgrpAddNew
            // 
            this.PgrpAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PgrpAddNew.Controls.Add(this.label5);
            this.PgrpAddNew.Controls.Add(this.label4);
            this.PgrpAddNew.Controls.Add(this.PbtnAdd);
            this.PgrpAddNew.Controls.Add(this.PtxtFinancing);
            this.PgrpAddNew.Controls.Add(this.PtxtAdd);
            this.PgrpAddNew.Location = new System.Drawing.Point(22, 28);
            this.PgrpAddNew.Name = "PgrpAddNew";
            this.PgrpAddNew.Size = new System.Drawing.Size(645, 85);
            this.PgrpAddNew.TabIndex = 0;
            this.PgrpAddNew.TabStop = false;
            this.PgrpAddNew.Text = "Agregar nuevo";
            // 
            // PbtnAdd
            // 
            this.PbtnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PbtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PbtnAdd.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PbtnAdd.Location = new System.Drawing.Point(530, 30);
            this.PbtnAdd.Name = "PbtnAdd";
            this.PbtnAdd.Size = new System.Drawing.Size(100, 28);
            this.PbtnAdd.TabIndex = 4;
            this.PbtnAdd.Text = "Agregar";
            this.PbtnAdd.UseVisualStyleBackColor = true;
            this.PbtnAdd.Click += new System.EventHandler(this.PbtnAdd_Click);
            // 
            // PtxtAdd
            // 
            this.PtxtAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PtxtAdd.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PtxtAdd.Location = new System.Drawing.Point(15, 30);
            this.PtxtAdd.MaxLength = 100;
            this.PtxtAdd.Name = "PtxtAdd";
            this.PtxtAdd.Size = new System.Drawing.Size(240, 28);
            this.PtxtAdd.TabIndex = 0;
            this.PtxtAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PdgvData
            // 
            this.PdgvData.AllowUserToAddRows = false;
            this.PdgvData.AllowUserToDeleteRows = false;
            this.PdgvData.AllowUserToResizeColumns = false;
            this.PdgvData.AllowUserToResizeRows = false;
            this.PdgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PdgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PdgvData.BackgroundColor = System.Drawing.Color.White;
            this.PdgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PdgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PdgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProject,
            this.colSite});
            this.PdgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.PdgvData.Location = new System.Drawing.Point(22, 143);
            this.PdgvData.Name = "PdgvData";
            this.PdgvData.ReadOnly = true;
            this.PdgvData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.PdgvData.RowHeadersVisible = false;
            this.PdgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PdgvData.Size = new System.Drawing.Size(645, 285);
            this.PdgvData.TabIndex = 2;
            // 
            // colProject
            // 
            this.colProject.HeaderText = "Proyecto";
            this.colProject.Name = "colProject";
            this.colProject.ReadOnly = true;
            // 
            // colSite
            // 
            this.colSite.HeaderText = "Sitio";
            this.colSite.Name = "colSite";
            this.colSite.ReadOnly = true;
            // 
            // tbpEdit
            // 
            this.tbpEdit.Controls.Add(this.groupBox2);
            this.tbpEdit.Controls.Add(this.groupBox1);
            this.tbpEdit.Location = new System.Drawing.Point(4, 26);
            this.tbpEdit.Name = "tbpEdit";
            this.tbpEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tbpEdit.Size = new System.Drawing.Size(687, 451);
            this.tbpEdit.TabIndex = 1;
            this.tbpEdit.Text = "Editar";
            this.tbpEdit.UseVisualStyleBackColor = true;
            // 
            // EbtnEliminar
            // 
            this.EbtnEliminar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EbtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EbtnEliminar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EbtnEliminar.Location = new System.Drawing.Point(415, 163);
            this.EbtnEliminar.Name = "EbtnEliminar";
            this.EbtnEliminar.Size = new System.Drawing.Size(100, 28);
            this.EbtnEliminar.TabIndex = 36;
            this.EbtnEliminar.Text = "Eliminar";
            this.EbtnEliminar.UseVisualStyleBackColor = true;
            this.EbtnEliminar.Click += new System.EventHandler(this.EbtnEliminar_Click);
            // 
            // EbtnGuardar
            // 
            this.EbtnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EbtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EbtnGuardar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EbtnGuardar.Location = new System.Drawing.Point(160, 163);
            this.EbtnGuardar.Name = "EbtnGuardar";
            this.EbtnGuardar.Size = new System.Drawing.Size(100, 28);
            this.EbtnGuardar.TabIndex = 33;
            this.EbtnGuardar.Text = "Guardar";
            this.EbtnGuardar.UseVisualStyleBackColor = true;
            this.EbtnGuardar.Click += new System.EventHandler(this.EbtnGuardar_Click);
            // 
            // EtxtModifyName
            // 
            this.EtxtModifyName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EtxtModifyName.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EtxtModifyName.Location = new System.Drawing.Point(170, 35);
            this.EtxtModifyName.MaximumSize = new System.Drawing.Size(678, 28);
            this.EtxtModifyName.MaxLength = 100;
            this.EtxtModifyName.Name = "EtxtModifyName";
            this.EtxtModifyName.Size = new System.Drawing.Size(457, 28);
            this.EtxtModifyName.TabIndex = 27;
            this.EtxtModifyName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft NeoGothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre del proyecto";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft NeoGothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Proyecto";
            // 
            // EcboProject
            // 
            this.EcboProject.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EcboProject.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.EcboProject.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.EcboProject.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F);
            this.EcboProject.FormattingEnabled = true;
            this.EcboProject.Location = new System.Drawing.Point(170, 36);
            this.EcboProject.MaximumSize = new System.Drawing.Size(678, 0);
            this.EcboProject.Name = "EcboProject";
            this.EcboProject.Size = new System.Drawing.Size(457, 25);
            this.EcboProject.TabIndex = 1;
            this.EcboProject.SelectedIndexChanged += new System.EventHandler(this.EcboProject_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft NeoGothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Financiamiento";
            // 
            // EtxtFinancing
            // 
            this.EtxtFinancing.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EtxtFinancing.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EtxtFinancing.Location = new System.Drawing.Point(170, 95);
            this.EtxtFinancing.MaximumSize = new System.Drawing.Size(678, 28);
            this.EtxtFinancing.MaxLength = 100;
            this.EtxtFinancing.Name = "EtxtFinancing";
            this.EtxtFinancing.Size = new System.Drawing.Size(457, 28);
            this.EtxtFinancing.TabIndex = 27;
            this.EtxtFinancing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.EcboProject);
            this.groupBox1.Location = new System.Drawing.Point(16, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(655, 80);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.EtxtModifyName);
            this.groupBox2.Controls.Add(this.EbtnEliminar);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.EbtnGuardar);
            this.groupBox2.Controls.Add(this.EtxtFinancing);
            this.groupBox2.Location = new System.Drawing.Point(16, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(655, 220);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Modificar";
            // 
            // PtxtFinancing
            // 
            this.PtxtFinancing.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PtxtFinancing.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PtxtFinancing.Location = new System.Drawing.Point(261, 30);
            this.PtxtFinancing.MaxLength = 100;
            this.PtxtFinancing.Name = "PtxtFinancing";
            this.PtxtFinancing.Size = new System.Drawing.Size(240, 28);
            this.PtxtFinancing.TabIndex = 2;
            this.PtxtFinancing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft MHei", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(336, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "Financiamiento";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft MHei", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(76, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Nombre del proyecto";
            // 
            // Projects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabProject);
            this.Font = new System.Drawing.Font("Microsoft NeoGothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Projects";
            this.Size = new System.Drawing.Size(701, 487);
            this.tabProject.ResumeLayout(false);
            this.tbpProjects.ResumeLayout(false);
            this.PgrpAddNew.ResumeLayout(false);
            this.PgrpAddNew.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PdgvData)).EndInit();
            this.tbpEdit.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabProject;
        private System.Windows.Forms.TabPage tbpProjects;
        private System.Windows.Forms.TabPage tbpEdit;
        private System.Windows.Forms.DataGridView PdgvData;
        private System.Windows.Forms.GroupBox PgrpAddNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProject;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSite;
        private System.Windows.Forms.TextBox PtxtAdd;
        private System.Windows.Forms.Button PbtnAdd;
        private System.Windows.Forms.ComboBox EcboProject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox EtxtModifyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EbtnGuardar;
        private System.Windows.Forms.Button EbtnEliminar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EtxtFinancing;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox PtxtFinancing;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}
