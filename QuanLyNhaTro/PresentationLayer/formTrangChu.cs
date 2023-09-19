using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaTro
{
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void đăngXuấtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Khai báo biến traloi 
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp 
            traloi = MessageBox.Show("Bạn có muốn đăng xuất không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không? 
            if (traloi == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void chiTiếtHợpĐồngThuêPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChiTietHopDongThuePhong cthd = new frmChiTietHopDongThuePhong();
            cthd.ShowDialog();
        }

        private void chiTiếtSửDụngDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChiTietDichVu ctdv = new frmChiTietDichVu();
            ctdv.ShowDialog();
        }

        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmNhanVien nv = new frmNhanVien();
            nv.ShowDialog();
        }

        private void thiếtBịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThietBi tb = new frmThietBi();
            tb.ShowDialog();
        }

        private void trangBịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrangBi cttb = new frmTrangBi();
            cttb.ShowDialog();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien nv = new frmNhanVien();
            nv.ShowDialog();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaiKhoan tk = new frmTaiKhoan();
            tk.ShowDialog();
        }

        private void phòngTrọToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhongTro pt = new frmPhongTro();
            pt.ShowDialog();
        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDichVu dv = new frmDichVu();
            dv.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachHang kh = new frmKhachHang();
            kh.ShowDialog();
        }

        private void sổThuTiềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSoThuTien stt = new frmSoThuTien();
            stt.ShowDialog();
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            pbxLogo.Load(@"Resources\THlogo.png"); //load logo vào pictureboxLogo
            this.BackgroundImage = Image.FromFile(@"Resources\home1.jpg"); //load hình back ground vào form
            btnNhanVien.BackgroundImage = Image.FromFile(@"Resources\nhanvien.png"); //load hình back ground vào button
            btnKhachHang.BackgroundImage = Image.FromFile(@"Resources\khachhang.png"); //load hình back ground vào button
            btnDichVu.BackgroundImage = Image.FromFile(@"Resources\dichvu.png"); //load hình back ground vào button
            btnHopDong.BackgroundImage = Image.FromFile(@"Resources\hopdong.png"); //load hình back ground vào button
            btnPhongTro.BackgroundImage = Image.FromFile(@"Resources\phongtro.png"); //load hình back ground vào button
        }

        private void hợpĐồngThuêPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formHopDongThuePhong hd = new formHopDongThuePhong();
            hd.ShowDialog();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongTinPhanMem tt = new frmThongTinPhanMem();
            tt.ShowDialog();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang kh = new frmKhachHang();
            kh.ShowDialog();
        }

        private void btnPhongTro_Click(object sender, EventArgs e)
        {
            frmPhongTro pt = new frmPhongTro();
            pt.ShowDialog();
        }

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            formHopDongThuePhong hd = new formHopDongThuePhong();
            hd.ShowDialog();
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            frmDichVu dv = new frmDichVu();
            dv.ShowDialog();
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
