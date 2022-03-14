using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Evaseac.Properties;

/// <summary>
/// if(doneChanges) LoadSmthng();
/// 
/// </summary>

namespace Evaseac
{
    public partial class Sites : UserControl
    {
        private frmMain Main;
        private string temp;

        public bool edt = true; //Show loss data warning once

        public Sites(frmMain main)
        {
            InitializeComponent();
            this.Main = main;
            sites = new List<string>();
            idTemps = new List<string>();
        }

        public Sites()
        {
            InitializeComponent();
            sites = new List<string>();
            idTemps = new List<string>();
        }

        //Attributes

        private List<string> sites { get; set; }
        public List<string> idTemps { get; set; }

        //Methods

        public void setMain(frmMain frm)
        {
            Main = frm;
        }

        private void CreateTemp()
        {
            idTemps.Clear();

            if (sites.Count > 0 && StxtResp.Text != "")
            {
                int i;
                for (i = 0; i < sites.Count; i++)
                {
                    DataTable xTemp = DB.Select("SELECT ID FROM Temporada WHERE IdSitio = " + DB.GetID("Sitio", sites[i]) + " AND Temporada = '" + temp + "'");
                    if (xTemp.Rows.Count == 0)
                    {
                        DB.Insert("INSERT INTO Temporada (Responsable, Temporada, IdSitio) VALUES ('" + StxtResp.Text + "', '" + temp + "', " + DB.GetID("Sitio", sites[i]) + ")");
                        idTemps.Add(DB.Select("SELECT ID FROM Temporada ORDER BY ID DESC LIMIT 1").Rows[0][0].ToString());
                    }
                    else
                        idTemps.Add(xTemp.Rows[0][0].ToString());
                }

                Main.btnParamEnabled(true);
            }
            else
                Main.btnParamEnabled(false);
        }

        public void LoadSites()
        {
            sites.Clear();
            Main.btnParamEnabled(false);

            if (ScboProject.Items.Count != DB.Select("SELECT ID FROM Proyecto").Rows.Count)
                DB.FillCombobox("nombre", "Proyecto", ScboProject);

            SdgvSites.Rows.Clear();
            foreach (DataGridViewColumn col in SdgvSites.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            DataTable dtSites = DB.Select("SELECT s.nombre, p.nombre, Abreviatura, RioCuenca, Norte, Oeste, Altitud FROM Sitio s, Proyecto p WHERE p.ID = s.IdProyecto ORDER BY s.ID DESC");
            
            for (int i = 0; i < dtSites.Rows.Count; i++)
                SdgvSites.Rows.Add(false, dtSites.Rows[i][0].ToString(), dtSites.Rows[i][1].ToString(), dtSites.Rows[i][2].ToString(), dtSites.Rows[i][3].ToString(), dtSites.Rows[i][4].ToString(), dtSites.Rows[i][5].ToString(), dtSites.Rows[i][6].ToString());
            SdgvSites.ClearSelection();

            temp = SdtTemp.Value.ToString("yyyy-MM") + "-01 0:00:00";
        }

        private void LoadNew()
        {
            DB.FillCombobox("nombre", "Proyecto", NcboProject);
        }

        private void NClearText()
        {
            NtxtName.Text = null;
            NcboState.Text = null;
            NcboProject.Text = null;
            NtxtAbb.Text = null;
            NtxtRiverS.Text = null;
            NtxtNorthCoor.Text = null;
            NtxtWestCoor.Text = null;
            NtxtAltitude.Text = null;
        }

        private void LoadEdit()
        {
            if (!EpnlEdit.Enabled)
            {
                EClearText();

                EcboSrchProject.SelectedIndex = -1;
                EcboSrchSite.SelectedIndex = -1;

                if (EcboSrchProject.Items.Count != DB.Select("SELECT ID FROM Proyecto").Rows.Count)
                {
                    DB.FillCombobox("nombre", "Proyecto", EcboSrchProject);
                    DB.FillCombobox("nombre", "Proyecto", EcboProject);
                }
                if (EcboSrchSite.Items.Count != DB.Select("SELECT ID FROM Sitio").Rows.Count)
                    DB.FillCombobox("nombre", "Sitio", EcboSrchSite);

                EpnlEdit.Enabled = false;
            }
        }

        private void EClearText()
        {
            EcboSrchSite.Text = null;
            EtxtName.Text = null;
            EcboState.Text = null;
            EcboProject.Text = null;
            EtxtAbb.Text = null;
            EtxtRiver.Text = null;
            EtxtNorthCoor.Text = null;
            EtxtWestCoor.Text = null;
            EtxtAltitude.Text = null;
        }

        //Events

            //Sites

        private void StxtResp_Leave(object sender, EventArgs e)
        {
            CreateTemp();
        }

        private void ScboState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ScboState.SelectedIndex != -1)
            {
                SdgvSites.Rows.Clear();

                DataTable dtState = DB.Select("SELECT s.nombre, p.nombre, Abreviatura, RioCuenca, Norte, Oeste, Altitud FROM Sitio s, Proyecto p WHERE p.ID = s.IdProyecto AND Estado = '" + ScboState.SelectedItem.ToString() + "' ORDER BY s.ID DESC");
                for (int i = 0; i < dtState.Rows.Count; i++)
                    SdgvSites.Rows.Add(false, dtState.Rows[i][0], dtState.Rows[i][1], dtState.Rows[i][2], dtState.Rows[i][3], dtState.Rows[i][4], dtState.Rows[i][5], dtState.Rows[i][6]);
                SdgvSites.ClearSelection();

                ScboProject.SelectedIndex = -1;
            }
        }

        private void ScboProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ScboProject.SelectedIndex != -1)
            {
                SdgvSites.Rows.Clear();

                DataTable dtProject = DB.Select("SELECT s.nombre, p.nombre, Abreviatura, RioCuenca, Norte, Oeste, Altitud FROM Sitio s, Proyecto p WHERE p.ID = s.IdProyecto AND s.IdProyecto = " + DB.GetID("Proyecto", ScboProject.SelectedItem) + " ORDER BY s.ID DESC");
                for (int i = 0; i < dtProject.Rows.Count; i++)
                    SdgvSites.Rows.Add(false, dtProject.Rows[i][0], dtProject.Rows[i][1], dtProject.Rows[i][2], dtProject.Rows[i][3], dtProject.Rows[i][4], dtProject.Rows[i][5], dtProject.Rows[i][6]);
                SdgvSites.ClearSelection();

                ScboState.SelectedIndex = -1;
            }
        }

        private void SdgvSites_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool cntn = true;

            if (Main.stsChanged > 0)
            {
                if (edt)
                {
                    DialogResult conf = MessageBox.Show("Si selecciona otros sitios, se limpiaran los datos de las pantallas de Parametros y Macroinvertebrados, podiendose perder información que estaba a punto de ingresar\n\n¿Desea continuar?", "Notificación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (conf == DialogResult.No)
                    {
                        cntn = false;
                        edt = true;
                    }
                    else if (conf == DialogResult.Yes)
                        edt = false;
                }
            }

            if (cntn)
            {
                string currentSt = SdgvSites.CurrentRow.Cells[1].Value.ToString();

                if (SdgvSites.CurrentCell.ColumnIndex.Equals(0) && e.RowIndex != -1)
                {
                    if (SdgvSites.CurrentCell.Value.ToString() == "False") //true
                    {
                        SdgvSites.CurrentCell.Value = true;

                        sites.Add(currentSt);
                        DataTable xResp = DB.Select("SELECT Responsable FROM Temporada WHERE IdSitio = " + DB.GetID("Sitio", currentSt) + " AND Temporada = '" + temp + "'");
                        if (xResp.Rows.Count > 0)
                        {
                            MessageBox.Show("El sitio elegido ya tiene una temporada registrada en " + temp + ", por lo que todos los datos que se ingresen estarán bajo el responasble " + xResp.Rows[0][0].ToString(), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            StxtResp.Text = xResp.Rows[0][0].ToString();
                        }
                    }
                    else //False
                    {
                        SdgvSites.CurrentCell.Value = false;

                        sites.Remove(currentSt);
                    }

                    Main.btnParamEnabled(false);
                    //Checking if there's > 0 to enable btnParam
                    CreateTemp();
                }
            }

            SdgvSites.ClearSelection();
        }

        private void SdtTemp_ValueChanged(object sender, EventArgs e)
        {
            StxtResp.Text = "";
            for (int i = 0; i < SdgvSites.Rows.Count; i++)
                SdgvSites.Rows[i].Cells[0].Value = false;
            sites.Clear();
            CreateTemp();

            temp = SdtTemp.Value.ToString("yyyy-MM") + "-01 0:00:00";
        }

        private void StxtResp_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SdgvSites.Focus();
            }
        }

        //New

        private void NbtnSave_Click(object sender, EventArgs e)
        {
            if (NtxtName.Text != "" && NcboProject.SelectedIndex != -1 && NcboState.SelectedIndex != -1 && NtxtAbb.Text != "" && NtxtRiverS.Text != "" && NtxtNorthCoor.Text != "" && NtxtWestCoor.Text != "" && NtxtAltitude.Text != "")
            {
                if (DB.Select("SELECT ID FROM Sitio WHERE nombre = '" + NtxtName.Text + "'").Rows.Count == 0)
                {
                    DB.Insert("INSERT INTO Sitio (Nombre, Estado, IdProyecto, Abreviatura, RioCuenca, Norte, Oeste, Altitud)"
                        + "VALUES('" + NtxtName.Text + "', '" + NcboState.SelectedItem.ToString() + "', " + DB.GetID("Proyecto", NcboProject.SelectedItem) + ", '" + NtxtAbb.Text + "', '" + NtxtRiverS.Text + "', " + NtxtNorthCoor.Text + ", " + NtxtWestCoor.Text + ", " + NtxtAltitude.Text + ")");
                    MessageBox.Show("Proyecto ingresado correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NClearText();
                }
                else
                {
                    MessageBox.Show("El nombre del sitio ya existe\nVuelva a intentarlo con un diferente nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Ingrese todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (NcboState.SelectedItem == null)
                    NcboState.Text = null;
                if (NcboProject.SelectedItem == null)
                    NcboProject.Text = null;
            }
        }

            //Edit

        private void EbtnSave_Click(object sender, EventArgs e)
        {
            if (EtxtName.Text != "" && EtxtAbb.Text != "" && EtxtAltitude.Text != "" && EtxtNorthCoor.Text != "" && EtxtRiver.Text != "" && EtxtWestCoor.Text != "" && EcboProject.SelectedIndex != -1 && EcboState.SelectedIndex != -1)
                if (DB.Select("SELECT ID From Sitio WHERE Nombre = '" + EtxtName.Text + "'").Rows.Count.Equals(0) || EtxtName.Text.Equals(EcboSrchSite.SelectedItem))
                {
                    float north;
                    float west;
                    float altitude;

                    if (float.TryParse(EtxtNorthCoor.Text, out north) && float.TryParse(EtxtWestCoor.Text, out west) && float.TryParse(EtxtAltitude.Text, out altitude))
                    {
                        string queryUpdate = "UPDATE Sitio SET IdProyecto = " + DB.GetID("Proyecto", EcboProject.SelectedItem) + ", "
                            + "Nombre = '" + EtxtName.Text + "', Estado = '" + EcboState.SelectedItem.ToString() + "', "
                            + "Abreviatura = '" + EtxtAbb.Text + "', RioCuenca = '" + EtxtRiver.Text + "', Norte = " + north + ", "
                            + "Oeste = " + west + ", Altitud = " + altitude + " WHERE ID = " + DB.GetID("Sitio", EcboSrchSite.SelectedItem);

                        DB.Insert(queryUpdate);
                        MessageBox.Show("Datos modificados correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EpnlEdit.Enabled = false;
                        EcboSrchSite.Items.Clear();
                        LoadEdit();
                    }
                    else
                        MessageBox.Show("Algunos de los datos que necesitan ir en formato de numero, no han sido ingresados correctamente\n(Norte, Oeste, Altitud)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                    MessageBox.Show("El nombre del sitio ya existe\nVuelva a intentarlo con un diferente nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                MessageBox.Show("Hay datos faltantes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void EbtnEliminate_Click(object sender, EventArgs e)
        {
            if (DB.Select("SELECT ID FROM Temporada WHERE IdSitio = " + DB.GetID("Sitio", EcboSrchSite.SelectedItem)).Rows.Count == 0)
            {
                DB.Insert("DELETE FROM Sitio WHERE ID = " + DB.GetID("Sitio", EcboSrchSite.SelectedItem));
                MessageBox.Show("Sitio eliminado correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EpnlEdit.Enabled = false;
                LoadEdit();
            }
            else
            {
                DialogResult conf = MessageBox.Show("El sitio ya cuenta con una temporada registrada\nPara poder eliminarlo deberá ingresar la contraseña\n(NOTA: Si ya se han ingresado parametros en el, se eliminara todo lo ingresado en él)", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (conf == DialogResult.OK)
                    using (frmPassword frm = new frmPassword())
                        if (frm.ShowDialog() == DialogResult.OK)
                            if (frm.password == DB.getData("password", "Usuario", "WHERE usuario = 'admin'"))
                            {
                                string idSte = DB.GetID("Sitio", EcboSrchSite.SelectedItem);

                                DB.Insert("DELETE P.* FROM Parametros AS P INNER JOIN Temporada AS T ON P.IdTemporada = T.ID WHERE T.IdSitio = " + idSte);
                                DB.Insert("DELETE Pc.* FROM ParametrosCrudo AS Pc INNER JOIN Temporada AS T ON Pc.IdTemporada = T.ID WHERE T.IdSitio = " + idSte);
                                DB.Insert("DELETE Pps.* FROM ParametrosPSitios AS Pps INNER JOIN Temporada AS T ON Pps.IdTemporada = T.ID WHERE T.IdSitio = " + idSte);
                                DB.Insert("DELETE F.* FROM FamiliasSitios AS F INNER JOIN Temporada AS T ON F.IdTemporada = T.ID WHERE T.IdSitio = " + idSte);
                                DB.Insert("DELETE G.* FROM GenerosSitios AS G INNER JOIN Temporada AS T ON G.IdTemporada = T.ID WHERE T.IdSitio = " + idSte);

                                DB.Insert("DELETE FROM Temporada WHERE IdSitio = " + idSte);
                                DB.Insert("DELETE FROM Sitio WHERE ID = " + idSte);

                                EpnlEdit.Enabled = false;
                                LoadEdit();
                            }
            }
        }

        private void EcboSrchSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EcboSrchSite.SelectedIndex != -1)
            {
                DataTable dtSelect = DB.Select("SELECT Nombre, Estado, IdProyecto, Abreviatura, RioCuenca, Norte, Oeste, Altitud FROM Sitio WHERE ID = " + DB.GetID("Sitio", EcboSrchSite.SelectedItem));

                EpnlEdit.Enabled = true;

                EtxtName.Text = dtSelect.Rows[0][0].ToString();
                EcboState.SelectedItem = dtSelect.Rows[0][1].ToString();
                EcboProject.SelectedItem = DB.Select("SELECT Nombre FROM Proyecto WHERE ID = " + dtSelect.Rows[0][2].ToString()).Rows[0][0];
                EtxtAbb.Text = dtSelect.Rows[0][3].ToString();
                EtxtRiver.Text = dtSelect.Rows[0][4].ToString();
                EtxtNorthCoor.Text = dtSelect.Rows[0][5].ToString();
                EtxtWestCoor.Text = dtSelect.Rows[0][6].ToString();
                EtxtAltitude.Text = dtSelect.Rows[0][7].ToString();
            }
        }

        private void EcboSrchProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EcboSrchProject.SelectedIndex != -1)
            {
                DataTable dtSite = DB.Select("SELECT s.nombre, p.nombre, Abreviatura, RioCuenca, Norte, Oeste, Altitud FROM Sitio s, Proyecto p WHERE p.ID = s.IdProyecto AND s.IdProyecto = " + DB.GetID("Proyecto", EcboSrchProject.SelectedItem) + " ORDER BY s.ID DESC");

                EcboSrchSite.Items.Clear();
                for (int i = 0; i < dtSite.Rows.Count; i++)
                    EcboSrchSite.Items.AddRange(new object[] { dtSite.Rows[i][0] });
            }
        }
        
            //Common

        private void tabSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabSite.SelectedIndex)
            {
                case 0: LoadSites(); break;
                case 1: LoadNew(); break;
                case 2: LoadEdit(); break;
            }
        }
        
        private void Combobox_TextChanged(object sender, EventArgs e)
        {
            if (tabSite.SelectedIndex == 0)
            {
                if (ScboState.Text == "" && ScboProject.Text == "")
                    LoadSites();
            }
            else if (tabSite.SelectedIndex == 1)
            {
                // Perform actions to prevent not selected items
            }
            else if (tabSite.SelectedIndex == 2)
            {
                if (EcboSrchProject.Text == "")
                {
                    EcboSrchSite.Text = "";
                    EpnlEdit.Enabled = false;
                    LoadEdit();
                }
                else if (EcboSrchSite.Text == "" && EcboSrchProject.Text != "")
                {
                    EClearText();
                    EpnlEdit.Enabled = false;
                }
            }
        }

        private void Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-')) || ((e.KeyChar == '.') && (txt.Text.IndexOf('.') > -1))
                || ((e.KeyChar == '-') && (txt.Text.IndexOf('-') > -1)) || ((e.KeyChar == '-') && (txt.SelectionStart == -1)) || ((e.KeyChar == '.') && (txt.SelectionStart == 0)))
                e.Handled = true;
        }

        //
    }
}
