using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDBMSWF
{
    public partial class FLinhKien : Form
    {
        public FLinhKien()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void LoadNhomLinhKienToComboBox(ComboBox comboBox)
        {  
            string query = "SELECT MaNhom, TenNhom FROM NhomLinhKien";
            string connectionString = DataConnector.connectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    comboBox.Items.Clear();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        comboBox.Items.Add(new { Text = row["TenNhom"].ToString(), Value = row["MaNhom"] });
                    }

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
                connection.Close();
            }
        }
        private void BindingData()
        {
            try
            {
                lbl_maLK.DataBindings.Clear();
                lbl_tenLK.DataBindings.Clear();
                lbl_nhomLK.DataBindings.Clear();
                lbl_moTa.DataBindings.Clear();
                lbl_giaTien.DataBindings.Clear();
                lbl_soLuong.DataBindings.Clear();
                productImage.DataBindings.Clear();

                lbl_maLK.DataBindings.Add("Text", listProduct_gridView.DataSource, "MaLK");
                lbl_tenLK.DataBindings.Add("Text", listProduct_gridView.DataSource, "TenLK");
                lbl_nhomLK.DataBindings.Add("Text", listProduct_gridView.DataSource, "TenNhom");
                lbl_moTa.DataBindings.Add("Text", listProduct_gridView.DataSource, "MoTa");
                lbl_giaTien.DataBindings.Add("Text", listProduct_gridView.DataSource, "GiaTien");
                lbl_soLuong.DataBindings.Add("Text", listProduct_gridView.DataSource, "SoLuong");

                // load ảnh sản phẩm
                if (listProduct_gridView.CurrentRow != null)
                {
                    var imageData = listProduct_gridView.CurrentRow.Cells["AnhLK"].Value;
                    if (imageData != null && imageData != DBNull.Value)
                    {
                        Binding imageBinding = new Binding("Image", listProduct_gridView.DataSource, "AnhLK");
                        imageBinding.Format += new ConvertEventHandler(DataConnector.ImageFormat);
                        productImage.DataBindings.Add(imageBinding);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }
        private void FLinhKien_Load(object sender, EventArgs e)
        {
            listProduct_gridView.DataSource = null;
            listProduct_gridView.DataSource = NhanVienDAO.listProduct();
            LoadNhomLinhKienToComboBox(box_nhomLk);
            BindingData();
        }

        private void txb_search_TextChanged(object sender, EventArgs e)
        {
            listProduct_gridView.DataSource = null;
            string tenLK = txb_search.Text;
            listProduct_gridView.DataSource = NhanVienDAO.getProductByName(tenLK);
            BindingData();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            listProduct_gridView.DataSource = null;
            string tenNhom = "";
            if (box_nhomLk.SelectedItem != null)
            {
                var selectedItem = (dynamic)box_nhomLk.SelectedItem;
                tenNhom = selectedItem.Text;
            }
            string str_gia = box_gia.SelectedItem?.ToString();
            float gia;
            if (string.IsNullOrEmpty(str_gia))
            {
                gia = 0;
            }
            else
            {
                gia = float.Parse(str_gia);
            }
            string trangThai = box_trangThai.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(trangThai))
            {
                trangThai = "";
            }
            listProduct_gridView.DataSource = NhanVienDAO.getProductByFilter(tenNhom, gia, trangThai);
            BindingData();
        }

        private void btn_addToOrder_Click(object sender, EventArgs e)
        {
            try
            {
                OrderItem order = new OrderItem(lbl_maLK.Text, lbl_tenLK.Text, 1, float.Parse(lbl_giaTien.Text), productImage.Image);
                FNhanvien.AddOrderItem(order);
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
