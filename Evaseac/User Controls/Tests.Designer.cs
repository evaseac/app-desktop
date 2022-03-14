namespace Evaseac
{
    partial class Tests
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
            this.components = new System.ComponentModel.Container();
            this.tabTests = new System.Windows.Forms.TabControl();
            this.tbpSites = new System.Windows.Forms.TabPage();
            this.dgvTestTemps = new System.Windows.Forms.DataGridView();
            this.cmsOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tspEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tspDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboTest_S = new System.Windows.Forms.ComboBox();
            this.lblTaxon_S = new System.Windows.Forms.Label();
            this.btnNext_S = new System.Windows.Forms.Button();
            this.lblValue = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.cboParam = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboSite = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbpTest = new System.Windows.Forms.TabPage();
            this.dgvTests = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboTest = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblParam = new System.Windows.Forms.Label();
            this.lblNoParams = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtRepet = new System.Windows.Forms.TextBox();
            this.txtParam = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtNoParams = new System.Windows.Forms.TextBox();
            this.txtTest = new System.Windows.Forms.TextBox();
            this.cmsStsOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tspDeleteSte = new System.Windows.Forms.ToolStripMenuItem();
            this.tabTests.SuspendLayout();
            this.tbpSites.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestTemps)).BeginInit();
            this.cmsOpciones.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tbpTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTests)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.cmsStsOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabTests
            // 
            this.tabTests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabTests.Controls.Add(this.tbpSites);
            this.tabTests.Controls.Add(this.tbpTest);
            this.tabTests.Font = new System.Drawing.Font("Microsoft MHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTests.Location = new System.Drawing.Point(3, 3);
            this.tabTests.Name = "tabTests";
            this.tabTests.Padding = new System.Drawing.Point(30, 3);
            this.tabTests.SelectedIndex = 0;
            this.tabTests.Size = new System.Drawing.Size(695, 481);
            this.tabTests.TabIndex = 0;
            this.tabTests.SelectedIndexChanged += new System.EventHandler(this.tabTests_SelectedIndexChanged);
            // 
            // tbpSites
            // 
            this.tbpSites.Controls.Add(this.dgvTestTemps);
            this.tbpSites.Controls.Add(this.groupBox4);
            this.tbpSites.Controls.Add(this.groupBox3);
            this.tbpSites.Location = new System.Drawing.Point(4, 26);
            this.tbpSites.Name = "tbpSites";
            this.tbpSites.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSites.Size = new System.Drawing.Size(687, 451);
            this.tbpSites.TabIndex = 0;
            this.tbpSites.Text = "Sitios";
            this.tbpSites.UseVisualStyleBackColor = true;
            // 
            // dgvTestTemps
            // 
            this.dgvTestTemps.AllowUserToAddRows = false;
            this.dgvTestTemps.AllowUserToDeleteRows = false;
            this.dgvTestTemps.AllowUserToResizeColumns = false;
            this.dgvTestTemps.AllowUserToResizeRows = false;
            this.dgvTestTemps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTestTemps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTestTemps.BackgroundColor = System.Drawing.Color.White;
            this.dgvTestTemps.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTestTemps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestTemps.ContextMenuStrip = this.cmsStsOptions;
            this.dgvTestTemps.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTestTemps.Location = new System.Drawing.Point(16, 276);
            this.dgvTestTemps.Name = "dgvTestTemps";
            this.dgvTestTemps.ReadOnly = true;
            this.dgvTestTemps.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTestTemps.RowHeadersVisible = false;
            this.dgvTestTemps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTestTemps.Size = new System.Drawing.Size(655, 159);
            this.dgvTestTemps.TabIndex = 4;
            this.dgvTestTemps.Click += new System.EventHandler(this.dgvTestTemps_Click);
            // 
            // cmsOpciones
            // 
            this.cmsOpciones.Font = new System.Drawing.Font("Microsoft PhagsPa", 9.75F);
            this.cmsOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspEdit,
            this.tspDelete});
            this.cmsOpciones.Name = "cmsOpciones";
            this.cmsOpciones.Size = new System.Drawing.Size(127, 48);
            this.cmsOpciones.Text = "Opciones";
            // 
            // tspEdit
            // 
            this.tspEdit.Enabled = false;
            this.tspEdit.Name = "tspEdit";
            this.tspEdit.Size = new System.Drawing.Size(126, 22);
            this.tspEdit.Text = "Editar";
            this.tspEdit.Click += new System.EventHandler(this.tspEdit_Click);
            // 
            // tspDelete
            // 
            this.tspDelete.Name = "tspDelete";
            this.tspDelete.Size = new System.Drawing.Size(126, 22);
            this.tspDelete.Text = "Eliminar";
            this.tspDelete.Click += new System.EventHandler(this.tspDelete_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.cboTest_S);
            this.groupBox4.Controls.Add(this.lblTaxon_S);
            this.groupBox4.Controls.Add(this.btnNext_S);
            this.groupBox4.Controls.Add(this.lblValue);
            this.groupBox4.Controls.Add(this.txtValue);
            this.groupBox4.Controls.Add(this.cboParam);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(16, 82);
            this.groupBox4.MaximumSize = new System.Drawing.Size(2000, 525);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(655, 177);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // cboTest_S
            // 
            this.cboTest_S.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboTest_S.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboTest_S.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTest_S.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTest_S.FormattingEnabled = true;
            this.cboTest_S.Location = new System.Drawing.Point(214, 24);
            this.cboTest_S.Name = "cboTest_S";
            this.cboTest_S.Size = new System.Drawing.Size(310, 27);
            this.cboTest_S.TabIndex = 0;
            this.cboTest_S.SelectedIndexChanged += new System.EventHandler(this.cboTest_S_SelectedIndexChanged);
            // 
            // lblTaxon_S
            // 
            this.lblTaxon_S.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTaxon_S.AutoSize = true;
            this.lblTaxon_S.Font = new System.Drawing.Font("Microsoft JhengHei Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxon_S.Location = new System.Drawing.Point(151, 27);
            this.lblTaxon_S.Name = "lblTaxon_S";
            this.lblTaxon_S.Size = new System.Drawing.Size(57, 19);
            this.lblTaxon_S.TabIndex = 31;
            this.lblTaxon_S.Text = "Prueba";
            // 
            // btnNext_S
            // 
            this.btnNext_S.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnNext_S.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext_S.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext_S.Location = new System.Drawing.Point(514, 123);
            this.btnNext_S.Name = "btnNext_S";
            this.btnNext_S.Size = new System.Drawing.Size(100, 28);
            this.btnNext_S.TabIndex = 6;
            this.btnNext_S.Text = "Siguiente";
            this.btnNext_S.UseVisualStyleBackColor = true;
            this.btnNext_S.Click += new System.EventHandler(this.btnNext_S_Click);
            // 
            // lblValue
            // 
            this.lblValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(41, 125);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(56, 17);
            this.lblValue.TabIndex = 26;
            this.lblValue.Text = "Valor (n)";
            // 
            // txtValue
            // 
            this.txtValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtValue.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.Location = new System.Drawing.Point(137, 123);
            this.txtValue.MaxLength = 100;
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(355, 28);
            this.txtValue.TabIndex = 4;
            this.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValue_KeyPress);
            this.txtValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtValue_KeyUp);
            // 
            // cboParam
            // 
            this.cboParam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboParam.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboParam.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboParam.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F);
            this.cboParam.FormattingEnabled = true;
            this.cboParam.Location = new System.Drawing.Point(137, 79);
            this.cboParam.Name = "cboParam";
            this.cboParam.Size = new System.Drawing.Size(200, 25);
            this.cboParam.TabIndex = 2;
            this.cboParam.SelectedIndexChanged += new System.EventHandler(this.cboParam_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Parametro";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.cboSite);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(16, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(655, 60);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // cboSite
            // 
            this.cboSite.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboSite.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboSite.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.cboSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSite.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSite.FormattingEnabled = true;
            this.cboSite.Location = new System.Drawing.Point(149, 26);
            this.cboSite.Name = "cboSite";
            this.cboSite.Size = new System.Drawing.Size(420, 25);
            this.cboSite.TabIndex = 3;
            this.cboSite.SelectedIndexChanged += new System.EventHandler(this.cboSite_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft MHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(96, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 21);
            this.label12.TabIndex = 0;
            this.label12.Text = "Sitio:";
            // 
            // tbpTest
            // 
            this.tbpTest.Controls.Add(this.dgvTests);
            this.tbpTest.Controls.Add(this.groupBox2);
            this.tbpTest.Controls.Add(this.groupBox1);
            this.tbpTest.Location = new System.Drawing.Point(4, 26);
            this.tbpTest.Name = "tbpTest";
            this.tbpTest.Padding = new System.Windows.Forms.Padding(3);
            this.tbpTest.Size = new System.Drawing.Size(687, 451);
            this.tbpTest.TabIndex = 1;
            this.tbpTest.Text = "Pruebas";
            this.tbpTest.UseVisualStyleBackColor = true;
            // 
            // dgvTests
            // 
            this.dgvTests.AllowUserToAddRows = false;
            this.dgvTests.AllowUserToDeleteRows = false;
            this.dgvTests.AllowUserToResizeColumns = false;
            this.dgvTests.AllowUserToResizeRows = false;
            this.dgvTests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTests.BackgroundColor = System.Drawing.Color.White;
            this.dgvTests.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTests.ContextMenuStrip = this.cmsOpciones;
            this.dgvTests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTests.Location = new System.Drawing.Point(16, 260);
            this.dgvTests.MultiSelect = false;
            this.dgvTests.Name = "dgvTests";
            this.dgvTests.ReadOnly = true;
            this.dgvTests.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTests.RowHeadersVisible = false;
            this.dgvTests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTests.Size = new System.Drawing.Size(655, 175);
            this.dgvTests.TabIndex = 4;
            this.dgvTests.Click += new System.EventHandler(this.dgvTests_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cboTest);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblParam);
            this.groupBox2.Controls.Add(this.lblNoParams);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnNext);
            this.groupBox2.Controls.Add(this.txtRepet);
            this.groupBox2.Controls.Add(this.txtParam);
            this.groupBox2.Location = new System.Drawing.Point(16, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(655, 114);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parámetros";
            // 
            // cboTest
            // 
            this.cboTest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboTest.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboTest.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTest.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F);
            this.cboTest.FormattingEnabled = true;
            this.cboTest.Location = new System.Drawing.Point(173, 24);
            this.cboTest.Name = "cboTest";
            this.cboTest.Size = new System.Drawing.Size(200, 25);
            this.cboTest.TabIndex = 0;
            this.cboTest.SelectedIndexChanged += new System.EventHandler(this.cboTest_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(351, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Repeticiones";
            // 
            // lblParam
            // 
            this.lblParam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblParam.AutoSize = true;
            this.lblParam.Location = new System.Drawing.Point(31, 76);
            this.lblParam.Name = "lblParam";
            this.lblParam.Size = new System.Drawing.Size(85, 17);
            this.lblParam.TabIndex = 22;
            this.lblParam.Text = "Parámetro (n)";
            // 
            // lblNoParams
            // 
            this.lblNoParams.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNoParams.AutoSize = true;
            this.lblNoParams.Location = new System.Drawing.Point(400, 26);
            this.lblNoParams.Name = "lblNoParams";
            this.lblNoParams.Size = new System.Drawing.Size(145, 17);
            this.lblNoParams.TabIndex = 22;
            this.lblNoParams.Text = "Número de parametros: ";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Prueba";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(519, 71);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 28);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Siguiente";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtRepet
            // 
            this.txtRepet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtRepet.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepet.Location = new System.Drawing.Point(447, 71);
            this.txtRepet.MaxLength = 3;
            this.txtRepet.Name = "txtRepet";
            this.txtRepet.Size = new System.Drawing.Size(55, 28);
            this.txtRepet.TabIndex = 4;
            this.txtRepet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRepet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Textbox_KeyPress);
            // 
            // txtParam
            // 
            this.txtParam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtParam.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParam.Location = new System.Drawing.Point(136, 71);
            this.txtParam.MaxLength = 100;
            this.txtParam.Name = "txtParam";
            this.txtParam.Size = new System.Drawing.Size(190, 28);
            this.txtParam.TabIndex = 2;
            this.txtParam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtNoParams);
            this.groupBox1.Controls.Add(this.txtTest);
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(655, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pruebas";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Número de parámetros";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(158, 30);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 17);
            this.label18.TabIndex = 22;
            this.label18.Text = "Prueba";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(489, 50);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 28);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtNoParams
            // 
            this.txtNoParams.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNoParams.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoParams.Location = new System.Drawing.Point(305, 50);
            this.txtNoParams.MaxLength = 3;
            this.txtNoParams.Name = "txtNoParams";
            this.txtNoParams.Size = new System.Drawing.Size(135, 28);
            this.txtNoParams.TabIndex = 2;
            this.txtNoParams.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNoParams.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Textbox_KeyPress);
            // 
            // txtTest
            // 
            this.txtTest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTest.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTest.Location = new System.Drawing.Point(80, 50);
            this.txtTest.MaxLength = 100;
            this.txtTest.Name = "txtTest";
            this.txtTest.Size = new System.Drawing.Size(200, 28);
            this.txtTest.TabIndex = 0;
            this.txtTest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmsStsOptions
            // 
            this.cmsStsOptions.Font = new System.Drawing.Font("Microsoft PhagsPa", 9.75F);
            this.cmsStsOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspDeleteSte});
            this.cmsStsOptions.Name = "cmsStsOptions";
            this.cmsStsOptions.Size = new System.Drawing.Size(127, 26);
            // 
            // tspDeleteSte
            // 
            this.tspDeleteSte.Enabled = false;
            this.tspDeleteSte.Name = "tspDeleteSte";
            this.tspDeleteSte.Size = new System.Drawing.Size(152, 22);
            this.tspDeleteSte.Text = "Eliminar";
            this.tspDeleteSte.Click += new System.EventHandler(this.tspDeleteSte_Click);
            // 
            // Tests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabTests);
            this.Font = new System.Drawing.Font("Microsoft NeoGothic", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Tests";
            this.Size = new System.Drawing.Size(701, 487);
            this.tabTests.ResumeLayout(false);
            this.tbpSites.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestTemps)).EndInit();
            this.cmsOpciones.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tbpTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTests)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.cmsStsOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabTests;
        private System.Windows.Forms.TabPage tbpSites;
        private System.Windows.Forms.TabPage tbpTest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNoParams;
        private System.Windows.Forms.TextBox txtTest;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvTests;
        private System.Windows.Forms.ComboBox cboTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblParam;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtRepet;
        private System.Windows.Forms.TextBox txtParam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNoParams;
        private System.Windows.Forms.ContextMenuStrip cmsOpciones;
        private System.Windows.Forms.ToolStripMenuItem tspEdit;
        private System.Windows.Forms.ToolStripMenuItem tspDelete;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboSite;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblTaxon_S;
        private System.Windows.Forms.ComboBox cboTest_S;
        private System.Windows.Forms.ComboBox cboParam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnNext_S;
        private System.Windows.Forms.DataGridView dgvTestTemps;
        private System.Windows.Forms.ContextMenuStrip cmsStsOptions;
        private System.Windows.Forms.ToolStripMenuItem tspDeleteSte;
    }
}
