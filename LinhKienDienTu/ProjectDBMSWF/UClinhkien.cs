using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDBMSWF
{
    public partial class UClinhkien : UserControl
    {
        public UClinhkien()
        {
            InitializeComponent();
        }
        public Label ProductName
        {
            get => lbl_productName; set => lbl_productName = value;
        }
        public Label TrangThai
        {
            get => lbl_trangThai; set => lbl_trangThai = value;
        }
        public Label SoLuong
        {
            get => lbl_soLuong; set => lbl_soLuong = value;
        }
        public Label GiaTien
        {
            get => lbl_giaTien; set => lbl_giaTien = value;
        }
        public Guna2PictureBox AnhLK
        {
            get => image_Product; set => image_Product = value;
        }

        public event EventHandler ViewClicked;

        private void btnView_Click(object sender, EventArgs e)
        {
            if (ViewClicked != null)
            {
                ViewClicked(this, e);
            }
        }
    }
}
