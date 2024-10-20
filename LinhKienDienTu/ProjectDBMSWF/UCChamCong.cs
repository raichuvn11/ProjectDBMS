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
    public partial class UCChamCong : UserControl
    {
        public event EventHandler<string> ChamCongCompleted;
        private string maNV;
        private string maCa;
        private string ngayLam;
        public UCChamCong()
        {
            InitializeComponent();
        }


        public void LoadCaLamViec(DataTable dataTable, string maNV)
        {
            this.maNV = maNV;
            if (dataTable.Rows.Count > 0)
            {
                // Lấy dữ liệu từ dòng đầu tiên
                DataRow row = dataTable.Rows[0];

                // Cập nhật các TextBox
                lb_maCa.Text += row["MaCa"].ToString();
                maCa = row["MaCa"].ToString();
                lb_TenCa.Text += row["TenCa"].ToString();
                lb_ngay.Text += Convert.ToDateTime(row["Ngay"]).ToString("dd-MM-yyyy"); // Định dạng ngày nếu cần
                ngayLam = Convert.ToDateTime(row["Ngay"]).ToString("dd-MM-yyyy");
                lb_batDau.Text += row["ThoiGianBD"].ToString();
                lb_KetThuc.Text += row["ThoiGianKT"].ToString();
            }
        }

        private void btn_chamCong_Click(object sender, EventArgs e)
        {
            string maNhanVien = maNV;

            NhanVienDAO.chamCong(maNV, maCa);
            FNhanvien.ngayLamViec = ngayLam;
            ChamCongCompleted?.Invoke(this, ngayLam);
        }
    }
}
