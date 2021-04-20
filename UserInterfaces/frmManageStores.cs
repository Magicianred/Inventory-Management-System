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
    public partial class frmManageStores : Form
    {
        public frmManageStores()
        {
            InitializeComponent();
            dgvStores.AutoGenerateColumns = false;
        }

        private void frmManageStores_Load(object sender, EventArgs e)
        {
            LoadStores();
            LoadStatuses();
        }

        private void LoadStatuses()
        {
            try
            {
                cmbStatus.DataSource = InventoryManagementDb.DB.Statuses.ToList();
                cmbStatus.ValueMember = "Id";
                cmbStatus.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void LoadStores(List<Store> stores = null)
        {
            try
            {
                dgvStores.DataSource = null;
                dgvStores.DataSource = stores ?? InventoryManagementDb.DB.Stores.ToList();

                lblStoresNumber.Text = $"{(dgvStores.DataSource as List<Store>).Count()} stores";
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void btnAddStore_Click(object sender, EventArgs e)
        {
            Panel pnlChildForm = this.Parent as Panel;
            if (pnlChildForm != null)
            {
                frmAddStore frmAddStore = new frmAddStore();
                frmAddStore.FormBorderStyle = FormBorderStyle.None;
                frmAddStore.TopLevel = false;
                frmAddStore.BringToFront();

                pnlChildForm.Controls.Clear();
                pnlChildForm.Controls.Add(frmAddStore);
                frmAddStore.Show();
                this.Hide();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void dgvStores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var store = dgvStores.SelectedRows[0].DataBoundItem as Store;

                if (e.ColumnIndex == 2)
                {
                    Panel pnlChildForm = this.Parent as Panel;
                    if (pnlChildForm != null)
                    {
                        frmAddStore frmAddStore = new frmAddStore(store);
                        frmAddStore.FormBorderStyle = FormBorderStyle.None;
                        frmAddStore.TopLevel = false;
                        frmAddStore.BringToFront();

                        pnlChildForm.Controls.Clear();
                        pnlChildForm.Controls.Add(frmAddStore);
                        frmAddStore.Show();
                        this.Hide();
                    }

                }
                if (e.ColumnIndex == 3
                    && MessageBox.Show(Messages.Delete, Messages.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    InventoryManagementDb.DB.Stores.Remove(store);
                    InventoryManagementDb.DB.SaveChanges();

                    txtSearch.Text = "";
                }

                LoadStores();
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void Filter()
        {
            try
            {
                var filter = txtSearch.Text.ToLower();
                var status = cmbStatus.SelectedItem as Status;

                LoadStores(
                    InventoryManagementDb.DB.Stores.Where(
                        u => (u.Name.ToLower().Contains(filter)
                        || string.IsNullOrEmpty(filter))
                        && u.Status.Id == status.Id
                        ).ToList());
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }
    }
}
