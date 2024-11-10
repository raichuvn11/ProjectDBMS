namespace ProjectDBMSWF
{
    partial class FDangnhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FDangnhap));
            this.pnlLogin = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.btnQly = new Guna.UI2.WinForms.Guna2Button();
            this.btnNvien = new Guna.UI2.WinForms.Guna2Button();
            this.btnDangnhap = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.btnClose = new Guna.UI2.WinForms.Guna2ImageButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.txbLoginAdmin = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtMaNV = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSĐT = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.Transparent;
            this.pnlLogin.Controls.Add(this.panel2);
            this.pnlLogin.Controls.Add(this.panel1);
            this.pnlLogin.Controls.Add(this.btnQly);
            this.pnlLogin.Controls.Add(this.btnNvien);
            this.pnlLogin.Controls.Add(this.btnDangnhap);
            this.pnlLogin.Controls.Add(this.label2);
            this.pnlLogin.Controls.Add(this.label1);
            this.pnlLogin.FillColor = System.Drawing.Color.White;
            this.pnlLogin.Location = new System.Drawing.Point(0, -1);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.ShadowColor = System.Drawing.Color.Black;
            this.pnlLogin.ShadowShift = 15;
            this.pnlLogin.Size = new System.Drawing.Size(375, 562);
            this.pnlLogin.TabIndex = 11;
            this.pnlLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLogin_Paint);
            // 
            // btnQly
            // 
            this.btnQly.Animated = true;
            this.btnQly.BorderRadius = 10;
            this.btnQly.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnQly.CustomImages.Image = global::ProjectDBMSWF.Properties.Resources.user1;
            this.btnQly.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnQly.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnQly.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnQly.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnQly.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnQly.FillColor = System.Drawing.Color.Transparent;
            this.btnQly.Font = new System.Drawing.Font("UTM Alberta Heavy", 9F);
            this.btnQly.ForeColor = System.Drawing.Color.Black;
            this.btnQly.Location = new System.Drawing.Point(213, 168);
            this.btnQly.Name = "btnQly";
            this.btnQly.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnQly.Size = new System.Drawing.Size(114, 45);
            this.btnQly.TabIndex = 27;
            this.btnQly.Text = "Quản Lý";
            this.btnQly.Click += new System.EventHandler(this.btnQly_Click);
            // 
            // btnNvien
            // 
            this.btnNvien.Animated = true;
            this.btnNvien.BorderRadius = 10;
            this.btnNvien.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnNvien.CustomImages.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.btnNvien.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNvien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNvien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNvien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNvien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNvien.FillColor = System.Drawing.Color.Transparent;
            this.btnNvien.Font = new System.Drawing.Font("UTM Alberta Heavy", 9F);
            this.btnNvien.ForeColor = System.Drawing.Color.Black;
            this.btnNvien.Location = new System.Drawing.Point(66, 168);
            this.btnNvien.Name = "btnNvien";
            this.btnNvien.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnNvien.Size = new System.Drawing.Size(114, 45);
            this.btnNvien.TabIndex = 28;
            this.btnNvien.Text = "Nhân Viên";
            this.btnNvien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnNvien.Click += new System.EventHandler(this.btnNvien_Click);
            // 
            // btnDangnhap
            // 
            this.btnDangnhap.AutoRoundedCorners = true;
            this.btnDangnhap.BackColor = System.Drawing.Color.Transparent;
            this.btnDangnhap.BorderRadius = 20;
            this.btnDangnhap.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDangnhap.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDangnhap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDangnhap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDangnhap.FillColor = System.Drawing.Color.Black;
            this.btnDangnhap.Font = new System.Drawing.Font("UTM Alberta Heavy", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangnhap.ForeColor = System.Drawing.Color.White;
            this.btnDangnhap.Location = new System.Drawing.Point(128, 456);
            this.btnDangnhap.Name = "btnDangnhap";
            this.btnDangnhap.ShadowDecoration.BorderRadius = 25;
            this.btnDangnhap.ShadowDecoration.Enabled = true;
            this.btnDangnhap.Size = new System.Drawing.Size(121, 42);
            this.btnDangnhap.TabIndex = 18;
            this.btnDangnhap.Text = "Đăng nhập";
            this.btnDangnhap.Click += new System.EventHandler(this.btnDangnhap_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("UTM Alberta Heavy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(125, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Đăng nhập để tiếp tục";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("UTM Alberta Heavy", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(81, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 42);
            this.label1.TabIndex = 15;
            this.label1.Text = "CHANG STORE";
            // 
            // guna2AnimateWindow1
            // 
            this.guna2AnimateWindow1.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_SLIDE;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnClose.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.btnClose.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnClose.ImageRotate = 0F;
            this.btnClose.ImageSize = new System.Drawing.Size(20, 20);
            this.btnClose.IndicateFocus = true;
            this.btnClose.Location = new System.Drawing.Point(859, -1);
            this.btnClose.Name = "btnClose";
            this.btnClose.PressedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.btnClose.PressedState.ImageSize = new System.Drawing.Size(30, 30);
            this.btnClose.Size = new System.Drawing.Size(35, 36);
            this.btnClose.TabIndex = 10;
            this.btnClose.UseTransparentBackground = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProjectDBMSWF.Properties.Resources.output;
            this.pictureBox1.Location = new System.Drawing.Point(371, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(523, 562);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txbLoginAdmin);
            this.panel1.Location = new System.Drawing.Point(57, 240);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 152);
            this.panel1.TabIndex = 29;
            // 
            // txbLoginAdmin
            // 
            this.txbLoginAdmin.Animated = true;
            this.txbLoginAdmin.BorderRadius = 8;
            this.txbLoginAdmin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbLoginAdmin.DefaultText = "";
            this.txbLoginAdmin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txbLoginAdmin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txbLoginAdmin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbLoginAdmin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbLoginAdmin.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbLoginAdmin.Font = new System.Drawing.Font("UTM Alberta Heavy", 9F);
            this.txbLoginAdmin.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbLoginAdmin.IconLeft = ((System.Drawing.Image)(resources.GetObject("txbLoginAdmin.IconLeft")));
            this.txbLoginAdmin.Location = new System.Drawing.Point(3, 51);
            this.txbLoginAdmin.Name = "txbLoginAdmin";
            this.txbLoginAdmin.PasswordChar = '*';
            this.txbLoginAdmin.PlaceholderText = "Mã Nhân Viên";
            this.txbLoginAdmin.SelectedText = "";
            this.txbLoginAdmin.Size = new System.Drawing.Size(252, 38);
            this.txbLoginAdmin.TabIndex = 21;
            this.txbLoginAdmin.TextChanged += new System.EventHandler(this.txbLoginAdmin_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtSĐT);
            this.panel2.Controls.Add(this.txtMaNV);
            this.panel2.Location = new System.Drawing.Point(57, 240);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(261, 152);
            this.panel2.TabIndex = 30;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Animated = true;
            this.txtMaNV.BorderRadius = 8;
            this.txtMaNV.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaNV.DefaultText = "";
            this.txtMaNV.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaNV.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaNV.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaNV.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaNV.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaNV.Font = new System.Drawing.Font("UTM Alberta Heavy", 9F);
            this.txtMaNV.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaNV.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtMaNV.IconLeft")));
            this.txtMaNV.Location = new System.Drawing.Point(6, 23);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.PasswordChar = '\0';
            this.txtMaNV.PlaceholderText = "Mã Nhân Viên";
            this.txtMaNV.SelectedText = "";
            this.txtMaNV.Size = new System.Drawing.Size(252, 38);
            this.txtMaNV.TabIndex = 21;
            // 
            // txtSĐT
            // 
            this.txtSĐT.Animated = true;
            this.txtSĐT.BorderRadius = 8;
            this.txtSĐT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSĐT.DefaultText = "";
            this.txtSĐT.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSĐT.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSĐT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSĐT.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSĐT.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSĐT.Font = new System.Drawing.Font("UTM Alberta Heavy", 9F);
            this.txtSĐT.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSĐT.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtSĐT.IconLeft")));
            this.txtSĐT.Location = new System.Drawing.Point(6, 92);
            this.txtSĐT.Name = "txtSĐT";
            this.txtSĐT.PasswordChar = '*';
            this.txtSĐT.PlaceholderText = "SĐT";
            this.txtSĐT.SelectedText = "";
            this.txtSĐT.Size = new System.Drawing.Size(252, 38);
            this.txtSĐT.TabIndex = 21;
            // 
            // FDangnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(894, 561);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FDangnhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FLogin";
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel pnlLogin;
        private Guna.UI2.WinForms.Guna2Button btnQly;
        private Guna.UI2.WinForms.Guna2Button btnNvien;
        private Guna.UI2.WinForms.Guna2Button btnDangnhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ImageButton btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2Panel panel1;
        private Guna.UI2.WinForms.Guna2TextBox txbLoginAdmin;
        private Guna.UI2.WinForms.Guna2Panel panel2;
        private Guna.UI2.WinForms.Guna2TextBox txtMaNV;
        private Guna.UI2.WinForms.Guna2TextBox txtSĐT;
    }
}