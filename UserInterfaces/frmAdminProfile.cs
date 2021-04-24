using InventoryManagementApp.Data;
using InventoryManagementApp.DataClasses;
using InventoryManagementApp.Helpers;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace InventoryManagementApp.UserInterfaces
{
    public partial class frmAdminProfile : Form
    {
        private Administrator admin;

        public frmAdminProfile(Administrator admin)
        {
            InitializeComponent();
            this.admin = admin;
        }

        private void LoadGenders()
        {
            try
            {
                cmbGender.DataSource = InventoryManagementDb.DB.Genders.ToList();
                cmbGender.ValueMember = "Id";
                cmbGender.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                Messages.HandleException(ex);
            }
        }

        private void LoadAdminData()
        {
            if (admin != null)
            {
                txtFullName.Text = admin.FullName;
                txtUsername.Text = admin.Username;
                txtEmail.Text = admin.Email;
                txtTelephone.Text = $"{admin.Phone}";
                
                if (admin.Gender !=null)
                {
                    cmbGender.SelectedValue = admin.Gender.Id;
                }

                if (admin.ProfilePicture != null)
                {
                    pbProfilePicture.Image = Images.FromByteToImage(admin.ProfilePicture);
                }
            }
        }

        private void pbProfilePicture_Click(object sender, EventArgs e)
        {
            if (ofdProfilePicture.ShowDialog() == DialogResult.OK)
            {
                pbProfilePicture.Image = Image.FromFile(ofdProfilePicture.FileName);
            }
        }

        private void btnRemoveProfilePicture_Click(object sender, EventArgs e)
        {
            if (pbProfilePicture.Image != null)
            {
                pbProfilePicture.Image = null;
                admin.ProfilePicture = null;
            }

            InventoryManagementDb.DB.Entry(admin).State = System.Data.Entity.EntityState.Modified;
            InventoryManagementDb.DB.SaveChanges();
        }

        private void frmAdminProfile_Load(object sender, EventArgs e)
        {
            LoadGenders();
            LoadAdminData();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            frmPasswordChange frmPasswordChange = new frmPasswordChange(admin);
            frmPasswordChange.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                admin.FullName = txtFullName.Text;
                admin.Username = txtUsername.Text;
                admin.Email = txtEmail.Text;
                admin.Phone = int.Parse(txtTelephone.Text);

                if(pbProfilePicture.Image != null)
                {
                    admin.ProfilePicture = Images.FromImageToByte(pbProfilePicture.Image);
                }
                
                admin.Gender = cmbGender.SelectedItem as Gender;
          
                InventoryManagementDb.DB.Entry(admin).State = System.Data.Entity.EntityState.Modified;
                InventoryManagementDb.DB.SaveChanges();

                lblOperationInfo.Text = Messages.SuccessfullyModified;
            }
        }

        private bool ValidateData()
        {
            return Validator.ValidateControl(txtFullName, err, Messages.RequiredField)
                && Validator.ValidateControl(txtUsername, err, Messages.RequiredField)
                && Validator.ValidateControl(txtEmail, err, Messages.RequiredField)
                && Validator.ValidateNumber(txtTelephone, err, Messages.RequiredField);
        }
    }
}
