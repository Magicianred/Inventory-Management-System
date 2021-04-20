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
    public partial class frmAddStore : Form
    {
        private Store store;
        private bool editStore = true;

        public frmAddStore()
        {
            InitializeComponent();
        }

        public frmAddStore(Store store) : this()
        {
            this.store = store;
        }

        private void frmAddStore_Load(object sender, EventArgs e)
        {
            LoadStatuses();

            if (store != null)
            {
                lblEvidentStore.Text = "Edit Store Info";
                LoadStoreData();
            }
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

        private void LoadStoreData()
        {
            txtStoreName.Text = store.Name;
            cmbStatus.SelectedValue = store.Status.Id;
        }

        private void btnManageStores_Click(object sender, EventArgs e)
        {
            Panel pnlChildForm = this.Parent as Panel;

            if (pnlChildForm != null)
            {
                frmManageStores frmManageStores = new frmManageStores();
                frmManageStores.FormBorderStyle = FormBorderStyle.None;
                frmManageStores.TopLevel = false;
                frmManageStores.BringToFront();

                pnlChildForm.Controls.Clear();
                pnlChildForm.Controls.Add(frmManageStores);
                frmManageStores.Show();
                this.Hide();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateStoreData())
                {
                    if (store == null)
                    {
                        store = new Store();
                        editStore = false;
                    }

                    store.Name = txtStoreName.Text;
                    store.Status = cmbStatus.SelectedItem as Status;

                    if (editStore)
                    {
                        InventoryManagementDb.DB.Entry(store).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        InventoryManagementDb.DB.Stores.Add(store);
                    }

                    InventoryManagementDb.DB.SaveChanges();
                    ClearData();

                    if (editStore)
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
            txtStoreName.Text = "";
        }

        private bool ValidateStoreData()
        {
            return Validator.ValidateControl(txtStoreName, err, Messages.RequiredField);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }
    }
}
