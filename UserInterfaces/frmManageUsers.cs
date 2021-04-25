using InventoryManagementApp.Data;
using InventoryManagementApp.DataClasses;
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
        public frmManageUsers()
        {
            InitializeComponent();
            dgvUsers.AutoGenerateColumns = false;
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            LoadGenders();
            LoadUsers();
        }

        private void LoadGenders()
        {
            try
            {
                cmbGenders.DataSource = InventoryManagementDb.DB.Genders.ToList();
                cmbGenders.ValueMember = "Id";
                cmbGenders.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
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

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var user = dgvUsers.SelectedRows[0].DataBoundItem as User;

                if(e.ColumnIndex == 4)
                {
                    OpenChildForm(new frmAddUser(user));
                }

                if (e.ColumnIndex == 5 
                    && MessageBox.Show(Messages.Delete, Messages.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                    == DialogResult.Yes)
                {
                    InventoryManagementDb.DB.Users.Remove(user);
                    InventoryManagementDb.DB.SaveChanges();

                    txtSearch.Text = "";
                }

                LoadUsers();
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void OpenChildForm(Form form)
        {
            pnlChildForm = this.Parent as Panel;
            if (pnlChildForm != null)
            {
                form.FormBorderStyle = FormBorderStyle.None;
                form.TopLevel = false;
                form.BringToFront();

                pnlChildForm.Controls.Clear();
                pnlChildForm.Controls.Add(form);
                form.Show();
                this.Hide();
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmAddUser());
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void cmbGenders_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void Filter()
        {
            try
            {
                var filter = txtSearch.Text.ToLower();
                var gender = cmbGenders.SelectedItem as Gender;
                
                if (gender != null)
                {
                    LoadUsers(
                        InventoryManagementDb.DB.Users.Where(
                            u => (u.Username.ToLower().Contains(filter)
                            || u.FullName.ToLower().Contains(filter)
                            || u.Email.ToLower().Contains(filter)
                            || u.Telephone.ToString().Contains(filter)
                            || string.IsNullOrEmpty(filter))
                            && u.Gender.Id == gender.Id
                            ).ToList());
                }
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void lblClearFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadUsers();
        }
    }
}
