using InventoryManagementApp.Data;
using InventoryManagementApp.Helpers;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ValidateUserData())
                //{
                //   InventoryManagementDb.DB.Users.Add(
                //        new User()
                //        {
                //            Username = txtUsername.Text,
                //            FullName = txtFullname.Text,
                //            Password = txtPassword.Text,
                //            Telephone = int.Parse(txtTelephone.Text),
                //            Email = txtEmail.Text
                //        });
                //    InventoryManagementDb.DB.SaveChanges();

                //    MessageBox.Show(Messages.SuccessfullyAdded);
                    
                //    ClearData();
                //    LoadUsers();
                //}
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);                
            }
        }

        private bool ValidateUserData()
        {
            return true;
            //return Validator.ValidateControl(txtUsername, err, Messages.RequiredField)
            // && Validator.ValidateControl(txtFullname, err, Messages.RequiredField)
            // && Validator.ValidateControl(txtPassword, err, Messages.RequiredField)
            // && Validator.ValidateNumber(txtTelephone, err, Messages.RequiredNumber);
        }

        private void ClearData()
        {
           //txtUsername.Text = txtFullname.Text = txtPassword.Text = txtTelephone.Text = ""; 
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

            try
            {
                var user = dgvUsers.SelectedRows[0].DataBoundItem as User;//TO-DO: make sure it's the same user(data of the selected user) 
                
                if (ValidateUserData())
                { 
                    //user.Username = txtUsername.Text;
                    //user.FullName = txtFullname.Text;
                    //user.Password = txtPassword.Text;
                    //user.Telephone = int.Parse(txtTelephone.Text);
                    //user.Email = txtEmail.Text;
                    
                    //InventoryManagementDb.DB.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    //InventoryManagementDb.DB.SaveChanges();
                    //LoadUsers();

                    MessageBox.Show(Messages.SuccessfullyModified);
                    ClearData();
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
    }
}
