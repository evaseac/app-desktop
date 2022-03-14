using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace Evaseac.User_Controls
{
    public partial class Macroinvertebrados : UserControl
    {
        public Macroinvertebrados()
        {
            InitializeComponent();
            tabMacroinvertebrados.SelectedIndex = 1;
            idTemps = new List<string>();
        }

        //Attributes
        public List<string> idTemps { get; set; }

        //Methods

        public void setTabPageIndex(int i)
        {
            tabMacroinvertebrados.SelectedIndex = i;
        }

        public void LoadThis()
        {
            tabMacroinvertebrados_SelectedIndexChanged(null, null);
        }

        private void LoadSites()
        {
            if (idTemps.Count > 0)
            {
                cboSite.Items.Clear();

                for (int i = 0; i < idTemps.Count; i++)
                    cboSite.Items.AddRange(new object[] { DB.Select("SELECT Nombre FROM Sitio WHERE ID = " + DB.Select("SELECT IdSitio FROM Temporada WHERE ID = " + idTemps[i]).Rows[0][0] + "").Rows[0][0] });
                cboSite.SelectedIndex = 0;

                if (radFamily_S.Checked)
                    RadioSites_CheckedChanged(radFamily_S, null);
                else
                    RadioSites_CheckedChanged(radGenSp_S, null);
            }
            else
            {
                cboSite.Items.Clear();
                dgvTaxons_S.DataSource = null;
                MessageBox.Show("No hay sitios seleccionados", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tabMacroinvertebrados.SelectedIndex = 1;
            }
        }

        private void FillDgvTaxons()
        {
            dgvTaxons.DataSource = null;
            string query;
            if (radFamily_S.Checked)
                query = "SELECT C.Nombre AS Clase, O.Nombre AS Orden, F.Nombre AS Familia, FS.Numero AS Número, FS.Habitat AS Hábitat FROM Clase AS C, Orden AS O, Familia AS F, FamiliasSitios AS FS "
                    + "WHERE F.Nombre != 'no identificado' AND C.ID = O.IdClase AND O.ID = F.IdOrden AND FS.IdFamilia = F.ID AND FS.IdTemporada = " + idTemps[cboSite.SelectedIndex];
            else
                query = "SELECT C.Nombre AS Clase, O.Nombre AS Orden, F.Nombre AS Familia, G.Nombre AS Genero, GS.Numero AS Número, GS.Habitat AS Hábitat FROM Clase AS C, Orden AS O, Familia AS F, Genero AS G, GenerosSitios AS GS "
                    + "WHERE G.Nombre != 'no identificado' AND C.ID = O.IdClase AND O.ID = F.IdOrden AND F.ID = G.IdFamilia AND GS.IdGenero = G.ID AND GS.IdTemporada = " + idTemps[cboSite.SelectedIndex];

            DataTable xTaxons = DB.Select(query);
            dgvTaxons_S.DataSource = xTaxons;
            dgvTaxons_S.ClearSelection();

            tspDelete.Enabled = false;

            //Filling autocomplete textbox
            DataTable xHab = DB.Select("SELECT Habitat FROM FamiliasSitios GROUP BY Habitat");
            AutoCompleteStringCollection src = new AutoCompleteStringCollection();
            for (int i = 0; i < xHab.Rows.Count; i++)
                src.AddRange(new string[] { xHab.Rows[i][0].ToString() });
            xHab = DB.Select("SELECT GS.Habitat FROM GenerosSitios AS GS, FamiliasSitios AS FS WHERE GS.Habitat != FS.Habitat ORDER BY GS.Habitat");
            for (int i = 0; i < xHab.Rows.Count; i++)
                src.AddRange(new string[] { xHab.Rows[i][0].ToString() });
            txtHabit.AutoCompleteCustomSource = src;
        }

        private void LoadMacros()
        {
            cboFilteredTax.Text = "";
            RadioButtonChecked();
        }

        private void RadioButtonChecked()
        {
            if (radClase.Checked)
                RadiobuttonMacro_CheckedChanged(radClase, null);
            if (radOrder.Checked)
                RadiobuttonMacro_CheckedChanged(radOrder, null);
            if (radFamlily.Checked)
                RadiobuttonMacro_CheckedChanged(radFamlily, null);
            else
                RadiobuttonMacro_CheckedChanged(radGenre, null);
        }

        private void LoadAddEdt()
        {
            if (cboClass.Items.Count == 0)
            {
                txtClass.Text = txtOrder.Text = txtFam.Text = txtGenSpcs.Text = "";
                cboEdtClass.Text = cboEdtFam.Text = cboEdtGnrSp.Text = cboEdtOrd.Text = "";
                cboClass.Text = cboFam.Text = cboOrder.Text = "";

                cboEdtClass.Items.Clear();
                cboEdtFam.Items.Clear();
                cboEdtGnrSp.Items.Clear();
                cboEdtOrd.Items.Clear();
                cboFam.Items.Clear();
                cboOrder.Items.Clear();

                //Retrieving data
                DataTable xClass = DB.Select("SELECT Nombre FROM Clase WHERE Nombre <> 'no identificado' ORDER BY Nombre");
                DataTable xOrder = DB.Select("SELECT Nombre FROM Orden WHERE Nombre <> 'no identificado' ORDER BY Nombre");
                DataTable xFam = DB.Select("SELECT Nombre FROM Familia WHERE Nombre <> 'no identificado' ORDER BY Nombre");
                DataTable xGenre = DB.Select("SELECT Nombre FROM Genero WHERE Nombre <> 'no identificado' ORDER BY Nombre");

                cboOrder.Items.AddRange(new object[] { "no identificado" });

                int i;
                for (i = 0; i < xClass.Rows.Count; i++)
                {
                    cboClass.Items.AddRange(new object[] { xClass.Rows[i][0] });
                    cboEdtClass.Items.AddRange(new object[] { xClass.Rows[i][0] });
                }
                for (i = 0; i < xOrder.Rows.Count; i++)
                {
                    cboOrder.Items.AddRange(new object[] { xOrder.Rows[i][0] });
                    cboEdtOrd.Items.AddRange(new object[] { xOrder.Rows[i][0] });
                }
                for (i = 0; i < xFam.Rows.Count; i++)
                {
                    cboFam.Items.AddRange(new object[] { xFam.Rows[i][0] });
                    cboEdtFam.Items.AddRange(new object[] { xFam.Rows[i][0] });
                }
                for (i = 0; i < xGenre.Rows.Count; i++)
                    cboEdtGnrSp.Items.AddRange(new object[] { xGenre.Rows[i][0] });
            }
        }

        private string InsertNonIdentifiedTaxon(string taxon)
        {
            using (frmAddNonIdtfdTaxon frm = new frmAddNonIdtfdTaxon())
            {
                frm.setTaxon(taxon);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    return frm.IdTaxon;
                }
                else
                    return null;
            }
        }

        //Events

        ///Sites

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboTaxon.SelectedIndex != -1 && txtNumber.Text != "" && txtHabit.Text != "")
            {
                string query = "";
                bool exist = false;
                if (radGenSp_S.Checked)
                    if (DB.Select("SELECT * FROM GenerosSitios WHERE IdGenero = " + DB.GetID("Genero", cboTaxon.SelectedItem) + " AND IdTemporada = " + idTemps[cboSite.SelectedIndex] + " AND Habitat = '" + txtHabit.Text + "'").Rows.Count == 0)
                        query = "INSERT INTO GenerosSitios (IdGenero, IdTemporada, Numero, Habitat) "
                            + "VALUES (" + DB.GetID("Genero", cboTaxon.SelectedItem) + ", " + idTemps[cboSite.SelectedIndex] + ", " + txtNumber.Text + ", '" + txtHabit.Text + "')";
                    else
                        exist = true;
                else
                    if (DB.Select("SELECT * FROM FamiliasSitios WHERE IdFamilia = " + DB.GetID("Familia", cboTaxon.SelectedItem) + " AND IdTemporada = " + idTemps[cboSite.SelectedIndex] + " AND Habitat = '" + txtHabit.Text + "'").Rows.Count == 0)
                        query = "INSERT INTO FamiliasSitios (IdFamilia, IdTemporada, Numero, Habitat) "
                            + "VALUES (" + DB.GetID("Familia", cboTaxon.SelectedItem) + ", " + idTemps[cboSite.SelectedIndex] + ", " + txtNumber.Text + ", '" + txtHabit.Text + "')";
                    else
                        exist = true;

                if (!exist)
                {
                    DB.Insert(query);
                    FillDgvTaxons();
                }
                else
                    MessageBox.Show("El taxón ya ha sido ingresado en la temporada y hábitat", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cboTaxon.ResetText();
                cboTaxon.Focus();
                txtNumber.Text = null;
            }
        }

        private void cboSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSite.SelectedIndex != -1)
                FillDgvTaxons();
        }

        private void RadioSites_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rad = sender as RadioButton;

            if (rad.Checked)
            {
                cboTaxon.Text = null;
                cboTaxon.Items.Clear();

                if (rad == radFamily_S)
                {
                    lblTaxon_S.Text = "Familia";

                    DataTable xFamily = DB.Select("SELECT Nombre FROM Familia WHERE Nombre <> 'no identificado' ORDER BY Nombre");
                    for (int i = 0; i < xFamily.Rows.Count; i++)
                        cboTaxon.Items.AddRange(new object[] { xFamily.Rows[i][0] });
                }
                else if (rad == radGenSp_S)
                {
                    lblTaxon_S.Text = "Género";

                    DataTable xGenre = DB.Select("SELECT G.Nombre FROM Genero AS G WHERE Nombre <> 'no identificado' ORDER BY Nombre");
                    for (int i = 0; i < xGenre.Rows.Count; i++)
                        cboTaxon.Items.AddRange(new object[] { xGenre.Rows[i][0] });
                }

                FillDgvTaxons();
            }
        }
        
        private void tspDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvTaxons_S.SelectedRows.Count; i++)
            {
                string query;

                if (radFamily_S.Checked)
                {
                    query = "DELETE FROM FamiliasSitios WHERE IdFamilia = " + DB.GetID("Familia", dgvTaxons_S.SelectedRows[i].Cells[2].Value) + " AND IdTemporada = " + idTemps[cboSite.SelectedIndex];

                    DataTable xIdGen = DB.Select("SELECT ID FROM Genero WHERE IdFamilia = " + DB.GetID("Familia", dgvTaxons_S.SelectedRows[i].Cells[2].Value));
                    for (int j = 0; j < xIdGen.Rows.Count; j++)
                        DB.Insert("DELETE FROM GenerosSitios WHERE IdGenero = " + xIdGen.Rows[j][0] + " AND IdTemporada = " + idTemps[cboSite.SelectedIndex]);
                }
                else
                    query = "DELETE FROM GenerosSitios WHERE IdGenero = " + DB.GetID("Genero", dgvTaxons_S.SelectedRows[i].Cells[3].Value) + " AND IdTemporada = " + idTemps[cboSite.SelectedIndex];

                DB.Insert(query);
            }

            FillDgvTaxons();
        }

        private void dgvTaxons_S_Click(object sender, EventArgs e)
        {
            if (dgvTaxons_S.SelectedRows.Count > 0)
                tspDelete.Enabled = true;
            else
                tspDelete.Enabled = false;
        }

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        ///Macros

        private void RadiobuttonMacro_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rad = sender as RadioButton;

            if (rad.Checked)
            {
                //cboFilteredTax.Text = "";

                lblTaxon.Visible = cboFilteredTax.Visible = true;
                cboFilteredTax.Items.Clear();

                string query;
                dgvTaxons.DataSource = null;

                if (rad == radClase)
                {
                    DataTable xClase = DB.Select("SELECT Nombre AS Clase FROM Clase WHERE ID != 1 ORDER BY ID DESC");
                    dgvTaxons.DataSource = xClase;

                    lblTaxon.Visible = cboFilteredTax.Visible = false;
                }
                else if (rad == radOrder)
                {
                    query = "SELECT C.Nombre AS Clase, O.Nombre AS Orden FROM Clase AS C, Orden AS O WHERE O.Nombre != 'no identificado' AND C.ID = O.IdClase ORDER BY O.ID DESC";
                    DataTable xOrder = DB.Select(query);
                    dgvTaxons.DataSource = xOrder;
                    
                    lblTaxon.Text = "Clase";

                    DataTable xClase = DB.Select("SELECT Nombre AS Clase FROM Clase WHERE ID != 1 ORDER BY Nombre");
                    for (int i = 0; i < xClase.Rows.Count; i++)
                        cboFilteredTax.Items.AddRange(new object[] { xClase.Rows[i][0] });
                }
                else if (rad == radFamlily)
                {
                    query = "SELECT C.Nombre AS Clase, O.Nombre AS Orden, F.Nombre AS Familia FROM Clase AS C, Orden AS O, Familia AS F "
                        + "WHERE F.Nombre != 'no identificado' AND C.ID = O.IdClase AND O.ID = F.IdOrden ORDER BY F.ID DESC";
                    DataTable xFamily = DB.Select(query);
                    dgvTaxons.DataSource = xFamily;
                    
                    lblTaxon.Text = "Orden";
                    
                    DataTable xOrd = DB.Select("SELECT Nombre FROM Orden WHERE Nombre != 'no identificado' ORDER BY Nombre");
                    for (int i = 0; i < xOrd.Rows.Count; i++)
                        cboFilteredTax.Items.AddRange(new object[] { xOrd.Rows[i][0] });
                }
                else
                {
                    query = "SELECT C.Nombre AS Clase, O.Nombre AS Orden, F.Nombre AS Familia, G.Nombre AS Genero FROM Clase AS C, Orden AS O, Familia AS F, Genero AS G "
                        + "WHERE G.Nombre != 'no identificado' AND C.ID = O.IdClase AND O.ID = F.IdOrden AND F.ID = G.IdFamilia ORDER BY G.ID DESC";
                    DataTable xGenre = DB.Select(query);
                    dgvTaxons.DataSource = xGenre;
                    
                    lblTaxon.Text = "Familia";
                    
                    DataTable xFam = DB.Select("SELECT Nombre FROM Familia WHERE Nombre != 'no identificado' ORDER BY Nombre");
                    for (int i = 0; i < xFam.Rows.Count; i++)
                        cboFilteredTax.Items.AddRange(new object[] { xFam.Rows[i][0] });
                }

                dgvTaxons.ClearSelection();
            }
        }

        private void cboFilteredTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFilteredTax.SelectedIndex != -1)
            {
                string query;

                dgvTaxons.DataSource = null;

                if (radOrder.Checked)
                {
                    query = "SELECT C.Nombre AS Clase, O.Nombre AS Orden FROM Clase AS C, Orden AS O "
                        + "WHERE C.Nombre = '" + cboFilteredTax.SelectedItem + "' AND O.Nombre <> 'no identificado' AND C.ID = O.IdClase";
                    DataTable xFltrdOrder = DB.Select(query);
                    dgvTaxons.DataSource = xFltrdOrder;
                }
                else if (radFamlily.Checked)
                {
                    query = "SELECT C.Nombre AS Clase, O.Nombre AS Orden, F.Nombre AS Familia FROM Clase AS C, Orden AS O, Familia AS F "
                        + "WHERE O.Nombre = '" + cboFilteredTax.SelectedItem + "' AND F.Nombre <> 'no identificado' AND C.ID = O.IdClase AND O.ID = F.IdOrden";
                    DataTable xFltrdFam = DB.Select(query);
                    dgvTaxons.DataSource = xFltrdFam;
                }
                else if (radGenre.Checked)
                {
                    query = "SELECT C.Nombre AS Clase, O.Nombre AS Orden, F.Nombre AS Familia, G.Nombre AS Genero FROM Clase AS C, Orden AS O, Familia AS F, Genero AS G "
                        + "WHERE F.Nombre = '" + cboFilteredTax.SelectedItem + "' AND  G.Nombre <> 'no identificado' AND C.ID = O.IdClase AND O.ID = F.IdOrden AND F.ID = G.IdFamilia";
                    DataTable xFltrdGenre = DB.Select(query);
                    dgvTaxons.DataSource = xFltrdGenre;
                }

                dgvTaxons.ClearSelection();
            }
        }

        private void cboFilteredTax_TextChanged(object sender, EventArgs e)
        {
            if (cboFilteredTax.Text == "")
            {
                cboFilteredTax.SelectedIndex = -1;
                cboFilteredTax.Items.Clear();
                RadioButtonChecked();
            }
        }

        private void cboTaxon_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAdd.PerformClick();
        }

        ///Add || Edit

        private void btnAddEdit_Click(object sender, EventArgs e)
        {
            if (radAdd.Checked)
            { 
                if (txtClass.Text != "" || txtOrder.Text != "" || txtFam.Text != "" || txtGenSpcs.Text != "")
                {
                    string missing = "";
                    bool insrt = true;
                    int nonIdentified = 0;

                    List<string> qrys = new List<string>();

                    if (txtClass.Text != "")
                        qrys.Add("INSERT INTO Clase (Nombre) VALUES ('" + txtClass.Text + "')");
                    //Orden
                    if (txtOrder.Text != "" && cboClass.SelectedIndex == -1)
                    {
                        insrt = false;
                        missing += " Agregar una clase al orden";
                    }
                    else if (txtOrder.Text != "" && cboClass.SelectedIndex != -1)
                        qrys.Add("INSERT INTO Orden (Nombre, IdClase) VALUES ('" + txtOrder.Text + "', " + DB.GetID("Clase", cboClass.SelectedItem) + ")");
                    //Familia
                    if (txtFam.Text != "" && cboOrder.SelectedIndex == -1)
                    {
                        insrt = false;
                        if (missing != "")
                            missing += ", agregar un orden a la familia";
                        else
                            missing += " Agregar un orden a la familia";
                    }
                    else if (txtFam.Text != "" && cboOrder.SelectedIndex != -1 && cboOrder.SelectedIndex != 0)
                        qrys.Add("INSERT INTO Familia (Nombre, IdOrden) VALUES ('" + txtFam.Text + "', " + DB.GetID("Orden", cboOrder.SelectedItem) + ")");
                    else if (txtFam.Text != "" && cboOrder.SelectedIndex == 0)
                        nonIdentified = 3;
                    //Género o especie
                    if (txtGenSpcs.Text != "" && cboFam.SelectedIndex == -1)
                    {
                        insrt = false;
                        if (missing != "")
                            missing += ", agregar una familia al Género/Especie";
                        else
                            missing += " Agregar una familia al Género/Especie";
                    }
                    else if (txtGenSpcs.Text != "" && cboFam.SelectedIndex != -1 && cboFam.SelectedIndex != 0)
                        qrys.Add("INSERT INTO Genero (Nombre, IdFamilia) VALUES ('" + txtGenSpcs.Text + "', " + DB.GetID("Familia", cboFam.SelectedItem) + ")");
                    else if (txtGenSpcs.Text != "" && cboFam.SelectedIndex == 0)
                        nonIdentified++;

                    if (insrt)
                    {
                        string exstng = "";

                        if (txtClass.Text != "")
                            if (DB.Select("SELECT ID FROM Clase WHERE Nombre = '" + txtClass.Text + "'").Rows.Count != 0)
                                exstng += " La clase ya existe";
                        if (txtOrder.Text != "")
                            if (DB.Select("SELECT ID FROM Orden WHERE Nombre = '" + txtOrder.Text + "'").Rows.Count != 0)
                                if (exstng == "")
                                    exstng += " El orden ya existe";
                                else
                                    exstng += ", el orden ya existe";
                        if (txtFam.Text != "")
                            if (DB.Select("SELECT ID FROM Familia WHERE Nombre = '" + txtFam.Text + "'").Rows.Count != 0)
                                if (exstng == "")
                                    exstng += " La familia ya existe";
                                else
                                    exstng += ", la familia ya existe";
                        if (txtGenSpcs.Text != "")
                            if (DB.Select("SELECT ID FROM Genero WHERE Nombre = '" + txtGenSpcs.Text + "'").Rows.Count != 0)
                                if (exstng == "")
                                    exstng += " El Género/Especie ya existe";
                                else
                                    exstng += ", el género/especie ya existe";

                        if (exstng == "")
                        {
                            int succesInsrts;

                            for (int i = 0; i < qrys.Count; i++)
                                DB.Insert(qrys[i]);
                            succesInsrts = qrys.Count;

                            if (nonIdentified == 3) //Family
                            {
                                string idOrder = InsertNonIdentifiedTaxon("Familia");
                                if (idOrder != null)
                                {
                                    DB.Insert("INSERT INTO Familia (Nombre, IdOrden) VALUES ('" + txtFam.Text + "', " + idOrder + ")");
                                    succesInsrts++;
                                }
                            }
                            else if (nonIdentified == 1) //Genre
                            {
                                string idFam = InsertNonIdentifiedTaxon("Genero");
                                if (idFam != null)
                                {
                                    DB.Insert("INSERT INTO Genero (Nombre, IdFamilia) VALUES ('" + txtGenSpcs.Text + "', " + idFam + ")");
                                    succesInsrts++;
                                }
                            }
                            else if (nonIdentified == 4) //Both
                            {
                                string idOrder = InsertNonIdentifiedTaxon("Familia");
                                if (idOrder != null)
                                {
                                    DB.Insert("INSERT INTO Familia (Nombre, IdOrden) VALUES ('" + txtFam.Text + "', " + idOrder + ")");
                                    succesInsrts++;
                                }
                                string idFam = InsertNonIdentifiedTaxon("Genero");
                                if (idFam != null)
                                {
                                    DB.Insert("INSERT INTO Genero (Nombre, IdFamilia) VALUES ('" + txtGenSpcs.Text + "', " + idFam + ")");
                                    succesInsrts++;
                                }
                            }

                            if (succesInsrts == 1)
                                MessageBox.Show("Taxón agregado correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Taxones agregados correctamente: " + succesInsrts, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            cboClass.Items.Clear();
                            LoadAddEdt();
                            LoadMacros();
                        }
                        else
                            MessageBox.Show("La operación no pudo ser completada debido a los siguentes problemas:" + exstng, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("La operación no se puede concretar debido a que falta:" + missing, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (cboEdtClass.SelectedIndex != -1 || cboEdtFam.SelectedIndex != -1 || cboEdtGnrSp.SelectedIndex != -1 || cboEdtOrd.SelectedIndex != -1)
                {
                    int unidntfd = 0;
                    List<string> qrys = new List<string>();

                    if (cboEdtOrd.SelectedIndex != -1 && cboClass.SelectedIndex != 0)
                        qrys.Add("UPDATE Orden SET IdClase = " + DB.GetID("Clase", cboClass.SelectedItem) + " WHERE Nombre = '" + cboEdtOrd.SelectedItem + "'");
                    if (cboEdtFam.SelectedIndex != -1 && cboOrder.SelectedIndex != 0)
                        qrys.Add("UPDATE Familia SET IdOrden = " + DB.GetID("Orden", cboOrder.SelectedItem) + " WHERE Nombre = '" + cboEdtFam.SelectedItem + "'");
                    else if (cboEdtFam.SelectedIndex != -1 && cboOrder.SelectedIndex == 0)
                        unidntfd += 2;
                    if (cboEdtGnrSp.SelectedIndex != -1 && cboFam.SelectedIndex != 0)
                        qrys.Add("UPDATE Genero SET IdFamilia = " + DB.GetID("Familia", cboFam.SelectedItem) + " WHERE Nombre = '" + cboEdtGnrSp.SelectedItem + "'");
                    else if (cboEdtGnrSp.SelectedIndex != -1 && cboFam.SelectedIndex == 0)
                        unidntfd++;

                    for (int i = 0; i < qrys.Count; i++)
                        DB.Insert(qrys[i]);

                    int succesInsts = qrys.Count;

                    switch (unidntfd)
                    {
                        case 2://Family
                            string idOrder = InsertNonIdentifiedTaxon("Familia");
                            if (idOrder != null)
                            {
                                //Deleting if unidentified has no more taxons in it
                                string idUn = DB.Select("SELECT IdOrden FROM Familia WHERE Nombre = '" + cboEdtFam.SelectedItem + "'").Rows[0][0].ToString();
                                if (DB.Select("SELECT Nombre FROM Orden WHERE ID = " + idUn).Rows[0][0].ToString() == "no identificado"
                                    && DB.Select("SELECT ID FROM Familia WHERE IdOrden = " + idUn).Rows.Count < 2)
                                    DB.Insert("DELETE FROM Orden WHERE ID = " + idUn);

                                DB.Insert("UPDATE Familia SET IdOrden = " + idOrder + " WHERE Nombre = '" + cboEdtFam.SelectedItem + "'");
                                succesInsts++;
                            }
                            break;
                        case 1://Genre
                            string idFamilia = InsertNonIdentifiedTaxon("Genero");
                            if (idFamilia != null)
                            {
                                //Deleting if unidentified has no more taxons in it
                                string idUn = DB.Select("SELECT IdFamilia FROM Genero WHERE Nombre = '" + cboEdtGnrSp.SelectedItem + "'").Rows[0][0].ToString();
                                if (DB.Select("SELECT Nombre FROM Familia WHERE ID = " + idUn).Rows[0][0].ToString() == "no identificado"
                                    && DB.Select("SELECT ID FROM Genero WHERE IdFamilia = " + idUn).Rows.Count < 2)
                                    DB.Insert("DELETE FROM Familia WHERE ID = " + idUn);

                                DB.Insert("UPDATE Genero SET IdFamilia = " + idFamilia + " WHERE Nombre = '" + cboEdtGnrSp.SelectedItem + "'");
                                succesInsts++;
                            }
                            break;
                        case 3://Both
                            string idOrd = InsertNonIdentifiedTaxon("Familia");
                            if (idOrd != null)
                            {
                                succesInsts++;
                            }
                            string idFam = InsertNonIdentifiedTaxon("Genero");
                            if (idFam != null)
                            {
                                succesInsts++;
                            }
                            break;
                    }

                    if (succesInsts == 1)
                        MessageBox.Show("Taxón modificado correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Taxones modificados correctamente: " + succesInsts, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cboClass.Items.Clear();
                    LoadAddEdt();
                    LoadMacros();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cboEdtClass.SelectedIndex != -1 || cboEdtFam.SelectedIndex != -1 || cboEdtGnrSp.SelectedIndex != -1 || cboEdtOrd.SelectedIndex != -1)
            {
                string errs = "";
                List<string> qrys = new List<string>();

                if (cboEdtClass.SelectedIndex != -1)
                {
                    qrys.Add("DELETE FROM Clase WHERE Nombre = '" + cboEdtClass.SelectedItem + "'");
                    if (DB.Select("SELECT ID FROM Orden WHERE IdClase = " + DB.GetID("Clase", cboEdtClass.SelectedItem)).Rows.Count != 0)
                        errs += " La clase ya tiene ordenes ingresados";
                }
                if (cboEdtOrd.SelectedIndex != -1)
                {
                    qrys.Add("DELETE FROM Orden WHERE Nombre = '" + cboEdtOrd.SelectedItem + "'");
                    if (DB.Select("SELECT ID FROM Familia WHERE IdOrden = " + DB.GetID("Orden", cboEdtOrd.SelectedItem)).Rows.Count != 0)
                        if (errs == "")
                            errs += " El orden ya tiene familias ingresados";
                        else
                            errs += ", el orden ya tiene familias ingresados";
                }
                if (cboEdtFam.SelectedIndex != -1)
                {
                    qrys.Add("DELETE FROM Familia WHERE Nombre = '" + cboEdtFam.SelectedItem + "'");
                    if (DB.Select("SELECT ID FROM Genero WHERE IdFamilia = " + DB.GetID("Familia", cboEdtFam.SelectedItem)).Rows.Count != 0)
                        if (errs == "")
                            errs += " La familia ya tiene generos ingresados";
                        else
                            errs += ", la familia ya tiene generos ingresados";
                }
                if (cboEdtGnrSp.SelectedIndex != -1)
                    qrys.Add("DELETE FROM Genero WHERE Nombre = '" + cboEdtGnrSp.SelectedItem + "'");
                

                if (errs.Equals(""))
                {
                    for (int i = 0; i < qrys.Count; i++)
                        DB.Insert(qrys[i]);

                    if (qrys.Count == 1)
                        MessageBox.Show("Taxón eliminado correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Taxones eliminados correctamente: " + qrys.Count, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cboClass.Items.Clear();
                    LoadAddEdt();
                    LoadMacros();
                }
                else
                    MessageBox.Show("La operación no se pudo completar debido a los siguientes errores:" + errs, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboboxAddEdt_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;

            if (cbo.SelectedIndex != -1)
            {
                if (cbo == cboEdtOrd)
                    cboClass.SelectedItem = DB.Select("SELECT Nombre FROM Clase WHERE ID = " + DB.Select("SELECT IdClase FROM Orden WHERE Nombre = '" + cboEdtOrd.SelectedItem + "'").Rows[0][0]).Rows[0][0];
                else if (cbo == cboEdtFam)
                    cboOrder.SelectedItem = DB.Select("SELECT Nombre FROM Orden WHERE ID = " + DB.Select("SELECT IdOrden FROM Familia WHERE Nombre = '" + cboEdtFam.SelectedItem + "'").Rows[0][0]).Rows[0][0];
                else if (cbo == cboEdtGnrSp)
                    cboFam.SelectedItem = DB.Select("SELECT Nombre FROM Familia WHERE ID = " + DB.Select("SELECT IdFamilia FROM Genero WHERE Nombre = '" + cboEdtGnrSp.SelectedItem + "'").Rows[0][0]).Rows[0][0];
            }
        }

        private void ComboboxAddEdt_TextChanged(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;

            if (cbo.Text == "")
            {
                if (cbo == cboEdtOrd)
                    cboClass.Text = "";
                if (cbo == cboEdtFam)
                    cboOrder.Text = "";
                if (cbo == cboEdtGnrSp)
                    cboFam.Text = "";

                cbo.Refresh();
            }
        }

        private void RadioAddEdt_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rad = sender as RadioButton;
            if (rad.Checked)
                if (rad == radAdd)
                {
                    cboEdtClass.Text = cboEdtFam.Text = cboEdtGnrSp.Text = cboEdtOrd.Text = "";

                    grpAddEdit.Text = btnAddEdit.Text = "Agregar";
                    pnlAdd.Visible = true;
                    pnlEdt.Visible = btnDelete.Visible = false;
                    btnAddEdit.Location = new System.Drawing.Point(btnAddEdit.Location.X + 122, 285);
                }
                else
                {
                    grpAddEdit.Text = "Editar";
                    btnAddEdit.Text = "Guardar";
                    pnlEdt.Visible = btnDelete.Visible = true;
                    pnlAdd.Visible = false;
                    btnAddEdit.Location = new System.Drawing.Point(btnAddEdit.Location.X - 122, 285);
                }
        }

        ///Common

        private void tabMacroinvertebrados_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabMacroinvertebrados.SelectedIndex)
            {
                case 0: LoadSites(); break;
                case 1: if (dgvTaxons.Rows.Count == 0) LoadMacros(); break;
                case 2: LoadAddEdt(); break;
            }
        }

        //
    }
}
