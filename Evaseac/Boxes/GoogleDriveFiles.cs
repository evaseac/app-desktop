using System;
using System.Windows.Forms;
using Evaseac.User.Google_Drive;
using Evaseac.Validation;

namespace Evaseac.Boxes
{
    public partial class frmGoogleDriveFiles : Form
    {
        public frmGoogleDriveFiles()
        {
            InitializeComponent();
        }

        public string GetLink()
        {
            return txtShareLink.Text;
        }

        private void GoogleDriveFiles_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            trvFiles.Nodes.Clear();
            trvFiles.Nodes.Add(APIv3.GetDriveFilesNode(null, APIv3.GetFolderId()));
            trvFiles.Nodes[0].Expand();
            this.AcceptButton = null;

            Cursor.Current = Cursors.Default;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (trvFiles.SelectedNode != null && trvFiles.SelectedNode.Text.Contains(".pdf"))
            {
                txtShareLink.Text = APIv3.ShareFile(APIv3.GetFileId(trvFiles.SelectedNode.Text));
            }
            else
                MessageBox.Show("Por favor escoja un archivo pdf", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void trvFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            txtFile.Text = trvFiles.SelectedNode.FullPath.ToString().Replace("\\", "/").Replace("Raiz (root)", "/root");

            if (trvFiles.SelectedNode.Text.Contains(".pdf"))
                this.AcceptButton = btnChoose;
        }
    }
}
