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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                openChildForm(new frmAddUser());
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);                
            }
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

        private void btnEdit_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    var user = dgvUsers.SelectedRows[0].DataBoundItem as User;//TO-DO: make sure it's the same user(data of the selected user) 
                
            //    if (ValidateUserData())
            //    { 
            //        //user.Username = txtUsername.Text;
            //        //user.FullName = txtFullname.Text;
            //        //user.Password = txtPassword.Text;
            //        //user.Telephone = int.Parse(txtTelephone.Text);
            //        //user.Email = txtEmail.Text;
                    
            //        //InventoryManagementDb.DB.Entry(user).State = System.Data.Entity.EntityState.Modified;
            //        //InventoryManagementDb.DB.SaveChanges();
            //        //LoadUsers();

            //        MessageBox.Show(Messages.SuccessfullyModified);
            //        ClearData();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Messages.HandleException(ex);
            //}
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //var user = dgvUsers.SelectedRows[0].DataBoundItem as User;
               
                //txtUsername.Text = user.Username;
                //txtFullname.Text = user.FullName;
                //txtPassword.Text = user.Password;
                //txtTelephone.Text = $"{user.Telephone}";
                //txtEmail.Text = user.Email;
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlChildForm.Controls.Add(childForm);
            pnlChildForm.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }
    }
}
