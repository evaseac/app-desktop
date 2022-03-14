namespace Evaseac.User_Controls
{
    partial class Macroinvertebrados
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
            this.tabMacroinvertebrados = new System.Windows.Forms.TabControl();
            this.tbpSites = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtHabit = new System.Windows.Forms.TextBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTaxon_S = new System.Windows.Forms.Label();
            this.radGenSp_S = new System.Windows.Forms.RadioButton();
            this.cboTaxon = new System.Windows.Forms.ComboBox();
            this.radFamily_S = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboSite = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dgvTaxons_S = new System.Windows.Forms.DataGridView();
            this.csmOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tspDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tbpMacroinvertebrados = new System.Windows.Forms.TabPage();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.cboFilteredTax = new System.Windows.Forms.ComboBox();
            this.lblTaxon = new System.Windows.Forms.Label();
            this.radGenre = new System.Windows.Forms.RadioButton();
            this.radFamlily = new System.Windows.Forms.RadioButton();
            this.radOrder = new System.Windows.Forms.RadioButton();
            this.radClase = new System.Windows.Forms.RadioButton();
            this.dgvTaxons = new System.Windows.Forms.DataGridView();
            this.tbpAddEdit = new System.Windows.Forms.TabPage();
            this.grpAddEdit = new System.Windows.Forms.GroupBox();
            this.pnlAdd = new System.Windows.Forms.Panel();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.txtFam = new System.Windows.Forms.TextBox();
            this.txtGenSpcs = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddEdit = new System.Windows.Forms.Button();
            this.cboFam = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboOrder = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboClass = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.pnlEdt = new System.Windows.Forms.Panel();
            this.cboEdtGnrSp = new System.Windows.Forms.ComboBox();
            this.cboEdtOrd = new System.Windows.Forms.ComboBox();
            this.cboEdtFam = new System.Windows.Forms.ComboBox();
            this.cboEdtClass = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radEdit = new System.Windows.Forms.RadioButton();
            this.radAdd = new System.Windows.Forms.RadioButton();
            this.tabMacroinvertebrados.SuspendLayout();
            this.tbpSites.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaxons_S)).BeginInit();
            this.csmOptions.SuspendLayout();
            this.tbpMacroinvertebrados.SuspendLayout();
            this.grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaxons)).BeginInit();
            this.tbpAddEdit.SuspendLayout();
            this.grpAddEdit.SuspendLayout();
            this.pnlAdd.SuspendLayout();
            this.pnlEdt.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMacroinvertebrados
            // 
            this.tabMacroinvertebrados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMacroinvertebrados.Controls.Add(this.tbpSites);
            this.tabMacroinvertebrados.Controls.Add(this.tbpMacroinvertebrados);
            this.tabMacroinvertebrados.Controls.Add(this.tbpAddEdit);
            this.tabMacroinvertebrados.Font = new System.Drawing.Font("Microsoft MHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMacroinvertebrados.Location = new System.Drawing.Point(3, 3);
            this.tabMacroinvertebrados.Name = "tabMacroinvertebrados";
            this.tabMacroinvertebrados.Padding = new System.Drawing.Point(30, 3);
            this.tabMacroinvertebrados.SelectedIndex = 0;
            this.tabMacroinvertebrados.Size = new System.Drawing.Size(695, 481);
            this.tabMacroinvertebrados.TabIndex = 0;
            this.tabMacroinvertebrados.SelectedIndexChanged += new System.EventHandler(this.tabMacroinvertebrados_SelectedIndexChanged);
            // 
            // tbpSites
            // 
            this.tbpSites.Controls.Add(this.groupBox3);
            this.tbpSites.Controls.Add(this.groupBox2);
            this.tbpSites.Controls.Add(this.dgvTaxons_S);
            this.tbpSites.Location = new System.Drawing.Point(4, 26);
            this.tbpSites.Name = "tbpSites";
            this.tbpSites.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSites.Size = new System.Drawing.Size(687, 451);
            this.tbpSites.TabIndex = 0;
            this.tbpSites.Text = "Sitios";
            this.tbpSites.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtHabit);
            this.groupBox3.Controls.Add(this.txtNumber);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.lblTaxon_S);
            this.groupBox3.Controls.Add(this.radGenSp_S);
            this.groupBox3.Controls.Add(this.cboTaxon);
            this.groupBox3.Controls.Add(this.radFamily_S);
            this.groupBox3.Location = new System.Drawing.Point(16, 82);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(655, 72);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            // 
            // txtHabit
            // 
            this.txtHabit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtHabit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtHabit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtHabit.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHabit.Location = new System.Drawing.Point(416, 39);
            this.txtHabit.MaxLength = 100;
            this.txtHabit.Name = "txtHabit";
            this.txtHabit.Size = new System.Drawing.Size(125, 28);
            this.txtHabit.TabIndex = 35;
            this.txtHabit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNumber
            // 
            this.txtNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNumber.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumber.Location = new System.Drawing.Point(289, 39);
            this.txtNumber.MaxLength = 100;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(57, 28);
            this.txtNumber.TabIndex = 33;
            this.txtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft JhengHei Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(352, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 19);
            this.label8.TabIndex = 30;
            this.label8.Text = "Hábitat";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(556, 39);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(79, 28);
            this.btnAdd.TabIndex = 37;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(249, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 19);
            this.label7.TabIndex = 30;
            this.label7.Text = "No.";
            // 
            // lblTaxon_S
            // 
            this.lblTaxon_S.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTaxon_S.AutoSize = true;
            this.lblTaxon_S.Font = new System.Drawing.Font("Microsoft JhengHei Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxon_S.Location = new System.Drawing.Point(15, 43);
            this.lblTaxon_S.Name = "lblTaxon_S";
            this.lblTaxon_S.Size = new System.Drawing.Size(59, 19);
            this.lblTaxon_S.TabIndex = 30;
            this.lblTaxon_S.Text = "Genero";
            // 
            // radGenSp_S
            // 
            this.radGenSp_S.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radGenSp_S.AutoSize = true;
            this.radGenSp_S.Font = new System.Drawing.Font("Microsoft NeoGothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGenSp_S.Location = new System.Drawing.Point(308, 15);
            this.radGenSp_S.Name = "radGenSp_S";
            this.radGenSp_S.Size = new System.Drawing.Size(129, 21);
            this.radGenSp_S.TabIndex = 29;
            this.radGenSp_S.Text = "Género o especie";
            this.radGenSp_S.UseVisualStyleBackColor = true;
            this.radGenSp_S.CheckedChanged += new System.EventHandler(this.RadioSites_CheckedChanged);
            // 
            // cboTaxon
            // 
            this.cboTaxon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboTaxon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboTaxon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTaxon.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F);
            this.cboTaxon.FormattingEnabled = true;
            this.cboTaxon.Location = new System.Drawing.Point(85, 42);
            this.cboTaxon.MaximumSize = new System.Drawing.Size(300, 0);
            this.cboTaxon.MinimumSize = new System.Drawing.Size(150, 0);
            this.cboTaxon.Name = "cboTaxon";
            this.cboTaxon.Size = new System.Drawing.Size(150, 25);
            this.cboTaxon.TabIndex = 31;
            this.cboTaxon.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cboTaxon_KeyUp);
            // 
            // radFamily_S
            // 
            this.radFamily_S.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radFamily_S.AutoSize = true;
            this.radFamily_S.Checked = true;
            this.radFamily_S.Font = new System.Drawing.Font("Microsoft NeoGothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radFamily_S.Location = new System.Drawing.Point(188, 15);
            this.radFamily_S.Name = "radFamily_S";
            this.radFamily_S.Size = new System.Drawing.Size(66, 21);
            this.radFamily_S.TabIndex = 28;
            this.radFamily_S.TabStop = true;
            this.radFamily_S.Text = "Familia";
            this.radFamily_S.UseVisualStyleBackColor = true;
            this.radFamily_S.CheckedChanged += new System.EventHandler(this.RadioSites_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cboSite);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(16, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(655, 60);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
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
            // dgvTaxons_S
            // 
            this.dgvTaxons_S.AllowUserToAddRows = false;
            this.dgvTaxons_S.AllowUserToDeleteRows = false;
            this.dgvTaxons_S.AllowUserToResizeColumns = false;
            this.dgvTaxons_S.AllowUserToResizeRows = false;
            this.dgvTaxons_S.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTaxons_S.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTaxons_S.BackgroundColor = System.Drawing.Color.White;
            this.dgvTaxons_S.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTaxons_S.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaxons_S.ContextMenuStrip = this.csmOptions;
            this.dgvTaxons_S.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTaxons_S.Location = new System.Drawing.Point(16, 170);
            this.dgvTaxons_S.Name = "dgvTaxons_S";
            this.dgvTaxons_S.ReadOnly = true;
            this.dgvTaxons_S.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTaxons_S.RowHeadersVisible = false;
            this.dgvTaxons_S.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTaxons_S.Size = new System.Drawing.Size(655, 265);
            this.dgvTaxons_S.TabIndex = 26;
            this.dgvTaxons_S.Click += new System.EventHandler(this.dgvTaxons_S_Click);
            // 
            // csmOptions
            // 
            this.csmOptions.Font = new System.Drawing.Font("Microsoft PhagsPa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csmOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspDelete});
            this.csmOptions.Name = "csmOptions";
            this.csmOptions.Size = new System.Drawing.Size(127, 26);
            // 
            // tspDelete
            // 
            this.tspDelete.Enabled = false;
            this.tspDelete.Name = "tspDelete";
            this.tspDelete.Size = new System.Drawing.Size(126, 22);
            this.tspDelete.Text = "Eliminar";
            this.tspDelete.Click += new System.EventHandler(this.tspDelete_Click);
            // 
            // tbpMacroinvertebrados
            // 
            this.tbpMacroinvertebrados.Controls.Add(this.grpFilter);
            this.tbpMacroinvertebrados.Controls.Add(this.dgvTaxons);
            this.tbpMacroinvertebrados.Location = new System.Drawing.Point(4, 26);
            this.tbpMacroinvertebrados.Name = "tbpMacroinvertebrados";
            this.tbpMacroinvertebrados.Padding = new System.Windows.Forms.Padding(3);
            this.tbpMacroinvertebrados.Size = new System.Drawing.Size(687, 451);
            this.tbpMacroinvertebrados.TabIndex = 1;
            this.tbpMacroinvertebrados.Text = "Macroinvertebrados";
            this.tbpMacroinvertebrados.UseVisualStyleBackColor = true;
            // 
            // grpFilter
            // 
            this.grpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFilter.Controls.Add(this.cboFilteredTax);
            this.grpFilter.Controls.Add(this.lblTaxon);
            this.grpFilter.Controls.Add(this.radGenre);
            this.grpFilter.Controls.Add(this.radFamlily);
            this.grpFilter.Controls.Add(this.radOrder);
            this.grpFilter.Controls.Add(this.radClase);
            this.grpFilter.Location = new System.Drawing.Point(16, 21);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(655, 110);
            this.grpFilter.TabIndex = 14;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filtrar";
            // 
            // cboFilteredTax
            // 
            this.cboFilteredTax.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboFilteredTax.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboFilteredTax.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFilteredTax.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F);
            this.cboFilteredTax.FormattingEnabled = true;
            this.cboFilteredTax.Location = new System.Drawing.Point(145, 65);
            this.cboFilteredTax.Name = "cboFilteredTax";
            this.cboFilteredTax.Size = new System.Drawing.Size(436, 25);
            this.cboFilteredTax.TabIndex = 10;
            this.cboFilteredTax.SelectedIndexChanged += new System.EventHandler(this.cboFilteredTax_SelectedIndexChanged);
            this.cboFilteredTax.TextChanged += new System.EventHandler(this.cboFilteredTax_TextChanged);
            // 
            // lblTaxon
            // 
            this.lblTaxon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTaxon.AutoSize = true;
            this.lblTaxon.Location = new System.Drawing.Point(75, 67);
            this.lblTaxon.Name = "lblTaxon";
            this.lblTaxon.Size = new System.Drawing.Size(42, 17);
            this.lblTaxon.TabIndex = 1;
            this.lblTaxon.Text = "Taxón";
            // 
            // radGenre
            // 
            this.radGenre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radGenre.AutoSize = true;
            this.radGenre.Font = new System.Drawing.Font("Microsoft NeoGothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGenre.Location = new System.Drawing.Point(420, 25);
            this.radGenre.Name = "radGenre";
            this.radGenre.Size = new System.Drawing.Size(64, 20);
            this.radGenre.TabIndex = 8;
            this.radGenre.Text = "Genero";
            this.radGenre.UseVisualStyleBackColor = true;
            this.radGenre.CheckedChanged += new System.EventHandler(this.RadiobuttonMacro_CheckedChanged);
            // 
            // radFamlily
            // 
            this.radFamlily.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radFamlily.AutoSize = true;
            this.radFamlily.Font = new System.Drawing.Font("Microsoft NeoGothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radFamlily.Location = new System.Drawing.Point(340, 25);
            this.radFamlily.Name = "radFamlily";
            this.radFamlily.Size = new System.Drawing.Size(63, 20);
            this.radFamlily.TabIndex = 6;
            this.radFamlily.Text = "Familia";
            this.radFamlily.UseVisualStyleBackColor = true;
            this.radFamlily.CheckedChanged += new System.EventHandler(this.RadiobuttonMacro_CheckedChanged);
            // 
            // radOrder
            // 
            this.radOrder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radOrder.AutoSize = true;
            this.radOrder.Font = new System.Drawing.Font("Microsoft NeoGothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radOrder.Location = new System.Drawing.Point(260, 25);
            this.radOrder.Name = "radOrder";
            this.radOrder.Size = new System.Drawing.Size(59, 20);
            this.radOrder.TabIndex = 4;
            this.radOrder.Text = "Orden";
            this.radOrder.UseVisualStyleBackColor = true;
            this.radOrder.CheckedChanged += new System.EventHandler(this.RadiobuttonMacro_CheckedChanged);
            // 
            // radClase
            // 
            this.radClase.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radClase.AutoSize = true;
            this.radClase.Checked = true;
            this.radClase.Font = new System.Drawing.Font("Microsoft NeoGothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radClase.Location = new System.Drawing.Point(180, 25);
            this.radClase.Name = "radClase";
            this.radClase.Size = new System.Drawing.Size(53, 20);
            this.radClase.TabIndex = 2;
            this.radClase.TabStop = true;
            this.radClase.Text = "Clase";
            this.radClase.UseVisualStyleBackColor = true;
            this.radClase.CheckedChanged += new System.EventHandler(this.RadiobuttonMacro_CheckedChanged);
            // 
            // dgvTaxons
            // 
            this.dgvTaxons.AllowUserToAddRows = false;
            this.dgvTaxons.AllowUserToDeleteRows = false;
            this.dgvTaxons.AllowUserToResizeColumns = false;
            this.dgvTaxons.AllowUserToResizeRows = false;
            this.dgvTaxons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTaxons.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTaxons.BackgroundColor = System.Drawing.Color.White;
            this.dgvTaxons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTaxons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaxons.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTaxons.Location = new System.Drawing.Point(16, 160);
            this.dgvTaxons.Name = "dgvTaxons";
            this.dgvTaxons.ReadOnly = true;
            this.dgvTaxons.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTaxons.RowHeadersVisible = false;
            this.dgvTaxons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTaxons.Size = new System.Drawing.Size(655, 265);
            this.dgvTaxons.TabIndex = 13;
            // 
            // tbpAddEdit
            // 
            this.tbpAddEdit.Controls.Add(this.grpAddEdit);
            this.tbpAddEdit.Controls.Add(this.groupBox1);
            this.tbpAddEdit.Location = new System.Drawing.Point(4, 26);
            this.tbpAddEdit.Name = "tbpAddEdit";
            this.tbpAddEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAddEdit.Size = new System.Drawing.Size(687, 451);
            this.tbpAddEdit.TabIndex = 2;
            this.tbpAddEdit.Text = "Agregar/Editar";
            this.tbpAddEdit.UseVisualStyleBackColor = true;
            // 
            // grpAddEdit
            // 
            this.grpAddEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAddEdit.Controls.Add(this.pnlEdt);
            this.grpAddEdit.Controls.Add(this.pnlAdd);
            this.grpAddEdit.Controls.Add(this.btnDelete);
            this.grpAddEdit.Controls.Add(this.btnAddEdit);
            this.grpAddEdit.Controls.Add(this.cboFam);
            this.grpAddEdit.Controls.Add(this.label6);
            this.grpAddEdit.Controls.Add(this.cboOrder);
            this.grpAddEdit.Controls.Add(this.label4);
            this.grpAddEdit.Controls.Add(this.label5);
            this.grpAddEdit.Controls.Add(this.cboClass);
            this.grpAddEdit.Controls.Add(this.label3);
            this.grpAddEdit.Controls.Add(this.label2);
            this.grpAddEdit.Controls.Add(this.label1);
            this.grpAddEdit.Controls.Add(this.label18);
            this.grpAddEdit.Location = new System.Drawing.Point(16, 111);
            this.grpAddEdit.MaximumSize = new System.Drawing.Size(2000, 525);
            this.grpAddEdit.MinimumSize = new System.Drawing.Size(655, 325);
            this.grpAddEdit.Name = "grpAddEdit";
            this.grpAddEdit.Size = new System.Drawing.Size(655, 325);
            this.grpAddEdit.TabIndex = 1;
            this.grpAddEdit.TabStop = false;
            this.grpAddEdit.Text = "Agregar";
            // 
            // pnlAdd
            // 
            this.pnlAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlAdd.Controls.Add(this.txtClass);
            this.pnlAdd.Controls.Add(this.txtOrder);
            this.pnlAdd.Controls.Add(this.txtFam);
            this.pnlAdd.Controls.Add(this.txtGenSpcs);
            this.pnlAdd.Location = new System.Drawing.Point(142, 49);
            this.pnlAdd.Name = "pnlAdd";
            this.pnlAdd.Size = new System.Drawing.Size(223, 204);
            this.pnlAdd.TabIndex = 18;
            // 
            // txtClass
            // 
            this.txtClass.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtClass.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClass.Location = new System.Drawing.Point(3, 19);
            this.txtClass.MaxLength = 100;
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(200, 28);
            this.txtClass.TabIndex = 0;
            this.txtClass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtOrder
            // 
            this.txtOrder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtOrder.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrder.Location = new System.Drawing.Point(3, 70);
            this.txtOrder.MaxLength = 100;
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(200, 28);
            this.txtOrder.TabIndex = 2;
            this.txtOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFam
            // 
            this.txtFam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFam.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFam.Location = new System.Drawing.Point(3, 117);
            this.txtFam.MaxLength = 100;
            this.txtFam.Name = "txtFam";
            this.txtFam.Size = new System.Drawing.Size(200, 28);
            this.txtFam.TabIndex = 6;
            this.txtFam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtGenSpcs
            // 
            this.txtGenSpcs.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtGenSpcs.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGenSpcs.Location = new System.Drawing.Point(3, 173);
            this.txtGenSpcs.MaxLength = 100;
            this.txtGenSpcs.Name = "txtGenSpcs";
            this.txtGenSpcs.Size = new System.Drawing.Size(200, 28);
            this.txtGenSpcs.TabIndex = 10;
            this.txtGenSpcs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(405, 285);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 28);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddEdit
            // 
            this.btnAddEdit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEdit.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEdit.Location = new System.Drawing.Point(292, 285);
            this.btnAddEdit.Name = "btnAddEdit";
            this.btnAddEdit.Size = new System.Drawing.Size(100, 28);
            this.btnAddEdit.TabIndex = 20;
            this.btnAddEdit.Text = "Agregar";
            this.btnAddEdit.UseVisualStyleBackColor = true;
            this.btnAddEdit.Click += new System.EventHandler(this.btnAddEdit_Click);
            // 
            // cboFam
            // 
            this.cboFam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboFam.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboFam.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFam.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F);
            this.cboFam.FormattingEnabled = true;
            this.cboFam.Location = new System.Drawing.Point(417, 222);
            this.cboFam.Name = "cboFam";
            this.cboFam.Size = new System.Drawing.Size(200, 25);
            this.cboFam.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(363, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Familia";
            // 
            // cboOrder
            // 
            this.cboOrder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboOrder.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboOrder.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboOrder.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F);
            this.cboOrder.FormattingEnabled = true;
            this.cboOrder.Location = new System.Drawing.Point(417, 166);
            this.cboOrder.Name = "cboOrder";
            this.cboOrder.Size = new System.Drawing.Size(200, 25);
            this.cboOrder.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(368, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Orden";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Genero ó Especie";
            // 
            // cboClass
            // 
            this.cboClass.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboClass.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F);
            this.cboClass.FormattingEnabled = true;
            this.cboClass.Location = new System.Drawing.Point(417, 119);
            this.cboClass.Name = "cboClass";
            this.cboClass.Size = new System.Drawing.Size(200, 25);
            this.cboClass.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Familia";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(373, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Clase";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Orden";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(98, 70);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(38, 17);
            this.label18.TabIndex = 5;
            this.label18.Text = "Clase";
            // 
            // pnlEdt
            // 
            this.pnlEdt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlEdt.Controls.Add(this.cboEdtGnrSp);
            this.pnlEdt.Controls.Add(this.cboEdtOrd);
            this.pnlEdt.Controls.Add(this.cboEdtFam);
            this.pnlEdt.Controls.Add(this.cboEdtClass);
            this.pnlEdt.Location = new System.Drawing.Point(142, 24);
            this.pnlEdt.Name = "pnlEdt";
            this.pnlEdt.Size = new System.Drawing.Size(223, 229);
            this.pnlEdt.TabIndex = 21;
            this.pnlEdt.Visible = false;
            // 
            // cboEdtGnrSp
            // 
            this.cboEdtGnrSp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboEdtGnrSp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboEdtGnrSp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEdtGnrSp.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F);
            this.cboEdtGnrSp.FormattingEnabled = true;
            this.cboEdtGnrSp.Location = new System.Drawing.Point(3, 198);
            this.cboEdtGnrSp.Name = "cboEdtGnrSp";
            this.cboEdtGnrSp.Size = new System.Drawing.Size(200, 25);
            this.cboEdtGnrSp.TabIndex = 8;
            this.cboEdtGnrSp.SelectedIndexChanged += new System.EventHandler(this.ComboboxAddEdt_SelectedIndexChanged);
            this.cboEdtGnrSp.TextChanged += new System.EventHandler(this.ComboboxAddEdt_TextChanged);
            // 
            // cboEdtOrd
            // 
            this.cboEdtOrd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboEdtOrd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboEdtOrd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEdtOrd.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F);
            this.cboEdtOrd.FormattingEnabled = true;
            this.cboEdtOrd.Location = new System.Drawing.Point(3, 95);
            this.cboEdtOrd.Name = "cboEdtOrd";
            this.cboEdtOrd.Size = new System.Drawing.Size(200, 25);
            this.cboEdtOrd.TabIndex = 8;
            this.cboEdtOrd.SelectedIndexChanged += new System.EventHandler(this.ComboboxAddEdt_SelectedIndexChanged);
            this.cboEdtOrd.TextChanged += new System.EventHandler(this.ComboboxAddEdt_TextChanged);
            // 
            // cboEdtFam
            // 
            this.cboEdtFam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboEdtFam.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboEdtFam.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEdtFam.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F);
            this.cboEdtFam.FormattingEnabled = true;
            this.cboEdtFam.Location = new System.Drawing.Point(3, 142);
            this.cboEdtFam.Name = "cboEdtFam";
            this.cboEdtFam.Size = new System.Drawing.Size(200, 25);
            this.cboEdtFam.TabIndex = 8;
            this.cboEdtFam.SelectedIndexChanged += new System.EventHandler(this.ComboboxAddEdt_SelectedIndexChanged);
            this.cboEdtFam.TextChanged += new System.EventHandler(this.ComboboxAddEdt_TextChanged);
            // 
            // cboEdtClass
            // 
            this.cboEdtClass.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboEdtClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboEdtClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEdtClass.Font = new System.Drawing.Font("Yu Gothic Light", 9.75F);
            this.cboEdtClass.FormattingEnabled = true;
            this.cboEdtClass.Location = new System.Drawing.Point(3, 44);
            this.cboEdtClass.Name = "cboEdtClass";
            this.cboEdtClass.Size = new System.Drawing.Size(200, 25);
            this.cboEdtClass.TabIndex = 8;
            this.cboEdtClass.SelectedIndexChanged += new System.EventHandler(this.ComboboxAddEdt_SelectedIndexChanged);
            this.cboEdtClass.TextChanged += new System.EventHandler(this.ComboboxAddEdt_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radEdit);
            this.groupBox1.Controls.Add(this.radAdd);
            this.groupBox1.Location = new System.Drawing.Point(16, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(655, 71);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // radEdit
            // 
            this.radEdit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radEdit.AutoSize = true;
            this.radEdit.Font = new System.Drawing.Font("Microsoft NeoGothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radEdit.Location = new System.Drawing.Point(360, 31);
            this.radEdit.Name = "radEdit";
            this.radEdit.Size = new System.Drawing.Size(60, 21);
            this.radEdit.TabIndex = 2;
            this.radEdit.Text = "Editar";
            this.radEdit.UseVisualStyleBackColor = true;
            this.radEdit.CheckedChanged += new System.EventHandler(this.RadioAddEdt_CheckedChanged);
            // 
            // radAdd
            // 
            this.radAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radAdd.AutoSize = true;
            this.radAdd.Checked = true;
            this.radAdd.Font = new System.Drawing.Font("Microsoft NeoGothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAdd.Location = new System.Drawing.Point(240, 31);
            this.radAdd.Name = "radAdd";
            this.radAdd.Size = new System.Drawing.Size(74, 21);
            this.radAdd.TabIndex = 0;
            this.radAdd.TabStop = true;
            this.radAdd.Text = "Agregar";
            this.radAdd.UseVisualStyleBackColor = true;
            this.radAdd.CheckedChanged += new System.EventHandler(this.RadioAddEdt_CheckedChanged);
            // 
            // Macroinvertebrados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabMacroinvertebrados);
            this.Font = new System.Drawing.Font("Microsoft NeoGothic", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Macroinvertebrados";
            this.Size = new System.Drawing.Size(701, 487);
            this.tabMacroinvertebrados.ResumeLayout(false);
            this.tbpSites.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaxons_S)).EndInit();
            this.csmOptions.ResumeLayout(false);
            this.tbpMacroinvertebrados.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaxons)).EndInit();
            this.tbpAddEdit.ResumeLayout(false);
            this.grpAddEdit.ResumeLayout(false);
            this.grpAddEdit.PerformLayout();
            this.pnlAdd.ResumeLayout(false);
            this.pnlAdd.PerformLayout();
            this.pnlEdt.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMacroinvertebrados;
        private System.Windows.Forms.TabPage tbpSites;
        private System.Windows.Forms.TabPage tbpMacroinvertebrados;
        private System.Windows.Forms.TabPage tbpAddEdit;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.DataGridView dgvTaxons;
        private System.Windows.Forms.RadioButton radGenre;
        private System.Windows.Forms.RadioButton radFamlily;
        private System.Windows.Forms.RadioButton radOrder;
        private System.Windows.Forms.RadioButton radClase;
        private System.Windows.Forms.Label lblTaxon;
        private System.Windows.Forms.ComboBox cboFilteredTax;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radEdit;
        private System.Windows.Forms.RadioButton radAdd;
        private System.Windows.Forms.GroupBox grpAddEdit;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.ComboBox cboClass;
        private System.Windows.Forms.Button btnAddEdit;
        private System.Windows.Forms.ComboBox cboFam;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboOrder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGenSpcs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFam;
        private System.Windows.Forms.TextBox txtOrder;
        private System.Windows.Forms.Panel pnlAdd;
        private System.Windows.Forms.Panel pnlEdt;
        private System.Windows.Forms.ComboBox cboEdtGnrSp;
        private System.Windows.Forms.ComboBox cboEdtOrd;
        private System.Windows.Forms.ComboBox cboEdtFam;
        private System.Windows.Forms.ComboBox cboEdtClass;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvTaxons_S;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboSite;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblTaxon_S;
        private System.Windows.Forms.RadioButton radGenSp_S;
        private System.Windows.Forms.ComboBox cboTaxon;
        private System.Windows.Forms.RadioButton radFamily_S;
        private System.Windows.Forms.ContextMenuStrip csmOptions;
        private System.Windows.Forms.ToolStripMenuItem tspDelete;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHabit;
        private System.Windows.Forms.Label label8;
    }
}
