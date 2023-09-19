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
    public partial class frmDangNhap : Form
    {
        BusinessLayerTaiKhoan tkbusiness = new BusinessLayerTaiKhoan();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string err = "";
            // Thông tin đăng nhập (Tên người dùng/ Mật khẩu)
            if (tkbusiness.DangNhap(ref err, txtTenNguoiDung.Text, txtMatKhau.Text.Trim()))
            {
                txtTenNguoiDung.ResetText();
                txtMatKhau.ResetText();
                txtTenNguoiDung.Focus();
                frmLoading ld = new frmLoading();
                ld.Show();
                //this.Close();
            }

            else // không đúng thì xuất ra thông báo!
            {
                MessageBox.Show(err, "Thông báo!");
                this.txtTenNguoiDung.ResetText();
                this.txtMatKhau.ResetText();
                this.txtTenNguoiDung.Focus();
            }
        }

        private void txtTenNguoiDung_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chuyển xuống nhập Mật khẩu
            if (e.KeyChar == 13)
                txtMatKhau.Focus();
        }

        private void formDangNhap_Load(object sender, EventArgs e)
        {
            txtTenNguoiDung.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Xóa Tên người dùng và mật khẩu
            this.txtTenNguoiDung.Clear();
            this.txtMatKhau.Clear();
            this.txtTenNguoiDung.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Thoát khỏi FormDangNhap
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Đăng nhập
            if (e.KeyChar == 13)
                btnDangNhap_Click(null, null);
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(@"Resources\dangnhap.jpg"); //load hình back ground vào form
        }
    }
}
