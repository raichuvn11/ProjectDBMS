namespace ProjectDBMSWF
{
    partial class FXulydonhang
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.orderGridView = new System.Windows.Forms.DataGridView();
            this.btn_addHoaDon = new Guna.UI2.WinForms.Guna2Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txb_diachi = new System.Windows.Forms.TextBox();
            this.txb_email = new System.Windows.Forms.TextBox();
            this.txb_sdt = new System.Windows.Forms.TextBox();
            this.txb_hoten = new System.Windows.Forms.TextBox();
            this.lbl_triGiaHoaDon = new System.Windows.Forms.Label();
            this.lbl_itemNumber = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_hoTen = new System.Windows.Forms.Label();
            this.grbox_thanhToan = new System.Windows.Forms.GroupBox();
            this.btn_capNhat = new Guna.UI2.WinForms.Guna2Button();
            this.btn_huyProduct = new Guna.UI2.WinForms.Guna2Button();
            this.lbl_tongTien = new System.Windows.Forms.Label();
            this.lbl_soLuong = new System.Windows.Forms.Label();
            this.txb_soLuong = new System.Windows.Forms.TextBox();
            this.lbl_maLK = new System.Windows.Forms.Label();
            this.lbl_giaTien = new System.Windows.Forms.Label();
            this.lbl_productName = new System.Windows.Forms.Label();
            this.detailProduct = new System.Windows.Forms.GroupBox();
            this.imageProduct = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderGridView)).BeginInit();
            this.grbox_thanhToan.SuspendLayout();
            this.detailProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.orderGridView);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(23, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 630);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách sản phẩm";
            // 
            // orderGridView
            // 
            this.orderGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderGridView.Location = new System.Drawing.Point(5, 26);
            this.orderGridView.Margin = new System.Windows.Forms.Padding(2);
            this.orderGridView.Name = "orderGridView";
            this.orderGridView.RowHeadersWidth = 51;
            this.orderGridView.RowTemplate.Height = 24;
            this.orderGridView.Size = new System.Drawing.Size(518, 599);
            this.orderGridView.TabIndex = 1;
            // 
            // btn_addHoaDon
            // 
            this.btn_addHoaDon.BorderRadius = 5;
            this.btn_addHoaDon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_addHoaDon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_addHoaDon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_addHoaDon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_addHoaDon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_addHoaDon.ForeColor = System.Drawing.Color.White;
            this.btn_addHoaDon.Location = new System.Drawing.Point(369, 284);
            this.btn_addHoaDon.Name = "btn_addHoaDon";
            this.btn_addHoaDon.Size = new System.Drawing.Size(149, 30);
            this.btn_addHoaDon.TabIndex = 10;
            this.btn_addHoaDon.Text = "Xuất hóa đơn";
            this.btn_addHoaDon.Click += new System.EventHandler(this.btn_addHoaDon_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 220);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(489, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "---------------------------------------------------------------------------------" +
    "---------------";
            // 
            // txb_diachi
            // 
            this.txb_diachi.Location = new System.Drawing.Point(166, 171);
            this.txb_diachi.Margin = new System.Windows.Forms.Padding(2);
            this.txb_diachi.Name = "txb_diachi";
            this.txb_diachi.Size = new System.Drawing.Size(338, 26);
            this.txb_diachi.TabIndex = 8;
            // 
            // txb_email
            // 
            this.txb_email.Location = new System.Drawing.Point(166, 126);
            this.txb_email.Margin = new System.Windows.Forms.Padding(2);
            this.txb_email.Name = "txb_email";
            this.txb_email.Size = new System.Drawing.Size(338, 26);
            this.txb_email.TabIndex = 8;
            // 
            // txb_sdt
            // 
            this.txb_sdt.Location = new System.Drawing.Point(166, 81);
            this.txb_sdt.Margin = new System.Windows.Forms.Padding(2);
            this.txb_sdt.Name = "txb_sdt";
            this.txb_sdt.Size = new System.Drawing.Size(338, 26);
            this.txb_sdt.TabIndex = 8;
            // 
            // txb_hoten
            // 
            this.txb_hoten.Location = new System.Drawing.Point(166, 36);
            this.txb_hoten.Margin = new System.Windows.Forms.Padding(2);
            this.txb_hoten.Name = "txb_hoten";
            this.txb_hoten.Size = new System.Drawing.Size(338, 26);
            this.txb_hoten.TabIndex = 8;
            // 
            // lbl_triGiaHoaDon
            // 
            this.lbl_triGiaHoaDon.AutoSize = true;
            this.lbl_triGiaHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_triGiaHoaDon.Location = new System.Drawing.Point(15, 294);
            this.lbl_triGiaHoaDon.Name = "lbl_triGiaHoaDon";
            this.lbl_triGiaHoaDon.Size = new System.Drawing.Size(133, 20);
            this.lbl_triGiaHoaDon.TabIndex = 7;
            this.lbl_triGiaHoaDon.Text = "Giá trị hóa đơn:";
            // 
            // lbl_itemNumber
            // 
            this.lbl_itemNumber.AutoSize = true;
            this.lbl_itemNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_itemNumber.Location = new System.Drawing.Point(15, 259);
            this.lbl_itemNumber.Name = "lbl_itemNumber";
            this.lbl_itemNumber.Size = new System.Drawing.Size(108, 20);
            this.lbl_itemNumber.TabIndex = 7;
            this.lbl_itemNumber.Text = "Số món hàng:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Địa chỉ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Số điện thoại";
            // 
            // lbl_hoTen
            // 
            this.lbl_hoTen.AutoSize = true;
            this.lbl_hoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_hoTen.Location = new System.Drawing.Point(15, 38);
            this.lbl_hoTen.Name = "lbl_hoTen";
            this.lbl_hoTen.Size = new System.Drawing.Size(146, 20);
            this.lbl_hoTen.TabIndex = 7;
            this.lbl_hoTen.Text = "Họ tên Khách hàng";
            // 
            // grbox_thanhToan
            // 
            this.grbox_thanhToan.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grbox_thanhToan.Controls.Add(this.btn_addHoaDon);
            this.grbox_thanhToan.Controls.Add(this.label6);
            this.grbox_thanhToan.Controls.Add(this.txb_diachi);
            this.grbox_thanhToan.Controls.Add(this.txb_email);
            this.grbox_thanhToan.Controls.Add(this.txb_sdt);
            this.grbox_thanhToan.Controls.Add(this.txb_hoten);
            this.grbox_thanhToan.Controls.Add(this.lbl_triGiaHoaDon);
            this.grbox_thanhToan.Controls.Add(this.lbl_itemNumber);
            this.grbox_thanhToan.Controls.Add(this.label5);
            this.grbox_thanhToan.Controls.Add(this.label4);
            this.grbox_thanhToan.Controls.Add(this.label3);
            this.grbox_thanhToan.Controls.Add(this.lbl_hoTen);
            this.grbox_thanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbox_thanhToan.Location = new System.Drawing.Point(568, 358);
            this.grbox_thanhToan.Name = "grbox_thanhToan";
            this.grbox_thanhToan.Size = new System.Drawing.Size(524, 331);
            this.grbox_thanhToan.TabIndex = 7;
            this.grbox_thanhToan.TabStop = false;
            this.grbox_thanhToan.Text = "Thông tin thanh toán";
            // 
            // btn_capNhat
            // 
            this.btn_capNhat.BorderRadius = 5;
            this.btn_capNhat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_capNhat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_capNhat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_capNhat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_capNhat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_capNhat.ForeColor = System.Drawing.Color.White;
            this.btn_capNhat.Location = new System.Drawing.Point(280, 228);
            this.btn_capNhat.Name = "btn_capNhat";
            this.btn_capNhat.Size = new System.Drawing.Size(94, 30);
            this.btn_capNhat.TabIndex = 9;
            this.btn_capNhat.Text = "Cập nhật";
            this.btn_capNhat.Click += new System.EventHandler(this.btn_capNhat_Click);
            // 
            // btn_huyProduct
            // 
            this.btn_huyProduct.BorderRadius = 5;
            this.btn_huyProduct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_huyProduct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_huyProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_huyProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_huyProduct.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_huyProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_huyProduct.ForeColor = System.Drawing.Color.White;
            this.btn_huyProduct.Location = new System.Drawing.Point(397, 228);
            this.btn_huyProduct.Name = "btn_huyProduct";
            this.btn_huyProduct.Size = new System.Drawing.Size(94, 30);
            this.btn_huyProduct.TabIndex = 9;
            this.btn_huyProduct.Text = "Xóa ";
            this.btn_huyProduct.Click += new System.EventHandler(this.btn_huyProduct_Click);
            // 
            // lbl_tongTien
            // 
            this.lbl_tongTien.AutoSize = true;
            this.lbl_tongTien.Location = new System.Drawing.Point(235, 145);
            this.lbl_tongTien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_tongTien.Name = "lbl_tongTien";
            this.lbl_tongTien.Size = new System.Drawing.Size(49, 20);
            this.lbl_tongTien.TabIndex = 8;
            this.lbl_tongTien.Text = "Tổng:";
            // 
            // lbl_soLuong
            // 
            this.lbl_soLuong.AutoSize = true;
            this.lbl_soLuong.Location = new System.Drawing.Point(235, 110);
            this.lbl_soLuong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_soLuong.Name = "lbl_soLuong";
            this.lbl_soLuong.Size = new System.Drawing.Size(76, 20);
            this.lbl_soLuong.TabIndex = 8;
            this.lbl_soLuong.Text = "Số lượng:";
            // 
            // txb_soLuong
            // 
            this.txb_soLuong.Location = new System.Drawing.Point(312, 108);
            this.txb_soLuong.Margin = new System.Windows.Forms.Padding(2);
            this.txb_soLuong.Name = "txb_soLuong";
            this.txb_soLuong.Size = new System.Drawing.Size(46, 26);
            this.txb_soLuong.TabIndex = 7;
            // 
            // lbl_maLK
            // 
            this.lbl_maLK.AutoSize = true;
            this.lbl_maLK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_maLK.Location = new System.Drawing.Point(235, 50);
            this.lbl_maLK.Name = "lbl_maLK";
            this.lbl_maLK.Size = new System.Drawing.Size(35, 20);
            this.lbl_maLK.TabIndex = 6;
            this.lbl_maLK.Text = "Mã:";
            // 
            // lbl_giaTien
            // 
            this.lbl_giaTien.AutoSize = true;
            this.lbl_giaTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_giaTien.Location = new System.Drawing.Point(235, 79);
            this.lbl_giaTien.Name = "lbl_giaTien";
            this.lbl_giaTien.Size = new System.Drawing.Size(68, 20);
            this.lbl_giaTien.TabIndex = 6;
            this.lbl_giaTien.Text = "Đơn giá:";
            // 
            // lbl_productName
            // 
            this.lbl_productName.AutoSize = true;
            this.lbl_productName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_productName.Location = new System.Drawing.Point(235, 24);
            this.lbl_productName.Name = "lbl_productName";
            this.lbl_productName.Size = new System.Drawing.Size(117, 20);
            this.lbl_productName.TabIndex = 3;
            this.lbl_productName.Text = "ProductName";
            // 
            // detailProduct
            // 
            this.detailProduct.BackColor = System.Drawing.SystemColors.ControlLight;
            this.detailProduct.Controls.Add(this.btn_capNhat);
            this.detailProduct.Controls.Add(this.btn_huyProduct);
            this.detailProduct.Controls.Add(this.lbl_tongTien);
            this.detailProduct.Controls.Add(this.lbl_soLuong);
            this.detailProduct.Controls.Add(this.txb_soLuong);
            this.detailProduct.Controls.Add(this.lbl_maLK);
            this.detailProduct.Controls.Add(this.lbl_giaTien);
            this.detailProduct.Controls.Add(this.lbl_productName);
            this.detailProduct.Controls.Add(this.imageProduct);
            this.detailProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailProduct.Location = new System.Drawing.Point(568, 78);
            this.detailProduct.Margin = new System.Windows.Forms.Padding(2);
            this.detailProduct.Name = "detailProduct";
            this.detailProduct.Padding = new System.Windows.Forms.Padding(2);
            this.detailProduct.Size = new System.Drawing.Size(524, 275);
            this.detailProduct.TabIndex = 6;
            this.detailProduct.TabStop = false;
            this.detailProduct.Text = "Chi tiết sản phẩm";
            // 
            // imageProduct
            // 
            this.imageProduct.Location = new System.Drawing.Point(13, 24);
            this.imageProduct.Margin = new System.Windows.Forms.Padding(2);
            this.imageProduct.Name = "imageProduct";
            this.imageProduct.Size = new System.Drawing.Size(217, 234);
            this.imageProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageProduct.TabIndex = 0;
            this.imageProduct.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "ĐƠN HÀNG CỦA BẠN";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 25;
            this.guna2Elipse1.TargetControl = this;
            // 
            // FXulydonhang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(1111, 720);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbox_thanhToan);
            this.Controls.Add(this.detailProduct);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FXulydonhang";
            this.Text = "FXulydonhang";
            this.Load += new System.EventHandler(this.FXulydonhang_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderGridView)).EndInit();
            this.grbox_thanhToan.ResumeLayout(false);
            this.grbox_thanhToan.PerformLayout();
            this.detailProduct.ResumeLayout(false);
            this.detailProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView orderGridView;
        private Guna.UI2.WinForms.Guna2Button btn_addHoaDon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txb_diachi;
        private System.Windows.Forms.TextBox txb_email;
        private System.Windows.Forms.TextBox txb_sdt;
        private System.Windows.Forms.TextBox txb_hoten;
        private System.Windows.Forms.Label lbl_triGiaHoaDon;
        private System.Windows.Forms.Label lbl_itemNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_hoTen;
        private System.Windows.Forms.GroupBox grbox_thanhToan;
        private Guna.UI2.WinForms.Guna2Button btn_capNhat;
        private Guna.UI2.WinForms.Guna2Button btn_huyProduct;
        private System.Windows.Forms.Label lbl_tongTien;
        private System.Windows.Forms.Label lbl_soLuong;
        private System.Windows.Forms.TextBox txb_soLuong;
        private System.Windows.Forms.Label lbl_maLK;
        private System.Windows.Forms.Label lbl_giaTien;
        private System.Windows.Forms.Label lbl_productName;
        private System.Windows.Forms.GroupBox detailProduct;
        private System.Windows.Forms.PictureBox imageProduct;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}