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
            this.txbLogin = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2ImageButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.Transparent;
            this.pnlLogin.Controls.Add(this.btnQly);
            this.pnlLogin.Controls.Add(this.btnNvien);
            this.pnlLogin.Controls.Add(this.txbLogin);
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
            this.btnNvien.Font = new System.Drawing.Font("UTM Alberta Heavy", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNvien.ForeColor = System.Drawing.Color.Black;
            this.btnNvien.Location = new System.Drawing.Point(66, 168);
            this.btnNvien.Name = "btnNvien";
            this.btnNvien.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnNvien.Size = new System.Drawing.Size(114, 45);
            this.btnNvien.TabIndex = 28;
            this.btnNvien.Text = "Nhân Viên";
            this.btnNvien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.btnDangnhap.Location = new System.Drawing.Point(128, 351);
            this.btnDangnhap.Name = "btnDangnhap";
            this.btnDangnhap.ShadowDecoration.BorderRadius = 25;
            this.btnDangnhap.ShadowDecoration.Enabled = true;
            this.btnDangnhap.Size = new System.Drawing.Size(121, 42);
            this.btnDangnhap.TabIndex = 18;
            this.btnDangnhap.Text = "Đăng nhập";
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
            // txbLogin
            // 
            this.txbLogin.Animated = true;
            this.txbLogin.BorderRadius = 8;
            this.txbLogin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbLogin.DefaultText = "";
            this.txbLogin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txbLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txbLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbLogin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbLogin.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbLogin.Font = new System.Drawing.Font("UTM Alberta Heavy", 9F);
            this.txbLogin.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbLogin.IconLeft = ((System.Drawing.Image)(resources.GetObject("txbLogin.IconLeft")));
            this.txbLogin.Location = new System.Drawing.Point(66, 260);
            this.txbLogin.Name = "txbLogin";
            this.txbLogin.PasswordChar = '\0';
            this.txbLogin.PlaceholderText = "Mã Nhân Viên";
            this.txbLogin.SelectedText = "";
            this.txbLogin.Size = new System.Drawing.Size(261, 38);
            this.txbLogin.TabIndex = 20;
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
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel pnlLogin;
        private Guna.UI2.WinForms.Guna2Button btnQly;
        private Guna.UI2.WinForms.Guna2Button btnNvien;
        private Guna.UI2.WinForms.Guna2TextBox txbLogin;
        private Guna.UI2.WinForms.Guna2Button btnDangnhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ImageButton btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
    }
}