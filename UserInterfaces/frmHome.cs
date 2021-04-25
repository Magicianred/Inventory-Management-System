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
            HideSubMenues();
        }

        private void frmHome_Load(object sender, System.EventArgs e)
        {
            CustomizeDesign();
            LoadAdminData();

            OpenChildForm(new frmDashboard());
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlChildForm.Controls.Add(childForm);
            pnlChildForm.Tag = childForm;
            
            childForm.BringToFront();
            childForm.Show();

            LoadAdminData();
        }
        private void HideSubMenues()
        {
            pnlUsers.Visible = false;
            pnlProducts.Visible = false;
            pnlCustomers.Visible = false;
            pnlOrders.Visible = false;
        }

        private void lblMoreProductInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenChildForm(new frmManageProducts());
        }

        private void lblUsersInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenChildForm(new frmManageUsers());
        }

        private void lblOrdersInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenChildForm(new frmManageOrders());
        }

        private void lblCustomersInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenChildForm(new frmManageCustomers());
        }

        private void lblStoresInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenChildForm(new frmManageStores());
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            ShowSubMenu(pnlUsers);
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

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmManageUsers());
        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmManageCustomers());
        }

        private void btnManageOrders_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmManageOrders());
        }

        private void btnManageProducts_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmManageProducts());
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmAddUser());
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmAddProduct());
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmAddCustomer());
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmAddOrder());
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmManageCategories());
            HideSubMenues();
        }

        private void btnBrands_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmManageBrands());
            HideSubMenues();
        }

        private void btnStores_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmManageStores());
            HideSubMenues();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDashboard());
            HideSubMenues();
        }

        private void pbAdmin_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmAdminProfile(admin));
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
        }
        
        private void ShowSubMenu(Panel subMenu)
        {
            if(!subMenu.Visible)
            {
                HideSubMenues();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
