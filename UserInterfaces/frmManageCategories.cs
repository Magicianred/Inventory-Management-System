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
    public partial class frmManageCategories : Form
    {
        public frmManageCategories()
        {
            InitializeComponent();
        }

        private void frmManageCategories_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories(List<Category> categories = null)
        {
            try
            {
                dgvCategories.DataSource = null;
                dgvCategories.DataSource = categories ?? InventoryManagementDb.DB.Categories.ToList();

                lblCategories.Text = $"{(dgvCategories.DataSource as List<Category>).Count()} categories";
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateCategoryData())
                {
                    InventoryManagementDb.DB.Categories.Add(
                         new Category()
                         {
                             CategoryName = txtCategoryName.Text
                         });
                    InventoryManagementDb.DB.SaveChanges();

                    MessageBox.Show(Messages.SuccessfullyAdded);

                    ClearData();
                    LoadCategories();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var category = dgvCategories.SelectedRows[0].DataBoundItem as Category;

            try
            {
                foreach (var item in InventoryManagementDb.DB.Categories)
                {
                    if (item.Id == category.Id
                        && MessageBox.Show(Messages.Delete,
                        Messages.Question,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question)
                        == DialogResult.Yes)
                    {
                        InventoryManagementDb.DB.Categories.Remove(item);
                        InventoryManagementDb.DB.SaveChanges();

                        LoadCategories();
                        MessageBox.Show(Messages.SuccessfullyDeleted);
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var category = dgvCategories.SelectedRows[0].DataBoundItem as Category;//TO-DO: make sure it's the same user(data of the selected user) 

                if (ValidateCategoryData())
                {
                    category.CategoryName = txtCategoryName.Text;

                    InventoryManagementDb.DB.Entry(category).State = System.Data.Entity.EntityState.Modified;
                    InventoryManagementDb.DB.SaveChanges();

                    LoadCategories();

                    MessageBox.Show(Messages.SuccessfullyModified);
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var category = dgvCategories.SelectedRows[0].DataBoundItem as Category;

                if (e.ColumnIndex == 2)
                {
                    Panel pnlChildForm = this.Parent as Panel;
                    if (pnlChildForm != null)
                    {
                        frmAddCategory frmAddCategory = new frmAddCategory(category)
                        {
                            FormBorderStyle = FormBorderStyle.None,
                            TopLevel = false
                        };
                        frmAddCategory.BringToFront();

                        pnlChildForm.Controls.Clear();
                        pnlChildForm.Controls.Add(frmAddCategory);
                        frmAddCategory.Show();
                        this.Hide();
                    }

                }
                if (e.ColumnIndex == 3
                    && MessageBox.Show(Messages.Delete, Messages.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    InventoryManagementDb.DB.Categories.Remove(category);
                    InventoryManagementDb.DB.SaveChanges();

                    txtSearch.Text = "";
                }

                LoadCategories();
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            Panel pnlChildForm = this.Parent as Panel;
            if (pnlChildForm != null)
            {
                frmAddCategory frmAddCategory = new frmAddCategory();
                frmAddCategory.FormBorderStyle = FormBorderStyle.None;
                frmAddCategory.TopLevel = false;
                frmAddCategory.BringToFront();

                pnlChildForm.Controls.Clear();
                pnlChildForm.Controls.Add(frmAddCategory);
                frmAddCategory.Show();
                this.Hide();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var filter = txtSearch.Text.ToLower();

            LoadCategories(
                InventoryManagementDb.DB.Categories.Where(
                    u => u.CategoryName.ToLower().Contains(filter)
                    || string.IsNullOrEmpty(filter)
                    ).ToList());
        }
    }
}
