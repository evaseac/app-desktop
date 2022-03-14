using System;
using System.Data;
using System.Windows.Forms;
using Evaseac.Properties;

namespace Evaseac
{
    public partial class Projects : UserControl
    {
        private Sites ucpSites;

        public Projects()
        {
            InitializeComponent();
        }

        //Methods

        public void LoadProjects()
        {
            EtxtModifyName.Text = null;
            EcboProject.SelectedIndex = -1;

            //Loading DataGridView
            PdgvData.Rows.Clear();
            foreach (DataGridViewColumn col in PdgvData.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            //string query = "SELECT a.* FROM ( "
            //    + "SELECT P.Nombre, S.Nombre AS Site FROM Proyecto AS P INNER JOIN Sitio S ON S.IdProyecto = P.ID"
            //    + " UNION ALL "
            //    + "SELECT P.Nombre, NULL AS Site FROM Proyecto AS P LEFT JOIN Sitio S ON S.IdProyecto = P.ID"
            //    + ") AS a";
            string query = "SELECT P.Nombre, S.Nombre AS Site FROM Proyecto AS P LEFT JOIN Sitio AS S ON S.IdProyecto = P.ID ORDER BY P.ID DESC";
            DataTable dtQuery = DB.Select(query);
            if (dtQuery.Rows.Count != 0)
                for (int i = 0; i < dtQuery.Rows.Count; i++)
                    PdgvData.Rows.Add(dtQuery.Rows[i][0].ToString(), dtQuery.Rows[i][1].ToString());

            PdgvData.ClearSelection();
        }

        private void LoadEdit()
        {
            EcboProject.Text = EtxtModifyName.Text = EtxtFinancing.Text = "";
            EcboProject.Items.Clear();

            DataTable dtCbo = DB.Select("SELECT nombre FROM Proyecto");
            for (int i = 0; i < dtCbo.Rows.Count; i++)
                EcboProject.Items.AddRange(new object[] { dtCbo.Rows[i][0] });

            EcboProject.Focus();
        }

        public void setUcpSites(Sites ucp)
        {
            ucpSites = ucp;
        }

        //Events

            //Proyectos

        private void PbtnAdd_Click(object sender, EventArgs e)
        {
            if (PtxtAdd.Text != "" && PtxtFinancing.Text != "")
                if(DB.Select("SELECT ID FROM Proyecto WHERE nombre = '" + PtxtAdd.Text + "'").Rows.Count == 0)
                {
                    DB.Insert("INSERT INTO Proyecto (Nombre, Financiamiento) VALUES('" + PtxtAdd.Text + "', '" + PtxtFinancing.Text + "')");
                    MessageBox.Show("Proyecto ingresado correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PtxtAdd.Text = PtxtFinancing.Text = null;
                    LoadProjects();
                }
                else
                    MessageBox.Show("El nombre del proyecto ya existe\nVuelva a intentarlo con un diferente nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

            //Eliminar

        private void EbtnEliminar_Click(object sender, EventArgs e)
        {
            if (EcboProject.SelectedIndex != -1)
                if (DB.Select("SELECT ID FROM Sitio WHERE IdProyecto = " + DB.GetID("Proyecto", EcboProject.SelectedItem)).Rows.Count == 0)
                {
                    DB.Insert("DELETE FROM Proyecto WHERE ID = " + DB.GetID("Proyecto", EcboProject.SelectedItem));
                    MessageBox.Show("Proyecto eliminado correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEdit();
                }
                else
                {
                    DialogResult conf = MessageBox.Show("El proyecto no puede ser eliminado por tener sitios asociados a él\nPara poder eliminarlo deberá ingresar la contraseña\n(NOTA: Si borra el proyecto, se borrarán todos los datos ingresados en sus sitios)", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (conf == DialogResult.OK)
                        using (frmPassword frm = new frmPassword())
                            if (frm.ShowDialog() == DialogResult.OK)
                                if (frm.password == DB.getData("password", "Usuario", "WHERE usuario = 'admin'"))
                                {
                                    string idPrjct = DB.GetID("Proyecto", EcboProject.SelectedItem);

                                    DB.Insert("DELETE P.* FROM (Parametros AS P INNER JOIN Temporada AS T ON P.IdTemporada = T.ID) INNER JOIN Sitio AS S ON T.IdSitio = S.ID WHERE S.IdProyecto = " + idPrjct);
                                    DB.Insert("DELETE Pc.* FROM (ParametrosCrudo AS Pc INNER JOIN Temporada AS T ON Pc.IdTemporada = T.ID) INNER JOIN Sitio AS S ON T.IdSitio = S.ID WHERE S.IdProyecto = " + idPrjct);
                                    DB.Insert("DELETE Pps.* FROM (ParametrosPSitios AS Pps INNER JOIN Temporada AS T ON Pps.IdTemporada = T.ID) INNER JOIN Sitio AS S ON T.IdSitio = S.ID WHERE S.IdProyecto = " + idPrjct);
                                    DB.Insert("DELETE F.* FROM (FamiliasSitios AS F INNER JOIN Temporada AS T ON F.IdTemporada = T.ID) INNER JOIN Sitio AS S ON T.IdSitio = S.ID WHERE S.IdProyecto = " + idPrjct);
                                    DB.Insert("DELETE G.* FROM (GenerosSitios AS G INNER JOIN Temporada AS T ON G.IdTemporada = T.ID) INNER JOIN Sitio AS S ON T.IdSitio = S.ID WHERE S.IdProyecto = " + idPrjct);
                                    DB.Insert("DELETE T.* FROM Temporada AS T INNER JOIN Sitio AS S ON T.IdSitio = S.ID WHERE S.IdProyecto = " + idPrjct);

                                    DB.Insert("DELETE FROM Sitio WHERE IdProyecto = " + idPrjct);
                                    DB.Insert("DELETE FROM Proyecto WHERE ID = " + idPrjct);

                                    ucpSites.LoadSites();
                                    LoadEdit();
                                }
                }
        }

        private void EbtnGuardar_Click(object sender, EventArgs e)
        {
            if (EcboProject.SelectedIndex != -1 && EtxtModifyName.Text != "" && EtxtFinancing.Text != "")
                if (DB.Select("SELECT ID FROM Proyecto WHERE nombre = '" + EtxtModifyName.Text + "'").Rows.Count == 0 || (EcboProject.SelectedItem.ToString() == EtxtModifyName.Text))
                {
                    DB.Insert("UPDATE Proyecto SET nombre = '" + EtxtModifyName.Text + "', Financiamiento = '" + EtxtFinancing.Text + "' WHERE ID = " + DB.GetID("Proyecto", EcboProject.SelectedItem));
                    MessageBox.Show("Proyecto modificado correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEdit();
                }
                else
                    MessageBox.Show("El nombre del proyecto ya existe\nVuelva a intentarlo con un diferente nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void EcboProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EcboProject.SelectedIndex != -1)
            {
                EtxtModifyName.Text = EcboProject.SelectedItem.ToString();
                EtxtFinancing.Text = DB.Select("SELECT Financiamiento FROM Proyecto WHERE ID = " + DB.GetID("Proyecto", EcboProject.SelectedItem)).Rows[0][0].ToString();
            }
        }

        //Common

        private void tabProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabProject.SelectedIndex)
            {
                case 0: LoadProjects(); break;
                case 1: LoadEdit(); break;
            }
        }

        //
    }
}
