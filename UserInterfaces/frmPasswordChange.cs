using InventoryManagementApp.Data;
using InventoryManagementApp.DataClasses;
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

namespace InventoryManagementApp.UserInterfaces
{
    public partial class frmPasswordChange : Form
    {
        private Administrator admin;
        public frmPasswordChange(Administrator admin)
        {
            InitializeComponent();
            this.admin = admin;
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
                txtCurrentPassword.UseSystemPasswordChar = txtNewPassword.UseSystemPasswordChar = txtConfirmNewPassword.UseSystemPasswordChar = false;
            else
                txtCurrentPassword.UseSystemPasswordChar = txtNewPassword.UseSystemPasswordChar = txtConfirmNewPassword.UseSystemPasswordChar = true;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (admin != null && ValidateData() && admin.Password == txtCurrentPassword.Text 
                && ValidateNewPassword() && txtNewPassword.Text == txtConfirmNewPassword.Text)
            {
                lblInvalidUserInput.Text = "";
                admin.Password = txtNewPassword.Text;

                InventoryManagementDb.DB.Entry(admin).State = System.Data.Entity.EntityState.Modified;
                InventoryManagementDb.DB.SaveChanges();

                this.Close();
            }
            else
            {
                lblInvalidUserInput.Text = Messages.DataNotMatching;
            }
        }

        private bool ValidateData()
        {
            return Validator.ValidateControl(txtCurrentPassword, err, Messages.RequiredField)
                && Validator.ValidateControl(txtNewPassword, err, Messages.RequiredField);
        }

        private bool ValidateNewPassword()
        {
            return Validator.ValidatePassword(txtNewPassword, txtConfirmNewPassword, err, Messages.DataNotMatching);
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            ValidateNewPassword();
        }

        private void txtConfirmNewPassword_TextChanged(object sender, EventArgs e)
        {
            ValidateNewPassword();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
