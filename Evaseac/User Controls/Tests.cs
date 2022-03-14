using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Evaseac
{
    public partial class Tests : UserControl
    {
        private int noParams, curParam = 1; //Parameters
        private List<string> qrysParam = new List<string>();

        private int noRep, curRep = 1; //Sites
        private float curValue = 0;
        private string curTest;
        private List<string> qrysPrm = new List<string>();

        public Tests()
        {
            InitializeComponent();
            idTemps = new List<string>();
        }

        ///Atributtes

        public List<string> idTemps { get; set; }

        ///Methods
        
        public void setTabIndex(int i)
        {
            tabTests.SelectedIndex = i;
        }

        public void LoadThis()
        {
            LoadSites();
            tabTests_SelectedIndexChanged(null, null);
        }

        private void LoadSites()
        {
            if (idTemps.Count > 0)
            {
                cboSite.Items.Clear();
                
                for (int i = 0; i < idTemps.Count; i++)
                    cboSite.Items.AddRange(new object[] { DB.Select("SELECT Nombre FROM Sitio WHERE ID = " + DB.Select("SELECT IdSitio FROM Temporada WHERE ID = " + idTemps[i]).Rows[0][0] + "").Rows[0][0] });
                cboSite.SelectedIndex = 0;

                ReLoadSites();
            }
        }

        private void ReLoadSites()
        {
            if (idTemps.Count > 0)
            {
                if (cboSite.SelectedIndex != -1)
                {
                    tspDeleteSte.Enabled = false;
                    qrysPrm.Clear();

                    txtValue.Text = "";
                    cboParam.Text = "";
                    cboTest.ResetText();
                    cboParam.ResetText();
                    lblValue.Text = "Valor (n)";

                    curValue = 0;
                    curRep = 1;

                    cboTest_S.Items.Clear();
                    DataTable xTests = DB.Select("SELECT P.Nombre FROM Prueba AS P, ParametrosP AS PP WHERE P.ID = PP.IdPrueba GROUP BY P.Nombre ORDER BY P.Nombre");
                    for (int i = 0; i < xTests.Rows.Count; i++)
                        cboTest_S.Items.AddRange(new object[] { xTests.Rows[i][0] });

                    FillSites();
                }
            }
            else
            {
                cboSite.Items.Clear();
                dgvTestTemps.DataSource = null;
                MessageBox.Show("No hay sitios seleccionados", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tabTests.SelectedIndex = 1;
            }
        }

        private void FillSites()
        {
            string query = "SELECT P.Nombre, P.Parametros FROM Prueba AS P, ParametrosP AS PP, ParametrosPSitios AS PS "
                + "WHERE P.ID = PP.IdPrueba AND PP.ID = PS.IdParametrosP AND PS.IdTemporada = " + idTemps[cboSite.SelectedIndex] + " GROUP BY P.Nombre, P.Parametros";
            //string query = "SELECT P.Nombre AS [Pruebas agregadas], P.Parametros AS [Número de parámetros] FROM Prueba AS P, ParametrosP AS PP, ParametrosPSitios AS PS "
            //    + "WHERE P.ID = PP.IdPrueba AND PP.ID = PS.IdParametrosP AND PS.IdTemporada = " + idTemps[cboSite.SelectedIndex] + " GROUP BY P.Nombre, P.Parametros";
            DataTable xTests = DB.Select(query);
            dgvTestTemps.DataSource = xTests;
            dgvTestTemps.ClearSelection();
        }

        private void LoadTests()
        {
            CleanTests();
            CleanParams();
            FillTests();

            curParam = 1;
            lblNoParams.Text = "Número de parametros: ";
            lblParam.Text = "Parámetro (0)";
            qrysParam.Clear();
        }

        private void CleanTests()
        {
            txtTest.Text = "";
            txtNoParams.Text = "";
        }

        private void FillTests()
        {
            cboTest.ResetText();
            cboTest.Items.Clear();
            DataTable xTsts;
            if (DB.Select("SELECT ID FROM ParametrosP").Rows.Count > 0)
                xTsts = DB.Select("SELECT Prueba.Nombre FROM Prueba LEFT JOIN ParametrosP ON ParametrosP.IdPrueba = Prueba.ID WHERE ParametrosP.IdPrueba IS NULL");
            else
                xTsts = DB.Select("SELECT P.Nombre FROM Prueba AS P ORDER BY P.Nombre");
            for (int i = 0; i < xTsts.Rows.Count; i++)
                cboTest.Items.AddRange(new object[] { xTsts.Rows[i][0] });

            DataTable xTests = DB.Select("SELECT Nombre, Parametros FROM Prueba ORDER BY ID DESC");
            dgvTests.DataSource = xTests;
            dgvTests.ClearSelection();
        }

        private void CleanParams()
        {
            txtParam.Text = txtRepet.Text = "";
        }

        /// Events

        //Sitios

        private void btnNext_S_Click(object sender, EventArgs e)
        {
            if (cboParam.SelectedIndex != -1 && txtValue.Text != "")
            {
                curRep++;
                lblValue.Text = "Valor (" + curRep + "/" + noRep + ")";
                if (curRep == noRep)
                    btnNext_S.Text = "Finalizar";
                else
                    btnNext_S.Text = "Siguiente";
                
                curValue += float.Parse(txtValue.Text);
                if (curRep > noRep)
                {
                    curValue /= noRep;
                    qrysPrm.Add("INSERT INTO ParametrosPSitios (IdParametrosP, IdTemporada, Valor) VALUES (" + DB.Select("SELECT ID FROM ParametrosP WHERE Nombre = '" + cboParam.SelectedItem + "' AND IdPrueba = " + DB.GetID("Prueba", curTest)).Rows[0][0].ToString() + ", " + idTemps[cboSite.SelectedIndex] + ", " + curValue + ")");

                    cboParam.Items.Remove(cboParam.SelectedItem);
                    if (cboParam.Items.Count > 0)
                    {
                        cboParam.SelectedIndex = 0;
                        curValue = 0;
                        curRep = 1;
                        lblValue.Text = "Valor (" + curRep + "/" + noRep + ")";
                        txtValue.Text = "";
                        txtValue.Focus();
                    }
                    else
                    {
                        for (int i = 0; i < qrysPrm.Count; i++)
                            DB.Insert(qrysPrm[i]);
                        MessageBox.Show("Parámetros agregados correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ReLoadSites();
                        cboTest_S.ResetText();
                        cboTest_S.Focus();
                    }
                }
                else
                {
                    txtValue.Text = "";
                    txtValue.Focus();
                }
            }
        }

        private void tspDeleteSte_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvTestTemps.SelectedRows.Count; i++)
            {
                DataTable xIdPrm = DB.Select("SELECT ID FROM ParametrosP WHERE IdPrueba = " + DB.GetID("Prueba", dgvTestTemps.SelectedRows[i].Cells[0].Value));
                for (int j = 0; j < xIdPrm.Rows.Count; j++)
                    DB.Insert("DELETE FROM ParametrosPSitios WHERE IdTemporada = " + idTemps[cboSite.SelectedIndex] + " AND IdParametrosP = " + xIdPrm.Rows[j][0].ToString());
            }
            FillSites();
        }

        private void dgvTestTemps_Click(object sender, EventArgs e)
        {
            if (dgvTestTemps.SelectedRows.Count > 0)
                tspDeleteSte.Enabled = true;
            else
                tspDeleteSte.Enabled = false;
        }

        private void cboSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillSites();
        }

        private void cboTest_S_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTest_S.SelectedIndex != -1)
            {
                bool alrAdded = false;
                for (int j = 0; j < dgvTestTemps.Rows.Count; j++)
                    if (dgvTestTemps.Rows[j].Cells[0].Value.ToString() == cboTest_S.SelectedItem.ToString())
                        alrAdded = true;

                if (!alrAdded)
                {
                    cboParam.Items.Clear();

                    DataTable xParams = DB.Select("SELECT Nombre FROM ParametrosP WHERE IdPrueba = " + DB.GetID("Prueba", cboTest_S.SelectedItem));
                    for (int i = 0; i < xParams.Rows.Count; i++)
                        cboParam.Items.AddRange(new object[] { xParams.Rows[i][0] });

                    cboParam.SelectedIndex = 0;
                    curTest = cboTest_S.SelectedItem.ToString();
                }
                else
                {
                    MessageBox.Show("La prueba ya ha sido agregada, para volverla a ingresar primero necesita eliminarla", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboTest_S.Text = "";
                    cboTest_S.ResetText();
                }
            }
        }

        private void cboParam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboParam.SelectedIndex != -1)
            {
                txtValue.Focus();

                noRep = int.Parse(DB.Select("SELECT Repeticiones FROM ParametrosP WHERE ID = " + DB.GetID("ParametrosP", cboParam.SelectedItem)).Rows[0][0].ToString());
                lblValue.Text = "Valor (" + curRep + "/" + noRep + ")";

                if (curRep == noRep)
                    btnNext_S.Text = "Finalizar";
                else
                    btnNext_S.Text = "Siguiente";
            }
        }

        private void txtValue_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnNext_S.PerformClick();
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) || ((e.KeyChar == '.') && (txtValue.Text.IndexOf('.') > -1))
                || ((e.KeyChar == '.') && ((sender as TextBox).SelectionStart == 0)))
                e.Handled = true;
        }

        //Tests

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTest.Text != "" && (txtNoParams.Text != "" && !txtNoParams.Text.Equals("0")))
            {
                if (DB.Select("SELECT ID FROM Prueba WHERE Nombre = '" + txtTest.Text + "'").Rows.Count == 0)
                {
                    string query = "INSERT INTO Prueba (Nombre, Parametros) VALUES ('" + txtTest.Text + "', " + int.Parse(txtNoParams.Text) + ")";
                    DB.Insert(query);
                    MessageBox.Show("Prueba agregada correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTests();
                }
                else
                    MessageBox.Show("La operación no se puede concretar debido a que la prueba ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (txtParam.Text != "" && (txtRepet.Text != "" && !txtRepet.Text.Equals("0")) && cboTest.SelectedIndex != -1)
            {
                curParam++;
                lblParam.Text = "Parámetro (" + curParam + ")";
                if (curParam == noParams)
                    btnNext.Text = "Finalizar";
                else
                    btnNext.Text = "Siguiente";

                qrysParam.Add("INSERT INTO ParametrosP (Nombre, IdPrueba, Repeticiones) VALUES ('" + txtParam.Text + "', " + DB.GetID("Prueba", cboTest.SelectedItem) + ", " + txtRepet.Text + ")");

                if (curParam > noParams)
                {
                    for (int i = 0; i < qrysParam.Count; i++)
                        DB.Insert(qrysParam[i]);

                    MessageBox.Show("Parametros agregados correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTests();
                }
                else
                {
                    CleanParams();
                    txtParam.Focus();
                }
            }
        }

        private void tspEdit_Click(object sender, EventArgs e)
        {
            using (frmEditParam frm = new frmEditParam())
            {
                frm.test = dgvTests.SelectedRows[0].Cells[0].Value.ToString();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    FillTests();
                }
            }
        }

        private void tspDelete_Click(object sender, EventArgs e)
        {
            bool cntn = true;
            if (dgvTests.SelectedRows.Count != 0)
            {
                if (DB.Select("SELECT P.Nombre, P.Parametros FROM Prueba AS P, ParametrosP AS PP, ParametrosPSitios AS PS WHERE P.ID = PP.IdPrueba AND P.ID = " + DB.GetID("Prueba", dgvTests.SelectedRows[0].Cells[0].Value.ToString()) + " GROUP BY PS.IdTemporada, P.Nombre, P.Parametros").Rows.Count > 0)
                {
                    DialogResult conf = MessageBox.Show("Al eliminar una prueba se eliminarán todos los registros que se hayan tenido en los sitios\n¿Desea continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (conf == DialogResult.No)
                        cntn = false;
                }
                if (cntn)
                {
                    string idTst = DB.GetID("Prueba", dgvTests.SelectedRows[0].Cells[0].Value.ToString());

                    DataTable xParams = DB.Select("SELECT ID FROM ParametrosP WHERE IdPrueba = " + idTst);
                    for (int i = 0; i < xParams.Rows.Count; i++)
                        DB.Insert("DELETE FROM ParametrosPSitios WHERE IdParametrosP = " + xParams.Rows[i][0].ToString());
                    DB.Insert("DELETE FROM ParametrosP WHERE IdPrueba = " + idTst);
                    DB.Insert("DELETE FROM Prueba WHERE ID = " + idTst);
                    LoadTests();
                }
            }   
        }

        private void dgvTests_Click(object sender, EventArgs e)
        {
            if (dgvTests.SelectedRows.Count > 0)
            {
                tspDelete.Enabled = true;

                bool enableEdit = true;
                for (int i = 0; i < cboTest.Items.Count; i++)
                    if (dgvTests.SelectedRows[0].Cells[0].Value.ToString() == cboTest.Items[i].ToString())
                        enableEdit = false;
                tspEdit.Enabled = enableEdit;
            }
            else
                tspEdit.Enabled = tspDelete.Enabled = false;
        }

        private void cboTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTest.SelectedIndex != -1)
            {
                CleanParams();

                noParams = int.Parse(DB.Select("SELECT Parametros FROM Prueba WHERE ID = " + DB.GetID("Prueba", cboTest.SelectedItem)).Rows[0][0].ToString());
                lblNoParams.Text = "Número de parametros: " + noParams;
                lblParam.Text = "Parámetro (" + curParam + ")";

                if (curParam == noParams)
                    btnNext.Text = "Finalizar";
                else
                    btnNext.Text = "Siguiente";

                txtParam.Focus();
            }
        }

        private void Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void tabTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabTests.SelectedIndex)
            {
                case 0: ReLoadSites(); break;
                case 1: if (dgvTests.Rows.Count == 0) LoadTests(); break;
            }
        }

        //
    }
}
