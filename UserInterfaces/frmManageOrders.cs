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
    public partial class frmManageOrders : Form
    {
        public frmManageOrders()
        {
            InitializeComponent();
            dgvOrders.AutoGenerateColumns = false;
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmAddOrder());
        }

        private void OpenChildForm(Form form)
        {
            Panel pnlChildForm = this.Parent as Panel;

            if (pnlChildForm != null)
            {
                if (form != null)
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

        private void frmManageOrders_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadOrders();
        }

        private void LoadCustomers()
        {
            try
            {
                cmbCustomers.DataSource = InventoryManagementDb.DB.Customers.ToList();
                cmbCustomers.ValueMember = "Id";
                cmbCustomers.DisplayMember = "FullName";
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void LoadOrders(List<Order> orders = null)
        {
            try
            {
                dgvOrders.DataSource = null;
                dgvOrders.DataSource = orders ?? InventoryManagementDb.DB.Orders.ToList();

                lblOrdersNumber.Text = $"{(dgvOrders.DataSource as List<Order>).Count()} orders";
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

        private void Filter()
        {
            try
            {
                var filter = txtSearch.Text.ToLower();
                var date = dtpOrderDate.Value;
                var customer = cmbCustomers.SelectedItem as Customer;

                if (customer != null && date != null)
                {
                    LoadOrders(
                        InventoryManagementDb.DB.Orders.Where(o =>
                            (string.IsNullOrEmpty(filter)
                            || o.Customer.FullName.ToLower().Contains(filter)
                            || o.Id.ToString().Contains(filter))
                            && date.Date <= o.OrderDate
                            && o.Customer.Id == customer.Id
                            ).ToList());
                }
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var order = dgvOrders.SelectedRows[0].DataBoundItem as Order;
                
                if (e.ColumnIndex == 4)
                {
                    OpenChildForm(new frmAddOrder(order));
                }

                if(e.ColumnIndex == 5)
                {
                   OpenChildForm(new frmPrintOrder(order)); 
                }

                if (e.ColumnIndex == 6
                    && MessageBox.Show(Messages.Delete, Messages.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    var orderItems = InventoryManagementDb.DB.OrderDetails.Where(o => o.Order.Id == order.Id).ToList();

                    foreach (var orderItem in orderItems)
                    {
                        InventoryManagementDb.DB.OrderDetails.Remove(orderItem);
                    }

                    InventoryManagementDb.DB.Orders.Remove(order);
                    InventoryManagementDb.DB.SaveChanges();
                }

                LoadOrders();
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void dtpOrderDate_ValueChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void lblClearFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadOrders();
        }

        private void cmbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }
    }
}
