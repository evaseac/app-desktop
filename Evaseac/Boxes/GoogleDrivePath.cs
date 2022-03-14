using Evaseac.User.Google_Drive;
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
    public partial class frmGoogleDrivePath : Form
    {
        public frmGoogleDrivePath()
        {
            InitializeComponent();
        }

        public string GetFolderId()
        {
            return txtFolderId.Text;
        }

        public string GetRoute()
        {
            return txtRoute.Text;
        }

        private string GetParentFolder(string path)
        {
            int i, j;
            int counter = 0;
            int slashCount = path.Count(f => f == '/');

            // Gets penultimate substring of path
            for (i = 0; i < path.Count(); i++)
            {
                if (path[i].Equals('/'))
                    counter++;
                if (counter == slashCount - 1)
                    break;
            }

            // Gets length of penultimate directory
            counter = 0;
            for (j = i + 1; j < path.Count(); j++)
            {
                counter++;
                if (path[j] == '/')
                    break;
            }

            return path.Substring(i + 1, counter - 1);
        }

        private void frmGoogleDrivePath_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            trvDirectories.Nodes.Clear();
            trvDirectories.Nodes.Add(APIv3.GetDriveDirectoryNode(null, APIv3.GetFolderId()));
            trvDirectories.Nodes[0].Expand();
            trvDirectories.SelectedNode = trvDirectories.Nodes[0];

            Cursor.Current = Cursors.Default;
        }

        private void trvDirectories_AfterSelect(object sender, TreeViewEventArgs e)
        {
            txtRoute.Text = trvDirectories.SelectedNode.FullPath.Replace("\\", "/").Replace(APIv3.RootName, "/root");
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            string folderId = APIv3.GetFolderId();

            if (trvDirectories.SelectedNode != null && !txtRoute.Text.Equals("/root"))
            {
                string parentFolder = GetParentFolder(txtRoute.Text);

                if (!parentFolder.Equals("root"))
                    //folderId = APIv3.GetFolderId(trvGDFolders.SelectedNode.Text); -> RECOMMENDED IF PROGRAM MISBEHAVE
                    folderId = APIv3.GetFolderId(trvDirectories.SelectedNode.Text, APIv3.GetFolderId(parentFolder));
                else
                    folderId = APIv3.GetFolderId(trvDirectories.SelectedNode.Text, APIv3.GetFolderId());
            }
            else
                MessageBox.Show("No se ha seleccionado ningún folder, se guardará en el folder Raíz (root)", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            txtFolderId.Text = folderId;
        }
    }
}
