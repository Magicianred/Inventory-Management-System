using InventoryManagementApp.Data;
using InventoryManagementApp.Helpers;
using InventoryManagementApp.UserInterfaces;
using System;
using System.Windows.Forms;

namespace InventoryManagementApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
                txtPassword.UseSystemPasswordChar = false;
            else
                txtPassword.UseSystemPasswordChar = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateAdminInput()) {
                    foreach (var admin in InventoryManagementDb.DB.Administrators)//should be admin, not user
                    {
                        if (txtUsername.Text == admin.Username && txtPassword.Text == admin.Password)
                        {
                            frmHome frmHome = new frmHome(admin);
                            frmHome.ShowDialog();
                            return;
                        }
                    }
                    MessageBox.Show(Messages.DataNotMatching);
                }
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private bool ValidateAdminInput()
        {
                return Validator.ValidateControl(txtUsername, err, Messages.RequiredField)
                    && Validator.ValidateControl(txtPassword, err, Messages.RequiredField);
        }

        private void lblSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                frmSignUp frmSignUp = new frmSignUp();
                frmSignUp.ShowDialog();
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
