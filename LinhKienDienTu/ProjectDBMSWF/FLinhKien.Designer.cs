namespace ProjectDBMSWF
{
    partial class FLinhKien
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
            this.listProduct_gridView = new System.Windows.Forms.DataGridView();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_search = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.box_trangThai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.box_gia = new Guna.UI2.WinForms.Guna2ComboBox();
            this.box_nhomLk = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lbl_giaTien = new System.Windows.Forms.Label();
            this.lbl_moTa = new System.Windows.Forms.Label();
            this.lbl_soLuong = new System.Windows.Forms.Label();
            this.lbl_nhomLK = new System.Windows.Forms.Label();
            this.lbl_maLK = new System.Windows.Forms.Label();
            this.lbl_tenLK = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btn_addToOrder = new Guna.UI2.WinForms.Guna2Button();
            this.productImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txb_search = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.listProduct_gridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productImage)).BeginInit();
            this.SuspendLayout();
            // 
            // listProduct_gridView
            // 
            this.listProduct_gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listProduct_gridView.Location = new System.Drawing.Point(4, 17);
            this.listProduct_gridView.Margin = new System.Windows.Forms.Padding(2);
            this.listProduct_gridView.Name = "listProduct_gridView";
            this.listProduct_gridView.RowTemplate.Height = 24;
            this.listProduct_gridView.Size = new System.Drawing.Size(580, 593);
            this.listProduct_gridView.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listProduct_gridView);
            this.groupBox1.Location = new System.Drawing.Point(15, 83);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(589, 615);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách sản phẩm";
            // 
            // btn_search
            // 
            this.btn_search.BorderRadius = 5;
            this.btn_search.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_search.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_search.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_search.ForeColor = System.Drawing.Color.White;
            this.btn_search.Location = new System.Drawing.Point(996, 22);
            this.btn_search.Margin = new System.Windows.Forms.Padding(2);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(99, 36);
            this.btn_search.TabIndex = 22;
            this.btn_search.Text = "Tìm kiếm";
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(725, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Trạng thái";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(548, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Giá";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(335, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "Nhóm";
            // 
            // box_trangThai
            // 
            this.box_trangThai.BackColor = System.Drawing.Color.Transparent;
            this.box_trangThai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.box_trangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.box_trangThai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.box_trangThai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.box_trangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.box_trangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.box_trangThai.ItemHeight = 30;
            this.box_trangThai.Items.AddRange(new object[] {
            "Đang Bán",
            "Hết Hàng",
            "Ngừng Kinh Doanh"});
            this.box_trangThai.Location = new System.Drawing.Point(796, 22);
            this.box_trangThai.Margin = new System.Windows.Forms.Padding(2);
            this.box_trangThai.Name = "box_trangThai";
            this.box_trangThai.Size = new System.Drawing.Size(106, 36);
            this.box_trangThai.TabIndex = 16;
            // 
            // box_gia
            // 
            this.box_gia.BackColor = System.Drawing.Color.Transparent;
            this.box_gia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.box_gia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.box_gia.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.box_gia.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.box_gia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.box_gia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.box_gia.ItemHeight = 30;
            this.box_gia.Items.AddRange(new object[] {
            "500000",
            "2000000",
            "5000000",
            "10000000"});
            this.box_gia.Location = new System.Drawing.Point(580, 22);
            this.box_gia.Margin = new System.Windows.Forms.Padding(2);
            this.box_gia.Name = "box_gia";
            this.box_gia.Size = new System.Drawing.Size(106, 36);
            this.box_gia.TabIndex = 17;
            // 
            // box_nhomLk
            // 
            this.box_nhomLk.BackColor = System.Drawing.Color.Transparent;
            this.box_nhomLk.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.box_nhomLk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.box_nhomLk.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.box_nhomLk.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.box_nhomLk.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.box_nhomLk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.box_nhomLk.ItemHeight = 30;
            this.box_nhomLk.Items.AddRange(new object[] {
            "CPU",
            "RAM",
            "Ổ cứng SSD",
            "Nguồn máy tính"});
            this.box_nhomLk.Location = new System.Drawing.Point(382, 22);
            this.box_nhomLk.Margin = new System.Windows.Forms.Padding(2);
            this.box_nhomLk.Name = "box_nhomLk";
            this.box_nhomLk.Size = new System.Drawing.Size(106, 36);
            this.box_nhomLk.TabIndex = 18;
            // 
            // lbl_giaTien
            // 
            this.lbl_giaTien.AutoSize = true;
            this.lbl_giaTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_giaTien.Location = new System.Drawing.Point(36, 485);
            this.lbl_giaTien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_giaTien.Name = "lbl_giaTien";
            this.lbl_giaTien.Size = new System.Drawing.Size(77, 20);
            this.lbl_giaTien.TabIndex = 1;
            this.lbl_giaTien.Text = "Giá tiền:";
            // 
            // lbl_moTa
            // 
            this.lbl_moTa.AutoSize = true;
            this.lbl_moTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_moTa.Location = new System.Drawing.Point(36, 401);
            this.lbl_moTa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_moTa.Name = "lbl_moTa";
            this.lbl_moTa.Size = new System.Drawing.Size(49, 20);
            this.lbl_moTa.TabIndex = 1;
            this.lbl_moTa.Text = "mô tả";
            // 
            // lbl_soLuong
            // 
            this.lbl_soLuong.AutoSize = true;
            this.lbl_soLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_soLuong.Location = new System.Drawing.Point(231, 370);
            this.lbl_soLuong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_soLuong.Name = "lbl_soLuong";
            this.lbl_soLuong.Size = new System.Drawing.Size(76, 20);
            this.lbl_soLuong.TabIndex = 1;
            this.lbl_soLuong.Text = "Số lượng:";
            // 
            // lbl_nhomLK
            // 
            this.lbl_nhomLK.AutoSize = true;
            this.lbl_nhomLK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nhomLK.Location = new System.Drawing.Point(36, 370);
            this.lbl_nhomLK.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_nhomLK.Name = "lbl_nhomLK";
            this.lbl_nhomLK.Size = new System.Drawing.Size(49, 20);
            this.lbl_nhomLK.TabIndex = 1;
            this.lbl_nhomLK.Text = "nhóm";
            // 
            // lbl_maLK
            // 
            this.lbl_maLK.AutoSize = true;
            this.lbl_maLK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_maLK.Location = new System.Drawing.Point(36, 315);
            this.lbl_maLK.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_maLK.Name = "lbl_maLK";
            this.lbl_maLK.Size = new System.Drawing.Size(96, 20);
            this.lbl_maLK.TabIndex = 1;
            this.lbl_maLK.Text = "Mã linh kiện:";
            // 
            // lbl_tenLK
            // 
            this.lbl_tenLK.AutoSize = true;
            this.lbl_tenLK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tenLK.Location = new System.Drawing.Point(36, 343);
            this.lbl_tenLK.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_tenLK.Name = "lbl_tenLK";
            this.lbl_tenLK.Size = new System.Drawing.Size(49, 20);
            this.lbl_tenLK.TabIndex = 1;
            this.lbl_tenLK.Text = "name";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.Controls.Add(this.lbl_giaTien);
            this.guna2Panel1.Controls.Add(this.lbl_moTa);
            this.guna2Panel1.Controls.Add(this.lbl_soLuong);
            this.guna2Panel1.Controls.Add(this.lbl_nhomLK);
            this.guna2Panel1.Controls.Add(this.lbl_maLK);
            this.guna2Panel1.Controls.Add(this.lbl_tenLK);
            this.guna2Panel1.Controls.Add(this.productImage);
            this.guna2Panel1.Location = new System.Drawing.Point(615, 83);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(481, 526);
            this.guna2Panel1.TabIndex = 15;
            // 
            // btn_addToOrder
            // 
            this.btn_addToOrder.BorderRadius = 5;
            this.btn_addToOrder.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_addToOrder.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_addToOrder.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_addToOrder.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_addToOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addToOrder.ForeColor = System.Drawing.Color.White;
            this.btn_addToOrder.Location = new System.Drawing.Point(764, 630);
            this.btn_addToOrder.Margin = new System.Windows.Forms.Padding(2);
            this.btn_addToOrder.Name = "btn_addToOrder";
            this.btn_addToOrder.Size = new System.Drawing.Size(212, 37);
            this.btn_addToOrder.TabIndex = 14;
            this.btn_addToOrder.Text = "Thêm vào đơn hàng";
            this.btn_addToOrder.Click += new System.EventHandler(this.btn_addToOrder_Click);
            // 
            // productImage
            // 
            this.productImage.ImageRotate = 0F;
            this.productImage.Location = new System.Drawing.Point(17, 19);
            this.productImage.Margin = new System.Windows.Forms.Padding(2);
            this.productImage.Name = "productImage";
            this.productImage.Size = new System.Drawing.Size(444, 269);
            this.productImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.productImage.TabIndex = 0;
            this.productImage.TabStop = false;
            // 
            // txb_search
            // 
            this.txb_search.BackgroundImage = global::ProjectDBMSWF.Properties.Resources.magnifying_glass;
            this.txb_search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.txb_search.BorderRadius = 5;
            this.txb_search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txb_search.DefaultText = "";
            this.txb_search.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txb_search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txb_search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txb_search.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txb_search.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txb_search.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txb_search.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txb_search.Location = new System.Drawing.Point(15, 22);
            this.txb_search.Margin = new System.Windows.Forms.Padding(2);
            this.txb_search.Name = "txb_search";
            this.txb_search.Padding = new System.Windows.Forms.Padding(2);
            this.txb_search.PasswordChar = '\0';
            this.txb_search.PlaceholderText = "nhập tên sản phẩm";
            this.txb_search.SelectedText = "";
            this.txb_search.Size = new System.Drawing.Size(280, 29);
            this.txb_search.TabIndex = 13;
            this.txb_search.TextChanged += new System.EventHandler(this.txb_search_TextChanged);
            // 
            // FLinhKien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(1111, 720);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.box_trangThai);
            this.Controls.Add(this.box_gia);
            this.Controls.Add(this.box_nhomLk);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.txb_search);
            this.Controls.Add(this.btn_addToOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FLinhKien";
            this.Text = "FLinhKien";
            this.Load += new System.EventHandler(this.FLinhKien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listProduct_gridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView listProduct_gridView;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Guna.UI2.WinForms.Guna2Button btn_search;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox box_trangThai;
        private Guna.UI2.WinForms.Guna2ComboBox box_gia;
        private Guna.UI2.WinForms.Guna2ComboBox box_nhomLk;
        private System.Windows.Forms.Label lbl_giaTien;
        private System.Windows.Forms.Label lbl_moTa;
        private System.Windows.Forms.Label lbl_soLuong;
        private System.Windows.Forms.Label lbl_nhomLK;
        private System.Windows.Forms.Label lbl_maLK;
        private System.Windows.Forms.Label lbl_tenLK;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox productImage;
        private Guna.UI2.WinForms.Guna2TextBox txb_search;
        private Guna.UI2.WinForms.Guna2Button btn_addToOrder;
    }
}