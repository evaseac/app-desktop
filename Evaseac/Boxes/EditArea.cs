using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaseac.Boxes
{
    public partial class EditArea : Form
    {
        private bool isValid;

        public EditArea()
        {
            InitializeComponent();
            isValid = false;
            DB.FillCombobox("Nombre", "Area", "Nombre", cboArea);
            this.ActiveControl = cboArea;
        }

        private void ReloadControls()
        {
            cboArea.SelectedIndex = -1;
            txtNewAreaName.Text = cboArea.Text = null;
            DB.FillCombobox("Nombre", "Area", "Nombre", cboArea);
            this.ActiveControl = cboArea;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isValid)
                return;

            if (cboArea.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un area", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboArea.Focus();
                return;
            }
            if (txtNewAreaName.Equals(""))
            {
                MessageBox.Show("Ingrese el nuevo nombre para el area", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewAreaName.Focus();
                return;
            }
            if (DB.AlreadyExists("Nombre", "Area", txtNewAreaName.Text))
            {
                MessageBox.Show("El area '" + txtNewAreaName.Text + "' ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirm = MessageBox.Show("¿Desea cambiar el nombre de '" + cboArea.SelectedItem.ToString() + "' a '" + txtNewAreaName.Text + "'?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (confirm == DialogResult.OK)
            {
                DB.Insert("UPDATE Area SET Nombre = '" + txtNewAreaName.Text + "' WHERE ID = " + DB.GetID("Area", cboArea.SelectedItem));

                if (MessageBox.Show("¿Desea seguir editando más elementos?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
                    isValid = true;
                    btnSave.PerformClick();
                }
                else
                    ReloadControls();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (isValid)
                return;

            if (cboArea.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un area", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboArea.Focus();
                return;
            }
            DataTable dtMembers = DB.Select("SELECT Etiqueta FROM Miembro WHERE IdArea = " + DB.GetID("Area", cboArea.SelectedItem));
            if (dtMembers.Rows.Count > 0)
            {
                string members = "";
                for (int i = 0; i < dtMembers.Rows.Count; i++)
                {
                    members += dtMembers.Rows[i][0].ToString();
                    if (i != dtMembers.Rows.Count - 1)
                        members += ", ";
                }

                MessageBox.Show("El area a eliminar tiene uno o más miembros asociados a el. Primero cambie el area de dichos miembros y después elimine esta área.\n\nMiembros asociados a '" + cboArea.SelectedItem.ToString() + "': " + members, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboArea.Focus();
                return;
            }
            
            if (MessageBox.Show("¿Desea eliminar el área '" + cboArea.SelectedItem.ToString() + "'?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DB.Insert("DELETE FROM Area WHERE Nombre = '" + cboArea.SelectedItem.ToString() + "'");
                if (MessageBox.Show("¿Desea seguir editando más elementos?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
                    isValid = true;
                    btnSave.PerformClick();
                }
                else
                    ReloadControls();
            }
        }
    }
}
