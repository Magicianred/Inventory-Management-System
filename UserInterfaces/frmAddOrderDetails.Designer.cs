namespace InventoryManagementApp.UserInterfaces
{
    partial class frmAddOrderDetails
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
            this.lblOrderDetails = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.cmbProducts = new System.Windows.Forms.ComboBox();
            this.nProductQuantity = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalAmountPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nProductQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOrderDetails
            // 
            this.lblOrderDetails.AutoSize = true;
            this.lblOrderDetails.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDetails.ForeColor = System.Drawing.Color.Gray;
            this.lblOrderDetails.Location = new System.Drawing.Point(25, 24);
            this.lblOrderDetails.Name = "lblOrderDetails";
            this.lblOrderDetails.Size = new System.Drawing.Size(102, 21);
            this.lblOrderDetails.TabIndex = 49;
            this.lblOrderDetails.Text = "Order Details";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblProduct.Location = new System.Drawing.Point(29, 74);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(53, 16);
            this.lblProduct.TabIndex = 51;
            this.lblProduct.Text = "Product:";
            // 
            // cmbProducts
            // 
            this.cmbProducts.BackColor = System.Drawing.SystemColors.Control;
            this.cmbProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProducts.FormattingEnabled = true;
            this.cmbProducts.Location = new System.Drawing.Point(29, 93);
            this.cmbProducts.Name = "cmbProducts";
            this.cmbProducts.Size = new System.Drawing.Size(389, 21);
            this.cmbProducts.TabIndex = 50;
            this.cmbProducts.SelectedIndexChanged += new System.EventHandler(this.cmbProducts_SelectedIndexChanged);
            // 
            // nProductQuantity
            // 
            this.nProductQuantity.Location = new System.Drawing.Point(424, 94);
            this.nProductQuantity.Name = "nProductQuantity";
            this.nProductQuantity.Size = new System.Drawing.Size(120, 20);
            this.nProductQuantity.TabIndex = 52;
            this.nProductQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nProductQuantity.ValueChanged += new System.EventHandler(this.nProductQuantity_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(423, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 53;
            this.label1.Text = "Quantity:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SandyBrown;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSave.Location = new System.Drawing.Point(333, 186);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(137, 34);
            this.btnSave.TabIndex = 54;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(68)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCancel.Location = new System.Drawing.Point(476, 186);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 34);
            this.btnCancel.TabIndex = 55;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(26, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 18);
            this.label2.TabIndex = 56;
            this.label2.Text = "Total Amount:";
            // 
            // lblTotalAmountPrice
            // 
            this.lblTotalAmountPrice.AutoSize = true;
            this.lblTotalAmountPrice.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmountPrice.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalAmountPrice.Location = new System.Drawing.Point(33, 184);
            this.lblTotalAmountPrice.Name = "lblTotalAmountPrice";
            this.lblTotalAmountPrice.Size = new System.Drawing.Size(0, 16);
            this.lblTotalAmountPrice.TabIndex = 57;
            // 
            // frmAddOrderDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(571, 232);
            this.Controls.Add(this.lblTotalAmountPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nProductQuantity);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.cmbProducts);
            this.Controls.Add(this.lblOrderDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddOrderDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddOrderDetails";
            this.Load += new System.EventHandler(this.frmAddOrderDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nProductQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOrderDetails;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.ComboBox cmbProducts;
        private System.Windows.Forms.NumericUpDown nProductQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalAmountPrice;
    }
}