using Evaseac.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Evaseac
{  
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void EnablePanel(Panel pnl)
        {
            pnlImport.Visible = pnlAdmin.Visible = pnlPreferences.Visible = false;
            pnlImport.Enabled = pnlAdmin.Enabled = pnlPreferences.Enabled = false;

            pnl.Visible = pnl.Enabled = true;
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            txtCurrentPass.Text = DB.getData(column: "password", table: "Usuario", condition: "WHERE usuario = 'admin'");
            btnAdmin.PerformClick();

            //Preferences
            chkAskParams.Checked = Settings.Default.askEdtParams;
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            EnablePanel(pnl: pnlAdmin);
        }

        private void btnPreference_Click(object sender, EventArgs e)
        {
            EnablePanel(pnl: pnlPreferences);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNewPass.Text == txtConfPass.Text)
            {
                DB.Insert("UPDATE Usuario SET password = '" + txtNewPass.Text + "' WHERE usuario = 'admin'");
                Settings.Default.Save();
                MessageBox.Show("Contraseña modificada correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtCurrentPass.Text = DB.getData(column: "password", table: "Usuario", condition: "WHERE usuario = 'admin'");
                txtNewPass.Text = txtConfPass.Text = null;
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewPass.Text = txtConfPass.Text = null;
                txtNewPass.Focus();
            }
        }

        private void chkAskParams_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.askEdtParams = chkAskParams.Checked;
            Settings.Default.Save();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            EnablePanel(pnl: pnlImport);
        }

        private void btnSelectSQLFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Archivos CSV (.csv)|*.csv"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                lblFileSelected.Text = openFileDialog.FileName;
            }
        }

        /// <summary>
        /// Deletes the 
        /// </summary>
        /// <param name="data">The content of the database exported represented in a non-standard CSV format</param>
        /// <param name="queries">A string list that will store the queries to do later</param>
        private void ReIntializeDatabase(string[] data, List<string> queries)
        {
            int sectionNumber = 0; // 0: Table name, 1: Parameters, 2: Data, o.c.: invalid
            string tableName = "", parameters = "";
            for (int i = 0; i < data.Length; i++)
            {
                string currentRow = data[i];
                switch (sectionNumber)
                {
                    // Table name section
                    case 0:
                        tableName = currentRow.Substring(1, currentRow.Length - 2);
                        DB.Insert("DELETE FROM " + tableName);
                        sectionNumber = 1;
                        break;
                    case 1:
                        parameters = "(" + currentRow + ")";
                        sectionNumber = 2;
                        break;
                    case 2:
                        if (!isTableName(currentRow))
                        {
                            queries.Add("INSERT INTO " + tableName + parameters + " VALUE (" + currentRow + ")");
                        }
                        else
                        {
                            sectionNumber = 0;
                            i--;
                        }

                        if (isTableName(data[(i + 1) % data.Length]))
                            sectionNumber = 0;
                        break;
                }
            }
        }

        /// <summary>
        /// Verifies if a string is a table name according to the non-written rules of the CSV format for SQL database representation
        /// </summary>
        /// <param name="value">The string to analyze</param>
        private bool isTableName(string value)
        {
            if (String.IsNullOrEmpty(value))
                return false;
            if (value[0] == '-' && value[value.Length - 1] == '-')
                return true;
            return false;
        }

        private void btnImportDatabase_Click(object sender, EventArgs e)
        {
            string textWarning = "¿Esta seguro de realizar esta acción?\n\nUna vez realizado esto no hay vuelta atrás para recuperar los datos ingresados en la aplicación";
            if (MessageBox.Show(textWarning, "ATENCIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            List<string> queries = new List<string>();
            ReIntializeDatabase(System.IO.File.ReadAllLines(lblFileSelected.Text), queries);
            Messages.Log("--------- QUERIES");
            while (queries.Count != 0)
            {
                string query = queries[queries.Count - 1];
                queries.RemoveAt(queries.Count - 1);
                DB.Insert(query);
            }
            MessageBox.Show("Operación realizada con éxito", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
