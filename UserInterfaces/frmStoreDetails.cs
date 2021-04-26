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
    public partial class frmStoreDetails : Form
    {
        private Store store;

        public frmStoreDetails(Store store)
        {
            InitializeComponent();

            this.store = store;
            dgvStoreDetails.AutoGenerateColumns = false;
        }

        private void frmStoreDetails_Load(object sender, EventArgs e)
        {
            if (store != null) 
            {
                LoadStoreDetails();
            }
        }

        private void LoadStoreDetails()
        {
            lblStoreName.Text = store.Name;

            try
            {
                var storeDetails = InventoryManagementDb.DB.StoreDetails.Where(sd => sd.Store.Id == store.Id).ToList();

                dgvStoreDetails.DataSource = null;
                dgvStoreDetails.DataSource = storeDetails;

                lblProductsNumber.Text = $"{storeDetails.Count()} available products";
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void dgvStoreDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var storeDetail = dgvStoreDetails.SelectedRows[0].DataBoundItem as StoreDetails;

                if (e.ColumnIndex == 2
                    && MessageBox.Show(Messages.Delete, Messages.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    InventoryManagementDb.DB.StoreDetails.Remove(storeDetail);
                    InventoryManagementDb.DB.SaveChanges();
                }

                LoadStoreDetails();
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (store != null)
            {
                Backgrounds.LoadFormBackground(new frmAddStoreItem(store));
                LoadStoreDetails();
            }
        }

        private void btnManageStores_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmManageStores());
        }

        private void OpenChildForm(Form form)
        {
            Panel pnlChildForm = this.Parent as Panel;
            if (pnlChildForm != null)
            {
                form.FormBorderStyle = FormBorderStyle.None;
                form.TopLevel = false;
                form.BringToFront();

                pnlChildForm.Controls.Clear();
                pnlChildForm.Controls.Add(form);
                form.Show();
                this.Hide();
            }
        }
    }
}
