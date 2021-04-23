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
    public partial class frmAdminProfile : Form
    {
        public frmAdminProfile(DataClasses.Administrator admin)
        {
            InitializeComponent();
        }
    }
}
