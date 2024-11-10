using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDBMSWF
{
    public partial class FDangnhap : Form
    {
        ConnectDB cnt = new ConnectDB(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LinhKienDienTu2;Integrated Security=True");
        public static String MaNV;
        public static String SĐT;
        public FDangnhap()
        {
            InitializeComponent();
            panel1.Hide();
            panel2.Hide();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            if (btnNvien.Checked == true)
            {
                MaNV = txtMaNV.Text;
                SĐT = txtSĐT.Text;

                if (AuthenticateUser(MaNV, SĐT))
                {
                    MessageBox.Show("Đăng nhập thành công");
                    FNhanvien f = new FNhanvien();
                    FNhanvien.maNV =MaNV;
                    f.Show();
                    this.Hide();
                    
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại");
                }
            }
            else if (btnQly.Checked == true && txbLoginAdmin.Text == "admin")
            {
                this.Hide(); 
                FQuanly f = new FQuanly();
                f.Show();
            }
        }

        private bool AuthenticateUser(string maNV, string sdt)
        {
            bool isAuthenticated = false;
           
                try
                {
                    cnt.Open();
                    SqlCommand cmd = new SqlCommand("SELECT [dbo].[sp_CheckLogin](@MaNV, @SDT)", cnt.GetConnection());
                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    cmd.Parameters.AddWithValue("@SDT", sdt);

                    isAuthenticated = (bool)cmd.ExecuteScalar();
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show(sqlEx.Message);
                }
            catch (Exception ex)
                {
                    MessageBox.Show("Lỗi:" + ex.Message);
                }
                finally
                {
                    cnt.Close();
                }

            return isAuthenticated;
        }
  
        private void btnNvien_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
        }

        private void btnQly_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
        }

        private void pnlLogin_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void txbLoginAdmin_TextChanged(object sender, EventArgs e)
        {

        }

        private void FDangnhap_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
        }
    }
}
