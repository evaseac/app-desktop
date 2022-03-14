using System;
using System.Drawing;
using System.Windows.Forms;

namespace Evaseac.Boxes
{
    public partial class Generic : Form
    {
        private Func<object, bool> _Validation;
        private Func<object, bool> _Action;

        public Generic(string message, string title = "", string accept = "Accept", string cancel = "Cancel", bool isPassword = false, Func<object, bool> validationFunction = null, Func<object, bool> actionFunction = null)
        {
            if (message.Length > 897)
                throw new OverflowException("The message is too long");

            InitializeComponent();
            this.lblMessage.Text = message;
            this.Text = title;
            this.btnAccept.Text = accept;
            this.btnCancel.Text = cancel;
            if (isPassword)
                this.TextBox.PasswordChar = '●';
            this._Validation = validationFunction;
            this._Action = actionFunction;

            ComponentsRelocation();
        }

        public string TextBoxString
        {
            get
            {
                return TextBox.Text;
            }
            set
            {
                TextBox.Text = value;
            }
        }

        private void ComponentsRelocation()
        {
            Size textboxSize = TextRenderer.MeasureText(this.lblMessage.Text, this.lblMessage.Font);
            int height = textboxSize.Height;
            int width = textboxSize.Width;

            int factor = (int)width / lblMessage.Width;
            this.Height += height * factor;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (_Validation == null)
                this.Close();
            else if (this._Validation != null && !String.IsNullOrEmpty(TextBoxString))
                if (_Validation(this) && _Action != null)
                    _Action(this);
        }
    }
}
