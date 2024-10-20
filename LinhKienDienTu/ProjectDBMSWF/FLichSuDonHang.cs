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
    public partial class FLichSuDonHang : Form
    {
        public FLichSuDonHang()
        {
            InitializeComponent();
        }

        private void FLichSuDonHang_Load(object sender, EventArgs e)
        {
            danhSachHD_gridView.DataSource = null;
            danhSachHD_gridView.DataSource = NhanVienDAO.getDanhSachHD(FNhanvien.maNV);
        }

        private void txb_tenKH_TextChanged(object sender, EventArgs e)
        {
            string tenKH = txb_tenKH.Text;
            danhSachHD_gridView.DataSource = NhanVienDAO.getDanhSachHDByName(FNhanvien.maNV, tenKH);
        }

        private void cbtn_timTheoGia_CheckedChanged(object sender, EventArgs e)
        {
            float giaTriMin = 0;
            float giaTriMax = 999999999;
            if (!string.IsNullOrEmpty(txb_minValue.Text))
            {
                giaTriMin = float.Parse(txb_minValue.Text);
            }
            if (!string.IsNullOrEmpty(txb_maxValue.Text))
            {
                giaTriMax = float.Parse(txb_maxValue.Text);
            }

            if (cbtn_timTheoGia.Checked)
            {
                danhSachHD_gridView.DataSource = NhanVienDAO.getDanhSachHDByValue(giaTriMin, giaTriMax, FNhanvien.maNV);
            }
            else
            {
                danhSachHD_gridView.DataSource = NhanVienDAO.getDanhSachHD(FNhanvien.maNV);
            }
        }

        private void cbtn_timTheoNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (cbtn_timTheoNgay.Checked)
            {
                DateTime date = dateHD.Value;
                danhSachHD_gridView.DataSource = NhanVienDAO.getDanhSachHDByDate(date, FNhanvien.maNV);
            }
            else
            {
                danhSachHD_gridView.DataSource = NhanVienDAO.getDanhSachHD(FNhanvien.maNV);
            }
        }

        private void danhSachHD_gridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string maHD = danhSachHD_gridView.Rows[e.RowIndex].Cells["MaHD"].Value.ToString();

            chiTietHD_gridView.DataSource = NhanVienDAO.getChiTietHD(maHD);
        }
    }
}
