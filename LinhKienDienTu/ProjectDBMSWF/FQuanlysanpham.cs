﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDBMSWF
{
    public partial class FQuanlysanpham : Form
    {
        public FQuanlysanpham()
        {
            InitializeComponent();
        }
        ConnectDB cnt = new ConnectDB(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LinhKienDienTu2;Integrated Security=True");
        private Image selectedImage;
        private void FQuanlysanpham_Load(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Hide();
            try
            {
                cnt.Open();

                // Câu lệnh SQL để lấy dữ liệu từ View
                string query = "SELECT * FROM ViewSanPham";

                // Khởi tạo SqlCommand
                using (SqlCommand cmd = new SqlCommand(query, cnt.GetConnection()))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    gvSP.DataSource = dataTable;
                    gvSP.Columns["AnhLK"].Width = 150;
                    DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)gvSP.Columns["AnhLK"];

                    
                    gvSP.RowTemplate.Height = 150; 

                    imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;  

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải sản phẩm: " + ex.Message);
            }
            finally
            {
                cnt.Close(); // Đóng kết nối
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            panel2.Show();
            LoadNhaCungCapToComboBox(cbMaNCC);
            LoadNhomLinhKienToComboBox(cbMaNH);
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
        public void LoadNhomLinhKienToComboBox(ComboBox comboBox)
        {
            // Câu lệnh SQL để lấy dữ liệu từ bảng NhomLinhKien
            string query = "SELECT MaNhom, TenNhom FROM NhomLinhKien";

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
                        // Thêm tên nhóm linh kiện vào ComboBox
                        comboBox.Items.Add(new { Text = row["TenNhom"].ToString(), Value = row["MaNhom"] });
                    }

                    // Đặt thuộc tính DisplayMember và ValueMember
                    comboBox.DisplayMember = "Text";
                    comboBox.ValueMember = "Value";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải nhóm linh kiện vào ComboBox: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối
                cnt.Close();
            }
        }

        private void btnHinhAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Chọn Hình Ảnh";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn đến hình ảnh
                    string filePath = openFileDialog.FileName;
                    selectedImage = Image.FromFile(filePath); // Tải hình ảnh vào biến
                    ptbHinhAnh.Image = selectedImage; // Hiển thị hình ảnh trong PictureBox
                }
            }
        }

        private void btnThemLK_Click(object sender, EventArgs e)
        {
            byte[] hinhAnhBytes = ImageToByteArray(ptbHinhAnh.Image);

            try
            {

                cnt.Open();

                using (SqlCommand command = new SqlCommand("sp_AddLinhKien", cnt.GetConnection()))
                {
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.AddWithValue("@MaLK", txtMaSP.Text);
                    command.Parameters.AddWithValue("@TenLK", txtTenSP.Text);
                    command.Parameters.AddWithValue("@GiaTien", txtGiaTien.Text);
                    command.Parameters.AddWithValue("@MoTa", txtMota.Text);
                    command.Parameters.AddWithValue("@SoLuong", 0);
                    command.Parameters.AddWithValue("@TrangThai", "Đang Bán");
                    command.Parameters.AddWithValue("@HinhAnh", (object)hinhAnhBytes ?? DBNull.Value); // Nếu không có hình ảnh, sử dụng DBNull
                    if (cbMaNH.SelectedItem != null)
                    {
                        var selectedItem = (dynamic)cbMaNH.SelectedItem;
                        string selectedId = selectedItem.Value;
                        command.Parameters.AddWithValue("@MaNhom", selectedId);
                    }
                    if (cbMaNCC.SelectedItem != null)
                    {
                        var selectedItem = (dynamic)cbMaNCC.SelectedItem;
                        string selectedId = selectedItem.Value;
                        command.Parameters.AddWithValue("@MaNCC", selectedId);
                    }
                    
                  int result = command.ExecuteNonQuery();

                }
                MessageBox.Show("Thêm sản phẩm thành công!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);

            }
            FQuanlysanpham_Load(sender, e);
        }
        private byte[] ImageToByteArray(Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // Lưu ảnh vào MemoryStream
                return ms.ToArray(); // Trả về mảng byte của ảnh
            }
        }

        private void gvSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadNhaCungCapToComboBox(cbMaNCC2);
            LoadNhomLinhKienToComboBox(cbMaNH2);
            panel3.Show();
            if (e.RowIndex >= 0)
            {
                
                DataGridViewRow row = gvSP.Rows[e.RowIndex];

                
                txtMaSP2.Text = row.Cells["MaLK"].Value.ToString();
                txtTenSP2.Text = row.Cells["TenLK"].Value.ToString();
                txtGiaTien2.Text = row.Cells["GiaTien"].Value.ToString();
                txtMoTa2.Text = row.Cells["MoTa"].Value.ToString();
                cbTrangThai.Text = row.Cells["TrangThai"].Value.ToString();
                cbMaNH2.Text = row.Cells["TenNhom"].Value.ToString();
                cbMaNCC2.Text = row.Cells["TenNhaCungCap"].Value.ToString();

                
                if (row.Cells["AnhLK"].Value != DBNull.Value)
                {
                    byte[] hinhAnhBytes = (byte[])row.Cells["AnhLK"].Value;
                    MemoryStream ms = new MemoryStream(hinhAnhBytes);
                    ptbHinhAnh2.Image = Image.FromStream(ms);
                }
                else
                {
                    ptbHinhAnh2.Image = null; 
                }
            }
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            panel3.Hide();
        }

        private void btnAnh2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Chọn Hình Ảnh";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn đến hình ảnh
                    string filePath = openFileDialog.FileName;
                    selectedImage = Image.FromFile(filePath); // Tải hình ảnh vào biến
                    ptbHinhAnh2.Image = selectedImage; // Hiển thị hình ảnh trong PictureBox
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            byte[] hinhAnhBytes = ImageToByteArray(ptbHinhAnh2.Image);

            try
            {

                cnt.Open();

                using (SqlCommand command = new SqlCommand("sp_UpdateLinhKien", cnt.GetConnection()))
                {
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.AddWithValue("@MaLK", txtMaSP2.Text);
                    command.Parameters.AddWithValue("@TenLK", txtTenSP2.Text);
                    command.Parameters.AddWithValue("@GiaTien", txtGiaTien2.Text);
                    command.Parameters.AddWithValue("@MoTa", txtMoTa2.Text);
                    command.Parameters.AddWithValue("@SoLuong", 0);
                    command.Parameters.AddWithValue("@TrangThai", cbTrangThai.Text);
                    command.Parameters.AddWithValue("@HinhAnh", (object)hinhAnhBytes ?? DBNull.Value); 
                    if (cbMaNH2.SelectedItem != null)
                    {
                        var selectedItem = (dynamic)cbMaNH2.SelectedItem;
                        string selectedId = selectedItem.Value;
                        command.Parameters.AddWithValue("@MaNhom", selectedId);
                    }
                    if (cbMaNCC2.SelectedItem != null)
                    {
                        var selectedItem = (dynamic)cbMaNCC2.SelectedItem;
                        string selectedId = selectedItem.Value;
                        command.Parameters.AddWithValue("@MaNCC", selectedId);
                    }

                    int result = command.ExecuteNonQuery();

                }
                MessageBox.Show("Sửa sản phẩm thành công!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);

            }
            FQuanlysanpham_Load(sender, e);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cnt.Open();


                using (SqlCommand command = new SqlCommand("SELECT * FROM fn_timTenLK(@TenLK)", cnt.GetConnection()))
                {

                    command.Parameters.AddWithValue("@TenLK", txtTimKiem.Text);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable); // Đổ dữ liệu vào DataTable
                        gvSP.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm nhà cung cấp: " + ex.Message);
            }
            finally
            {
                cnt.Close();
            }
        }

        private void txtTimGia_TextChanged(object sender, EventArgs e)
        {
              
            try
            {
                cnt.Open();


                using (SqlCommand command = new SqlCommand("SELECT * FROM fn_timTheoGiaLK(@GiaTien)", cnt.GetConnection()))
                {
                    string giaTienStr = txtTimGia.Text;
                    float giaTien;
                    if (giaTienStr == "")
                    {
                        command.Parameters.AddWithValue("@GiaTien", float.MaxValue);
                    }
                    else
                    if (float.TryParse(giaTienStr, out giaTien))
                    {

                        command.Parameters.AddWithValue("@GiaTien", giaTien);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable); 
                        gvSP.DataSource = dataTable;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm nhà cung cấp: " + ex.Message);
            }
            finally
            {
                cnt.Close();
            }
        }

        private void txtTimNhom_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cnt.Open();


                using (SqlCommand command = new SqlCommand("SELECT * FROM fn_timNhomLK(@TenNhom)", cnt.GetConnection()))
                {

                    command.Parameters.AddWithValue("@TenNhom", txtTimNhom.Text);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable); // Đổ dữ liệu vào DataTable
                        gvSP.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm nhà cung cấp: " + ex.Message);
            }
            finally
            {
                cnt.Close();
            }
        }


    }
}
