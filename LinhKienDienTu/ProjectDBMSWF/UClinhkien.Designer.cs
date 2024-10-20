namespace ProjectDBMSWF
{
    partial class UClinhkien
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.image_Product = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lbl_productName = new System.Windows.Forms.Label();
            this.lbl_giaTien = new System.Windows.Forms.Label();
            this.lbl_trangThai = new System.Windows.Forms.Label();
            this.lbl_soLuong = new System.Windows.Forms.Label();
            this.btn_chiTietProduct = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.image_Product)).BeginInit();
            this.SuspendLayout();
            // 
            // image_Product
            // 
            this.image_Product.BackgroundImage = global::ProjectDBMSWF.Properties.Resources.user1;
            this.image_Product.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.image_Product.ImageRotate = 0F;
            this.image_Product.Location = new System.Drawing.Point(3, 3);
            this.image_Product.Name = "image_Product";
            this.image_Product.Size = new System.Drawing.Size(110, 94);
            this.image_Product.TabIndex = 0;
            this.image_Product.TabStop = false;
            // 
            // lbl_productName
            // 
            this.lbl_productName.AutoSize = true;
            this.lbl_productName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_productName.Location = new System.Drawing.Point(120, 4);
            this.lbl_productName.Name = "lbl_productName";
            this.lbl_productName.Size = new System.Drawing.Size(117, 20);
            this.lbl_productName.TabIndex = 1;
            this.lbl_productName.Text = "ProductName";
            // 
            // lbl_giaTien
            // 
            this.lbl_giaTien.AutoSize = true;
            this.lbl_giaTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_giaTien.Location = new System.Drawing.Point(121, 77);
            this.lbl_giaTien.Name = "lbl_giaTien";
            this.lbl_giaTien.Size = new System.Drawing.Size(44, 20);
            this.lbl_giaTien.TabIndex = 2;
            this.lbl_giaTien.Text = "Price";
            // 
            // lbl_trangThai
            // 
            this.lbl_trangThai.AutoSize = true;
            this.lbl_trangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_trangThai.Location = new System.Drawing.Point(121, 32);
            this.lbl_trangThai.Name = "lbl_trangThai";
            this.lbl_trangThai.Size = new System.Drawing.Size(44, 16);
            this.lbl_trangThai.TabIndex = 2;
            this.lbl_trangThai.Text = "Status";
            // 
            // lbl_soLuong
            // 
            this.lbl_soLuong.AutoSize = true;
            this.lbl_soLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_soLuong.Location = new System.Drawing.Point(121, 48);
            this.lbl_soLuong.Name = "lbl_soLuong";
            this.lbl_soLuong.Size = new System.Drawing.Size(64, 16);
            this.lbl_soLuong.TabIndex = 2;
            this.lbl_soLuong.Text = "So Luong";
            // 
            // btn_chiTietProduct
            // 
            this.btn_chiTietProduct.BorderRadius = 5;
            this.btn_chiTietProduct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_chiTietProduct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_chiTietProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_chiTietProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_chiTietProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_chiTietProduct.ForeColor = System.Drawing.Color.White;
            this.btn_chiTietProduct.Location = new System.Drawing.Point(483, 67);
            this.btn_chiTietProduct.Name = "btn_chiTietProduct";
            this.btn_chiTietProduct.Size = new System.Drawing.Size(94, 30);
            this.btn_chiTietProduct.TabIndex = 3;
            this.btn_chiTietProduct.Text = "Chi tiết";
            // 
            // UClinhkien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.btn_chiTietProduct);
            this.Controls.Add(this.lbl_soLuong);
            this.Controls.Add(this.lbl_trangThai);
            this.Controls.Add(this.lbl_giaTien);
            this.Controls.Add(this.lbl_productName);
            this.Controls.Add(this.image_Product);
            this.Name = "UClinhkien";
            this.Size = new System.Drawing.Size(580, 100);
            ((System.ComponentModel.ISupportInitialize)(this.image_Product)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox image_Product;
        private System.Windows.Forms.Label lbl_productName;
        private System.Windows.Forms.Label lbl_giaTien;
        private System.Windows.Forms.Label lbl_trangThai;
        private System.Windows.Forms.Label lbl_soLuong;
        private Guna.UI2.WinForms.Guna2Button btn_chiTietProduct;
    }
}
