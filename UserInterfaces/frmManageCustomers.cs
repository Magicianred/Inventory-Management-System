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
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateCustomerData())
                {
                    InventoryManagementDb.DB.Customers.Add(
                         new Customer()
                         {
                             FullName = txtCustomerName.Text,
                             Phone = int.Parse(txtCustomerPhone.Text)
                         });
                    InventoryManagementDb.DB.SaveChanges();

                    MessageBox.Show(Messages.SuccessfullyAdded);

                    ClearData();
                    LoadCustomers();
                }
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void ClearData()
        {
            txtCustomerName.Text = txtCustomerPhone.Text = "";
        }

        private bool ValidateCustomerData()
        {
            return Validator.ValidateControl(txtCustomerName, err, Messages.RequiredField)
             && Validator.ValidateNumber(txtCustomerPhone, err, Messages.RequiredNumber);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var customer = dgvCustomers.SelectedRows[0].DataBoundItem as Customer;

            try
            {
                foreach (var item in InventoryManagementDb.DB.Customers)
                {
                    if (item.Id == customer.Id
                        && MessageBox.Show(Messages.Delete,
                        Messages.Question,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question)
                        == DialogResult.Yes)
                    {
                        InventoryManagementDb.DB.Customers.Remove(item);
                        InventoryManagementDb.DB.SaveChanges();

                        LoadCustomers();
                        MessageBox.Show(Messages.SuccessfullyDeleted);
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var customer = dgvCustomers.SelectedRows[0].DataBoundItem as Customer;//TO-DO: make sure it's the same user(data of the selected user) 
                                                                                      //TO-DD: You can't add new data and overwrite existing object, new form for adding and editing!!!
                if (ValidateCustomerData())
                {
                    customer.FullName = txtCustomerName.Text;
                    customer.Phone= int.Parse(txtCustomerPhone.Text);

                    InventoryManagementDb.DB.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                    InventoryManagementDb.DB.SaveChanges();
                    
                    LoadCustomers();

                    MessageBox.Show(Messages.SuccessfullyModified);
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var customer = dgvCustomers.SelectedRows[0].DataBoundItem as Customer;

                txtCustomerName.Text = customer.FullName;
                txtCustomerPhone.Text = $"{customer.Phone}";
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }
    }
}
