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
    public partial class frmLoading : Form
    {
        public Action action { get; set; }

        public frmLoading(Action action)
        {
            InitializeComponent();

            if (action == null)
                throw new ArgumentNullException();

            this.action = action;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(action).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
