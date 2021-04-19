namespace InventoryManagementApp.UserInterfaces
{
    partial class frmAddStore
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblOperationInfo = new System.Windows.Forms.Label();
            this.lblEvidentStore = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblStoreName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtStoreName = new System.Windows.Forms.TextBox();
            this.btnManageStores = new System.Windows.Forms.Button();
            this.lblStores = new System.Windows.Forms.Label();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbStatus);
            this.panel1.Controls.Add(this.lblOperationInfo);
            this.panel1.Controls.Add(this.lblEvidentStore);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.lblStoreName);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtStoreName);
            this.panel1.Location = new System.Drawing.Point(12, 133);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 323);
            this.panel1.TabIndex = 55;
            // 
            // lblOperationInfo
            // 
            this.lblOperationInfo.AutoSize = true;
            this.lblOperationInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperationInfo.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblOperationInfo.Location = new System.Drawing.Point(23, 287);
            this.lblOperationInfo.Name = "lblOperationInfo";
            this.lblOperationInfo.Size = new System.Drawing.Size(0, 18);
            this.lblOperationInfo.TabIndex = 52;
            // 
            // lblEvidentStore
            // 
            this.lblEvidentStore.AutoSize = true;
            this.lblEvidentStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvidentStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(68)))));
            this.lblEvidentStore.Location = new System.Drawing.Point(411, 9);
            this.lblEvidentStore.Name = "lblEvidentStore";
            this.lblEvidentStore.Size = new System.Drawing.Size(90, 22);
            this.lblEvidentStore.TabIndex = 47;
            this.lblEvidentStore.Text = "Add Store";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(68)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.Window;
            this.btnClear.Location = new System.Drawing.Point(187, 240);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 34);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblStoreName
            // 
            this.lblStoreName.AutoSize = true;
            this.lblStoreName.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblStoreName.Location = new System.Drawing.Point(24, 99);
            this.lblStoreName.Name = "lblStoreName";
            this.lblStoreName.Size = new System.Drawing.Size(38, 13);
            this.lblStoreName.TabIndex = 29;
            this.lblStoreName.Text = "Name:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSave.Location = new System.Drawing.Point(23, 240);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 34);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtStoreName
            // 
            this.txtStoreName.BackColor = System.Drawing.SystemColors.Control;
            this.txtStoreName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStoreName.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtStoreName.Location = new System.Drawing.Point(24, 115);
            this.txtStoreName.Name = "txtStoreName";
            this.txtStoreName.Size = new System.Drawing.Size(972, 13);
            this.txtStoreName.TabIndex = 28;
            // 
            // btnManageStores
            // 
            this.btnManageStores.BackColor = System.Drawing.Color.SteelBlue;
            this.btnManageStores.FlatAppearance.BorderSize = 0;
            this.btnManageStores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageStores.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageStores.ForeColor = System.Drawing.SystemColors.Window;
            this.btnManageStores.Location = new System.Drawing.Point(12, 78);
            this.btnManageStores.Name = "btnManageStores";
            this.btnManageStores.Size = new System.Drawing.Size(158, 34);
            this.btnManageStores.TabIndex = 54;
            this.btnManageStores.Text = "Manage Stores";
            this.btnManageStores.UseVisualStyleBackColor = false;
            this.btnManageStores.Click += new System.EventHandler(this.btnManageStores_Click);
            // 
            // lblStores
            // 
            this.lblStores.AutoSize = true;
            this.lblStores.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStores.ForeColor = System.Drawing.Color.Gray;
            this.lblStores.Location = new System.Drawing.Point(31, 45);
            this.lblStores.Name = "lblStores";
            this.lblStores.Size = new System.Drawing.Size(54, 21);
            this.lblStores.TabIndex = 53;
            this.lblStores.Text = "Stores";
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(23, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 54;
            this.label2.Text = "Status:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.SystemColors.Control;
            this.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(23, 158);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(370, 21);
            this.cmbStatus.TabIndex = 53;
            // 
            // frmAddStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 637);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnManageStores);
            this.Controls.Add(this.lblStores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddStore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddStore";
            this.Load += new System.EventHandler(this.frmAddStore_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblOperationInfo;
        private System.Windows.Forms.Label lblEvidentStore;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblStoreName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtStoreName;
        private System.Windows.Forms.Button btnManageStores;
        private System.Windows.Forms.Label lblStores;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbStatus;
    }
}