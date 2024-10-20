namespace ProjectDBMSWF
{
    partial class FChamCong
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
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.lb_ChamCong = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 25;
            this.guna2Elipse1.TargetControl = this;
            // 
            // lb_ChamCong
            // 
            this.lb_ChamCong.AutoSize = true;
            this.lb_ChamCong.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ChamCong.Location = new System.Drawing.Point(616, 428);
            this.lb_ChamCong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_ChamCong.Name = "lb_ChamCong";
            this.lb_ChamCong.Size = new System.Drawing.Size(158, 31);
            this.lb_ChamCong.TabIndex = 2;
            this.lb_ChamCong.Text = "Chấm Công";
            this.lb_ChamCong.Visible = false;
            // 
            // FChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(201)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(1481, 886);
            this.Controls.Add(this.lb_ChamCong);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FChamCong";
            this.Text = "FChamCong";
            this.Load += new System.EventHandler(this.FChamCong_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Label lb_ChamCong;
    }
}