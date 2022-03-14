using System;
using System.Windows.Forms;

namespace Evaseac
{
    public partial class frmPassword : Form
    {
        public frmPassword()
        {
            InitializeComponent();
        }

        public string password { get; set; }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            password = txtPassword.Text;
        }
    }
}
