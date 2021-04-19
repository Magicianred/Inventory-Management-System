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
    public partial class frmDashboard : Form
    {
        private Form activeForm = null;
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void lblProductInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openChildForm(new frmManageProducts());
        }

        private void lblOrdersInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openChildForm(new frmManageOrders());
        }

        private void lblStoresInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void lblUsersInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openChildForm(new frmManageUsers());
        }

        private void lblCustomersInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openChildForm(new frmManageCustomers());
        }

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;

            Panel pnlChildForm  = this.Parent as Panel;
            if (pnlChildForm != null)
            {
                activeForm.FormBorderStyle = FormBorderStyle.None;
                activeForm.TopLevel = false;
                activeForm.BringToFront();

                pnlChildForm.Controls.Clear();
                pnlChildForm.Controls.Add(childForm);
                activeForm.Show();
                this.Close();
            }
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void LoadData()
        {
            lblProductsNumber.Text = InventoryManagementDb.DB.Products.ToList().Count().ToString();
            lblOrdersNumber.Text = InventoryManagementDb.DB.Orders.ToList().Count().ToString();
            lblUsersNumber.Text = InventoryManagementDb.DB.Users.ToList().Count().ToString();
            lblCustomersNumber.Text = InventoryManagementDb.DB.Customers.ToList().Count().ToString();
            lblStoresNumber.Text = InventoryManagementDb.DB.Stores.ToList().Count().ToString();
        }
    }
}
