using InventoryManagementApp.Data;
using InventoryManagementApp.DataClasses;
using InventoryManagementApp.Helpers;
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
        private bool passwordConfirmed;
        private bool editUser = true;

        public frmAddUser()
        {
            InitializeComponent();
        }

        public frmAddUser(User user) : this()
        {
            this.user = user;
        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            LoadGenders();

            if (user != null)
            {
                lblEvidentUser.Text = "Edit User Info";
                
                LoadUserData();

                txtPassword.ReadOnly = true;
                txtPasswordConfirmation.ReadOnly = true;
                cbShowPassword.Enabled = false;
            }
        }

        private void LoadUserData()
        {
            try
            {
                txtFullName.Text = user.FullName;
                txtUsername.Text = user.Username;
                txtEmail.Text = user.Email;
                txtPassword.Text  = user.Password;
                txtPasswordConfirmation.Text = user.Password;
                txtTelephone.Text = $"{user.Telephone}";
                cmbGenders.SelectedValue = user.Gender.Id;
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateUserData())
                {
                    if (user == null)
                    {
                        user = new User();
                        editUser = false;
                        user.Password = txtPassword.Text;
                    }

                    user.FullName = txtFullName.Text;
                    user.Username = txtUsername.Text;
                    user.Email = txtEmail.Text;
                    user.Telephone = int.Parse(txtTelephone.Text);
                    user.Gender = (cmbGenders.SelectedItem as Gender);

                    if (editUser)
                    {
                        InventoryManagementDb.DB.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        InventoryManagementDb.DB.Users.Add(user);
                    }

                    InventoryManagementDb.DB.SaveChanges();
                    ClearData();

                    if (editUser)
                        lblOperationInfo.Text = Messages.SuccessfullyModified;
                    else
                        lblOperationInfo.Text = Messages.SuccessfullyAdded;
                }
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void ClearData()
        {
            txtFullName.Text = txtUsername.Text = txtPassword.Text = txtPasswordConfirmation.Text = txtEmail.Text = txtTelephone.Text = "";
            cbShowPassword.Checked = false;
        }

        private bool ValidateUserData()
        {
            return Validator.ValidateControl(txtFullName, err, Messages.RequiredField)
               && Validator.ValidateControl(txtUsername, err, Messages.RequiredField)
               && Validator.ValidateControl(txtEmail, err, Messages.RequiredField)
               && Validator.ValidateControl(txtPassword, err, Messages.RequiredField)
               && Validator.ValidateControl(txtPasswordConfirmation, err, Messages.RequiredField)
               && Validator.ValidateNumber(txtTelephone, err, Messages.RequiredNumber)
               && passwordConfirmed
               && txtPassword.Text == txtPasswordConfirmation.Text;
        }

        private void txtPasswordConfirmation_TextChanged(object sender, EventArgs e)
        {
            passwordConfirmed = true;

            if (!Validator.ValidatePassword(txtPassword, txtPasswordConfirmation, err, Messages.DataNotMatching)) 
            {
                passwordConfirmed = false;
                lblInvalidUserInput.Text = Messages.PasswordNotMatching;
                return;
            }
            else
            {
                lblInvalidUserInput.Text = "";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
                txtPassword.UseSystemPasswordChar = txtPasswordConfirmation.UseSystemPasswordChar = false;
            else
                txtPassword.UseSystemPasswordChar = txtPasswordConfirmation.UseSystemPasswordChar = true;
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmManageUsers());
        }

        private void OpenChildForm(Form form)
        {
            Panel pnlChildForm = this.Parent as Panel;
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
    }
}
