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
    public partial class FDangnhap : Form
    {
        ConnectDB cnt = new ConnectDB(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LinhKienDienTu2;Integrated Security=True");
        public FDangnhap()
        {
            InitializeComponent();
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
                
                    try
                    {
                        cnt.Open();
                        using (SqlCommand cmd = new SqlCommand("SELECT MaNV FROM fn_GetMaNV_BySDT(@MaNV)",cnt.GetConnection()))
                        {
                            
                            cmd.Parameters.AddWithValue("@MaNV", txbLogin.Text);

                            object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                FNhanvien.maNV = result.ToString();
                                FNhanvien f = new FNhanvien();
                                f.Show();
                                this.Hide();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đăng nhập thất bại");
                    }           
            }
            else if (btnQly.Checked == true && txbLogin.Text == "admin")
            {
                this.Hide(); 
                FQuanly f = new FQuanly();
                f.Show();
            }
        }
    }
}
