using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDBMSWF
{
    public class OrderItem
    {
        private string maLK;
        private string tenLK;
        private int soluong;
        private float donGia;
        private float tongTien;
        private Image anhLK;

        public string MaLK { get => maLK; set => maLK = value; }
        public string TenLK { get => tenLK; set => tenLK = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public float DonGia { get => donGia; set => donGia = value; }
        public float TongTien
        {
            get => tongTien;
            set => tongTien = value;
        }
        public Image AnhLK { get => anhLK; set => anhLK = value; }

        public OrderItem(string maLK, string tenLK, int soluong, float donGia, Image anhLK)
        {
            MaLK = maLK;
            TenLK = tenLK;
            Soluong = soluong;
            DonGia = donGia;
            TongTien = donGia * soluong;
            AnhLK = anhLK;
        }
    }
}
