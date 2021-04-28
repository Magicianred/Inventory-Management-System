using InventoryManagementApp.Data;
using InventoryManagementApp.DataClasses;
using InventoryManagementApp.DataRepository;
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
            InventoryManagementTemporaryBase.orderItems.Clear();
        }

        public frmAddOrder(Order order) : this()
        {
            this.order = order;
            LoadItems();
        }

        private void LoadItems()
        {
            var orderItems = InventoryManagementDb.DB.OrderDetails.Where(od => od.Order.Id == order.Id);

            foreach (var orderItem in orderItems)
            {
                InventoryManagementTemporaryBase.orderItems.Add(
                    new OrderItem()
                    {
                        Product = orderItem.Product,
                        ProductPrice = orderItem.ProductPrice,
                        ProductQuantity = orderItem.ProductQuantity,
                        TotalAmount = orderItem.TotalAmount
                    });
            }
        }

        private void btnManageOrders_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmManageOrders());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var orderItems = InventoryManagementTemporaryBase.orderItems;
                
                if (orderItems.Count > 0 && ValidateOrderData()) 
                { 
                    if (order == null)
                    {
                        order = new Order();
                        order.OrderDate = DateTime.Now;
                        editOrder = false;
                    }

                    order.Customer = (cmbCustomers.SelectedItem as Customer);
                    order.OrderTotal = orderItems.Sum(od=>od.TotalAmount);

                    if (editOrder)
                    {
                        InventoryManagementDb.DB.Entry(order).State = System.Data.Entity.EntityState.Modified;
                        lblOperationInfo.Text = Messages.SuccessfullyModified;
                    }
                    else
                    {
                        InventoryManagementDb.DB.Orders.Add(order);
                        lblOperationInfo.Text = Messages.SuccessfullyAdded;
                    }

                    //add items to order
                    foreach (var orderItem in orderItems)
                    {
                        if (!ItemExists(orderItem))
                        {
                            InventoryManagementDb.DB.OrderDetails.Add(
                                new OrderDetails()
                                {
                                    Order = order,
                                    Product = orderItem.Product,
                                    ProductQuantity = orderItem.ProductQuantity,
                                    ProductPrice = orderItem.ProductPrice,
                                    TotalAmount = orderItem.TotalAmount
                                });
                        }
                    }

                    //orderItems.Clear();
                    InventoryManagementDb.DB.SaveChanges();
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

        private bool ItemExists(OrderItem orderItem)
        {
            var orderDetails = InventoryManagementDb.DB.OrderDetails.Where(od => od.Order.Id == order.Id).ToList();

            foreach (var od in orderDetails)
            {
                if(od.Product == orderItem.Product)
                {
                    od.ProductQuantity = orderItem.ProductQuantity;
                    od.TotalAmount = orderItem.TotalAmount;
                    InventoryManagementDb.DB.Entry(od).State = System.Data.Entity.EntityState.Modified;

                    return true;
                }
            }

            return false;
        }

        private void InvalidOrder()
        {
            try
            {
                btnMakeOrder.Enabled = false;
                lblEmptyOrder.Text = Messages.EmptyOrder;
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
                InventoryManagementTemporaryBase.orderItems.Clear();
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
                var orderDetails = InventoryManagementTemporaryBase.orderItems;

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
                frmAddOrderDetails frmAddOrderDetails = new frmAddOrderDetails();
                Backgrounds.LoadFormBackground(frmAddOrderDetails);

                if (InventoryManagementTemporaryBase.orderItems.Count > 0)
                {
                    LoadOrderDetails();
                    btnMakeOrder.Enabled = true;
                    lblEmptyOrder.Text = "";
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
                var orderItem = dgvOrderDetails.SelectedRows[0].DataBoundItem as OrderItem;

                if (e.ColumnIndex == 4
                    && MessageBox.Show(Messages.Delete, Messages.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    InventoryManagementTemporaryBase.orderItems.Remove(orderItem);
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
