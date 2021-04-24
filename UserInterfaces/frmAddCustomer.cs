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
    public partial class frmAddCustomer : Form
    {
        private Customer customer;
        private bool editCustomer = true;

        public frmAddCustomer()
        {
            InitializeComponent();
        }

        public frmAddCustomer(Customer customer) : this()
        {
            this.customer = customer;
        }

        private void frmAddCustomer_Load(object sender, EventArgs e)
        {
            LoadGenders();

            if (customer != null)
            {
                lblEvidentCustomer.Text = "Edit User Info";
                LoadCustomerData();
            }
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

        private void LoadCustomerData()
        {
            txtFullName.Text = customer.FullName;
            txtEmail.Text = customer.Email;
            txtPhone.Text = $"{customer.Phone}";
            cmbGenders.SelectedValue = customer.Gender.Id;
        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            Panel pnlChildForm = this.Parent as Panel;

            if (pnlChildForm != null)
            {
                frmManageCustomers frmManageCustomers = new frmManageCustomers();
                frmManageCustomers.FormBorderStyle = FormBorderStyle.None;
                frmManageCustomers.TopLevel = false;
                frmManageCustomers.BringToFront();

                pnlChildForm.Controls.Clear();
                pnlChildForm.Controls.Add(frmManageCustomers);
                frmManageCustomers.Show();
                this.Hide();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var gender = cmbGenders.SelectedItem as Gender;
                if (ValidateCustomerData() && gender != null) 
                {
                    if (customer == null)
                    {
                        customer = new Customer();
                        editCustomer = false;
                    }

                    customer.FullName = txtFullName.Text;
                    customer.Email = txtEmail.Text;
                    customer.Phone = int.Parse(txtPhone.Text);
                    customer.Gender = gender;

                    if (editCustomer)
                    {
                        InventoryManagementDb.DB.Entry(customer).State = System.Data.Entity.EntityState.Modified;

                    }
                    else
                    {
                        InventoryManagementDb.DB.Customers.Add(customer);
                    }

                    InventoryManagementDb.DB.SaveChanges();
                    ClearData();

                    if (editCustomer)
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

        private void ClearData()
        {
            txtFullName.Text =  txtEmail.Text = txtPhone.Text = "";
        }

        private bool ValidateCustomerData()
        {
            return Validator.ValidateControl(txtFullName, err, Messages.RequiredField)
               && Validator.ValidateControl(txtEmail, err, Messages.RequiredField)
               && Validator.ValidateNumber(txtPhone, err, Messages.RequiredNumber);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }
    }
}
