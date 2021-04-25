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
    public partial class frmAddOrder : Form
    {
        private Order order;
        private bool editOrder = true;

        public frmAddOrder()
        {
            InitializeComponent();
            dgvOrderDetails.AutoGenerateColumns = false;
        }

        public frmAddOrder(Order order) : this()
        {
            this.order = order;
        }

        private void btnManageOrders_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmManageOrders());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (order != null)
                {
                    var orderItems = InventoryManagementDb.DB.OrderDetails.Where(o => o.Order.Id == order.Id).ToList();

                    if (ValidateOrderData() && orderItems.Count > 0)
                    {
                        order.Customer = cmbCustomers.SelectedItem as Customer;
                        order.OrderDate = DateTime.Now;
                        order.OrderTotal = orderItems.Sum(od => od.TotalAmount);

                        InventoryManagementDb.DB.Entry(order).State = System.Data.Entity.EntityState.Modified;
                        InventoryManagementDb.DB.SaveChanges();

                        if (editOrder)
                            lblOperationInfo.Text = Messages.SuccessfullyModified;
                        else
                            lblOperationInfo.Text = Messages.SuccessfullyAdded;
                    }
                    else
                    {
                        InvalidOrder();
                    }
                }
                else
                {
                    InvalidOrder();
                }
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void InvalidOrder()
        {
            try
            {
                btnMakeOrder.Enabled = false;
                lblEmptyOrder.Text = Messages.EmptyOrder;

                if (order != null)
                {
                    InventoryManagementDb.DB.Orders.Remove(order);
                    InventoryManagementDb.DB.SaveChanges();
                    order = null;
                    btnMakeOrder.Text = "Make Order";
                }
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private bool ValidateOrderData()
        {
            return (cmbCustomers.SelectedItem as Customer != null); 
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void ClearData()
        {
            try
            {
                var orderDetails = dgvOrderDetails.DataSource as List<OrderDetails>;

                foreach (var od in orderDetails)
                {
                    InventoryManagementDb.DB.OrderDetails.Remove(od);
                    InventoryManagementDb.DB.SaveChanges();
                }

                LoadOrderDetails();
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void frmAddOrder_Load(object sender, EventArgs e)
        {
            LoadCustomers();

            if (order != null)
            {
                lblEvidentOrder.Text = "Edit Product Info";
                LoadOrderData();
            }
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

        private void LoadOrderData()
        {
            btnMakeOrder.Text = "Update Order";
            cmbCustomers.SelectedValue = order.Customer.Id;
            LoadOrderDetails();
        }

        private void LoadOrderDetails()
        {
            try
            {
                var orderDetails = InventoryManagementDb.DB.OrderDetails.Where(o => o.Order.Id == order.Id).ToList();

                dgvOrderDetails.DataSource = null;
                dgvOrderDetails.DataSource = orderDetails;
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (order == null)
                {
                    order = new Order()
                    {
                        Customer = (cmbCustomers.SelectedItem as Customer),
                        OrderDate = DateTime.Now,
                        OrderTotal = 0
                    };
                    editOrder = false;

                    InventoryManagementDb.DB.Orders.Add(order);
                    InventoryManagementDb.DB.SaveChanges();
                }

                frmAddOrderDetails frmAddOrderDetails = new frmAddOrderDetails(order);
                Backgrounds.LoadFormBackground(frmAddOrderDetails);

                var orderItems = InventoryManagementDb.DB.OrderDetails.Where(o => o.Order.Id == order.Id).ToList();

                if (orderItems.Count > 0)
                {
                    LoadOrderDetails();
                    btnMakeOrder.Enabled = true;
                    lblEmptyOrder.Text = "";
                }
                else
                {
                    InventoryManagementDb.DB.Orders.Remove(order);
                    InventoryManagementDb.DB.SaveChanges();

                    order = null;
                    editOrder = false;
                }

            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void dgvOrderDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var orderDetails = dgvOrderDetails.SelectedRows[0].DataBoundItem as OrderDetails;

                if (e.ColumnIndex == 5)
                {
                    OpenChildForm(new frmAddOrderDetails(orderDetails));
                }

                if (e.ColumnIndex == 6
                    && MessageBox.Show(Messages.Delete, Messages.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    InventoryManagementDb.DB.OrderDetails.Remove(orderDetails);
                    InventoryManagementDb.DB.SaveChanges();
                }

                LoadOrderDetails();
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
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
    }
}
