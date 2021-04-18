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
    public partial class frmManageProducts : Form
    {
        public frmManageProducts()
        {
            InitializeComponent();
            dgvProducts.AutoGenerateColumns = false;
        }

        private void frmManageProducts_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        private void LoadCategories()
        {
            cmbCategorySearch.DataSource = InventoryManagementDb.DB.Categories.ToList();
            cmbCategorySearch.ValueMember = "Id";
            cmbCategorySearch.DisplayMember = "CategoryName";
        }

        private void LoadProducts(List<Product> products = null)
        {
            try
            {
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = products ?? InventoryManagementDb.DB.Products.ToList();
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
                if (ValidateProductData())
                {
                    //var category = cmbCategories.SelectedItem as Category;

                    //InventoryManagementDb.DB.Products.Add(
                    //     new Product()
                    //     {
                    //         ProductName = txtProductName.Text,
                    //         ProductQuantity = int.Parse(txtProductQuantity.Text),
                    //         ProductPrice = int.Parse(txtProductPrice.Text),
                    //         Description = txtDescription.Text,
                    //         Category = category
                    //     });
                    //InventoryManagementDb.DB.SaveChanges();

                    //MessageBox.Show(Messages.SuccessfullyAdded);

                    //ClearData();
                    //LoadProducts();
                }
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void ClearData()
        {
            //txtProductName.Text = txtProductQuantity.Text = txtProductPrice.Text = txtDescription.Text = "";
        }

        private bool ValidateProductData()
        {
            return true;
            //return Validator.ValidateControl(txtProductName, err, Messages.RequiredField)
            //    && Validator.ValidateControl(txtDescription, err, Messages.RequiredField)
            //    && Validator.ValidateNumber(txtProductQuantity, err, Messages.RequiredNumber)
            //    && Validator.ValidateNumber(txtProductPrice, err, Messages.RequiredNumber);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var product = dgvProducts.SelectedRows[0].DataBoundItem as Product;//TO-DO: make sure it's the same data of the selected user 
                                                                                      //TO-DD: You can't add new data and overwrite existing object, new form for adding and editing!!!
                if (ValidateProductData())
                {
                    //product.ProductName = txtProductName.Text;
                    //product.ProductQuantity = int.Parse(txtProductQuantity.Text);
                    //product.ProductPrice = int.Parse(txtProductPrice.Text);
                    //product.Description = txtDescription.Text;
                    //product.Category = (cmbCategories.SelectedItem as Category);

                    //InventoryManagementDb.DB.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    //InventoryManagementDb.DB.SaveChanges();

                    //LoadProducts();

                    //MessageBox.Show(Messages.SuccessfullyModified);
                    //ClearData();
                }
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var product = dgvProducts.SelectedRows[0].DataBoundItem as Product;

                foreach (var item in InventoryManagementDb.DB.Products)
                {
                    if (item.Id == product.Id
                        && MessageBox.Show(Messages.Delete,
                        Messages.Question,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question)
                        == DialogResult.Yes)
                    {
                        InventoryManagementDb.DB.Products.Remove(item);
                        InventoryManagementDb.DB.SaveChanges();

                        LoadProducts();
                        MessageBox.Show(Messages.SuccessfullyDeleted);
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var product = dgvProducts.SelectedRows[0].DataBoundItem as Product;
                if (e.ColumnIndex == 5)
                {
                    frmAddProduct frmAddProduct = new frmAddProduct(product);
                    frmAddProduct.Show();
                }
                if (e.ColumnIndex == 6
                    && MessageBox.Show(Messages.Delete, Messages.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    InventoryManagementDb.DB.Products.Remove(product);
                    InventoryManagementDb.DB.SaveChanges();
                }

                LoadProducts();
                //txtProductName.Text = product.ProductName;
                //txtProductQuantity.Text = $"{product.ProductQuantity}";  
                //txtProductPrice.Text = $"{product.ProductPrice}";
                //txtDescription.Text = product.Description;
                //cmbCategories.SelectedValue = product.Category.Id; 
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void cmbCategorySearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void Filter()
        {
            try
            {
                var filter = txtSearch.Text.ToLower();
                var category = cmbCategorySearch.SelectedItem as Category;

                LoadProducts(
                    InventoryManagementDb.DB.Products.Where(p =>
                        (p.ProductName.ToLower().Contains(filter)
                        || p.Description.ToLower().Contains(filter)
                        || string.IsNullOrEmpty(filter))
                        && p.Category.Id == category.Id).ToList());
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }
    }
}
