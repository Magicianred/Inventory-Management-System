using InventoryManagementApp.Data;
using InventoryManagementApp.DataClasses;
using InventoryManagementApp.Helpers;
using System;
using System.Linq;
using System.Windows.Forms;

namespace InventoryManagementApp.UserInterfaces
{
    public partial class frmAddProduct : Form
    {
        private Product product;
        private bool editProduct = true;

        public frmAddProduct()
        {
            InitializeComponent();
        }

        public frmAddProduct(Product product) : this()
        {
            this.product = product;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateProductData())
                {
                    if (product == null)
                    {
                        product = new Product();
                        editProduct = false;
                    }

                    product.ProductName = txtProductName.Text;
                    product.ProductQuantity = int.Parse(txtProductQuantity.Text);
                    product.ProductPrice = float.Parse(txtProductPrice.Text);
                    product.Description = txtDescription.Text;
                    product.Category = cmbCategories.SelectedItem as Category;
                    product.Brand = cmbBrands.SelectedItem as Brand;
                    product.Store = cmbStores.SelectedItem as Store;

                    if (editProduct)
                    {
                        InventoryManagementDb.DB.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        InventoryManagementDb.DB.Products.Add(product);
                    }

                    InventoryManagementDb.DB.SaveChanges();
                    ClearData();

                    if (editProduct)
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
            txtProductName.Text = txtProductQuantity.Text = txtProductPrice.Text = txtDescription.Text = "";
        }

        private bool ValidateProductData()
        {
            return Validator.ValidateControl(txtProductName, err, Messages.RequiredField)
                && Validator.ValidateNumber(txtProductQuantity, err, Messages.RequiredNumber)
                && Validator.ValidateNumber(txtProductPrice, err, Messages.RequiredNumber)
                && Validator.ValidateControl(txtDescription, err, Messages.RequiredField);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadBrands();
            LoadStores();

            if (product != null)
            {
                lblEvidentProduct.Text = "Edit Product Info";
                LoadProductData();
            }
        }

        private void LoadStores()
        {
            try
            {
                cmbStores.DataSource = InventoryManagementDb.DB.Stores.ToList();
                cmbStores.ValueMember = "Id";
                cmbStores.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void LoadBrands()
        {
            try
            {
                cmbBrands.DataSource = InventoryManagementDb.DB.Brands.ToList();
                cmbBrands.ValueMember = "Id";
                cmbBrands.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void LoadCategories()
        {
            try
            {
                cmbCategories.DataSource = InventoryManagementDb.DB.Categories.ToList();
                cmbCategories.ValueMember = "Id";
                cmbCategories.DisplayMember = "CategoryName";
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void LoadProductData()
        {
            txtProductName.Text = product.ProductName;
            txtProductQuantity.Text = $"{product.ProductQuantity}";
            txtProductPrice.Text = $"{product.ProductPrice}";
            txtDescription.Text = product.Description;
            cmbCategories.SelectedValue = product.Category.Id;
            cmbBrands.SelectedValue = product.Brand.Id;
            cmbStores.SelectedValue = product.Store.Id;
        }

        private void btnManageProducts_Click(object sender, EventArgs e)
        {
            Panel pnlChildForm = this.Parent as Panel;

            if (pnlChildForm != null)
            {
                frmManageProducts frmManageProducts = new frmManageProducts();
                frmManageProducts.FormBorderStyle = FormBorderStyle.None;
                frmManageProducts.TopLevel = false;
                frmManageProducts.BringToFront();

                pnlChildForm.Controls.Clear();
                pnlChildForm.Controls.Add(frmManageProducts);
                frmManageProducts.Show();
                this.Hide();
            }
        }
    }
}