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
    public partial class frmManageBrands : Form
    {
        public frmManageBrands()
        {
            InitializeComponent();
            dgvBrands.AutoGenerateColumns = false;
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            Panel pnlChildForm = this.Parent as Panel;
            if (pnlChildForm != null)
            {
                frmAddBrand frmAddBrand = new frmAddBrand();
                frmAddBrand.FormBorderStyle = FormBorderStyle.None;
                frmAddBrand.TopLevel = false;
                frmAddBrand.BringToFront();

                pnlChildForm.Controls.Clear();
                pnlChildForm.Controls.Add(frmAddBrand);
                frmAddBrand.Show();
                this.Hide();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var filter = txtSearch.Text.ToLower();

                LoadBrands(
                    InventoryManagementDb.DB.Brands.Where(
                        u => u.Name.ToLower().Contains(filter)
                        || string.IsNullOrEmpty(filter)
                        ).ToList());
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void LoadBrands(List<Brand> brands = null)
        {
            try
            {
                dgvBrands.DataSource = null;
                dgvBrands.DataSource = brands ?? InventoryManagementDb.DB.Brands.ToList();

                lblBrandsNumber.Text = $"{(dgvBrands.DataSource as List<Brand>).Count()} brands";
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void dgvBrands_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var brand = dgvBrands.SelectedRows[0].DataBoundItem as Brand;

                if (e.ColumnIndex == 2)//not working
                {
                    Panel pnlChildForm = this.Parent as Panel;
                    if (pnlChildForm != null)
                    {
                        frmAddBrand frmAddBrand = new frmAddBrand(brand);
                        frmAddBrand.FormBorderStyle = FormBorderStyle.None;
                        frmAddBrand.TopLevel = false;
                        frmAddBrand.BringToFront();

                        pnlChildForm.Controls.Clear();
                        pnlChildForm.Controls.Add(frmAddBrand);
                        frmAddBrand.Show();
                        this.Hide();
                    }

                }
                if (e.ColumnIndex == 3
                    && MessageBox.Show(Messages.Delete, Messages.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    InventoryManagementDb.DB.Brands.Remove(brand);
                    InventoryManagementDb.DB.SaveChanges();

                    txtSearch.Text = "";
                }

                LoadBrands();
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void frmManageBrands_Load(object sender, EventArgs e)
        {
            LoadBrands();
        }
    }
}
