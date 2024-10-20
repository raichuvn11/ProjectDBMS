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
    public partial class FQuanly : Form
    {
        public FQuanly()
        {
            InitializeComponent();
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
        private void ptb_avatar_Click(object sender, EventArgs e)
        {

        }

        private void btnQlykho_Click(object sender, EventArgs e)
        {
            OpenForm(new FQuanlykho());
        }

        private void btnQuanlyNvien_Click(object sender, EventArgs e)
        {
            OpenForm(new FQuanlynhanvien());
        }

        private void btnDoanhthu_Click(object sender, EventArgs e)
        {
            OpenForm(new FDoanhthu());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            OpenForm(new FNhaCungCap());
        }

        private void btnQLySanPham_Click(object sender, EventArgs e)
        {
            OpenForm(new FQuanlysanpham());
        }

        private void btnQlyNH_Click(object sender, EventArgs e)
        {
            OpenForm(new FQuanlynhaphang());
        }

        private void btnBangPC_Click(object sender, EventArgs e)
        {
            OpenForm(new FPhanCa());
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            OpenForm(new FQuanlykho());
        }
    }
}
