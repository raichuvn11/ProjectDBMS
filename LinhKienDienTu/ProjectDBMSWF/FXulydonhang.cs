using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDBMSWF
{
    public partial class FXulydonhang : Form
    {
        public FXulydonhang()
        {
            InitializeComponent();
        }

        private void detailGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void loadListOrder()
        {
            orderGridView.DataSource = FNhanvien.bindingList;
            lbl_maLK.DataBindings.Clear();
            lbl_productName.DataBindings.Clear();
            txb_soLuong.DataBindings.Clear();
            lbl_giaTien.DataBindings.Clear();
            lbl_tongTien.DataBindings.Clear();
            imageProduct.DataBindings.Clear();

            lbl_maLK.DataBindings.Add("Text", orderGridView.DataSource, "MaLK");
            lbl_productName.DataBindings.Add("Text", orderGridView.DataSource, "TenLk");
            txb_soLuong.DataBindings.Add("Text", orderGridView.DataSource, "SoLuong");
            lbl_giaTien.DataBindings.Add("Text", orderGridView.DataSource, "DonGia");
            lbl_tongTien.DataBindings.Add("Text", orderGridView.DataSource, "TongTien");
            imageProduct.DataBindings.Add("Image", orderGridView.DataSource, "AnhLK");
            lbl_itemNumber.Text = FNhanvien.listOrder.Count().ToString();
            lbl_triGiaHoaDon.Text = FNhanvien.listOrder.Sum(i => i.TongTien).ToString();
        }
        private void FXulydonhang_Load(object sender, EventArgs e)
        {
            orderGridView.DataSource = null;
            loadListOrder();
        }

        private void btn_capNhat_Click(object sender, EventArgs e)
        {
            orderGridView.DataSource = null;
            OrderItem order = new OrderItem(lbl_maLK.Text, lbl_productName.Text, int.Parse(txb_soLuong.Text), float.Parse(lbl_giaTien.Text), imageProduct.Image);
            FNhanvien.AddOrderItem(order);
            loadListOrder();
        }

        private void btn_huyProduct_Click(object sender, EventArgs e)
        {
            orderGridView.DataSource = null;
            OrderItem order = new OrderItem(lbl_maLK.Text, lbl_productName.Text, int.Parse(txb_soLuong.Text), float.Parse(lbl_giaTien.Text), imageProduct.Image);
            FNhanvien.RemoveOrderItem(lbl_maLK.Text);
            loadListOrder();
        }

        private void btn_addHoaDon_Click(object sender, EventArgs e)
        {

            try
            {
                NhanVienDAO.saveInfoKH(txb_hoten.Text, txb_sdt.Text, txb_email.Text, txb_diachi.Text);
                DateTime ngayXuatHD = DateTime.Now;
                string maKH = "KH" + txb_sdt.Text;
                NhanVienDAO.xuatHoaDon(ngayXuatHD, float.Parse(lbl_triGiaHoaDon.Text), maKH, FNhanvien.maNV);
                MessageBox.Show("Thêm hóa đơn thành công", "Thông báo");

                //thêm vào chi tiết hóa đơn
                string maHD = NhanVienDAO.getMaHD(FNhanvien.maNV, maKH, ngayXuatHD);
                foreach (OrderItem item in FNhanvien.listOrder)
                {
                    NhanVienDAO.themChiTietHD(item.MaLK, maHD, item.Soluong, item.DonGia, item.TongTien);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }



        }
    }
}
