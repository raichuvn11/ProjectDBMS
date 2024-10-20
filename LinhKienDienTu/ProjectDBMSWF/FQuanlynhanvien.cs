using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDBMSWF
{
    public partial class FQuanlynhanvien : Form
    {
        string strCon = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LinhKienDienTu2;Integrated Security=True";
        SqlConnection sqlCon = null;
        public FQuanlynhanvien()
        {
            InitializeComponent();
        }

        private void FQuanlynhanvien_Load(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon == null)
                {
                    sqlCon = new SqlConnection(strCon);
                }
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();

                    string sqlStr = string.Format("SELECT *FROM NhanVien");

                    SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, sqlCon);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvDanhSachNV.DataSource = dt;
                    MessageBox.Show("Ket noi thanh cong");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCon.Open();
                string sql = "SELECT *FROM dbo.fn_timMaNV(@MaNV)";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, sqlCon);
                adapter.SelectCommand.Parameters.AddWithValue("@MaNV", txtNhap.Text);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvDanhSachNV.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }

        private void dgvDanhSachNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhSachNV.Rows[e.RowIndex];

                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                if (row.Cells["GioiTinh"].Value.ToString() == "Nam")
                    cbGioiTinh.SelectedIndex = cbGioiTinh.Items.IndexOf("Nam");
                else
                    cbGioiTinh.SelectedIndex = cbGioiTinh.Items.IndexOf("Nữ");
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                dtpNgayBDLamViec.Value = Convert.ToDateTime(row.Cells["NgayBDLamViec"].Value);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCon.Open();
                string proc = String.Format("Execute nv_InsertNhanVien @MaNV, @HoTen, @SDT, @NgayBDLamViec, @NgaySinh, @GioiTinh, @DiaChi, @Luong");
                SqlCommand cmd = new SqlCommand(proc, sqlCon);
                cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("@NgayBDLamViec", dtpNgayBDLamViec.Value);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", cbGioiTinh.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@Luong", 0);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCon.Open();
                string proc = String.Format("Execute nv_deleteNhanVien @MaNV");
                SqlCommand cmd = new SqlCommand(proc, sqlCon);
                cmd.Parameters.AddWithValue("@MaNV", txtNhap.Text);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Xoá thành công");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên");
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCon.Open();
                string proc = String.Format("Execute nv_updateNhanVien @MaNV, @HoTen, @SDT, @NgayBDLamViec, @NgaySinh, @GioiTinh, @DiaChi, @Luong");
                SqlCommand cmd = new SqlCommand(proc, sqlCon);
                cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("@NgayBDLamViec", dtpNgayBDLamViec.Value);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", cbGioiTinh.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@Luong", 0);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sửa thành công");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            FQuanlynhanvien_Load(sender, e);
        }
    }
}
