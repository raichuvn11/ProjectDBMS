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
    public partial class FQuanlykho : Form
    {
        ConnectDB cnt = new ConnectDB(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LinhKienDienTu2;Integrated Security=True");
        public FQuanlykho()
        {
            InitializeComponent();
        }

        private void FQuanlykho_Load(object sender, EventArgs e)
        {
            panel2.Hide();
            try
            {
                cnt.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM ViewNhomLK", cnt.GetConnection());
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                gvProduct.DataSource = dataTable;
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

        private void gvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = gvProduct.Rows[e.RowIndex];
                txtMaNH.Text = row.Cells["MaNhom"].Value.ToString();
                txtTenNH.Text = row.Cells["TenNhom"].Value.ToString();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                cnt.Open();

                using (SqlCommand cmd = new SqlCommand("sp_InsertNhomLinhKien", cnt.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                   
                    cmd.Parameters.AddWithValue("@MaNhom", txtMaNH.Text);
                    cmd.Parameters.AddWithValue("@TenNhom", txtTenNH.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm Thành Công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm Nhóm Linh Kiện: " + ex.Message);
            }
            finally
            {
                cnt.Close();
            }
            FQuanlykho_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                cnt.Open();

                using (SqlCommand cmd = new SqlCommand("sp_UpdateNhomLinhKien", cnt.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@MaNhom", txtMaNH.Text);
                    cmd.Parameters.AddWithValue("@TenNhom", txtTenNH.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Thành Công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa Nhóm Linh Kiện: " + ex.Message);
            }
            finally
            {
                cnt.Close();
            }
            FQuanlykho_Load(sender, e);
        }

        private void txtTimKiem_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void gvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Show();
            try
            {
                cnt.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ViewSanPham Where TenNhom = @TenNhom ", cnt.GetConnection());
                cmd.Parameters.AddWithValue("@TenNhom", txtTenNH.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvSP.DataSource = dt;
                gvSP.Columns["AnhLK"].Width = 150;
                DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)gvSP.Columns["AnhLK"];


                gvSP.RowTemplate.Height = 150;

                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void txtTimKiemTen_KeyUp(object sender, KeyEventArgs e)
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
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
            finally
            {
                cnt.Close();
            }
        }

        private void txtTimGia_KeyUp(object sender, KeyEventArgs e)
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
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
            finally
            {
                cnt.Close();
            }
        }
    }
}
