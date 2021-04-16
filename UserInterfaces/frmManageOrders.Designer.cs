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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbCategorySearch = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblProductPrice = new System.Windows.Forms.Label();
            this.lblProductQty = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtProductPrice = new System.Windows.Forms.TextBox();
            this.txtProductQuantity = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtSearch.Location = new System.Drawing.Point(285, 78);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(421, 20);
            this.txtSearch.TabIndex = 31;
            // 
            // cmbCategorySearch
            // 
            this.cmbCategorySearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cmbCategorySearch.FormattingEnabled = true;
            this.cmbCategorySearch.Location = new System.Drawing.Point(720, 77);
            this.cmbCategorySearch.Name = "cmbCategorySearch";
            this.cmbCategorySearch.Size = new System.Drawing.Size(235, 21);
            this.cmbCategorySearch.TabIndex = 48;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblCategory.Location = new System.Drawing.Point(12, 322);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(92, 13);
            this.lblCategory.TabIndex = 47;
            this.lblCategory.Text = "Product Category:";
            // 
            // cmbCategories
            // 
            this.cmbCategories.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(12, 338);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(235, 21);
            this.cmbCategories.TabIndex = 46;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.SteelBlue;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.SystemColors.Window;
            this.btnHome.Location = new System.Drawing.Point(15, 493);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(235, 44);
            this.btnHome.TabIndex = 45;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.Window;
            this.btnDelete.Location = new System.Drawing.Point(136, 422);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(111, 23);
            this.btnDelete.TabIndex = 44;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.SteelBlue;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.SystemColors.Window;
            this.btnEdit.Location = new System.Drawing.Point(12, 422);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(118, 23);
            this.btnEdit.TabIndex = 43;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.Window;
            this.btnAdd.Location = new System.Drawing.Point(12, 382);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(235, 34);
            this.btnAdd.TabIndex = 42;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ProductName,
            this.ProductQuantity,
            this.ProductPrice,
            this.Description});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProducts.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProducts.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvProducts.Location = new System.Drawing.Point(285, 117);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(670, 420);
            this.dgvProducts.TabIndex = 41;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "Id";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // ProductQuantity
            // 
            this.ProductQuantity.DataPropertyName = "ProductQuantity";
            this.ProductQuantity.HeaderText = "Quantity";
            this.ProductQuantity.Name = "ProductQuantity";
            this.ProductQuantity.ReadOnly = true;
            // 
            // ProductPrice
            // 
            this.ProductPrice.DataPropertyName = "ProductPrice";
            this.ProductPrice.HeaderText = "Price";
            this.ProductPrice.Name = "ProductPrice";
            this.ProductPrice.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblDescription.Location = new System.Drawing.Point(12, 238);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 40;
            this.lblDescription.Text = "Description:";
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.AutoSize = true;
            this.lblProductPrice.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblProductPrice.Location = new System.Drawing.Point(12, 193);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(74, 13);
            this.lblProductPrice.TabIndex = 39;
            this.lblProductPrice.Text = "Product Price:";
            // 
            // lblProductQty
            // 
            this.lblProductQty.AutoSize = true;
            this.lblProductQty.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblProductQty.Location = new System.Drawing.Point(12, 144);
            this.lblProductQty.Name = "lblProductQty";
            this.lblProductQty.Size = new System.Drawing.Size(89, 13);
            this.lblProductQty.TabIndex = 38;
            this.lblProductQty.Text = "Product Quantity:";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblProductName.Location = new System.Drawing.Point(12, 101);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(78, 13);
            this.lblProductName.TabIndex = 37;
            this.lblProductName.Text = "Product Name:";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtDescription.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtDescription.Location = new System.Drawing.Point(12, 254);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(238, 55);
            this.txtDescription.TabIndex = 36;
            // 
            // txtProductPrice
            // 
            this.txtProductPrice.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtProductPrice.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtProductPrice.Location = new System.Drawing.Point(12, 209);
            this.txtProductPrice.Name = "txtProductPrice";
            this.txtProductPrice.Size = new System.Drawing.Size(238, 20);
            this.txtProductPrice.TabIndex = 35;
            // 
            // txtProductQuantity
            // 
            this.txtProductQuantity.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtProductQuantity.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtProductQuantity.Location = new System.Drawing.Point(12, 160);
            this.txtProductQuantity.Name = "txtProductQuantity";
            this.txtProductQuantity.Size = new System.Drawing.Size(238, 20);
            this.txtProductQuantity.TabIndex = 34;
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtProductName.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtProductName.Location = new System.Drawing.Point(12, 117);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(238, 20);
            this.txtProductName.TabIndex = 33;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-3, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1030, 61);
            this.panel1.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(31, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Products";
            // 
            // frmManageOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 550);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cmbCategorySearch);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategories);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblProductPrice);
            this.Controls.Add(this.lblProductQty);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtProductPrice);
            this.Controls.Add(this.txtProductQuantity);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbCategorySearch;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategories;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblProductPrice;
        private System.Windows.Forms.Label lblProductQty;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtProductPrice;
        private System.Windows.Forms.TextBox txtProductQuantity;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}