namespace InventoryManagementApp.UserInterfaces
{
    partial class frmManageOrders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.lblOrders = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblClearFilter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCustomers = new System.Windows.Forms.ComboBox();
            this.lblOrdersNumber = new System.Windows.Forms.Label();
            this.lblManageOrders = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Print = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddOrder.FlatAppearance.BorderSize = 0;
            this.btnAddOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOrder.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOrder.ForeColor = System.Drawing.SystemColors.Window;
            this.btnAddOrder.Location = new System.Drawing.Point(18, 55);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(158, 34);
            this.btnAddOrder.TabIndex = 41;
            this.btnAddOrder.Text = "Add Order";
            this.btnAddOrder.UseVisualStyleBackColor = false;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // lblOrders
            // 
            this.lblOrders.AutoSize = true;
            this.lblOrders.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrders.ForeColor = System.Drawing.Color.Gray;
            this.lblOrders.Location = new System.Drawing.Point(41, 19);
            this.lblOrders.Name = "lblOrders";
            this.lblOrders.Size = new System.Drawing.Size(58, 21);
            this.lblOrders.TabIndex = 40;
            this.lblOrders.Text = "Orders";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.lblClearFilter);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbCustomers);
            this.panel1.Controls.Add(this.lblOrdersNumber);
            this.panel1.Controls.Add(this.lblManageOrders);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dgvOrders);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Location = new System.Drawing.Point(18, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 433);
            this.panel1.TabIndex = 39;
            // 
            // lblClearFilter
            // 
            this.lblClearFilter.AutoSize = true;
            this.lblClearFilter.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearFilter.ForeColor = System.Drawing.Color.Gray;
            this.lblClearFilter.Location = new System.Drawing.Point(910, 404);
            this.lblClearFilter.Name = "lblClearFilter";
            this.lblClearFilter.Size = new System.Drawing.Size(70, 16);
            this.lblClearFilter.TabIndex = 50;
            this.lblClearFilter.Text = "Clear Filter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(642, 344);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 47;
            this.label1.Text = "Customer:";
            // 
            // cmbCustomers
            // 
            this.cmbCustomers.BackColor = System.Drawing.SystemColors.Control;
            this.cmbCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCustomers.FormattingEnabled = true;
            this.cmbCustomers.Location = new System.Drawing.Point(709, 342);
            this.cmbCustomers.Name = "cmbCustomers";
            this.cmbCustomers.Size = new System.Drawing.Size(271, 21);
            this.cmbCustomers.TabIndex = 46;
            // 
            // lblOrdersNumber
            // 
            this.lblOrdersNumber.AutoSize = true;
            this.lblOrdersNumber.BackColor = System.Drawing.SystemColors.Window;
            this.lblOrdersNumber.ForeColor = System.Drawing.Color.Gray;
            this.lblOrdersNumber.Location = new System.Drawing.Point(19, 342);
            this.lblOrdersNumber.Name = "lblOrdersNumber";
            this.lblOrdersNumber.Size = new System.Drawing.Size(0, 13);
            this.lblOrdersNumber.TabIndex = 38;
            // 
            // lblManageOrders
            // 
            this.lblManageOrders.AutoSize = true;
            this.lblManageOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManageOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(68)))));
            this.lblManageOrders.Location = new System.Drawing.Point(424, 16);
            this.lblManageOrders.Name = "lblManageOrders";
            this.lblManageOrders.Size = new System.Drawing.Size(134, 22);
            this.lblManageOrders.TabIndex = 39;
            this.lblManageOrders.Text = "Manage Orders";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(19, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 37;
            this.label2.Text = "Search:";
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Customer,
            this.OrderDate,
            this.OrderTotal,
            this.Edit,
            this.Print,
            this.Delete});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrders.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrders.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvOrders.Location = new System.Drawing.Point(22, 118);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowTemplate.Height = 35;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(958, 196);
            this.dgvOrders.TabIndex = 3;
            this.dgvOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellContentClick);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.Control;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(75, 87);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(905, 14);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::InventoryManagementApp.Properties.Resources.editIcon;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::InventoryManagementApp.Properties.Resources.print;
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Width = 70;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.HeaderText = "";
            this.dataGridViewImageColumn3.Image = global::InventoryManagementApp.Properties.Resources.delete;
            this.dataGridViewImageColumn3.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.ReadOnly = true;
            this.dataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn3.Width = 50;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(428, 342);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(348, 344);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 52;
            this.label3.Text = "Order Date:";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "Id";
            this.ID.HeaderText = "Order Number";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Customer
            // 
            this.Customer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Customer.DataPropertyName = "Customer";
            this.Customer.HeaderText = "Customer";
            this.Customer.Name = "Customer";
            this.Customer.ReadOnly = true;
            // 
            // OrderDate
            // 
            this.OrderDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OrderDate.DataPropertyName = "OrderDate";
            this.OrderDate.HeaderText = "Order Date";
            this.OrderDate.Name = "OrderDate";
            this.OrderDate.ReadOnly = true;
            // 
            // OrderTotal
            // 
            this.OrderTotal.DataPropertyName = "OrderTotal";
            this.OrderTotal.HeaderText = "Total";
            this.OrderTotal.Name = "OrderTotal";
            this.OrderTotal.ReadOnly = true;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "";
            this.Edit.Image = global::InventoryManagementApp.Properties.Resources.editIcon;
            this.Edit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Edit.Width = 50;
            // 
            // Print
            // 
            this.Print.HeaderText = "";
            this.Print.Image = global::InventoryManagementApp.Properties.Resources.print;
            this.Print.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Print.Name = "Print";
            this.Print.ReadOnly = true;
            this.Print.Width = 50;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "";
            this.Delete.Image = global::InventoryManagementApp.Properties.Resources.delete;
            this.Delete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Delete.Width = 50;
            // 
            // frmManageOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 637);
            this.Controls.Add(this.btnAddOrder);
            this.Controls.Add(this.lblOrders);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManageOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Management";
            this.Load += new System.EventHandler(this.frmManageOrders_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Label lblOrders;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblClearFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCustomers;
        private System.Windows.Forms.Label lblOrdersNumber;
        private System.Windows.Forms.Label lblManageOrders;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderTotal;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Print;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}