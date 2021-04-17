using InventoryManagementApp.Data;
using InventoryManagementApp.Users;
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
    public partial class frmAddUser : Form
    {
        private User user = null;

        public frmAddUser()
        {
            InitializeComponent();
        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            if (user == null)
            {
                lblEvidentUser.Text = "Edit User Info";
            }
            else
            {
                lblEvidentUser.Text = "Add User";
            }

            LoadGenders();
        }

        private void LoadGenders()
        {
            cmbGenders.DataSource = InventoryManagementDb.DB.Genders.ToList();
            cmbGenders.ValueMember = "Id";
            cmbGenders.DisplayMember = "Name";
        }
    }
}
