using InventoryManagementApp.Data;
using InventoryManagementApp.DataClasses;
using InventoryManagementApp.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            LoadGenders();
            LoadCustomers();
        }

        private void LoadGenders()
        {
            try
            {
                cmbGenders.DataSource = InventoryManagementDb.DB.Genders.ToList();
                cmbGenders.ValueMember = "Id";
                cmbGenders.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
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
            OpenChildForm(new frmAddCustomer());
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var customer = dgvCustomers.SelectedRows[0].DataBoundItem as Customer;

                LoadOrdersData(customer);

                if (e.ColumnIndex == 3)
                {
                   OpenChildForm(new frmAddCustomer(customer));
                }

                if (e.ColumnIndex == 4
                    && MessageBox.Show(Messages.Delete, Messages.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    InventoryManagementDb.DB.Customers.Remove(customer);
                    InventoryManagementDb.DB.SaveChanges();

                    txtSearch.Text = "";
                    
                    LoadCustomers();
                }
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void LoadOrdersData(Customer customer)
        {
            if (customer!=null)
            {
                var customerOrders = InventoryManagementDb.DB.Orders.Where(o => o.Customer.Id == customer.Id).ToList();

                if (customerOrders.Count != 0)
                {
                    lblOrders.Text = $"{customerOrders.Count()}";
                    lblAmount.Text = $"{customerOrders.Sum(o => o.OrderTotal)}";
                    lblDate.Text = $"{customerOrders.Max(o => o.OrderDate.Date)}";
                }
                else
                {
                    lblOrders.Text = lblAmount.Text = lblDate.Text = $"{0}";
                }
            }
        }

        private void cmbGenders_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void Filter()
        {
            var filter = txtSearch.Text.ToLower();
            var gender = cmbGenders.SelectedItem as Gender;
            
            if (gender != null)
            {
                LoadCustomers(
                    InventoryManagementDb.DB.Customers.Where(
                        c => (c.FullName.ToLower().Contains(filter)
                        || c.Email.ToLower().Contains(filter)
                        || c.Phone.ToString().Contains(filter)
                        || string.IsNullOrEmpty(filter))
                        && gender.Id == c.Gender.Id
                        ).ToList());
            }
        }

        private void lblClearFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadCustomers();
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
