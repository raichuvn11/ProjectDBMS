using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDBMSWF
{
    public partial class FNhanvien : Form
    {

        public static ObservableCollection<OrderItem> listOrder = new ObservableCollection<OrderItem>();
        public static BindingList<OrderItem> bindingList = new BindingList<OrderItem>(listOrder.ToList());
        public static string maNV = "NV01";

        public static string ngayLamViec = "";
        public static void AddOrderItem(OrderItem item)
        {
            var existingItem = listOrder.FirstOrDefault(i => i.MaLK == item.MaLK);
            if (existingItem == null)
            {
                listOrder.Add(item);
            }
            else
            {
                existingItem.Soluong = item.Soluong;
                existingItem.TongTien = existingItem.DonGia * existingItem.Soluong;
            }
        }
        public static void RemoveOrderItem(string maLK)
        {
            var itemToRemove = listOrder.FirstOrDefault(item => item.MaLK == maLK);
            if (itemToRemove != null)
            {
                listOrder.Remove(itemToRemove);
            }
        }
        public FNhanvien()
        {
            InitializeComponent();

            FNhanvien.listOrder.CollectionChanged += (s, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (OrderItem item in e.NewItems)
                    {
                        FNhanvien.bindingList.Add(item);
                    }
                }
                else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                {
                    foreach (OrderItem item in e.OldItems)
                    {
                        FNhanvien.bindingList.Remove(item);
                    }
                }
                else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
                {
                    foreach (OrderItem item in e.OldItems)
                    {
                        FNhanvien.bindingList.Remove(item);
                        FNhanvien.bindingList.Add(item);
                    }
                }
            };


        }
        private Form currentFormChild;

        public void OpenForm(Form form)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            PanelContain.Controls.Add(form);
            PanelContain.Tag = form;
            form.BringToFront();
            form.Show();
        }
        private void btnLichsu_Click(object sender, EventArgs e)
        {
            OpenForm(new FLichSuDonHang());
        }

        private void btnLinhkien_Click(object sender, EventArgs e)
        {
            OpenForm(new FLinhKien());
        }

        private void btnChamcong_Click(object sender, EventArgs e)
        {
            OpenForm(new FChamCong(this));
        }

        private void btnXuly_Click(object sender, EventArgs e)
        {
            OpenForm(new FXulydonhang());
        }

        private void btnDoanhthu_Click(object sender, EventArgs e)
        {
            OpenForm(new FDoanhThuCa());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        public void SetNgayLamViec(string ngay)
        {
            ngayLamViec = ngay;
            label2.Text = ngay;
        }

        private void FNhanvien_Load(object sender, EventArgs e)
        {
            label2.Text = ngayLamViec;
            label2.Visible = true;
        }
    }
}
