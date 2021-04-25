using InventoryManagementApp.Data;
using InventoryManagementApp.Helpers;
using InventoryManagementApp.UserInterfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace InventoryManagementApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            cbShowPassword.Enabled = false;
        }

        private bool ValidateAdminInput()
        {
            return Validator.ValidateControl(txtUsername, err, Messages.RequiredField)
                && Validator.ValidateControl(txtPassword, err, Messages.RequiredField);
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateAdminInput())
                {
                    foreach (var admin in InventoryManagementDb.DB.Administrators)
                    {
                        if ((txtUsername.Text == admin.Username || txtUsername.Text == admin.Email) && txtPassword.Text == admin.Password)
                        {
                            frmHome frmHome = new frmHome(admin);
                            frmHome.ShowDialog();

                            ClearUserInput();
                            LeaveUsername();
                            LeavePassword();

                            return;
                        }
                    }

                    lblInvalidUserInput.Text = Messages.InvalidUserInput;
                }
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void ClearUserInput()
        {
            txtUsername.Text = txtPassword.Text = "";
            lblInvalidUserInput.Text = "";
        }

        private void pnlUsername_Enter(object sender, EventArgs e)
        {
            txtUsername.BackColor = Color.White;
            pnlUsername.BackColor = Color.White;

            txtPassword.BackColor = SystemColors.Control;
            pnlPassword.BackColor = SystemColors.Control;

            if (txtUsername.Text == "Username / e-mail")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.SteelBlue;
            }
        }

        private void pnlPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.White;
            pnlPassword.BackColor = Color.White;

            txtUsername.BackColor = SystemColors.Control;
            pnlUsername.BackColor = SystemColors.Control;

            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.ForeColor = Color.SteelBlue;
                cbShowPassword.Enabled = true;
            }
        }

        private void pnlUsername_Leave(object sender, EventArgs e)
        {
            LeaveUsername();
        }

        private void LeaveUsername()
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username / e-mail";
                txtUsername.ForeColor = SystemColors.InactiveCaption;
            }

            txtUsername.BackColor = SystemColors.Control;
            pnlUsername.BackColor = SystemColors.Control;
        }

        private void pnlPassword_Leave(object sender, EventArgs e)
        {
            LeavePassword();
        }

        private void LeavePassword()
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                cbShowPassword.Checked = false;
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.Text = "Password";
                txtPassword.ForeColor = SystemColors.InactiveCaption;
                cbShowPassword.Enabled = false;
            }

            txtPassword.BackColor = SystemColors.Control;
            pnlPassword.BackColor = SystemColors.Control;
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
                txtPassword.UseSystemPasswordChar = false;
            else
                txtPassword.UseSystemPasswordChar = true;
        }
    }
}
