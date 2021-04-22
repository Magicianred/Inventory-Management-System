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
    public partial class frmManageOrders : Form
    {
        public frmManageOrders()
        {
            InitializeComponent();
            dgvOrders.AutoGenerateColumns = false;
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            Panel pnlChildForm = this.Parent as Panel;

            if (pnlChildForm != null)
            {
                frmAddOrder frmAddOrder = new frmAddOrder();
                frmAddOrder.FormBorderStyle = FormBorderStyle.None;
                frmAddOrder.TopLevel = false;
                frmAddOrder.BringToFront();

                pnlChildForm.Controls.Clear();
                pnlChildForm.Controls.Add(frmAddOrder);
                frmAddOrder.Show();
                this.Hide();
            }
        }

        private void frmManageOrders_Load(object sender, EventArgs e)
        {
            LoadOrders();
            LoadCustomers();
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
            //try
            //{
            //    var filter = txtSearch.Text.ToLower();
            //    var date = dtpOrderDate.Value;
            //    var customer = cmbCustomers.SelectedItem as Customer;

            //    if (customer != null && date != null)
            //    {
            //        LoadOrders(
            //            InventoryManagementDb.DB.Orders.Where(o =>
            //                string.IsNullOrEmpty(filter)
            //                && date.Date <= o.OrderDate
            //                && o.Customer.Id == customer.Id
            //                ).ToList());
            //    }
            //    else
            //    {
            //        LoadCustomers();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Messages.HandleException(ex);
            //}
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var order = dgvOrders.SelectedRows[0].DataBoundItem as Order;
                if (e.ColumnIndex == 4)
                {
                    Panel pnlChildForm = this.Parent as Panel;

                    if (pnlChildForm != null)
                    {
                        frmAddOrder frmAddOrder = new frmAddOrder(order);
                        frmAddOrder.FormBorderStyle = FormBorderStyle.None;
                        frmAddOrder.TopLevel = false;
                        frmAddOrder.BringToFront();

                        pnlChildForm.Controls.Clear();
                        pnlChildForm.Controls.Add(frmAddOrder);
                        frmAddOrder.Show();
                        this.Hide();
                    }
                }
                if(e.ColumnIndex == 5)
                {
                    Panel pnlChildForm = this.Parent as Panel;

                    if (pnlChildForm != null)
                    {
                        frmPrintOrder frmPrintOrder = new frmPrintOrder(order);
                        frmPrintOrder.FormBorderStyle = FormBorderStyle.None;
                        frmPrintOrder.TopLevel = false;
                        frmPrintOrder.BringToFront();

                        pnlChildForm.Controls.Clear();
                        pnlChildForm.Controls.Add(frmPrintOrder);
                        frmPrintOrder.Show();
                        this.Hide();
                    }
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

        private void cmbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void lblClearFilter_Click(object sender, EventArgs e)
        {
            LoadCustomers();
        }
    }
}
