namespace ProjectDBMSWF
{
    partial class UCChamCong
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
            this.btn_chamCong = new System.Windows.Forms.Button();
            this.lb_KetThuc = new System.Windows.Forms.Label();
            this.lb_batDau = new System.Windows.Forms.Label();
            this.lb_ngay = new System.Windows.Forms.Label();
            this.lb_TenCa = new System.Windows.Forms.Label();
            this.lb_maCa = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_chamCong
            // 
            this.btn_chamCong.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_chamCong.Font = new System.Drawing.Font("UTM Alberta Heavy", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_chamCong.Location = new System.Drawing.Point(31, 238);
            this.btn_chamCong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_chamCong.Name = "btn_chamCong";
            this.btn_chamCong.Size = new System.Drawing.Size(165, 50);
            this.btn_chamCong.TabIndex = 11;
            this.btn_chamCong.Text = "Chấm công";
            this.btn_chamCong.UseVisualStyleBackColor = false;
            this.btn_chamCong.Click += new System.EventHandler(this.btn_chamCong_Click);
            // 
            // lb_KetThuc
            // 
            this.lb_KetThuc.AutoSize = true;
            this.lb_KetThuc.Font = new System.Drawing.Font("UTM Alberta Heavy", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_KetThuc.Location = new System.Drawing.Point(27, 186);
            this.lb_KetThuc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_KetThuc.Name = "lb_KetThuc";
            this.lb_KetThuc.Size = new System.Drawing.Size(81, 17);
            this.lb_KetThuc.TabIndex = 10;
            this.lb_KetThuc.Text = "Giờ kết thúc";
            // 
            // lb_batDau
            // 
            this.lb_batDau.AutoSize = true;
            this.lb_batDau.Font = new System.Drawing.Font("UTM Alberta Heavy", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_batDau.Location = new System.Drawing.Point(27, 140);
            this.lb_batDau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_batDau.Name = "lb_batDau";
            this.lb_batDau.Size = new System.Drawing.Size(80, 17);
            this.lb_batDau.TabIndex = 9;
            this.lb_batDau.Text = "Giờ bắt đầu";
            // 
            // lb_ngay
            // 
            this.lb_ngay.AutoSize = true;
            this.lb_ngay.Font = new System.Drawing.Font("UTM Alberta Heavy", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ngay.Location = new System.Drawing.Point(27, 92);
            this.lb_ngay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_ngay.Name = "lb_ngay";
            this.lb_ngay.Size = new System.Drawing.Size(43, 17);
            this.lb_ngay.TabIndex = 8;
            this.lb_ngay.Text = "Ngày:";
            // 
            // lb_TenCa
            // 
            this.lb_TenCa.AutoSize = true;
            this.lb_TenCa.Font = new System.Drawing.Font("UTM Alberta Heavy", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TenCa.Location = new System.Drawing.Point(27, 48);
            this.lb_TenCa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_TenCa.Name = "lb_TenCa";
            this.lb_TenCa.Size = new System.Drawing.Size(45, 17);
            this.lb_TenCa.TabIndex = 7;
            this.lb_TenCa.Text = "Tên ca";
            // 
            // lb_maCa
            // 
            this.lb_maCa.AutoSize = true;
            this.lb_maCa.Font = new System.Drawing.Font("UTM Alberta Heavy", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_maCa.Location = new System.Drawing.Point(27, 6);
            this.lb_maCa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_maCa.Name = "lb_maCa";
            this.lb_maCa.Size = new System.Drawing.Size(49, 17);
            this.lb_maCa.TabIndex = 6;
            this.lb_maCa.Text = "Mã Ca:";
            // 
            // UCChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_chamCong);
            this.Controls.Add(this.lb_KetThuc);
            this.Controls.Add(this.lb_batDau);
            this.Controls.Add(this.lb_ngay);
            this.Controls.Add(this.lb_TenCa);
            this.Controls.Add(this.lb_maCa);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UCChamCong";
            this.Size = new System.Drawing.Size(245, 306);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_chamCong;
        private System.Windows.Forms.Label lb_KetThuc;
        private System.Windows.Forms.Label lb_batDau;
        private System.Windows.Forms.Label lb_ngay;
        private System.Windows.Forms.Label lb_TenCa;
        private System.Windows.Forms.Label lb_maCa;
    }
}
