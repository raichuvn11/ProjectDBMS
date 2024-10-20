using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
namespace ProjectDBMSWF
{
    public class DataConnector
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LinhKienDienTu2;Integrated Security=True";

        public void connectToDB(string query)
        {

        }
        public static void ImageFormat(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType != typeof(Image) || e.Value == DBNull.Value)
            {
                e.Value = null; // Nếu không có ảnh, hiển thị null
                return;
            }

            byte[] imgBytes = (byte[])e.Value;
            if (imgBytes != null && imgBytes.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imgBytes))
                {
                    e.Value = Image.FromStream(ms);
                }
            }
            else
            {
                e.Value = null; // Nếu dữ liệu ảnh rỗng, không hiển thị gì
            }
        }
    }
}
