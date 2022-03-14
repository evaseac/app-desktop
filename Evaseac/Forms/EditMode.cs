using Evaseac.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Evaseac
{
    public partial class frmEditMode : Form
    {
        public frmEditMode()
        {
            InitializeComponent();

            if (Settings.Default.dftParams)
                radParams.Checked = true;
            else
                radSites.Checked = true;
        }

        public bool parameters { get; set; }
        
        private void btnAccept_Click(object sender, EventArgs e)
        {
            parameters = radParams.Checked;
            
            Settings.Default.askEdtParams = chkAsk.Checked;
            Settings.Default.Save();
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
    }
}
