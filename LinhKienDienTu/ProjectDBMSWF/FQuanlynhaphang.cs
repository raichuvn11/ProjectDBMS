using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDBMSWF
{
    public partial class FQuanlynhaphang : Form
    {
        ConnectDB cnt = new ConnectDB(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LinhKienDienTu2;Integrated Security=True");
        string MaDonNhap;
        string MaLk;
        public FQuanlynhaphang()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FQuanlynhaphang_Load(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            try
            {
                cnt.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ViewDonNhapHang", cnt.GetConnection());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvDonNhap.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        public void LoadNhaCungCapToComboBox(ComboBox comboBox)
        {
            // Câu lệnh SQL để lấy dữ liệu từ bảng NhaCungCap
            string query = "SELECT MaNCC, TenNhaCungCap FROM NhaCungCap";

            // Mở kết nối
            try
            {
                cnt.Open();

                // Khởi tạo SqlCommand
                using (SqlCommand cmd = new SqlCommand(query, cnt.GetConnection()))
                {
                    // Tạo SqlDataAdapter để lấy dữ liệu
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();

                    // Lấp dữ liệu vào DataTable
                    adapter.Fill(dataTable);

                    // Xóa các mục hiện có trong ComboBox
                    comboBox.Items.Clear();

                    // Thêm các mục vào ComboBox
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Thêm tên nhà cung cấp vào ComboBox
                        comboBox.Items.Add(new { Text = row["TenNhaCungCap"].ToString(), Value = row["MaNCC"] });
                    }

                    // Đặt thuộc tính DisplayMember và ValueMember
                    comboBox.DisplayMember = "Text";
                    comboBox.ValueMember = "Value";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải nhà cung cấp vào ComboBox: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối
                cnt.Close();
            }
        }
        public void LoadTenLKToComboBox(ComboBox comboBox, string MaNCC)
        {
            
            string query = "SELECT MaLK, TenLK FROM LinhKien Where MaNCC = @MaNCC ";

            // Mở kết nối
            try
            {
                cnt.Open();

                // Khởi tạo SqlCommand
                using (SqlCommand cmd = new SqlCommand(query, cnt.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@MaNCC", MaNCC);
                    // Tạo SqlDataAdapter để lấy dữ liệu
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();

                    // Lấp dữ liệu vào DataTable
                    adapter.Fill(dataTable);

                    // Xóa các mục hiện có trong ComboBox
                    comboBox.Items.Clear();

                    // Thêm các mục vào ComboBox
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Thêm tên nhà cung cấp vào ComboBox
                        comboBox.Items.Add(new { Text = row["TenLK"].ToString(), Value = row["MaLK"] });
                    }

                    // Đặt thuộc tính DisplayMember và ValueMember
                    comboBox.DisplayMember = "Text";
                    comboBox.ValueMember = "Value";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải nhà cung cấp vào ComboBox: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối
                cnt.Close();
            }
        }
        private void btnThemDon_Click(object sender, EventArgs e)
        {
            panel4.Show();
            LoadNhaCungCapToComboBox(cbMaNCC2);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            FQuanlynhaphang_Load(sender, e);
        }

        private void btnThemLK_Click(object sender, EventArgs e)
        {
            panel3.Show();
            LoadTenLKToComboBox(cbTenSP, txtMaNCC.Text);
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            panel3.Hide();
            try
            {
                cnt.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ViewNhapHang Where MaDonNhap = @MaDonNhap ", cnt.GetConnection());
                cmd.Parameters.AddWithValue("@MaDonNhap", MaDonNhap);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvNhapHang.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            try
            {
                cnt.Open();

                using (SqlCommand cmd = new SqlCommand("sp_InsertNhapHang", cnt.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaDonNhap", MaDonNhap);
                    if (cbTenSP.SelectedItem != null)
                    {
                        var selectedItem = cbTenSP.SelectedItem as dynamic;
                        if (selectedItem != null && selectedItem.Value != null)
                        {
                            string selectedId = selectedItem.Value;
                            cmd.Parameters.AddWithValue("@MaLK", selectedId);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@MaLK", DBNull.Value);
                        }
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@MaLK", DBNull.Value);
                    }

                    int soluong = 0;
                    float dongia = 0f;

                    if (string.IsNullOrEmpty(txtSoLuong.Text) || !int.TryParse(txtSoLuong.Text, out soluong))
                    {
                        MessageBox.Show("Số lượng không hợp lệ.");
                        return;
                    }

                    if (string.IsNullOrEmpty(txtGiaNhap.Text) || !float.TryParse(txtGiaNhap.Text, out dongia))
                    {
                        MessageBox.Show("Giá nhập không hợp lệ.");
                        return;
                    }

                    cmd.Parameters.AddWithValue("@SoLuong", soluong);
                    cmd.Parameters.AddWithValue("@DonGia", dongia);
                    cmd.Parameters.AddWithValue("@TongTien", soluong * dongia);

                    cmd.ExecuteNonQuery();

                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }
            finally
            {
                cnt.Close();
            }
            btnBack2_Click(sender, e);
        }

        private void btnThemDonNhap_Click(object sender, EventArgs e)
        {
            try
            {
                cnt.Open();

                using (SqlCommand cmd = new SqlCommand("sp_InsertDonNhapHang", cnt.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NgayNhap",dtNgayNhap.Value.Date);
                    if (cbMaNCC2.SelectedItem != null)
                    {
                        var selectedItem = cbMaNCC2.SelectedItem as dynamic;
                        if (selectedItem != null && selectedItem.Value != null)
                        {
                            string selectedId = selectedItem.Value;
                            cmd.Parameters.AddWithValue("@MaNCC", selectedId);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@MaNCC", DBNull.Value);
                        }
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@MaNCC", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@GiaTriDonNhap", 1);

                    cmd.ExecuteNonQuery();

                }
            }
            catch (SqlException sqlEx)
            {

                MessageBox.Show(sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }
            finally
            {
                cnt.Close();
            }
            FQuanlynhaphang_Load(sender, e);
        }

        private void gvDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Show();
            
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = gvDonNhap.Rows[e.RowIndex];

                txtMaNCC.Text = row.Cells["MaNCC"].Value.ToString();
                MaDonNhap = row.Cells["MaDonNhap"].Value.ToString();

            }
            try
            {
                cnt.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ViewNhapHang Where MaDonNhap = @MaDonNhap ", cnt.GetConnection());
                cmd.Parameters.AddWithValue("@MaDonNhap", MaDonNhap);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvNhapHang.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnback4_Click(object sender, EventArgs e)
        {
            panel4.Hide();
        }

        private void gvNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel5.Show();
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = gvNhapHang.Rows[e.RowIndex];
                MaDonNhap = row.Cells["MaDonNhap"].Value.ToString();
                txtTenSP2.Text = row.Cells["TenLK"].Value.ToString();
                txtSoLuong2.Text = row.Cells["SoLuong"].Value.ToString();
                txtGiaNhap2.Text = row.Cells["DonGia"].Value.ToString();
                MaLk = row.Cells["MaLK"].Value.ToString();
            }
            
        }

        private void btnBack5_Click(object sender, EventArgs e)
        {
            panel5.Hide();
            try
            {
                cnt.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ViewNhapHang Where MaDonNhap = @MaDonNhap ", cnt.GetConnection());
                cmd.Parameters.AddWithValue("@MaDonNhap", MaDonNhap);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvNhapHang.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                cnt.Open();

                using (SqlCommand cmd = new SqlCommand("sp_UpdateNhapHang", cnt.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaDonNhap", MaDonNhap);
                    
                    cmd.Parameters.AddWithValue("@MaLK", MaLk);

                    int soluong = 0;
                    float dongia = 0f;

                    if (string.IsNullOrEmpty(txtSoLuong.Text) || !int.TryParse(txtSoLuong.Text, out soluong))
                    {
                        MessageBox.Show("Số lượng không hợp lệ.");
                        return;
                    }

                    if (string.IsNullOrEmpty(txtGiaNhap.Text) || !float.TryParse(txtGiaNhap.Text, out dongia))
                    {
                        MessageBox.Show("Giá nhập không hợp lệ.");
                        return;
                    }
                    cmd.Parameters.AddWithValue("@SoLuong", soluong);
                    cmd.Parameters.AddWithValue("@DonGia", dongia);
                    cmd.Parameters.AddWithValue("@TongTien", soluong * dongia);

                    cmd.ExecuteNonQuery();
                    
                }
            }
            catch (SqlException sqlEx)
            {

                MessageBox.Show(sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa đơn nhập hàng: " + ex.Message);
            }
            finally
            {
                cnt.Close();
            }
            btnBack5_Click(sender, e);
        }

        private void btnXoaLK_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở kết nối
                cnt.Open();

                // Tạo đối tượng SqlCommand để gọi thủ tục
                using (SqlCommand cmd = new SqlCommand("sp_DeleteNhapHang", cnt.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaDonNhap", MaDonNhap);

                    cmd.Parameters.AddWithValue("@MaLK", MaLk);

                    cmd.ExecuteNonQuery();

                }
            }
            catch (SqlException sqlEx)
            {
                
                MessageBox.Show(sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa đơn nhập hàng: " + ex.Message);
            }
            finally
            {
                cnt.Close();
            }
            btnBack5_Click(sender, e);
        }

        private void btnXoaDonNhap_Click(object sender, EventArgs e)
        {
            try
            {
                cnt.Open();

                using (SqlCommand cmd = new SqlCommand("sp_DeleteDonNhapHang", cnt.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số
                    cmd.Parameters.AddWithValue("@MaDonNhap", MaDonNhap);

                    // Thực hiện lệnh
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xóa đơn nhập hàng và các sản phẩm liên quan thành công!");
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                cnt.Close();
            }
            btnBack_Click(sender, e);
        }
    }
}
