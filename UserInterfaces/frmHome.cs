using InventoryManagementApp.DataClasses;
using InventoryManagementApp.Users;
using System.Windows.Forms;

namespace InventoryManagementApp.UserInterfaces
{
    public partial class frmHome : Form
    {
        private Administrator admin;
        public frmHome(Administrator admin)
        {
            InitializeComponent();
            this.admin = admin;
        }

        private void frmHome_Load(object sender, System.EventArgs e)
        {
            
        }
    }
}
