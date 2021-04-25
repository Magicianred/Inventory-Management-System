using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementApp.Helpers
{
    public class Backgrounds
    {
        public static void LoadFormBackground(Form form)
        {
            if (form != null)
            {
                Form frmBackground = new Form();

                frmBackground.StartPosition = FormStartPosition.Manual;
                frmBackground.FormBorderStyle = FormBorderStyle.None;
                frmBackground.Opacity = .70d;
                frmBackground.BackColor = Color.Black;
                frmBackground.WindowState = FormWindowState.Maximized;
                frmBackground.TopMost = true;
                frmBackground.Location = form.Location;
                frmBackground.ShowInTaskbar = false;
                frmBackground.Show();

                form.Owner = frmBackground;
                form.ShowDialog();

                frmBackground.Dispose();
            }
        }
    }
}
