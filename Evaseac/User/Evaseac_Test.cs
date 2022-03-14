using Evaseac.Properties;
using System;
using System.Windows.Forms;

namespace Evaseac
{
    public partial class Evaseac_Test : Form
    {
        public Evaseac_Test()
        {
            InitializeComponent();
        }

        private void Evaseac_Test_Load(object sender, EventArgs e)
        {
            new DB();

            //if (Settings.Default.dbRouteSource == "" || !DB.OpenConnection())
            //{
            //    MessageBox.Show("Sin base de datos seleccionada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    do
            //    {
            //        OpenFileDialog fileDB = new OpenFileDialog();
            //        fileDB.Title = "Seleccione una base de datos";
            //        fileDB.Filter = "Archivos acces(*.accdb)|*.accdb| Todos los archivos(*.*)|*.*";

            //        if (fileDB.ShowDialog() == DialogResult.OK)
            //        {
            //            Settings.Default.dbRouteSource = fileDB.FileName.Replace("\\", "/");
            //            Settings.Default.Save();
            //            new DB();
            //        }
            //    } while (!DB.OpenConnection());
            //}
            //DB.CloseConnection();
        }
    }
}
