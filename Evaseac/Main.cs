using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Debug = System.Diagnostics.Debug;

namespace Evaseac
{
    public partial class frmMain : Form
    {
        private bool btnParamClicked, btnMacroClicked, btnTstsClicked;
        public int stsChanged = 0;

        public frmMain()
        {
            new DB();

            InitializeComponent();          

            ucpSites.setMain(this);
        }

        #region Methods

        private void UcpBringToFront(UserControl ucp)
        {
            ucpProjects.Enabled = false;
            ucpProjects.Visible = false;
            ucpSites.Enabled = false;
            ucpSites.Visible = false;
            ucpParameters.Enabled = false;
            ucpParameters.Visible = false;
            ucpWorkgroups.Enabled = false;
            ucpWorkgroups.Visible = false;

            ucp.Enabled = true;
            ucp.Visible = true;
            ucp.BringToFront();
        }

        public void btnParamEnabled(bool state)
        {
            btnParam.Enabled = state;
        }

        #endregion

        #region Export

        /// <summary>
        /// Verifies if there are suitable conditions to export some selected data to a excel file with the help of <see cref="frmExport"/> where user can select which data to export and the name of the file, among other features.
        /// </summary>
        private void excelExport()
        {
            bool exist = false;
            for (int i = 0; i < ucpSites.idTemps.Count; i++)
                if (DB.Select("SELECT OD FROM Parametros WHERE IdTemporada = " + ucpSites.idTemps[i]).Rows.Count != 0
                   || DB.Select("SELECT Valor FROM ParametrosPSitios WHERE IdTemporada = " + ucpSites.idTemps[i]).Rows.Count != 0
                   || DB.Select("SELECT Numero FROM FamiliasSitios WHERE IdTemporada = " + ucpSites.idTemps[i]).Rows.Count != 0
                   || DB.Select("SELECT Numero FROM GenerosSitios WHERE IdTemporada = " + ucpSites.idTemps[i]).Rows.Count != 0)
                {
                    exist = true;
                    break;
                }

            if (ucpSites.idTemps.Count == 0)
                MessageBox.Show("Elija primero los sitios en el apartado de 'Sitios'", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (!exist && ucpSites.idTemps.Count == 1)
                MessageBox.Show("El sitio elegido no tiene parametros, macroinvertebrados ni pruebas ingresadas\nIngrese los datos en los apartados: 'Parametros' o 'Macroinvertebrados' u 'Otras pruebas', para poder exportar", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (!exist && ucpSites.idTemps.Count > 1)
                MessageBox.Show("Los sitios elegidos no tienen parametros, macroinvertebrados ni pruebas ingresadas\nIngrese los datos en los apartados: 'Parametros' o 'Macroinvertebrados' u 'Otras pruebas', para poder exportar", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (exist)
                using (frmExport frm = new frmExport())
                {
                    frm.idTemps = ucpSites.idTemps;
                    if (frm.ShowDialog() == DialogResult.OK)
                        MessageBox.Show("Operacion relizada correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        /// <summary>
        /// It will save in the desktop folder 1 csv file with all the information in the 19 tables the Data Base has.
        /// Each table will be separeted as the following: -[tableName]-
        /// This will help updating the remote info with local changes which users do.
        /// </summary>
        private void csvExport()
        {
            // this should be ordered from child to parent
            string[] tableNames = {"publicacionmiembros", "parametroscrudo", "parametros", "imagenes", "parametrospsitios", "parametrosp", "prueba", "generossitios", "genero", "familiassitios", "familia",
                "orden", "clase", "temporada", "sitio", "proyecto", "publicacion", "miembro", "area", "usuario" };

            // Joining data into CSV string
            StringBuilder sb = new StringBuilder();

            foreach (string tableName in tableNames)
            {
                DataTable dt = DB.Select("SELECT * FROM " + tableName);
                IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName);

                // table names will have the following format -area-
                sb.AppendLine("-" + tableName + "-");
                // table info will have the csv common format
                sb.AppendLine(string.Join(",", columnNames));
                foreach (DataRow row in dt.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => DB.GetSqlValue(field.ToString()));
                    sb.AppendLine(string.Join(",", fields));
                }
            }

            // Creating file in desktop folder
            try
            {
                string strPath = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
                string fileName = DateTime.Today.ToString("yyyy-MM-dd") + "-evdb.csv";
                string filePath = strPath + "\\" + fileName;
                FileStream fs = new FileStream(strPath + "\\" + fileName, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Close();
                MessageBox.Show("Archivo .csv creado correctamente en el escritorio de este ordenador." +
                    "\n\nLocación del archivo: " + filePath, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show("Archivo CSV no fue podido crear\n\nException:\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Other functions

        private bool AcceptClickPassword(object winform)
        {
            var form = winform as Boxes.Generic;
            var confirmationBox = new Boxes.Generic("Confirme la contraseña", accept: "Aceptar", cancel: "Cancelar", isPassword: true);

            bool passwordMatch = false;
            while (!passwordMatch)
            {
                if (confirmationBox.ShowDialog() != DialogResult.OK)
                    return false;

                passwordMatch = form.TextBoxString.Equals(confirmationBox.TextBoxString);
                if (!passwordMatch)
                {
                    MessageBox.Show("Las contraseñas no coinciden vuelva a intenarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    confirmationBox.TextBoxString = "";
                }
            }

            return true;
        }

        private bool InsertAdminPassword(object winform)
        {
            var form = winform as Boxes.Generic;

            if (DB.Insert("INSERT INTO Usuario (usuario, password) VALUE ('admin', '" + form.TextBoxString + "')"))
            {
                MessageBox.Show("Contraseña establecida correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            return false;
        }

        #endregion

        #region Events

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (DB.Select("SELECT ID FROM Clase").Rows.Count == 0 && DB.Select("SELECT ID FROM Orden").Rows.Count == 0)
            {
                DialogResult conf = MessageBox.Show("No se han encontrado taxones en la base de datos\n¿Desea agregar los taxones por defecto?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (conf == DialogResult.Yes)
                    DB.InsertDefaultTaxons();
            }

            ucpSites.idTemps = new List<string>();
            btnSites.PerformClick();

            ucpProjects.setUcpSites(ucpSites);
        }
        
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            btnProjects.BackColor = Color.Transparent;
            btnSites.BackColor = Color.Transparent;
            btnParam.BackColor = Color.Transparent;
            btnMacro.BackColor = Color.Transparent;
            btnTests.BackColor = Color.Transparent;
            btnWorkgroup.BackColor = Color.Transparent;

            btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(128)))), ((int)(((byte)(203)))));
            btn.ForeColor = Color.White;

            stsChanged = ucpSites.idTemps.Count;

            if (btn == btnProjects)
            {
                UcpBringToFront(ucpProjects);
                ucpProjects.LoadProjects();
            }
            else if (btn == btnSites)
            {
                UcpBringToFront(ucpSites);

                if (ucpSites.idTemps.Count == 0)
                    ucpSites.LoadSites();
                else
                    ucpSites.edt = true;
            }
            else if (btn == btnParam)
            {
                UcpBringToFront(ucpParameters);

                if (!btnParamClicked)
                {
                    ucpParameters.LoadField();
                    btnParamClicked = true;
                }
            }
            else if (btn == btnMacro)
            {
                if (ucpMacroinvertebrados.idTemps.Count == 0)
                    ucpMacroinvertebrados.setTabPageIndex(1);
                else
                    ucpMacroinvertebrados.setTabPageIndex(0);

                UcpBringToFront(ucpMacroinvertebrados);

                if (!btnMacroClicked)
                {
                    ucpMacroinvertebrados.LoadThis();
                    btnMacroClicked = true;
                }
            }
            else if (btn == btnTests)
            {
                if (ucpTests.idTemps.Count == 0)
                    ucpTests.setTabIndex(1);
                else
                    ucpTests.setTabIndex(0);

                UcpBringToFront(ucpTests);

                if (!btnTstsClicked)
                {
                    ucpTests.LoadThis();
                    btnTstsClicked = true;
                }
            }
            else if (btn == btnWorkgroup)
            {
                UcpBringToFront(ucpWorkgroups);
                ucpWorkgroups.tabWorkgroup_SelectedIndexChanged(null, null);
            }
        }

        private void btnParam_EnabledChanged(object sender, EventArgs e) //Determintes if sites have changed 
        {
            if (btnParam.Enabled)
            {
                ucpTests.idTemps = ucpMacroinvertebrados.idTemps = ucpParameters.idTemps = ucpSites.idTemps;
                btnParamClicked = btnMacroClicked = btnTstsClicked = false;
            }
            else
            {
                ucpParameters.idTemps.Clear();
                ucpMacroinvertebrados.idTemps.Clear();
                ucpTests.idTemps.Clear();
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            if (DB.Select("SELECT * FROM Usuario WHERE usuario = 'admin'").Rows.Count == 0)
            {
                string message = "No se encuentra ningun perfil de administrador en la base de datos. Es necesario establecer una contraseña para este "
                    + "perfil de usuario, el cual es de vital importancia para esta aplicación así como para la página web";
                new Boxes.Generic(message: message, title: "Aviso", accept: "Aceptar", cancel: "Cancelar", isPassword: true, validationFunction: AcceptClickPassword, actionFunction: InsertAdminPassword).ShowDialog();

                return;
            }

            if (DB.getData("password", "Usuario", "WHERE usuario = 'admin'") != "")
            {
                using (frmPassword frm = new frmPassword())
                {
                    frm.ShowDialog();
                    if (frm.password == DB.getData("password", "Usuario", "WHERE usuario = 'admin'"))
                        new frmConfig().Show();
                }
            }
            else
                new frmConfig().Show();
        }
        
        private void btnExport_Click(object sender, EventArgs e)
        {
            Boxes.ChooseExport frm = new Boxes.ChooseExport();

            var result = frm.ShowDialog();

            if (result == DialogResult.OK)
                excelExport();
            else if (result == DialogResult.Yes)
                csvExport();
        }

        private void btnHover_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(128)))), ((int)(((byte)(203))))))
                btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(133)))), ((int)(((byte)(255)))));
        }

        private void btnHover_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = Color.White;
        }

        #endregion
    }
}
