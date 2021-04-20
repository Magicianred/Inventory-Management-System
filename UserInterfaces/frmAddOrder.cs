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
    public partial class frmAddOrder : Form
    {
        private Order order;
        private bool editOrder = true;

        public frmAddOrder()
        {
            InitializeComponent();
        }

        public frmAddOrder(Order order)
        {
            this.order = order;
        }

        private void btnManageOrders_Click(object sender, EventArgs e)
        {
            Panel pnlChildForm = this.Parent as Panel;

            if (pnlChildForm != null)
            {
                frmManageOrders frmManageOrders = new frmManageOrders();
                frmManageOrders.FormBorderStyle = FormBorderStyle.None;
                frmManageOrders.TopLevel = false;
                frmManageOrders.BringToFront();

                pnlChildForm.Controls.Clear();
                pnlChildForm.Controls.Add(frmManageOrders);
                frmManageOrders.Show();
                this.Hide();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateOrderData())
                {
                    if (order == null)
                    {
                        order = new Order();
                        editOrder = false;
                    }

                    order.Customer = cmbCustomers.SelectedItem as Customer;
                    order.OrderDate = DateTime.Now;
                    

                    if (editOrder)
                    {
                        InventoryManagementDb.DB.Entry(order).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        InventoryManagementDb.DB.Orders.Add(order);
                    }

                    InventoryManagementDb.DB.SaveChanges();

                    if (editOrder)
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

        private bool ValidateOrderData()
        {
            return (cmbCustomers.SelectedItem as Customer != null); 
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

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
            cmbCustomers.SelectedValue = order.Customer.Id;
            LoadOrderDetails();
        }

        private void LoadOrderDetails()
        {

            try
            {
                var orderDetails = InventoryManagementDb.DB.OrderDetails.Where(o => o.Order.Id == order.Id);

                dgvStores.DataSource = null;
                dgvStores.DataSource = orderDetails;
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
                }
                frmAddOrderDetails frmAddOrderDetails = new frmAddOrderDetails(order);
                frmAddOrderDetails.ShowDialog();
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }
    }
}
