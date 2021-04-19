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
    public partial class frmAddCategory : Form
    {
        private Category category;
        private bool editCategory = true;

        public frmAddCategory()
        {
            InitializeComponent();
        }

        public frmAddCategory(Category category) : this()
        {
            this.category = category;
        }

        private void btnManageCategories_Click(object sender, EventArgs e)
        {
            Panel pnlChildForm = this.Parent as Panel;

            if (pnlChildForm != null)
            {
                frmManageCategories frmManageCategories = new frmManageCategories();
                frmManageCategories.FormBorderStyle = FormBorderStyle.None;
                frmManageCategories.TopLevel = false;
                frmManageCategories.BringToFront();

                pnlChildForm.Controls.Clear();
                pnlChildForm.Controls.Add(frmManageCategories);
                frmManageCategories.Show();
                this.Hide();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateCategoryData())
                {
                    if (category == null)
                    {
                        category = new Category();
                        editCategory = false;
                    }

                    category.CategoryName = txtCategoryName.Text;

                    if (editCategory)
                    {
                        InventoryManagementDb.DB.Entry(category).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        InventoryManagementDb.DB.Categories.Add(category);
                    }

                    InventoryManagementDb.DB.SaveChanges();
                    ClearData();

                    if (editCategory)
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
            txtCategoryName.Text = "";
        }

        private bool ValidateCategoryData()
        {
            return Validator.ValidateControl(txtCategoryName, err, Messages.RequiredField);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void frmAddCategory_Load(object sender, EventArgs e)
        {
            if (category != null)
            {
                lblEvidentCategory.Text = "Edit Category Info";
                LoadCategoryData();
            }
        }

        private void LoadCategoryData()
        {
            txtCategoryName.Text = category.CategoryName;
        }
    }
}
