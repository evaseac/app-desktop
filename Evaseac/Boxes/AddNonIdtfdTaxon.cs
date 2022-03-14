using System;
using System.Data;
using System.Windows.Forms;

namespace Evaseac
{
    public partial class frmAddNonIdtfdTaxon : Form
    {
        private bool nonIdtfdTwc = false;

        public frmAddNonIdtfdTaxon()
        {
            InitializeComponent();
        }

        public string IdTaxon { get; set; }

        public void setTaxon(string taxon)
        {
            cboTaxon.Text = "";
            cboTaxon.Items.Clear();

            if (taxon == "Familia")
            {
                lblTaxon.Text = "Clase";
                this.Text = "Insertar clase del orden no identificado";

                DataTable xClass = DB.Select("SELECT Nombre FROM Clase WHERE Nombre <> 'no identificado' ORDER BY Nombre");
                for (int i = 0; i < xClass.Rows.Count; i++)
                    cboTaxon.Items.AddRange(new object[] { xClass.Rows[i][0] });
            }
            else
            {
                lblTaxon.Text = "Orden";
                this.Text = "Insertar orden de la familia no identificada";

                cboTaxon.Items.AddRange(new object[] { "no identificado" });
                DataTable xOrder = DB.Select("SELECT Nombre FROM Orden WHERE Nombre <> 'no identificado' ORDER BY Nombre");
                for (int i = 0; i < xOrder.Rows.Count; i++)
                    cboTaxon.Items.AddRange(new object[] { xOrder.Rows[i][0] });
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string curTaxon;

            if (lblTaxon.Text == "Clase")
                curTaxon = "Orden";
            else
                curTaxon = "Familia";

            if (btnAdd.DialogResult == System.Windows.Forms.DialogResult.OK) //Inserting if identified
            {
                if (!nonIdtfdTwc)
                    if (DB.Select("SELECT ID FROM " + curTaxon + " WHERE Nombre = 'no identificado' AND Id" + lblTaxon.Text + " = " + DB.GetID(lblTaxon.Text, cboTaxon.SelectedItem)).Rows.Count == 0)
                    {
                        DB.Insert("INSERT INTO " + curTaxon + " (Nombre, Id" + lblTaxon.Text + ") VALUES ('no identificado', " + DB.GetID(lblTaxon.Text, cboTaxon.SelectedItem) + ")");
                        IdTaxon = DB.Select("SELECT TOP 1 ID FROM " + curTaxon + " ORDER BY ID DESC").Rows[0][0].ToString();
                    }
                    else
                        IdTaxon = DB.Select("SELECT ID FROM " + curTaxon + " WHERE Nombre = 'no identificado' AND Id" + lblTaxon.Text + " = " + DB.GetID(lblTaxon.Text, cboTaxon.SelectedItem)).Rows[0][0].ToString();
                else //Unidentified Family and Order
                {
                    string IdOrder;

                    //Getting IdOrder
                    if (DB.Select("SELECT ID FROM Orden WHERE Nombre = 'no identificado' AND IdClase = " + DB.GetID(lblTaxon.Text, cboTaxon.SelectedItem)).Rows.Count == 0)
                    {
                        DB.Insert("INSERT INTO Orden (Nombre, IdClase) VALUES ('no identificado', " + DB.GetID(lblTaxon.Text, cboTaxon.SelectedItem) + ")");
                        IdOrder = DB.Select("SELECT TOP 1 ID FROM Orden ORDER BY ID DESC").Rows[0][0].ToString();
                    }
                    else
                        IdOrder = DB.Select("SELECT ID FROM Orden WHERE Nombre = 'no identificado' AND IdClase = " + DB.GetID(lblTaxon.Text, cboTaxon.SelectedItem)).Rows[0][0].ToString();
                    //Getting Final Id
                    if (DB.Select("SELECT ID FROM Familia WHERE Nombre = 'no identificado' AND IdOrden = " + IdOrder).Rows.Count == 0)
                    {
                        DB.Insert("INSERT INTO Familia (Nombre, IdOrden) VALUES ('no identificado', " + IdOrder + ")");
                        IdTaxon = DB.Select("SELECT TOP 1 ID FROM Familia ORDER BY ID DESC").Rows[0][0].ToString();
                    }
                    else
                        IdTaxon = DB.Select("SELECT ID FROM Familia WHERE Nombre = 'no identificado' AND IdOrden = " + IdOrder).Rows[0][0].ToString();
                }
            }

            if (lblTaxon.Text == "Orden" && cboTaxon.SelectedIndex == 0)
            {
                setTaxon("Familia");
                nonIdtfdTwc = true;
            }
        }

        private void cboTaxon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTaxon.SelectedIndex != -1 && (lblTaxon.Text.Equals("Clase")) || (cboTaxon.SelectedIndex != 0 && lblTaxon.Text.Equals("Orden")))
                this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
