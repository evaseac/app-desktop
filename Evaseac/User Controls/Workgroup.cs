using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Evaseac.Properties;
using Evaseac.User.Google_Drive;
using Evaseac.Boxes;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Diagnostics;
using Evaseac.Validation;
using System.Net;
using System.Collections.Generic;

namespace Evaseac.User_Controls
{
    public partial class Workgroup : UserControl
    {
        private ToolTip toolTip;
        private const string PanelURLImageCaption = "\nDe un click para abrir la imagen en el navegador Web";
        private HashSet<int> idMembers; // it will work to save the IDs for various authors in a paper. It will be used for both Add Paper and edit Paper

        public Workgroup()
        {
            InitializeComponent();

            this.toolTip = new ToolTip(new System.ComponentModel.Container());
            this.idMembers = new HashSet<int>();
        }

        #region Common methods

        // To get empty strings as 'NULL' and strings as 'string'
        private void FormatTextboxesSQL(TextBox[] txts)
        {
            foreach(TextBox txt in txts)
            {
                if (txt.Text.Equals(""))
                    txt.Text = "NULL";
                else if (!txt.Text.Equals("NULL") && (!txt.Text[0].Equals('\'') && !txt.Text[txt.Text.Length - 1].Equals('\'')))
                    txt.Text = "'" + txt.Text + "'";
            }
        }

        private void LoadAddMembers()
        {
            if (cboEmArea.Items.Count != cboAmArea.Items.Count || cboAmArea.Items.Count == 0)
                FillAmAreaCombo();
            
            txtAmSearch.Text = "";
            FillAmMembersGrid();

            toolTip.SetToolTip(this.txtAmPhoto, "Ingrese aquí el url de Google Photos de la imagen a usar para el miembro");
        }

        private void LoadEditMembers()
        {
            if (cboAmArea.Items.Count != cboEmArea.Items.Count || cboEmArea.Items.Count == 0)
                FillEmAreaCombo();
            if (dgvAmMembers.Rows.Count != cboEmMemberSelect.Items.Count || cboEmMemberSelect.Items.Count == 0)
                FillEmMemberCombo();
        }

        private void LoadAddPapers()
        {
            FillApMembersCombo();
            FillApPapersGrid();
            FillApTitlesCombo();
            toolTip.SetToolTip(this.lnkApDrivePaper, "Muestra el link del enlace para el archivo compartido en Google Drive, si muestra '" + LinkText + "', es porque no se ha escogido o subido ningún archivo de Google Drive");
            toolTip.SetToolTip(this.txtEpCoverLink, "Muestra el link del enlace para la imagen de la portada guardada en Google Photos");
            
            idMembers.Clear();
        }

        private void LoadEditPapers()
        {
            FillEpComboboxes();
            toolTip.SetToolTip(this.txtEpPdfLink, "Muestra el link del enlace para el archivo compartido en Google Drive, si muestra '" + LinkText + "', es porque no se ha escogido o subido ningún archivo de Google Drive");
            toolTip.SetToolTip(this.txtEpCoverLink, "Muestra el link del enlace para la imagen de la portada guardada en Google Photos");

            idMembers.Clear();
        }

        public void tabWorkgroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabWorkgroup.SelectedIndex)
            {
                case 0:
                    LoadAddMembers();
                    break;
                case 1:
                    LoadEditMembers();
                    break;
                case 2:
                    LoadAddPapers();
                    break;
                case 3:
                    LoadEditPapers();
                    return;
            }
        }

        private async void WaitSeconds(double seconds)
        {
            await Task.Delay((int) seconds * 1000);
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void Workgroup_SizeChanged(object sender, EventArgs e)
        {
            if (this.tabWorkgroup.Size.Width >= (this.pnlAmPhoto.Location.X + this.pnlAmPhoto.Size.Width + 20) && !this.pnlAmPhoto.Visible)
                this.pnlAmPhoto.Visible = this.pnlEmPhoto.Visible = true;
            else if (this.pnlAmPhoto.Visible)
                this.pnlAmPhoto.Visible = this.pnlEmPhoto.Visible = false;
        }
        private void ReloadToolTipPanel(Panel panel)
        {
            if (panel.BackgroundImage != null)
                MessageBox.Show("Se mantendra la última imagen que se cargo correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (panel.Equals(pnlApCoverImage))
            {
                if (toolTip.GetToolTip(panel).Contains(PanelImageCaption) || toolTip.GetToolTip(panel).Equals(null))
                    txtApCoverUrl.Text = null;
                else
                    txtApCoverUrl.Text = toolTip.GetToolTip(panel).Replace(PanelURLImageCaption, "");

                btnApImageGenerate.Focus();
            }
            else if (panel.Equals(pnlAmPhoto))
            {
                if (toolTip.GetToolTip(panel).Contains(PanelURLImageCaption))
                    txtAmPhoto.Text = toolTip.GetToolTip(panel).Replace(PanelURLImageCaption, "");
                else
                    txtAmPhoto.Text = null;

                lblAmFoto.Focus();
            }
            else if (panel.Equals(pnlEmPhoto))
            {
                if (toolTip.GetToolTip(panel).Contains(PanelURLImageCaption))
                    txtEmPhoto.Text = toolTip.GetToolTip(panel).Replace(PanelURLImageCaption, "");
                else
                    txtEmPhoto.Text = null;

                lblEmPhoto.Focus();
            }
            else if (panel.Equals(pnlEpPhoto))
            {
                if (toolTip.GetToolTip(panel).Contains(PanelURLImageCaption))
                    txtEpCoverLink.Text = toolTip.GetToolTip(panel).Replace(PanelURLImageCaption, "");
                else
                    txtEpCoverLink.Text = null;

                lblEpCoverLink.Focus();
            }
        }
        private void LoadImageFromURL(Panel panel, string url)
        {
            if (Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
            {
                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    // Gets image from web
                    using (var response = WebRequest.Create(url).GetResponse())
                    using (var stream = response.GetResponseStream())
                        panel.BackgroundImage = Bitmap.FromStream(stream);

                    // sets final steps: toolTip, button focus
                    if (panel.Equals(pnlApCoverImage))
                    {
                        toolTip.SetToolTip(panel, txtApCoverUrl.Text + PanelURLImageCaption);
                        btnApSave.Focus();
                    }
                    else if (panel.Equals(pnlAmPhoto))
                    {
                        toolTip.SetToolTip(panel, txtAmPhoto.Text + PanelURLImageCaption);
                        btnAmSave.Focus();
                    }
                    else if (panel.Equals(pnlEmPhoto))
                    {
                        toolTip.SetToolTip(panel, txtEmPhoto.Text + PanelURLImageCaption);
                        txtEmCurriculum.Focus();
                    }
                    else if (panel.Equals(pnlEpPhoto))
                    {
                        toolTip.SetToolTip(panel, txtEpCoverLink.Text + PanelURLImageCaption);
                        btnEpSave.Focus();
                    }
                }
                catch (WebException we)
                {
                    ControlValidation.ShowErrorMessage("Ocurrió un error al tratar de cargar la imagen desde internet. Posiblemente el url haya sido modificado y no es valido el que se ingreso.\n\nWebException: " + we.Message);
                    ReloadToolTipPanel(panel);
                }
                catch (Exception ex)
                {
                    ControlValidation.ShowErrorMessage("Ocurrió un error al tratar de cargar la imagen desde internet\n\nException: " + ex.Message);
                    ReloadToolTipPanel(panel);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            else
            {
                ControlValidation.ShowErrorMessage("La dirección '" + url + "' no es una dirección valida de internet, verifique nuevamente la dirección que desee ingresar");
                ReloadToolTipPanel(panel);
            }
        }
        private void URLTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (String.IsNullOrEmpty(textBox.Text))
                    {
                        if (textBox.Equals(txtApCoverUrl))
                            pnlApCoverImage.BackgroundImage = null;
                        else if (textBox.Equals(txtAmPhoto))
                            pnlAmPhoto.BackgroundImage = null;
                        else if (textBox.Equals(txtEmPhoto))
                            pnlEmPhoto.BackgroundImage = null;
                        else if (textBox.Equals(txtEpCoverLink))
                            pnlEpPhoto.BackgroundImage = null;

                        return;
                    }

                    if (textBox.Equals(txtApCoverUrl))
                        LoadImageFromURL(pnlApCoverImage, textBox.Text);
                    else if (textBox.Equals(txtAmPhoto))
                        LoadImageFromURL(pnlAmPhoto, textBox.Text);
                    else if (textBox.Equals(txtEmPhoto))
                        LoadImageFromURL(pnlEmPhoto, textBox.Text);
                    else if (textBox.Equals(txtEpCoverLink))
                        LoadImageFromURL(pnlEpPhoto, textBox.Text);
                    break;
            }
        }
        private void URLTextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (String.IsNullOrEmpty(textBox.Text))
            {
                if (textBox.Equals(txtApCoverUrl))
                    pnlApCoverImage.BackgroundImage = null;
                else if (textBox.Equals(txtAmPhoto))
                    pnlAmPhoto.BackgroundImage = null;
                else if (textBox.Equals(txtEmPhoto))
                    pnlEmPhoto.BackgroundImage = null;
                else if (textBox.Equals(txtEpCoverLink))
                    pnlEpPhoto.BackgroundImage = null;

                return;
            }

            if (textBox.Equals(txtApCoverUrl))
                LoadImageFromURL(pnlApCoverImage, textBox.Text);
            else if (textBox.Equals(txtAmPhoto))
                LoadImageFromURL(pnlAmPhoto, textBox.Text);
            else if (textBox.Equals(txtEmPhoto))
                LoadImageFromURL(pnlEmPhoto, textBox.Text);
            else if (textBox.Equals(txtEpCoverLink))
                LoadImageFromURL(pnlEpPhoto, textBox.Text);
        }
        private void ImagePanel_BackgroundImageChanged(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;

            if (panel.BackgroundImage != null)
            {
                panel.Cursor = Cursors.Hand;

                if (panel.Equals(pnlApCoverImage))
                    btnApImageGenerate.Text = ButtonChangeText;
            }
            else
            {
                panel.Cursor = Cursors.Default;
                toolTip.SetToolTip(panel, null);

                if (panel.Equals(pnlApCoverImage))
                    btnApImageGenerate.Text = ButtonGenerateText;
            }
        }
        private void ImagePanel_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;

            if (!String.IsNullOrEmpty(toolTip.GetToolTip(panel)))
                if (panel.Equals(pnlApCoverImage))
                {
                    if (toolTip.GetToolTip(this.pnlApCoverImage).Contains(PanelImageCaption)) // Opens File Explorer
                        Process.Start(Directory.GetParent(toolTip.GetToolTip(this.pnlApCoverImage).Replace(PanelImageCaption, "")).FullName);
                    else if (toolTip.GetToolTip(this.pnlApCoverImage).Contains(PanelURLImageCaption)) // Opens web browser
                        Process.Start(this.txtApCoverUrl.Text);
                }
                else
                    Process.Start(toolTip.GetToolTip(panel).Replace(PanelURLImageCaption, ""));
        }

        #endregion

        #region Other functions

        private bool AcceptClickNewArea(object winform)
        {
            var form = winform as Boxes.Generic;

            if (DB.Select("SELECT * FROM Area WHERE Nombre = '" + form.TextBoxString + "'").Rows.Count > 0)
            {
                MessageBox.Show("El área '" + form.TextBoxString + "' ya existe en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool InsertArea(object winform)
        {
            var form = winform as Boxes.Generic;

            if (DB.Insert("INSERT INTO Area(Nombre) VALUE ('" + form.TextBoxString + "')"))
                return true;

            MessageBox.Show("El area no pudo ser ingresada correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        #endregion

        #region Add members section

        private DataTable dtMembers; // Variable for Add Member DataGridView

        private void FillAmAreaCombo()
        {
            DB.FillCombobox("Nombre", "Area", "Nombre", cboAmArea);
            cboAmArea.Items.AddRange(new object[] { "Nueva area..." });
            cboAmArea.Items.AddRange(new object[] { "Editar area..." });
        }
        private void FillAmMembersGrid()
        {
            if (dtMembers != null)
                dtMembers.Clear();

            dtMembers = DB.Select("SELECT M.Etiqueta AS Miembro, CASE WHEN M.Puesto IS NULL THEN 'Sin puesto asignado' ELSE M.Puesto END AS Puesto, CASE WHEN M.Correo IS NULL THEN 'Sin correo asignado' ELSE M.Correo END AS Correo, CASE WHEN M.IdArea IS NULL THEN 'Sin area asignada' ELSE A.Nombre END AS Area FROM Miembro AS M, Area AS A WHERE M.IdArea = A.ID OR M.IdArea IS NULL GROUP BY Miembro, Puesto, Correo, Area");
            dgvAmMembers.DataSource = dtMembers;

            dgvAmMembers.ClearSelection();
        }
        private void ClearAmText()
        {
            txtAmMember.Text = txtAmMemberName.Text = txtAmSurname.Text = txtAmCurriculum.Text = txtAmPosition.Text = txtAmGrade.Text
                = txtAmEmail.Text = txtAmPhoto.Text = txtAmSearch.Text = txtAmRG.Text = null;
        }
        private void ReloadAmControls()
        {
            ClearAmText();
            cboAmArea.SelectedIndex = -1;
            pnlAmPhoto.BackgroundImage = null;

            FillAmAreaCombo();
            FillAmMembersGrid();

            this.ActiveControl = txtAmMember;
        }

        private void btnAmSave_Click(object sender, EventArgs e)
        {
            if (txtAmMember.Text.Equals(""))
            {
                MessageBox.Show("Es necesario agregar un nombre de miembro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtAmMemberName.Text.Equals("Sin nombre asignado") || txtAmSurname.Text.Equals("Sin apellidos asignados") || txtAmCurriculum.Text.Equals("Sin ficha curricular asignada")
                    || txtAmPosition.Text.Equals("Sin puesto asignado") || txtAmGrade.Text.Equals("Sin grado asignado") || txtAmEmail.Text.Equals("Sin correo asignado") || txtAmPhoto.Text.Equals("Sin foto asignada"))
            {
                MessageBox.Show("Algún nombre es invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DB.AlreadyExists("Etiqueta", "Miembro", txtAmMember.Text))
            {
                MessageBox.Show("El miembro '" + txtAmMember.Text + "' ya se registró", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FormatTextboxesSQL(new TextBox[] { txtAmMember, txtAmMemberName, txtAmSurname, txtAmCurriculum, txtAmPosition, txtAmGrade, txtAmEmail, txtAmPhoto, txtAmRG });

            string idArea;
            if (cboAmArea.SelectedIndex > -1)
                idArea = DB.GetID("Area", cboAmArea.SelectedItem);
            else
                idArea = "NULL";

            string query = "INSERT INTO Miembro (Etiqueta, Nombre, Apellido, FichaCurricular, Puesto, Grado, Foto, Correo, IdArea, ResearchGate)" +
                "VALUE (" + txtAmMember.Text + ", " + txtAmMemberName.Text + ", " + txtAmSurname.Text + ", " + txtAmCurriculum.Text + ", " + txtAmPosition.Text + ", " + txtAmGrade.Text + ", " + txtAmPhoto.Text + ", " + txtAmEmail.Text + ", " + idArea + ", " + txtAmRG.Text + ")";
            DB.Insert(query);
            ReloadAmControls();
            MessageBox.Show("Miembro ingresado correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void cboAmArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAmArea.SelectedIndex == cboAmArea.Items.Count - 2) // New
            {
                new Boxes.Generic(message: "Inserte el nombre de la nueva área", accept: "Aceptar", cancel: "Cancelar", validationFunction: AcceptClickNewArea, actionFunction: InsertArea).ShowDialog();
            }
            else if (cboAmArea.SelectedIndex == cboAmArea.Items.Count - 1) // Edit
            {
                new Boxes.EditArea().ShowDialog();

                FillEmAreaCombo();
                FillAmMembersGrid();
            }

            if (cboAmArea.SelectedIndex >= cboAmArea.Items.Count - 2)
            {
                cboAmArea.SelectedIndex = -1;
                FillAmAreaCombo();
            }
        }
        private void InsertAmTextboxes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAmSave.PerformClick();
        }
        private void txtAmSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dvMembers = dtMembers.DefaultView;
            dvMembers.RowFilter = string.Format("Miembro like '%" + txtAmSearch.Text + "%' or Puesto like '%" + txtAmSearch.Text + "%' or Correo like '%" + txtAmSearch.Text + "%' or Area like '%" + txtAmSearch.Text + "%'");
            dgvAmMembers.DataSource = dvMembers.ToTable();
            dgvAmMembers.ClearSelection();
        }
        private void dgvAmMembers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string member = dgvAmMembers.Rows[dgvAmMembers.CurrentCell.RowIndex].Cells[0].Value.ToString();

            tabWorkgroup.SelectedIndex = 1;
            WaitSeconds(0.8);

            cboEmMemberSelect.Text = member;
            txtEmMember.Focus();
        }

        #endregion
        
        #region Edit members section

        private void FillEmMemberCombo()
        {
            ClearEmText();
            DB.FillCombobox("Etiqueta", "Miembro", "Etiqueta", cboEmMemberSelect);
        }
        private void FillEmAreaCombo()
        {
            DB.FillCombobox("Nombre", "Area", "Nombre", cboEmArea);
            cboEmArea.Items.AddRange(new object[] { "Nueva area..." });
            cboEmArea.Items.AddRange(new object[] { "Editar area..." });
        }
        private void ClearEmText()
        {
            cboEmArea.Text = txtEmMember.Text = txtEmMemberName.Text = txtEmSurname.Text = txtEmPosition.Text = txtEmGrade.Text
                = txtEmEmail.Text = txtEmPhoto.Text = txtEmCurriculum.Text = txtEmRG.Text = null;
            pnlEmPhoto.BackgroundImage = null;
        }
        private void ReloadEmControls()
        {
            cboEmMemberSelect.Text = "";
            cboEmMemberSelect.SelectedIndex = -1;

            ClearEmText();
            FillEmMemberCombo();
        }

        private void cboEmMemberSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEmMemberSelect.SelectedIndex > -1)
            {
                Cursor.Current = Cursors.WaitCursor;

                ClearEmText();

                DataTable dtMember = DB.Select("SELECT * FROM Miembro WHERE Etiqueta = '" + cboEmMemberSelect.SelectedItem.ToString() + "'");

                txtEmMember.Text = dtMember.Rows[0]["Etiqueta"].ToString();
                txtEmMemberName.Text = dtMember.Rows[0]["Nombre"].ToString();
                txtEmSurname.Text = dtMember.Rows[0]["Apellido"].ToString();
                txtEmCurriculum.Text = dtMember.Rows[0]["FichaCurricular"].ToString();
                txtEmPosition.Text = dtMember.Rows[0]["Puesto"].ToString();
                txtEmEmail.Text = dtMember.Rows[0]["Correo"].ToString();
                txtEmGrade.Text = dtMember.Rows[0]["Grado"].ToString();
                txtEmPhoto.Text = dtMember.Rows[0]["Foto"].ToString();
                txtEmRG.Text = dtMember.Rows[0]["ResearchGate"].ToString();

                if (!String.IsNullOrEmpty(txtEmPhoto.Text))
                    LoadImageFromURL(pnlEmPhoto, txtEmPhoto.Text);
                
                string idArea = dtMember.Rows[0]["IdArea"].ToString();
                if (!idArea.Equals(""))
                    cboEmArea.SelectedItem = DB.Select("SELECT Nombre FROM Area WHERE ID = " + idArea).Rows[0][0];
                else
                    cboEmArea.SelectedIndex = -1;

                Cursor.Current = Cursors.Default;

                cboEmMemberSelect.Focus();
            }
        }
        private void btnEmSave_Click(object sender, EventArgs e)
        {
            if (cboEmMemberSelect.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un miembro para luego editar su información", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtEmMember.Text.Equals(""))
            {
                MessageBox.Show("Es necesario agreagar un nombre de miembro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtEmMemberName.Text.Equals("Sin nombre asignado") || txtEmSurname.Text.Equals("Sin apellidos asignados") || txtEmCurriculum.Text.Equals("Sin ficha curricular asignada")
                    || txtEmPosition.Text.Equals("Sin puesto asignado") || txtEmGrade.Text.Equals("Sin grado asignado") || txtEmEmail.Text.Equals("Sin correo asignado") || txtEmPhoto.Text.Equals("Sin foto asignada"))
            {
                MessageBox.Show("Algún nombre es invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FormatTextboxesSQL(new TextBox[] { txtEmMember, txtEmMemberName, txtEmSurname, txtEmPosition, txtEmGrade, txtEmEmail, txtEmPhoto, txtEmCurriculum, txtEmRG });

            string idArea;
            if (cboEmArea.SelectedIndex > -1)
                idArea = DB.GetID("Area", cboEmArea.SelectedItem);
            else
                idArea = "NULL";

            // Updating
            string query = "UPDATE Miembro SET Etiqueta = " + txtEmMember.Text + ", Nombre = " + txtEmMemberName.Text + ", Apellido = " + txtEmSurname.Text + ", FichaCurricular = " + txtEmCurriculum.Text + ", Puesto = " + txtEmPosition.Text + ", Grado = " + txtEmGrade.Text + ", Foto = " + txtEmPhoto.Text + ", Correo = " + txtEmEmail.Text + ", IdArea = " + idArea + ", ResearchGate = " + txtEmRG.Text +
                " WHERE ID = " + DB.GetID("Miembro", "Etiqueta", cboEmMemberSelect.SelectedItem.ToString());

            DB.Insert(query);
            ReloadEmControls();
            MessageBox.Show("Miembro guardado correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnEmDelete_Click(object sender, EventArgs e)
        {
            if (cboEmMemberSelect.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un miembro para luego editar su información", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Confirmación para eliminar información de '" + cboEmMemberSelect.SelectedItem.ToString() + "'", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                return;

            string idMember = DB.GetID("Miembro", "Etiqueta", cboEmMemberSelect.SelectedItem.ToString());

            // TODO: Eliminar publicaciones relacionadas al miembro
            if (DB.Select("SELECT * FROM PublicacionMiembros WHERE IdMiembro = " + idMember).Rows.Count > 0)
                if (MessageBox.Show("El miembro '" + cboEmMemberSelect.SelectedItem.ToString() + "' tiene publicaciones relacionadas a el, al eliminar su información también se eliminarán sus publicaciones de la base de datos", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    return;

            // Deleting
            DB.Insert("DELETE FROM PublicacionMiembros WHERE IdMiembro = " + idMember);
            DB.Insert("DELETE FROM Miembro WHERE ID = " + idMember);
            ReloadEmControls();
            MessageBox.Show("Miembro eliminado correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Add papers section

        private string uploadedFilePath; // Variable for Add Paper File Path

        private const string PanelImageCaption = "\nDe un click para abrir la locacion de la imagen\nDe doble click para ampliar la imagen";
        private const string ButtonGenerateText = "Generar Imagen";
        private const string ButtonChangeText = "Escoger otro";
        private const string LinkText = "Link";

        private void FillApMembersCombo()
        {
            DB.FillCombobox("Etiqueta", "Miembro", "Etiqueta", cboApMember);
            if (cboApMember.Items.Count != 0)
                cboApMember.Items.AddRange(new object[] { "Varios" });

            this.idMembers.Clear();
        }
        private void FillApPapersGrid()
        {
            dgvApPapers.Rows.Clear();
            // retrieving data from DB
            // selects title and number of authors. THIS WILL BE THE SOURCE
            DataTable dtPapers = DB.Select("SELECT PM.IdPublicacion AS ID, P.Titulo, COUNT(*) AS NoMiembros FROM PublicacionMiembros AS PM INNER JOIN Publicacion AS P ON PM.IdPublicacion = P.ID GROUP BY PM.IdPublicacion ORDER BY PM.IdPublicacion DESC");
            // selects name of authors
            dtPapers.Columns.Add("Autor(es)", typeof(String));
            foreach (DataRow row in dtPapers.Rows)
            {
                string idPaper = row[0].ToString();
                // Retrieves names of authors
                DataTable dtMembers = DB.Select("SELECT M.Nombre AS Nombre, M.Apellido AS Apellido FROM PublicacionMiembros AS PM INNER JOIN Miembro AS M ON PM.IdMiembro = M.ID WHERE PM.IdPublicacion = " + idPaper + " ORDER BY PM.IdPublicacion DESC");
                // Concatanating authors names
                string authors = "";
                foreach (DataRow dataRow in dtMembers.Rows)
                    authors += dataRow[0].ToString() + " " + dataRow[1].ToString()[0] + ", ";
                authors = authors.Substring(0, authors.Length - 2);

                row[3] = authors;
                dgvApPapers.Rows.Add(row[1], row[3]);
            }
            dgvApPapers.ClearSelection();
        }
        private void FillApTitlesCombo()
        {
            //DB.FillCombobox("")
        }

        private void ReloadApControls()
        {
            ClearApText();
            cboApMember.SelectedIndex = -1;
            lnkApDrivePaper.Text = LinkText;
            btnApImageGenerate.Text = ButtonGenerateText;
            pnlApCoverImage.BackgroundImage = null;
            toolTip.SetToolTip(this.pnlApCoverImage, null);
            FillApPapersGrid();
        }
        private void ClearApText()
        {
            txtApCoverUrl.Text = txtApTitle.Text = cboApMember.Text = null;
        }
        /// <summary>
        /// Transforms a DataGridView to a Datatable
        /// </summary>
        /// <param name="dgv">The DataGridView to transform</param>
        /// <returns></returns>
        private DataTable GetDataTableFromDGV(DataGridView dgv)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
                if (column.Visible)
                    dt.Columns.Add();

            object[] cellValues = new object[dgv.Columns.Count];
            foreach (DataGridViewRow row in dgv.Rows)
                for (int i = 0; i < row.Cells.Count; i++)
                    cellValues[i] = row.Cells[i].Value;
                dt.Rows.Add(cellValues);

            return dt;
        }
        private void txtApSearch_TextChanged(object sender, EventArgs e)
        {
            // TODO
            //DataView dvPapers = GetDataTableFromDGV(dgvApPapers).DefaultView;
            //PrintDataView(dvPapers);
            //dvPapers.RowFilter = string.Format("Publicacion like '%" + txtApSearch.Text + "%'");
            //dgvApPapers.DataSource = dvPapers.ToTable();
            //dgvApPapers.ClearSelection();
        }

        private void btnApChooseDriveFile_Click(object sender, EventArgs e)
        {
            if (!APIv3.VerifyService())
                return;

            using (frmGoogleDriveFiles form = new frmGoogleDriveFiles())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    lnkApDrivePaper.Text = form.GetLink().Replace("?usp=drivesdk", "");
                }
            }
        }
        private void btnApUploadDrivePaper_Click(object sender, EventArgs e)
        {
            if (!APIv3.VerifyService())
                return;

            // First gets path file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF Files (*.pdf) | *.pdf";

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string filePath = openFileDialog.FileName;

            //// Google Drive process
            //APIv3.IntializeGDApi();

            string gdPath = Settings.Default.GoogleDrive[0];
            DialogResult result = MessageBox.Show("¿Desea guardar el archivo en la siguiente dirección de su Google Drive?\nDireccion: " + gdPath, "Info", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
            {
                MessageBox.Show("Se ha abortado la subida del archivo", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            
            if (result == DialogResult.Yes)
            {
                if (gdPath.Equals("/root"))
                    Settings.Default.GoogleDrive[1] = APIv3.GetFolderId();
            }
            else
            {
                using (frmGoogleDrivePath frm = new frmGoogleDrivePath())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        Settings.Default.GoogleDrive[0] = frm.GetRoute();
                        Settings.Default.GoogleDrive[1] = frm.GetFolderId();
                    }
                    // Save in root
                    else
                    {
                        MessageBox.Show("El archivo se guardará en el folder Raíz (root)", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Settings.Default.GoogleDrive[0] = "/root";
                        Settings.Default.GoogleDrive[1] = APIv3.GetFolderId();
                    }
                }
            }

            Cursor.Current = Cursors.WaitCursor;

            string shareLink = APIv3.Upload(filePath, Settings.Default.GoogleDrive[1], shared: true).Replace("?usp=drivesdk", "");
            lnkApDrivePaper.Text = shareLink;

            pnlApCoverImage.BackgroundImage = null;

            uploadedFilePath = filePath;
            // Ask to generate the image
            if (MessageBox.Show("¿Desea generar la imagen para la portada del archivo subido?", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                GenerateImage(filePath);

            Cursor.Current = Cursors.Default;
        }

        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel lnk = sender as LinkLabel;

            if (lnk.Text.Equals("Link"))
                return;

            lnk.LinkVisited = true;

            try
            {
                Process.Start(lnk.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al tratar de abrir el link\n\nException: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LinkLabel_TextChanged(object sender, EventArgs e)
        {
            LinkLabel link = sender as LinkLabel;
            link.LinkVisited = false;
        }

        private void GenerateImage(string filePath)
        {
            Cursor.Current = Cursors.WaitCursor;

            // Generating image
            string outputFile = filePath.Replace(".pdf", "_i.jpeg");
            try
            {
                GhostscriptSharp.GhostscriptWrapper.GeneratePageThumb(filePath, outputFile, 1, 210, 280);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar la imagen, posiblemente porque el archivo PDF escogido se encuentra en formato horizontal\nSe tendra que crear la imagen de portada manualmente, subirla a Google Photos y con el botón 'Escoger de Photos' seleccionarla\n\nException: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                return;
            }

            // Resizing image
            Image img;
            using (var bmpTemp = new Bitmap(outputFile))
            {
                img = new Bitmap(bmpTemp);
            }
            var image = ResizeImage(img, 210, 280);

            string imagePath = outputFile.Replace("_i.jpeg", ".jpeg");
            image.Save(imagePath);

            // Showing preview in Panel
            using (var imgtmp = new Bitmap(imagePath))
            {
                img = new Bitmap(imgtmp);
            }
            pnlApCoverImage.BackgroundImage = img;

            // Final steps
            toolTip.SetToolTip(this.pnlApCoverImage, imagePath + PanelImageCaption);
            try
            {
                File.Delete(outputFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al tratar de eliminar el archivo sin escalar\nSe sugiere borrar dicho archivo, mismo que se encuentra en: " + outputFile + "\n(Si no se encuentra ningun archivo así, haga caso omiso de este mensaje)\n\nException: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
            }

            Cursor.Current = Cursors.Default;
        }
        private void ChooseFileAndGenerateImage()
        {
            // Choosing from File Explorer
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF Files (*.pdf) | *.pdf";

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string filePath = openFileDialog.FileName;

            GenerateImage(filePath);
        }
        private void btnApImageGenerate_Click(object sender, EventArgs e)
        {
            if (uploadedFilePath == null && btnApImageGenerate.Text == ButtonGenerateText)
            {
                if (MessageBox.Show("No se ha subido ningún archivo, si continua se tendrá que escoger un archivo para generar la imagen para la portada", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    ChooseFileAndGenerateImage();
            }
            else if (btnApImageGenerate.Text == ButtonGenerateText)
                GenerateImage(uploadedFilePath);
            else
                ChooseFileAndGenerateImage();

            txtApCoverUrl.Text = null;
        }
        private void pnlApCoverImage_DoubleClick(object sender, EventArgs e)
        {
            if (!toolTip.GetToolTip(this.pnlApCoverImage).Contains(PanelImageCaption))
                return;

            try
            {
                Process.Start(toolTip.GetToolTip(this.pnlApCoverImage).Replace(PanelImageCaption, ""));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al tratar de abrir el archivo, el archivo ha sido borrado o se ha dañado\n\nException: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnApSave_Click(object sender, EventArgs e)
        {
            #region Data validation
            if (String.IsNullOrEmpty(txtApTitle.Text) && lnkApDrivePaper.Text.Equals(LinkText) && cboApMember.SelectedIndex == -1)
            {
                ControlValidation.ShowErrorMessage("No se ha colocado titulo, ni escogido miembro, ni escogido o subido un archivo del Google Drive");
                return;
            }
            if (String.IsNullOrEmpty(txtApTitle.Text))
            {
                ControlValidation.ShowErrorMessage("Es necesario colocar un título a la publicación a guardar");
                return;
            }
            if (DB.AlreadyExists("Titulo", "Publicacion", txtApTitle.Text))
            {
                ControlValidation.ShowErrorMessage("El titulo '" + txtApTitle.Text + "' ya existe en la base de datos, favor de escoger uno diferente o simplemente diferenciarlo con un '(1)', '2', etc.");
                return;
            }
            if (cboApMember.SelectedIndex == -1 || (cboApMember.SelectedIndex == cboApMember.Items.Count - 1 && this.idMembers.Count == 0))
            {
                ControlValidation.ShowErrorMessage("No se ha escogido ningún miembro");
                return;
            }
            if (lnkApDrivePaper.Text.Equals(LinkText))
            {
                ControlValidation.ShowErrorMessage("No se ha subido o escogido ningún archivo PDF al Google Drive, es necesario hacerlo para poder guardar una publicación");
                return;
            }
            if (String.IsNullOrEmpty(txtApCoverUrl.Text))
                if (MessageBox.Show("No se ha colocado ninguna imagen para la portada, ¿desea continuar?", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                    return;
            #endregion

            // Insertion to MySQL Database
            FormatTextboxesSQL(new TextBox[] { txtApTitle, txtApCoverUrl });
            lnkApDrivePaper.Text = (lnkApDrivePaper.Text != LinkText) ? "'" + lnkApDrivePaper.Text + "'" : "NULL";

            string query = "INSERT INTO Publicacion (Titulo, url, Foto)" +
                "VALUE (" + txtApTitle.Text + ", " + lnkApDrivePaper.Text + ", " + txtApCoverUrl.Text + ")";
            DB.Insert(query);
            string idPaper = DB.Select("SELECT ID FROM Publicacion WHERE Titulo=" + txtApTitle.Text + " ORDER BY ID DESC").Rows[0][0].ToString();

            string values = "";
            if (cboApMember.SelectedIndex != cboApMember.Items.Count - 1) // only one author
            {
                string idMember = DB.GetID("Miembro", "Etiqueta", cboApMember.SelectedItem.ToString());
                values = "(" + idPaper + ", " + idMember + ")";
            }
            else // various authors
            {
                foreach (int idMember in this.idMembers)
                    values += "(" + idPaper + ", " + idMember + "), ";
                values = values.Substring(0, values.Length - 2);
            }
            if (values == "") // Error
            {
                ControlValidation.ShowErrorMessage("No se pudo añadir a miembros como autores de la publicación.\nIntente añadir los miembros en \"Editar miembros\"");
                return;
            }

            query = "INSERT INTO PublicacionMiembros VALUES " + values;
            DB.Insert(query);

            ReloadApControls();
        }

        private void dgvApPapers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tabWorkgroup.SelectedIndex = 3;
            WaitSeconds(0.8);

            cboEpPapers.SelectedItem = dgvApPapers.Rows[dgvAmMembers.CurrentCell.RowIndex].Cells[0].Value;
            //txtEpTitle.Focus();
        }

        private void cboApMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboApMember.Items.Count >= 2 && cboApMember.SelectedIndex == cboApMember.Items.Count - 1)
            {
                var frmChoose = new frmChooseMembers();
                frmChoose.ShowDialog();
                this.idMembers = frmChoose.ids;

                //if (idMembers.Count > 0)
                //    cboApMember.Text += " (+" + idMembers.Count.ToString() + ")";
            }
        }
        #endregion

        #region Edit papers section
        private bool cboEpPaperWasChanged = false; // flag to show ChooseMember

        private void FillEpComboboxes()
        {
            cboEpPapers.Text = null;
            DB.FillCombobox("Titulo", "Publicacion", "Titulo", this.cboEpPapers);
            DB.FillCombobox("Etiqueta", "Miembro", "Etiqueta", this.cboEpMember);
            if (cboEpMember.Items.Count != 0)
                cboEpMember.Items.AddRange(new object[] { "Varios" });
        }
        private void ClearEpText()
        {
            cboEpMember.Text = txtEpTitle.Text = txtEpPdfLink.Text = txtEpCoverLink.Text = null;
            pnlEpPhoto.BackgroundImage = null;
        }
        private void ReloadEpControls()
        {
            ClearEpText();
            FillEpComboboxes();
        }
        
        private void cboEpPapers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEpPapers.SelectedIndex == -1)
            {
                ClearEpText();
                return;
            }

            ClearEpText();

            DataTable dtPaper = DB.Select("SELECT * FROM Publicacion WHERE Titulo = '" + cboEpPapers.SelectedItem.ToString() + "'");

            if (dtPaper.Rows.Count < 1)
            {
                ControlValidation.ShowErrorMessage("Ocurrio un error en la base de datos al tratar de obtener la información de la publicación '" + cboEpPapers.SelectedItem.ToString() + "'");
                return;
            }

            cboEpPaperWasChanged = true;

            txtEpTitle.Text = dtPaper.Rows[0]["Titulo"].ToString();
            txtEpPdfLink.Text = dtPaper.Rows[0]["url"].ToString();
            txtEpCoverLink.Text = dtPaper.Rows[0]["Foto"].ToString();
            // Retrieving authors
            idMembers.Clear();
            DataTable dtMembers = DB.Select("SELECT IdMiembro FROM PublicacionMiembros WHERE IdPublicacion = " + dtPaper.Rows[0]["ID"].ToString());
            if (dtMembers.Rows.Count > 1)
            {
                cboEpMember.SelectedIndex = cboEpMember.Items.Count - 1;                
                foreach (DataRow row in dtMembers.Rows)
                    idMembers.Add(int.Parse(row[0].ToString()));
            }
            else if (dtMembers.Rows.Count == 1)
                cboEpMember.SelectedItem = DB.Select("SELECT Etiqueta FROM Miembro WHERE ID = " + dtMembers.Rows[0][0].ToString()).Rows[0][0];
            else // TODO: Handle error
                ReloadEpControls();

            if (!String.IsNullOrEmpty(txtEpCoverLink.Text))
                LoadImageFromURL(pnlEpPhoto, txtEpCoverLink.Text);

            cboEpPapers.Focus();
            cboEpPaperWasChanged = false;
        }
        private void btnEpSave_Click(object sender, EventArgs e)
        {
            #region Data validation
            if (cboEpPapers.SelectedIndex == -1)
            {
                ControlValidation.ShowErrorMessage("Aún no se ha escogido ninguna publicación");
                return;
            }
            if (String.IsNullOrEmpty(txtEpTitle.Text))
            {
                ControlValidation.ShowErrorMessage("Es necesario poner un titulo a la publicación");
                return;
            }
            if (txtEpTitle.Text != cboEpPapers.SelectedItem.ToString() && DB.AlreadyExists("Titulo", "Publicacion", txtEpTitle.Text))
            {
                ControlValidation.ShowErrorMessage("El titulo '" + txtEpTitle.Text + "' ya existe lo tiene otra publicación, favor de diferenciar (o eliminar la otra publicación) este titulo para poder modificarlo");
                return;
            }
            if (cboEpMember.SelectedIndex == -1 || (cboEpMember.SelectedIndex == cboEpMember.Items.Count - 1 && idMembers.Count == 0))
            {
                ControlValidation.ShowErrorMessage("No se ha escogido ningún miembro");
                return;
            }
            if (String.IsNullOrEmpty(txtEpPdfLink.Text))
            {
                ControlValidation.ShowErrorMessage("Es necesario colocar un link de Google Drive para el PDF");
                return;
            }
            if (String.IsNullOrEmpty(txtEpCoverLink.Text))
                if (MessageBox.Show("No se ha colocado ninguna imagen para la portada, ¿desea continuar?", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                    return;
            #endregion

            Cursor.Current = Cursors.WaitCursor;

            // Proceed to MySQL database insertion
            if (cboEpMember.SelectedIndex != cboEpMember.Items.Count - 1)
            {
                idMembers.Clear();
                idMembers.Add(int.Parse(DB.GetID("Miembro", "Etiqueta", cboEpMember.SelectedItem.ToString())));
            }
            // confirmation
            if (MessageBox.Show("¿Desea actualizar la información de '" + cboEpPapers.SelectedItem.ToString() + "'?\n(Número de autores: " + idMembers.Count + ")", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            string idPaper = DB.GetID("Publicacion", "Titulo", cboEpPapers.SelectedItem.ToString());
            FormatTextboxesSQL(new TextBox[] { txtEpTitle, txtEpPdfLink, txtEpCoverLink });

            string query = "UPDATE Publicacion SET Titulo = " + txtEpTitle.Text + ", url = " + txtEpPdfLink.Text + ", Foto = " + txtEpCoverLink.Text +
                " WHERE ID = " + idPaper;

            DB.Insert(query);

            // authors
            DB.Insert("DELETE FROM PublicacionMiembros WHERE IdPublicacion = " + idPaper);
            foreach (int idMember in idMembers)
                DB.Insert("INSERT INTO PublicacionMiembros (IdPublicacion, IdMiembro) VALUE (" + idPaper + ", " + idMember + ")");

            ReloadEpControls();

            Cursor.Current = Cursors.Default;
        }
        private void btnEpEliminate_Click(object sender, EventArgs e)
        {
            #region Data validation
            if (cboEpPapers.SelectedIndex == -1)
            {
                ControlValidation.ShowErrorMessage("Aún no se ha escogido ninguna publicación");
                return;
            }
            if (MessageBox.Show("Confirmación para eliminar '" + cboEpPapers.SelectedItem.ToString() + "', de click en 'OK' para proceder a la eliminación de la publicación", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                return;
            #endregion

            Cursor.Current = Cursors.WaitCursor;

            string idPaper = DB.GetID("Publicacion", "Titulo", cboEpPapers.SelectedItem.ToString());
            DB.Insert("DELETE FROM PublicacionMiembros WHERE IdPublicacion = " + idPaper);
            string query = "DELETE FROM Publicacion WHERE ID = " + idPaper;
            DB.Insert(query);

            ReloadEpControls();

            Cursor.Current = Cursors.Default;
        }
        private void cboEpMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEpMember.SelectedIndex == cboEpMember.Items.Count - 1 && !cboEpPaperWasChanged)
            {
                var frmChoose = new frmChooseMembers();
                frmChoose.setIds(idMembers);
                frmChoose.ShowDialog();

                this.idMembers = frmChoose.ids;
            }
        }

        #endregion
    }
}
