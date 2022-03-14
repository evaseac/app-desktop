using System;
using System.Windows.Forms;

namespace Evaseac.Validation
{
    // compile with: -doc:DocFileName.xml

    /// <summary>
    /// This class is meant to be used for <c>System.Windows.Forms</c> controls data validation. To validate empty or null textboxes or whatever control it has text on it
    /// </summary>
    public static class ControlValidation
    {
        private static readonly string ErrorControlsMessage = "Algunos controles no son validos";
        private static readonly string NoValidControlsMessage = "Ningún control ha sido llenado correctamente";

        /// <summary>
        /// Displays a simple error message through <see cref="MessageBox.Show(string, string, MessageBoxButtons, MessageBoxIcon)"/>
        /// </summary>
        /// <param name="errorMessage">The error message to be displayed</param>
        /// <returns>Always returns <c>false</c></returns>
        public static bool ShowErrorMessage(string errorMessage) 
        { 
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        /// <summary>
        /// Displays a simple warning message through <see cref="MessageBox.Show(string, string, MessageBoxButtons, MessageBoxIcon)"/>
        /// </summary>
        /// <param name="warningMessage">The warning message to be displayed</param>
        /// <returns>Always returns <c>false</c></returns>
        public static void ShowWarningMessage(string warningMessage, string warningTitle = "Advertencia") =>
            MessageBox.Show(warningMessage, warningTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        /// <summary>
        /// Displays a simple info message through <see cref="MessageBox.Show(string, string, MessageBoxButtons, MessageBoxIcon)"/>
        /// </summary>
        /// <param name="infoMessage">The info message to be displayed</param>
        /// <returns>Always returns <c>false</c></returns>
        public static void ShowInformationMessage(string infoMessage, string infoTitle = "Informacion") =>
            MessageBox.Show(infoMessage, infoTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

        /// <summary>
        /// Validates if strings are not empty or null and displays the error messages
        /// </summary>
        /// <param name="mainErrorMessage">The main message to be displayed</param>
        /// <param name="controlsTexts">The texts of the controls to be validated</param>
        /// <param name="errorCaptions">The error messages of each control</param>
        /// <returns>A <c>bool<c/> indicating if the set of controls are valid or not</returns>
        /// <exception cref="System.IndexOutOfRangeException">Thrown when arrays do not match</exception>
        public static bool ValidControls(string mainErrorMessage, string[] controlsTexts, string[] errorCaptions)
        {
            if (controlsTexts.Length != errorCaptions.Length)
                throw new IndexOutOfRangeException("ValidControls(string mainErrorMessage, string[] controlsTexts, string[] errorCaptions)\n\ncontrolsTexts and errorCaptions do not match");

            bool isValid = true;

            string errorMessage = mainErrorMessage + "\n\n";
            int counter = 0;

            for (int i = 0; i < controlsTexts.Length; i++)
            {
                if (String.IsNullOrEmpty(controlsTexts[i]))
                {
                    errorMessage += errorCaptions[i];
                    if (i != controlsTexts.Length - 2)
                        errorMessage += "\n";

                    counter++;
                    isValid = false;
                }
            }

            if (counter == controlsTexts.Length)
                ShowErrorMessage(NoValidControlsMessage);
            else if (counter != 0)
                ShowErrorMessage(errorMessage);

            return isValid;
        }

        /// <summary>
        /// Validates if strings are not empty or null and displays the error messages
        /// </summary>
        /// <param name="controlsTexts">The texts of the controls to be validated</param>
        /// <param name="errorCaptions">The error messages of each control</param>
        /// <returns>A <c>bool<c/> indicating if the set of controls are valid or not</returns>
        /// <exception cref="System.IndexOutOfRangeException">Thrown when arrays do not match</exception>
        public static bool ValidControls(string[] controlsTexts, string[] errorCaptions)
        {
            if (controlsTexts.Length != errorCaptions.Length)
                throw new IndexOutOfRangeException("ValidControls(string[] controlsTexts, string[] errorCaptions)\n\ncontrolsTexts and errorCaptions do not match");

            return ValidControls(ErrorControlsMessage, controlsTexts, errorCaptions);
        }

        /// <summary>
        /// Validates if strings are not empty or null and displays the error messages
        /// </summary>
        /// <param name="mainErrorMessage">The main message to be displayed</param>
        /// <param name="textBoxes">The set of <c>TextBox[]</c> to be validated</param>
        /// <param name="errorCaptions">The error messages of each control</param>
        /// <returns>A <c>bool<c/> indicating if the set of controls are valid or not</returns>
        /// <exception cref="System.IndexOutOfRangeException">Thrown when arrays do not match</exception>
        public static bool ValidControls(string mainErrorMessage, TextBox[] textBoxes, string[] captions)
        {
            if (textBoxes.Length != captions.Length)
                throw new IndexOutOfRangeException("ValidTextboxes(string, TextBox[], string[]): TextBox[] and string[] do not match");

            string[] controlsTexts = new string[textBoxes.Length];

            for (int i = 0; i < textBoxes.Length; i++)
                controlsTexts[i] = textBoxes[i].Text;

            return ValidControls(mainErrorMessage, controlsTexts, captions);
        }

        public static bool ValidControl(object control, string errorCaption)
        {
            return ValidControls(new string[] { (control as TextBox).Text }, new string[] { errorCaption });
        }
    }
}
