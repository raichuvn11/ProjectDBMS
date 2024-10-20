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
    public partial class FPhanCa : Form
    {
        ConnectDB cnt = new ConnectDB(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LinhKienDienTu2;Integrated Security=True");
        string Maca;
        public FPhanCa()
        {
            InitializeComponent();
        }
        public void LoadNhanVienToComboBox(ComboBox comboBox)
        {
            string query = "SELECT MaNV, HoTen FROM NhanVien";

           
            try
            {
                cnt.Open();

                
                using (SqlCommand cmd = new SqlCommand(query, cnt.GetConnection()))
                {
                    
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();

                    
                    adapter.Fill(dataTable);

                    
                    comboBox.Items.Clear();

                    
                    foreach (DataRow row in dataTable.Rows)
                    {
                        
                        comboBox.Items.Add(new { Text = row["HoTen"].ToString(), Value = row["MaNV"] });
                    }
                    comboBox.DisplayMember = "Text";
                    comboBox.ValueMember = "Value";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải nhân viên vào ComboBox: " + ex.Message);
            }
            finally
            {
                
                cnt.Close();
            }
        }
        private void btnTaoCa_Click(object sender, EventArgs e)
        {
            try
            {
                cnt.Open();
                using (SqlCommand cmd = new SqlCommand("sp_AddCaLamViec", cnt.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ngay", dtNgay.Value.Date);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm Thành Công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            finally
            {

                cnt.Close();
            }
            FPhanCa_Load(sender, e);
        }

        private void FPhanCa_Load(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            try
            {
                cnt.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM ViewCaLamViec Where Ngay = @Ngay", cnt.GetConnection());
                cmd.Parameters.AddWithValue("@Ngay", dtNgay.Value.Date);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                gvBangca.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            finally
            {

                cnt.Close();
            }
        }

        private void dtNgay_ValueChanged(object sender, EventArgs e)
        {
            FPhanCa_Load(sender, e);
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            panel3.Show();
            LoadNhanVienToComboBox(cbNhanVien);

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void gvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel4.Show();
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = gvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNhanVien"].Value.ToString();
                txtTenNV.Text = row.Cells["TenNhanVien"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
            }
        }

        private void gvBangca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Show();
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = gvBangca.Rows[e.RowIndex];
                Maca = row.Cells["MaCa"].Value.ToString();
                txtTenCa.Text = row.Cells["TenCa"].Value.ToString();
                DateTime selectedDate = Convert.ToDateTime(row.Cells["Ngay"].Value);
                txtNgay.Text = selectedDate.ToString("dd/MM/yyyy");
                txtThoiGianBD.Text = row.Cells["ThoiGianBD"].Value.ToString();
                txtThoiGianKT.Text = row.Cells["ThoiGianKT"].Value.ToString();
            }
            try
            {
                cnt.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ViewPhanCa Where MaCa = @MaCa ", cnt.GetConnection());
                cmd.Parameters.AddWithValue("@MaCa", Maca);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvNhanVien.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnBack3_Click(object sender, EventArgs e)
        {
            panel3.Hide();
            try
            {
                cnt.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ViewPhanCa Where MaCa = @MaCa ", cnt.GetConnection());
                cmd.Parameters.AddWithValue("@MaCa", Maca);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvNhanVien.DataSource = dt;
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

                using (SqlCommand cmd = new SqlCommand("sp_InsertPhanCa", cnt.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (cbNhanVien.SelectedItem != null)
                    {
                        var selectedItem = (dynamic)cbNhanVien.SelectedItem;
                        string selectedId = selectedItem.Value;
                        cmd.Parameters.AddWithValue("@MaNhanVien", selectedId);
                    }
                    cmd.Parameters.AddWithValue("@MaCa", Maca);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm phân ca thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Phân ca đã tồn tại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                cnt.Close();
            }
            btnBack3_Click(sender, e);
        }

        private void btnBack4_Click(object sender, EventArgs e)
        {
            panel4.Hide();
            try
            {
                cnt.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ViewPhanCa Where MaCa = @MaCa ", cnt.GetConnection());
                cmd.Parameters.AddWithValue("@MaCa", Maca);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvNhanVien.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                cnt.Open();

                using (SqlCommand cmd = new SqlCommand("sp_DeletePhanCa", cnt.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaNhanVien", txtMaNV.Text);
                    cmd.Parameters.AddWithValue("@MaCa", Maca);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa phân ca thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy phân ca để xóa!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                cnt.Close();
            }
            btnBack4_Click(sender, e);
        }
    }
}
