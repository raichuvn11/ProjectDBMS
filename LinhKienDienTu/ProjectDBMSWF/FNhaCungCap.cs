using System;
using System.Collections;
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
    public partial class FNhaCungCap : Form
    {
        public FNhaCungCap()
        {
            InitializeComponent();
        }
        ConnectDB cnt = new ConnectDB(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LinhKienDienTu2;Integrated Security=True");
        private void FNhaCungCap_Load(object sender, EventArgs e)
        {
            try
            {
                cnt.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM ViewNhaCungCap", cnt.GetConnection());
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                gvNCC.DataSource = dataTable;
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
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                cnt.Open();

                using (SqlCommand cmd = new SqlCommand("AddNhaCungCap", cnt.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure; 

                    cmd.Parameters.AddWithValue("@TenNhaCungCap", txtTenNCC.Text);
                    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@SoDienThoai", txtSDT.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm nhà cung cấp thành công!");
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhà cung cấp: " + ex.Message);
            }
            finally
            {
                cnt.Close();
            }
            FNhaCungCap_Load(sender,e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                cnt.Open();

                using (SqlCommand cmd = new SqlCommand("UpdateNhaCungCap", cnt.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure; 

                    cmd.Parameters.AddWithValue("@MaNhaCungCap", txtMaNCC.Text);
                    cmd.Parameters.AddWithValue("@TenNhaCungCap", txtTenNCC.Text);
                    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@SoDienThoai", txtSDT.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật nhà cung cấp thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhà cung cấp với mã đã cho.");
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật nhà cung cấp: " + ex.Message);
            }
            finally
            {
                cnt.Close();
            }
            FNhaCungCap_Load(sender, e);
        }

        private void gvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                
                DataGridViewRow row = gvNCC.Rows[e.RowIndex];

                
                txtMaNCC.Text = row.Cells["Mã Nhà Cung Cấp"].Value.ToString(); 
                txtTenNCC.Text = row.Cells["Tên Nhà Cung Cấp"].Value.ToString();
                txtDiaChi.Text = row.Cells["Địa Chỉ"].Value.ToString();
                txtSDT.Text = row.Cells["Số Điện Thoại"].Value.ToString();
            }
        }

        private void txtTimKiem_KeyUp(object sender, KeyEventArgs e)
        {

            try
            {
                cnt.Open();


                using (SqlCommand cmd = new SqlCommand("SearchNhaCungCap", cnt.GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure; 


                    cmd.Parameters.AddWithValue("@TenNhaCungCap", txtTimKiem.Text);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        gvNCC.DataSource = dataTable; 
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message);
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
