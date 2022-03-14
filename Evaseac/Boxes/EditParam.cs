using System;
using System.Data;
using System.Windows.Forms;

namespace Evaseac
{
    public partial class frmEditParam : Form
    {
        private int idx = 0;
        private DataTable xParams;

        public frmEditParam()
        {
            InitializeComponent();
        }

        public string test { get; set; }

        private void setNxtParam()
        {
            if (idx != xParams.Rows.Count)
            {
                lblParam.Text = "Parámetro (" + (idx + 1).ToString() + "/" + xParams.Rows.Count.ToString() + ")";

                txtParameter.Text = xParams.Rows[idx][0].ToString();
                txtRepetitions.Text = xParams.Rows[idx][1].ToString();

                if (idx < xParams.Rows.Count - 1)
                    btnNext.DialogResult = DialogResult.None;
                else
                    btnNext.DialogResult = DialogResult.OK;
            }
        }

        private void frmEditParam_Load(object sender, EventArgs e)
        {
            if (!test.Equals(null))
            {
                lblTest.Text = test;
                xParams = DB.Select("SELECT Nombre, Repeticiones, ID FROM ParametrosP WHERE IdPrueba = " + DB.GetID("Prueba", test));
                setNxtParam();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (txtParameter.Text != "" && txtRepetitions.Text != "")
            {
                if (DB.Select("SELECT ID FROM ParametrosP WHERE Nombre = '" + txtParameter.Text + "'").Rows.Count == 0 || txtParameter.Text == xParams.Rows[idx][0].ToString())
                {
                    DB.Insert("UPDATE ParametrosP SET Nombre = '" + txtParameter.Text + "', Repeticiones = " + txtRepetitions.Text + " WHERE ID = " + xParams.Rows[idx][2].ToString());

                    idx++;
                    setNxtParam();

                    txtParameter.Focus();
                    txtParameter.Select(0, txtParameter.Text.Length);
                }
                else
                    MessageBox.Show(txtParameter.Text + " ya ha sido ingresado\nIntente de nuevo con uno diferente", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtRepetitions_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
