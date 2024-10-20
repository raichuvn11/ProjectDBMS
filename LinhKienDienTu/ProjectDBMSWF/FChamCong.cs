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
    public partial class FChamCong : Form
    {
        private FNhanvien formNhanVien;
        public FChamCong(FNhanvien formNhanVien)
        {
            InitializeComponent();
            this.formNhanVien = formNhanVien;
        }

        private void FChamCong_Load(object sender, EventArgs e)
        {
            DataTable dt = NhanVienDAO.GetCaLamViec(FNhanvien.maNV);
            if (dt.Rows.Count > 0)
            {

                UCChamCong uc = new UCChamCong();
                uc.LoadCaLamViec(dt, FNhanvien.maNV);
                uc.ChamCongCompleted += OnChamCongCompleted;
                this.Controls.Add(uc);
            }
            

        }
        private void OnChamCongCompleted(object sender, string ngayLamViec)
        {
            formNhanVien.SetNgayLamViec(ngayLamViec); // Cập nhật ngày làm việc về Form Nhân viên
        }
    }
}
