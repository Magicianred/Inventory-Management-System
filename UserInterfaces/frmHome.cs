using InventoryManagementApp.Data;
using InventoryManagementApp.DataClasses;
using InventoryManagementApp.Helpers;
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
            this.admin = admin;
        }

        private void LoadAdminData()
        {
            lblAdminName.Text = admin.FullName;
            if (admin.ProfilePicture != null)
            {
                pbAdmin.Image = Images.FromByteToImage(admin.ProfilePicture);
            }
            else
            {
                pbAdmin.Image = null;
            }
        }

        private void CustomizeDesign()
        {
            hideSubMenues();
        }

        private void frmHome_Load(object sender, System.EventArgs e)
        {
            CustomizeDesign();
            LoadAdminData();

            openChildForm(new frmDashboard());
        }

        private void lblMoreProductInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openChildForm(new frmManageProducts());
        }

        private void lblUsersInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openChildForm(new frmManageUsers());
        }

        private void lblOrdersInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openChildForm(new frmManageOrders());

        }

        private void lblCustomersInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openChildForm(new frmManageCustomers());

        }

        private void lblStoresInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openChildForm(new frmManageStores());
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
            openChildForm(new frmAddUser());
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

            LoadAdminData();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            openChildForm(new frmDashboard());
            hideSubMenues();
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

        private void btnCategories_Click(object sender, EventArgs e)
        {
            openChildForm(new frmManageCategories());
            hideSubMenues();
        }

        private void btnBrands_Click(object sender, EventArgs e)
        {
            openChildForm(new frmManageBrands());
            hideSubMenues();
        }

        private void btnStores_Click(object sender, EventArgs e)
        {
            openChildForm(new frmManageStores());
            hideSubMenues();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAddProduct());
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAddCustomer());
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAddOrder());
        }

        private void pbAdmin_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAdminProfile(admin));
        }
    }
}
