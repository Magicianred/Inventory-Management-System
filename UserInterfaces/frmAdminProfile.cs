using InventoryManagementApp.DataClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementApp.UserInterfaces
{
    public partial class frmAdminProfile : Form
    {
        private Administrator admin;
        public frmAdminProfile(Administrator admin)
        {
            InitializeComponent();
            this.admin = admin;

            LoadAdminData();
        }

        private void LoadAdminData()
        {
            
        }

        private void pbProfilePicture_Click(object sender, EventArgs e)
        {
            if (ofdProfilePicture.ShowDialog() == DialogResult.OK)
            {
                pbProfilePicture.Image = Image.FromFile(ofdProfilePicture.FileName);
            }
        }
    }
}
