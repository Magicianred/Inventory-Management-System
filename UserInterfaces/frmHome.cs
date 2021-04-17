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
        private Form activeForm = null;

        public frmHome(Administrator admin)
        {
            InitializeComponent();
            CustomizeDesign();
            this.admin = admin;
        }

        private void CustomizeDesign()
        {
            hideSubMenues();
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

        private void lblUsersInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmManageUsers frmManageUsers = new frmManageUsers();
            frmManageUsers.Show();
        }

        private void lblOrdersInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmManageOrders frmManageOrders = new frmManageOrders();
            frmManageOrders.Show();
        }

        private void lblCustomersInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmManageCustomers frmManageCustomers = new frmManageCustomers();
            frmManageCustomers.Show();
        }

        private void lblStoresInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frmStores
        }

        private void ShowSubMenu(Panel subMenu)
        {
            if(!subMenu.Visible)
            {
                hideSubMenues();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void hideSubMenues()
        {
            pnlUsers.Visible = false;
            pnlProducts.Visible = false;
            pnlCustomers.Visible = false;
            pnlOrders.Visible = false;
        }


        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlUsers);
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            openChildForm(new frmManageUsers());
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            //frmAddUser
        }
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;

            childForm.TopLevel = false;//child form will behave as a control
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlChildForm.Controls.Add(childForm);
            pnlChildForm.Tag = childForm;//associate form with the container panel
            
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if(activeForm!=null)
                activeForm.Close();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlProducts);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlCustomers);
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlOrders);
        }

        private void btnManageProducts_Click(object sender, EventArgs e)
        {
            openChildForm(new frmManageProducts());
        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            openChildForm(new frmManageCustomers());
        }

        private void btnManageOrders_Click(object sender, EventArgs e)
        {
            openChildForm(new frmManageOrders());
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
        }
    }
}
