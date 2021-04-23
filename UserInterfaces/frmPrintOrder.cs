using InventoryManagementApp.Data;
using InventoryManagementApp.DataClasses;
using InventoryManagementApp.DataRepository;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static InventoryManagementApp.DataRepository.dsOrderDetails;

namespace InventoryManagementApp.UserInterfaces
{
    public partial class frmPrintOrder : Form
    {
        private Order order;

        public frmPrintOrder(DataClasses.Order order)
        {
            InitializeComponent();
            this.order = order;
        }

        private void frmPrintOrder_Load(object sender, EventArgs e)
        {
            if (order != null)
            {
                var rpc = new ReportParameterCollection();
                rpc.Add(new ReportParameter("OrderId", $"{order.Id}"));
                rpc.Add(new ReportParameter("Customer", $"{order.Customer}"));
                rpc.Add(new ReportParameter("OrderDate", $"{order.OrderDate}"));
                rpc.Add(new ReportParameter("OrderTotal", $"{order.OrderTotal}"));

                var orderItems = InventoryManagementDb.DB.OrderDetails.Where(od => od.Order.Id == order.Id).ToList();

                var tblOrderItems = new OrderDetailsDataTable();

                foreach (var orderItem in orderItems)
                {
                    var row = tblOrderItems.NewOrderDetailsRow();

                    row.Product = $"{orderItem.Product}";
                    row.ProductPrice = orderItem.ProductPrice;
                    row.ProductQuantity = orderItem.ProductQuantity;
                    row.TotalAmount = orderItem.TotalAmount;

                    tblOrderItems.Rows.Add(row);
                }

                var rds = new ReportDataSource();
                rds.Name = "dSetOrder";
                rds.Value = tblOrderItems;

                reportViewer1.LocalReport.SetParameters(rpc);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
