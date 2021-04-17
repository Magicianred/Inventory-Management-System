using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementApp.Helpers
{
    public class Validator
    {
        public static bool ValidateControl(Control control, ErrorProvider err, string message)
        {
            bool _setError = false;
            if (control is TextBox && (string.IsNullOrEmpty(control.Text) || control.Text=="Password" || control.Text=="Username / e-mail"))
                _setError = true;
            else if (control is ComboBox && (string.IsNullOrEmpty((control as ComboBox).Text) || (control as ComboBox).SelectedIndex < 0))
                _setError = true;
            else if (control is PictureBox && (control as PictureBox).Image == null)
                _setError = true;

            if (_setError)
            {
                err.SetError(control, message);
                return false;
            }
            err.Clear();
            return true;
        }

        public static bool ValidateNumber(Control control, ErrorProvider err, string message)
        {

            bool _setError = false, isNumber;
            int number;

            isNumber = int.TryParse(control.Text, out number);

            if (control is TextBox && (string.IsNullOrEmpty(control.Text) || !isNumber))
            {
                _setError = true;
            }

            if (_setError)
            {
                err.SetError(control, message);
                return false;
            }
            err.Clear();
            return true;
        }
    }
}
