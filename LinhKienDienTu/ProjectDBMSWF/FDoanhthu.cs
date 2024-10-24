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
    public partial class FDoanhthu : Form
    {
        ConnectDB sqlCon = new ConnectDB(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LinhKienDienTu2;Integrated Security=True");
        public FDoanhthu()
        {
            InitializeComponent();
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCon.Open();
                string func = "SELECT dbo.fn_tongDoanhThu(@Start, @End)";
                SqlCommand cmd = new SqlCommand(func, sqlCon.GetConnection());
                cmd.Parameters.AddWithValue("@Start", dtpNgayBatDau.Value);
                cmd.Parameters.AddWithValue("@End", dtpNgayKetThuc.Value);
                txtDoanhThu.Text = cmd.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCon.Open();
                string func1 = "SELECT dbo.fn_doanhThuTheoThang(@Month, @Year)";
                SqlCommand cmd = new SqlCommand(func1, sqlCon.GetConnection());
                cmd.Parameters.AddWithValue("@Month", Convert.ToInt32(cbThang.SelectedItem));
                cmd.Parameters.AddWithValue("@Year", Convert.ToInt32(txtNam.Text));
                txtDoanhThuThang.Text = cmd.ExecuteScalar().ToString();

                string func2 = "SELECT dbo.fn_loiNhuanTheoThang(@Month, @Year)";
                SqlCommand cmd2 = new SqlCommand(func2, sqlCon.GetConnection());
                cmd2.Parameters.AddWithValue("@Month", Convert.ToInt32(cbThang.SelectedItem));
                cmd2.Parameters.AddWithValue("@Year", Convert.ToInt32(txtNam.Text));
                txtLoiNhuan.Text = cmd2.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
