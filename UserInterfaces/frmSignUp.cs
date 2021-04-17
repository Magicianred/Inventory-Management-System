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
    public partial class frmSignUp : Form
    {
        private bool passwordConfirmed;
        public frmSignUp()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (ValidateUserInput()) {
                var admin = new Administrator
                {
                    Username = txtUsername.Text,
                    FullName = txtFullName.Text,
                    Password = txtPassword.Text,
                    
                }; 
                InventoryManagementDb.DB.Administrators.Add(admin);
                InventoryManagementDb.DB.SaveChanges();
                                
                frmHome frmHome = new frmHome(admin);
                frmHome.Show();
            }
        }

        private bool ValidateUserInput()
        {
            return Validator.ValidateControl(txtUsername, err, Messages.RequiredField)
                && Validator.ValidateControl(txtFullName, err, Messages.RequiredField)
                && Validator.ValidateNumber(txtTelephone, err, Messages.RequiredNumber)
                && Validator.ValidateControl(txtPassword, err, Messages.RequiredField)
                && Validator.ValidateControl(txtPasswordConfirmation, err, Messages.RequiredField)
                && passwordConfirmed 
                && txtPassword.Text == txtPasswordConfirmation.Text;
        }

        private void lblSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();//hide SignUp
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
                txtPassword.UseSystemPasswordChar = txtPasswordConfirmation.UseSystemPasswordChar = false;
            else
                txtPassword.UseSystemPasswordChar = txtPasswordConfirmation.UseSystemPasswordChar = true;
        }

        private void txtPasswordConfirmation_TextChanged(object sender, EventArgs e)
        {
            var passwordConfirmation = txtPasswordConfirmation.Text;
            passwordConfirmed = true;

            //add to validator
            if (!txtPassword.Text.Contains(passwordConfirmation))
            {
                err.SetError(txtPasswordConfirmation, Messages.InvalidUserInput);
                passwordConfirmed = false;
                return;
            }
        }

        private void frmSignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
