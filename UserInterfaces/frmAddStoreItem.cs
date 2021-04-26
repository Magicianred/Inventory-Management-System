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
    public partial class frmAddStoreItem : Form
    {
        private StoreDetails storeDetail;
        private Store store;
        private bool itemExists = false;

        public frmAddStoreItem(Store store)
        {
            InitializeComponent();

            this.store = store;
            nUnitsInStock.Minimum = 1;
        }

        public frmAddStoreItem(StoreDetails storeDetail)
        {
            if (storeDetail != null)
            {
                this.storeDetail = storeDetail;
                this.store = storeDetail.Store;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateItemData())
                {
                    lblCheckInput.Text = "";

                    var product = (cmbProducts.SelectedItem as Product);
                    var storeItems = InventoryManagementDb.DB.StoreDetails.Where(sd => sd.Store.Id == store.Id).ToList();

                    foreach (var storeItem in storeItems)
                    {
                        if (storeItem.Product.ProductName == product.ProductName)
                        {
                            storeItem.UnitsInStock += int.Parse(nUnitsInStock.Value.ToString());

                            InventoryManagementDb.DB.Entry(storeItem).State = System.Data.Entity.EntityState.Modified;
                            itemExists = true;
                        }
                    }

                    if (!itemExists)
                    {
                        InventoryManagementDb.DB.StoreDetails.Add(
                            new StoreDetails()
                            {
                                Product = product,
                                UnitsInStock = int.Parse(nUnitsInStock.Value.ToString()),
                                Store = store
                            });
                    }
                    InventoryManagementDb.DB.SaveChanges();
                    Close();
                }
                else
                {
                    lblCheckInput.Text = Messages.CheckInput;
                }
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private bool ValidateItemData()
        {
            return cmbProducts.SelectedItem != null
                && nUnitsInStock.Value > 0;
        }

        private void frmAddStoreItem_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                cmbProducts.DataSource = InventoryManagementDb.DB.Products.ToList();
                cmbProducts.ValueMember = "Id";
                cmbProducts.DisplayMember = "ProductName";
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }
    }
}
