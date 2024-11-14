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
    public partial class FDoanhThuCa : Form
    {
        public FDoanhThuCa()
        {
            InitializeComponent();
        }

        private void FDoanhThuCa_Load(object sender, EventArgs e)
        {
            var dataSource = NhanVienDAO.loadDanhSachCaLam(FNhanvien.maNV);
            if (dataSource == null)
            {
                MessageBox.Show("Nhân viên chưa hoàn thành ca nào", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataGridView1.DataSource = dataSource;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string maCa = row.Cells["MaCa"].Value.ToString();
                dataGridView2.DataSource = NhanVienDAO.getDoanhThuTheoCa(maCa, FNhanvien.maNV);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime ngayBatDau = dtpNgayBatDau.Value;
            DateTime ngayKetThuc = dtpNgayKetThuc.Value;
            dataGridView2.DataSource = NhanVienDAO.getDoanhThuTheoCa(FNhanvien.maNV, ngayBatDau, ngayKetThuc);
        }
    }
}
