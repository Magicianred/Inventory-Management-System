using InventoryManagementApp.Data;
using InventoryManagementApp.DataClasses;
using InventoryManagementApp.Users;
using System;
using System.Linq;
using System.Windows.Forms;

namespace InventoryManagementApp.UserInterfaces
{
    public partial class frmHome : Form
    {
        private Administrator admin;
        public frmHome(Administrator admin)
        {
            InitializeComponent();
            CustomizeDesign();
            this.admin = admin;
        }

        private void CustomizeDesign()
        {
            pnlUsers.Visible = false;
        }

        private void frmHome_Load(object sender, System.EventArgs e)
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

        private void lblMoreProductInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmManageProducts frmManageProducts = new frmManageProducts();
            frmManageProducts.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmManageOrders frmManageOrders = new frmManageOrders();
            frmManageOrders.Show();
        }

        private void lblUsersInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmManageUsers frmManageUsers = new frmManageUsers();
            frmManageUsers.Show();
        }

        private void lblCustomersInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmManageCustomers frmManageCustomers = new frmManageCustomers();
            frmManageCustomers.Show();
        }

        private void lblStoresNumber_Click(object sender, EventArgs e)
        {
            //StoresForm
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlUsers);
        }

        private void ShowSubMenu(Panel subMenu)
        {
            if(!subMenu.Visible)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void hideSubMenu()
        {
            if (pnlUsers.Visible)
            {
                pnlUsers.Visible = false;
            }
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            frmManageUsers frmManageUsers = new frmManageUsers();
            frmManageUsers.Show();
            hideSubMenu();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
