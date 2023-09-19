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

namespace QuanLyNhaTro
{
    public partial class frmTaiKhoan : Form
    {
        BusinessLayerTaiKhoan tkbusiness = new BusinessLayerTaiKhoan();
        QuanLyNhaTroDataModel db = new QuanLyNhaTroDataModel();

        bool Them = false;

        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView  
                dgvTenNguoiDung.DataSource = tkbusiness.LayTaiKhoan();
                dgvTenNguoiDung.Columns[1].Visible = false;
                // Thay đổi độ rộng cột 
                dgvTenNguoiDung.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel 
                this.txtTenNguoiDung.ResetText();
                this.txtMKCu.ResetText();
                this.txtMKMoi.ResetText();
                this.txtXacNhan.ResetText();
                this.panel.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy 
                this.btnLuu.Enabled = false;
                this.btnHuyBo.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát 
                this.btnThemTK.Enabled = true;
                this.btnDoiMK.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnQuayLai.Enabled = true;
                // Đặt tên cột
                dgvTenNguoiDung.Columns[0].HeaderText = "Tên người dùng";
                // Sự kiện click chuột
                dgvTenNguoiDung_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung tài khoản. Đã xảy ra lỗi!");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool kq = false;
            string err = "";
            // Thêm dữ liệu 
            if (Them )
            {
                // Tài khoản đã tồn tại
                if (tkbusiness.KiemTraTaiKhoan(ref err, txtTenNguoiDung.Text))
                {
                    MessageBox.Show(err);
                    txtTenNguoiDung.ResetText();
                    txtMKMoi.ResetText();
                    txtMKCu.ResetText();
                    txtXacNhan.ResetText();
                }
                else
                {
                    if(txtMKMoi.Text.Trim() != txtXacNhan.Text.Trim())
                    {
                        err = "Mật khẩu xác nhận không giống nhau!";
                        MessageBox.Show(err);
                        txtMKMoi.ResetText();
                        txtXacNhan.ResetText();
                        txtMKMoi.Focus();
                    }
                    else
                    {
                        try
                        {
                            kq = tkbusiness.ThemTaiKhoan(ref err, txtTenNguoiDung.Text, txtMKMoi.Text);
                            if (kq)
                            {
                                // Load lại dữ liệu trên DataGridView 
                                LoadData();
                                // Thông báo 
                                MessageBox.Show("Đã thêm tài khoản thành công!");
                            }

                        }
                        catch (SqlException)
                        {
                            err = "Đã xảy ra lỗi! Không thể thêm tài khoản!";
                            MessageBox.Show(err);
                        }
                    }
                }
            }
            else // Đổi mật khẩu
            {
                kq = false;
                // Thứ tự dòng hiện hành 
                int r = dgvTenNguoiDung.CurrentCell.RowIndex;
                // MaKH hiện hành 
                string strTenNguoiDung =
                dgvTenNguoiDung.Rows[r].Cells[0].Value.ToString();

                if (tkbusiness.KiemTraMatKhau(ref err, txtTenNguoiDung.Text, txtMKCu.Text))
                {
                    MessageBox.Show(err);
                    txtMKCu.ResetText();
                    txtMKMoi.ResetText();
                    txtXacNhan.ResetText();
                    txtMKCu.Focus();
                }
                else if (txtMKMoi.Text.Trim() != txtXacNhan.Text.Trim())
                {
                    err = "Mật khẩu xác nhận không giống nhau!";
                    MessageBox.Show(err);
                    txtMKMoi.ResetText();
                    txtXacNhan.ResetText();
                    txtMKMoi.Focus();
                }
                else
                {
                    // Câu lệnh SQL 
                    kq = tkbusiness.DoiMatKhau(ref err, txtTenNguoiDung.Text, txtMKMoi.Text);
                    if (kq)
                    {
                        // Load lại dữ liệu trên DataGridView 
                        LoadData();
                        // Thông báo 
                        MessageBox.Show("Đã đổi mật khẩu thành công!");
                    }
                }
            }

        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            dgvTenNguoiDung_CellClick(null, null);
            // Kích hoạt biến Sửa 
            Them = false;
            // Cho phép thao tác trên Panel 
            this.panel.Enabled = true;
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThemTK.Enabled = false;
            this.btnDoiMK.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnQuayLai.Enabled = false;
            // Đưa con trỏ đến TextField txtMKCu
            this.txtMKCu.Enabled = true;
            this.txtMKCu.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool kq = false;
            string err = "";
            try
            {

                // Lấy thứ tự record hiện hành 
                int r = dgvTenNguoiDung.CurrentCell.RowIndex;
                // Lấy TenNguoiDung của record hiện hành 
                string strTenNguoiDung =
                dgvTenNguoiDung.Rows[r].Cells[0].Value.ToString();

                // Hiện thông báo xác nhận việc xóa mẫu tin 
                // Khai báo biến traloi 
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp 
                traloi = MessageBox.Show("Bạn có chắc chắn muốn xoá tài khoản này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không? 
                if (traloi == DialogResult.Yes)
                {
                    // Thực hiện câu lệnh SQL 
                    kq = tkbusiness.XoaTaiKhoan(ref err, txtTenNguoiDung.Text);
                    if (kq)
                    {
                        // Cập nhật lại DataGridView 
                        LoadData();
                        // Thông báo 
                        MessageBox.Show("Đã xóa tài khoản thành công!");
                    }
                }
                else
                {

                    // Thông báo 
                    MessageBox.Show("Không xoá được tài khoản!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!");
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel 
            this.txtTenNguoiDung.ResetText();
            this.txtMKCu.ResetText();
            this.txtMKMoi.ResetText();
            this.txtXacNhan.ResetText();
            this.panel.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            this.btnThemTK.Enabled = true;
            this.btnDoiMK.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnQuayLai.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = false;
            this.btnHuyBo.Enabled = false;
            dgvTenNguoiDung_CellClick(null, null);
        }

        private void btnThemTK_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            this.txtTenNguoiDung.ResetText();
            this.txtMKCu.ResetText();
            this.txtMKMoi.ResetText();
            this.txtXacNhan.ResetText();
            this.panel.ResetText();
            // Vô hiệu textbox MKCu
            this.txtMKCu.Enabled = false;
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThemTK.Enabled = false;
            this.btnDoiMK.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnQuayLai.Enabled = false;
            // Đưa con trỏ đến TextField txtTenNguoiDung
            this.txtTenNguoiDung.Focus();
            Them = true;
        }

        private void btnQL_Click(object sender, EventArgs e)
        {
            // Khai báo biến traloi 
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp 
            traloi = MessageBox.Show("Bạn có muốn trở về trang chủ?", "Trả lời",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không? 
            if (traloi == DialogResult.OK)
                this.Close();
        }

        private void formTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvTenNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.panel.Enabled = true;
            // Thứ tự dòng hiện hành 
            int r = dgvTenNguoiDung.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtTenNguoiDung.Text =
                dgvTenNguoiDung.Rows[r].Cells[0].Value.ToString();
        }
    }
}
