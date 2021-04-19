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
    public partial class frmAddBrand : Form
    {
        private Brand brand;
        private bool editBrand = true;

        public frmAddBrand()
        {
            InitializeComponent();
        }

        public frmAddBrand(Brand brand) : this()
        {
            this.brand = brand;
        }

        private void btnManageBrands_Click(object sender, EventArgs e)
        {
            Panel pnlChildForm = this.Parent as Panel;

            if (pnlChildForm != null)
            {
                frmManageBrands frmManageBrands = new frmManageBrands();
                frmManageBrands.FormBorderStyle = FormBorderStyle.None;
                frmManageBrands.TopLevel = false;
                frmManageBrands.BringToFront();

                pnlChildForm.Controls.Clear();
                pnlChildForm.Controls.Add(frmManageBrands);
                frmManageBrands.Show();
                this.Hide();
            }
        }

        private void frmAddBrand_Load(object sender, EventArgs e)
        {
            if (brand != null)
            {
                lblEvidentBrand.Text = "Edit Brand Info";
                LoadBrandData();
            }
        }

        private void LoadBrandData()
        {
            txtBrandName.Text = brand.Name;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateBrandData())
                {
                    if (brand == null)
                    {
                        brand = new Brand();
                        editBrand = false;
                    }

                    brand.Name = txtBrandName.Text;

                    if (editBrand)
                    {
                        InventoryManagementDb.DB.Entry(brand).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        InventoryManagementDb.DB.Brands.Add(brand);
                    }

                    InventoryManagementDb.DB.SaveChanges();
                    ClearData();

                    if (editBrand)
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
            txtBrandName.Text = "";
        }

        private bool ValidateBrandData()
        {
            return Validator.ValidateControl(txtBrandName, err, Messages.RequiredField);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }
    }
}
