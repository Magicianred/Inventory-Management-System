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
    public partial class frmManageCustomers : Form
    {
        public frmManageCustomers()
        {
            InitializeComponent();
            dgvCustomers.AutoGenerateColumns = false;
        }

        private void frmManageCustomers_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers(List<Customer> customers = null)
        {
            try
            {
                dgvCustomers.DataSource = null;
                dgvCustomers.DataSource = customers ?? InventoryManagementDb.DB.Customers.ToList();

                lblCustomersNumber.Text = $"{(dgvCustomers.DataSource as List<Customer>).Count()} customers";
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            Panel pnlChildForm = this.Parent as Panel;
            if (pnlChildForm != null)
            {
                frmAddCustomer frmAddCustomer = new frmAddCustomer();
                frmAddCustomer.FormBorderStyle = FormBorderStyle.None;
                frmAddCustomer.TopLevel = false;
                frmAddCustomer.BringToFront();

                pnlChildForm.Controls.Clear();
                pnlChildForm.Controls.Add(frmAddCustomer);
                frmAddCustomer.Show();
                this.Hide();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var filter = txtSearch.Text.ToLower();

            LoadCustomers(
                InventoryManagementDb.DB.Customers.Where(
                    c => c.FullName.ToLower().Contains(filter)
                    || c.Email.ToLower().Contains(filter)
                    || c.Phone.ToString().ToLower().Contains(filter)
                    || string.IsNullOrEmpty(filter)
                    ).ToList());
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var customer = dgvCustomers.SelectedRows[0].DataBoundItem as Customer;

                if (e.ColumnIndex == 3)
                {
                    Panel pnlChildForm = this.Parent as Panel;
                    if (pnlChildForm != null)
                    {
                        frmAddCustomer frmAddCustomer = new frmAddCustomer(customer);
                        frmAddCustomer.FormBorderStyle = FormBorderStyle.None;
                        frmAddCustomer.TopLevel = false;
                        frmAddCustomer.BringToFront();

                        pnlChildForm.Controls.Clear();
                        pnlChildForm.Controls.Add(frmAddCustomer);
                        frmAddCustomer.Show();
                        this.Hide();
                    }

                }
                if (e.ColumnIndex == 4
                    && MessageBox.Show(Messages.Delete, Messages.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    InventoryManagementDb.DB.Customers.Remove(customer);
                    InventoryManagementDb.DB.SaveChanges();

                    txtSearch.Text = "";
                }

                LoadCustomers();
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }
    }
}
