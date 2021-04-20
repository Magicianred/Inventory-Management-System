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
                //var category = cmbCategories.SelectedItem as Category;
                //var brand = cmbBrands.SelectedItem as Brand;

                //if (category != null && brand != null)
                //{
                    LoadOrders(
                        InventoryManagementDb.DB.Orders.Where(o =>
                            (o.Customer.FullName.ToLower().Contains(filter)
                            || string.IsNullOrEmpty(filter))
                            //&& (p.Category.Id == category.Id
                            //&& p.Brand.Id == brand.Id)
                            ).ToList());
                //}
                //else
                //{
                //    LoadProducts();
                //}
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
    }
}
