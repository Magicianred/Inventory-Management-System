﻿using System;
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
    public partial class frmPrintOrder : Form
    {
        public frmPrintOrder(DataClasses.Order order)
        {
            InitializeComponent();
        }
    }
}