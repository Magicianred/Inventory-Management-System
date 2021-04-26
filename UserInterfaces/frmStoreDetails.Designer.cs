namespace InventoryManagementApp.UserInterfaces
{
    partial class frmStoreDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblStoreDetails = new System.Windows.Forms.Label();
            this.btnManageStores = new System.Windows.Forms.Button();
            this.pnlStores = new System.Windows.Forms.Panel();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvStoreDetails = new System.Windows.Forms.DataGridView();
            this.lblStoreName = new System.Windows.Forms.Label();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitsInStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblProductsNumber = new System.Windows.Forms.Label();
            this.pnlStores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoreDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStoreDetails
            // 
            this.lblStoreDetails.AutoSize = true;
            this.lblStoreDetails.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoreDetails.ForeColor = System.Drawing.Color.Gray;
            this.lblStoreDetails.Location = new System.Drawing.Point(34, 22);
            this.lblStoreDetails.Name = "lblStoreDetails";
            this.lblStoreDetails.Size = new System.Drawing.Size(98, 21);
            this.lblStoreDetails.TabIndex = 47;
            this.lblStoreDetails.Text = "Store Details";
            // 
            // btnManageStores
            // 
            this.btnManageStores.BackColor = System.Drawing.Color.SteelBlue;
            this.btnManageStores.FlatAppearance.BorderSize = 0;
            this.btnManageStores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageStores.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageStores.ForeColor = System.Drawing.SystemColors.Window;
            this.btnManageStores.Location = new System.Drawing.Point(22, 61);
            this.btnManageStores.Name = "btnManageStores";
            this.btnManageStores.Size = new System.Drawing.Size(158, 34);
            this.btnManageStores.TabIndex = 48;
            this.btnManageStores.Text = "Manage Stores";
            this.btnManageStores.UseVisualStyleBackColor = false;
            this.btnManageStores.Click += new System.EventHandler(this.btnManageStores_Click);
            // 
            // pnlStores
            // 
            this.pnlStores.BackColor = System.Drawing.Color.White;
            this.pnlStores.Controls.Add(this.lblProductsNumber);
            this.pnlStores.Controls.Add(this.btnAddItem);
            this.pnlStores.Controls.Add(this.label1);
            this.pnlStores.Controls.Add(this.dgvStoreDetails);
            this.pnlStores.Controls.Add(this.lblStoreName);
            this.pnlStores.Location = new System.Drawing.Point(22, 114);
            this.pnlStores.Name = "pnlStores";
            this.pnlStores.Size = new System.Drawing.Size(1003, 443);
            this.pnlStores.TabIndex = 49;
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.Color.SandyBrown;
            this.btnAddItem.FlatAppearance.BorderSize = 0;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.ForeColor = System.Drawing.SystemColors.Window;
            this.btnAddItem.Location = new System.Drawing.Point(853, 389);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(137, 34);
            this.btnAddItem.TabIndex = 58;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(21, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 21);
            this.label1.TabIndex = 48;
            this.label1.Text = "Available Products";
            // 
            // dgvStoreDetails
            // 
            this.dgvStoreDetails.AllowUserToAddRows = false;
            this.dgvStoreDetails.AllowUserToDeleteRows = false;
            this.dgvStoreDetails.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStoreDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvStoreDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStoreDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product,
            this.UnitsInStock,
            this.Delete});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStoreDetails.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvStoreDetails.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvStoreDetails.Location = new System.Drawing.Point(13, 149);
            this.dgvStoreDetails.Name = "dgvStoreDetails";
            this.dgvStoreDetails.ReadOnly = true;
            this.dgvStoreDetails.RowTemplate.Height = 35;
            this.dgvStoreDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStoreDetails.Size = new System.Drawing.Size(977, 216);
            this.dgvStoreDetails.TabIndex = 34;
            this.dgvStoreDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStoreDetails_CellContentClick);
            // 
            // lblStoreName
            // 
            this.lblStoreName.AutoSize = true;
            this.lblStoreName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoreName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(68)))));
            this.lblStoreName.Location = new System.Drawing.Point(415, 13);
            this.lblStoreName.Name = "lblStoreName";
            this.lblStoreName.Size = new System.Drawing.Size(105, 22);
            this.lblStoreName.TabIndex = 19;
            this.lblStoreName.Text = "Store Name";
            // 
            // Product
            // 
            this.Product.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Product.DataPropertyName = "Product";
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            // 
            // UnitsInStock
            // 
            this.UnitsInStock.DataPropertyName = "UnitsInStock";
            this.UnitsInStock.HeaderText = "Units In Stock";
            this.UnitsInStock.Name = "UnitsInStock";
            this.UnitsInStock.ReadOnly = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "";
            this.Delete.Image = global::InventoryManagementApp.Properties.Resources.delete;
            this.Delete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Width = 50;
            // 
            // lblProductsNumber
            // 
            this.lblProductsNumber.AutoSize = true;
            this.lblProductsNumber.BackColor = System.Drawing.SystemColors.Window;
            this.lblProductsNumber.ForeColor = System.Drawing.Color.Gray;
            this.lblProductsNumber.Location = new System.Drawing.Point(22, 383);
            this.lblProductsNumber.Name = "lblProductsNumber";
            this.lblProductsNumber.Size = new System.Drawing.Size(0, 13);
            this.lblProductsNumber.TabIndex = 59;
            // 
            // frmStoreDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 637);
            this.Controls.Add(this.pnlStores);
            this.Controls.Add(this.btnManageStores);
            this.Controls.Add(this.lblStoreDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStoreDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStoreDetails";
            this.Load += new System.EventHandler(this.frmStoreDetails_Load);
            this.pnlStores.ResumeLayout(false);
            this.pnlStores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoreDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStoreDetails;
        private System.Windows.Forms.Button btnManageStores;
        private System.Windows.Forms.Panel pnlStores;
        private System.Windows.Forms.Label lblStoreName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvStoreDetails;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitsInStock;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.Label lblProductsNumber;
    }
}