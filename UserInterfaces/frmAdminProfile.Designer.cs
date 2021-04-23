namespace InventoryManagementApp.UserInterfaces
{
    partial class frmAdminProfile
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
            this.pbProfilePicture = new System.Windows.Forms.PictureBox();
            this.ofdProfilePicture = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // pbProfilePicture
            // 
            this.pbProfilePicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbProfilePicture.Image = global::InventoryManagementApp.Properties.Resources.PngItem_2560255;
            this.pbProfilePicture.Location = new System.Drawing.Point(53, 45);
            this.pbProfilePicture.Name = "pbProfilePicture";
            this.pbProfilePicture.Size = new System.Drawing.Size(171, 178);
            this.pbProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProfilePicture.TabIndex = 0;
            this.pbProfilePicture.TabStop = false;
            this.pbProfilePicture.Click += new System.EventHandler(this.pbProfilePicture_Click);
            // 
            // ofdProfilePicture
            // 
            this.ofdProfilePicture.FileName = "openFileDialog1";
            // 
            // frmAdminProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 637);
            this.Controls.Add(this.pbProfilePicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAdminProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAdminProfile";
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbProfilePicture;
        private System.Windows.Forms.OpenFileDialog ofdProfilePicture;
    }
}