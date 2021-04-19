using InventoryManagementApp.Data;
using InventoryManagementApp.Helpers;
using InventoryManagementApp.UserInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementApp.Users
{
    public partial class frmManageUsers : Form
    {
        private Form activeForm = null;
        public frmManageUsers()
        {
            InitializeComponent();
            dgvUsers.AutoGenerateColumns = false;
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers(List<User> users = null)
        {
            try
            {
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = users ?? InventoryManagementDb.DB.Users.ToList();

                lblUsersNumber.Text = $"{(dgvUsers.DataSource as List<User>).Count()} users";
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var user = dgvUsers.SelectedRows[0].DataBoundItem as User;

            try
            {
                foreach (var item in InventoryManagementDb.DB.Users)
                {
                    if (item.Id == user.Id
                        && MessageBox.Show(Messages.Delete,
                        Messages.Question,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question)
                        == DialogResult.Yes)
                    {
                        InventoryManagementDb.DB.Users.Remove(item);
                        InventoryManagementDb.DB.SaveChanges();
                        
                        LoadUsers();
                        MessageBox.Show(Messages.SuccessfullyDeleted);
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var user = dgvUsers.SelectedRows[0].DataBoundItem as User;

                if(e.ColumnIndex==4)
                {
                    pnlChildForm = this.Parent as Panel;
                    if (pnlChildForm != null)
                    {
                        frmAddUser frmAddUser = new frmAddUser(user);
                        frmAddUser.FormBorderStyle = FormBorderStyle.None;
                        frmAddUser.TopLevel = false;
                        frmAddUser.BringToFront();

                        pnlChildForm.Controls.Clear();
                        pnlChildForm.Controls.Add(frmAddUser);
                        frmAddUser.Show();
                        this.Hide();
                    }

                }
                if (e.ColumnIndex == 5 
                    && MessageBox.Show(Messages.Delete, Messages.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                    == DialogResult.Yes)
                {
                    InventoryManagementDb.DB.Users.Remove(user);
                    InventoryManagementDb.DB.SaveChanges();
                }

                LoadUsers();
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var filter = txtSearch.Text.ToLower();

            LoadUsers(
                InventoryManagementDb.DB.Users.Where(
                    u => u.Username.ToLower().Contains(filter)
                    || u.FullName.ToLower().Contains(filter)
                    || u.Email.ToLower().Contains(filter)
                    || u.Telephone.ToString().ToLower().Contains(filter)
                    || string.IsNullOrEmpty(filter)
                    ).ToList());
        }
    }
}
