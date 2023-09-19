using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace QuanLyNhaTro
{
    public partial class frmNhanVien : Form
    {
        BusinessLayerNhanVien nvbusiness =
            new BusinessLayerNhanVien();
        QuanLyNhaTroDataModel db = new QuanLyNhaTroDataModel();
        bool Them = false;
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
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

        private void formNhanVien_Load(object sender, EventArgs e)
        {
            pbxLogo.Load(@"Resources\nhanvien3.png"); //load logo vào pictureboxLogo
            LoadData();
            LoadCombobox();
        }

        public void LoadCombobox()
        {
            try
            {
                //load giới tính của nhân viên
                this.cbxGioi.DataSource = nvbusiness.LayNhanVien();
                this.cbxGioi.ValueMember = "GioiTinh";
                this.cbxGioi.DisplayMember = "Giới";
            }
            catch (SqlException error)  //bắt lỗi sql
            {
                MessageBox.Show("Không truy cập dữ liệu nhân viên được!\rLỗi: " + error.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception er)    //bắt các lỗi khác
            {
                MessageBox.Show("Không truy cập dữ liệu nhân viên được!\rLỗi: " + er.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            Them = true;

            // Xóa trống các đối tượng trong Panel 
            this.txtMaNV.ResetText();
            this.txtHoTen.ResetText();
            this.panel.ResetText();
            this.dtpNgaySinh.ResetText();
            //this.dtp.ResetText();
            this.cbxGioi.ResetText();
            this.txtCCCD.ResetText();
            this.txtQueQuan.ResetText();
            this.txtLuong.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnQuayLai.Enabled = false;
            // Đưa con trỏ đến TextField txtMaNV
            this.txtMaNV.Focus();
        }

        void LoadData()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView  
                dgvNhanVien.DataSource = nvbusiness.LayNhanVien();
                dgvNhanVien.Columns[7].Visible = false;
                // Thay đổi độ rộng cột 
                dgvNhanVien.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel 
                this.txtMaNV.ResetText();
                this.txtHoTen.ResetText();
                this.panel.ResetText();
                this.dtpNgaySinh.ResetText();
                //this.dtp.ResetText();
                this.cbxGioi.ResetText();
                this.txtCCCD.ResetText();
                this.txtQueQuan.ResetText();
                this.txtLuong.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy 
                this.btnLuu.Enabled = false;
                this.btnHuyBo.Enabled = false;
                this.panel.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát 
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnQuayLai.Enabled = true;
                // Đặt tên cột
                dgvNhanVien.Columns[0].HeaderText = "Mã nhân viên";
                dgvNhanVien.Columns[1].HeaderText = "Tên";
                dgvNhanVien.Columns[2].HeaderText = "Giới tính";
                dgvNhanVien.Columns[3].HeaderText = "Năm sinh";
                dgvNhanVien.Columns[4].HeaderText = "CCCD/CMND";
                dgvNhanVien.Columns[5].HeaderText = "Quê quán";
                dgvNhanVien.Columns[6].HeaderText = "Lương";
                // Sự kiện click chuột
                dgvNhanVien_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung nhân viên.Đã xảy ra lỗi!");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool kq = false;
            string err = "";
            // Thêm dữ liệu 
            if (Them)
            {
                try
                {
                    kq = nvbusiness.ThemNhanVien(ref err, txtMaNV.Text, txtHoTen.Text, cbxGioi.Text,
                        DateTime.Parse(dtpNgaySinh.Text), txtQueQuan.Text, txtCCCD.Text, int.Parse(txtLuong.Text));
                    if (kq)
                    {
                        // Load lại dữ liệu trên DataGridView 
                        LoadData();
                        // Thông báo 
                        MessageBox.Show("Đã thêm xong!");
                    }

                }
                catch (SqlException)
                {
                    err = "Không thêm được. Lỗi rồi!";
                    MessageBox.Show(err);
                }
            }
            else
            {
                kq = false;
                // Thứ tự dòng hiện hành 
                int r = dgvNhanVien.CurrentCell.RowIndex;
                // MaKH hiện hành 
                string strMaNV =
                dgvNhanVien.Rows[r].Cells[0].Value.ToString();

                // Câu lệnh SQL 
                kq = nvbusiness.CapNhatNhanVien(ref err, txtMaNV.Text, txtHoTen.Text, cbxGioi.Text,
                        DateTime.Parse(dtpNgaySinh.Text), txtQueQuan.Text, txtCCCD.Text, int.Parse(txtLuong.Text));
                if (kq)
                {
                    // Load lại dữ liệu trên DataGridView 
                    LoadData();
                    // Thông báo 
                    MessageBox.Show("Đã cập nhật xong!");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            // Cho phép thao tác trên Panel 
            this.panel.Enabled = true;
            dgvNhanVien_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnQuayLai.Enabled = false;
            // Đưa con trỏ đến TextField txtMaNV 
            this.txtMaNV.Enabled = false;
            this.txtHoTen.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool kq = false;
            string err = "";
            try
            {

                // Lấy thứ tự record hiện hành 
                int r = dgvNhanVien.CurrentCell.RowIndex;
                // Lấy MaNV của record hiện hành 
                string strNhanVien =
                dgvNhanVien.Rows[r].Cells[0].Value.ToString();

                // Hiện thông báo xác nhận việc xóa mẫu tin 
                // Khai báo biến traloi 
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp 
                traloi = MessageBox.Show("Bạn có chắc xóa nhân viên này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không? 
                if (traloi == DialogResult.Yes)
                {
                    // Thực hiện câu lệnh SQL 
                    kq = nvbusiness.XoaNhanVien(ref err, txtMaNV.Text);
                    if (kq)
                    {
                        // Cập nhật lại DataGridView 
                        LoadData();
                        // Thông báo 
                        MessageBox.Show("Đã xóa xong!");
                    }
                }
                else
                {

                    // Thông báo 
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!");
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dgvNhanVien.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtMaNV.Text =
                dgvNhanVien.Rows[r].Cells[0].Value.ToString();
            this.txtHoTen.Text =
                dgvNhanVien.Rows[r].Cells[1].Value.ToString();
            this.cbxGioi.SelectedValue =
                dgvNhanVien.Rows[r].Cells[2].Value.ToString();
            this.dtpNgaySinh.Value = DateTime.Parse
                (dgvNhanVien.Rows[r].Cells[3].Value.ToString());
            //string shortDate = dtp.Value.ToShortDateString();
            //this.dtp.Text = shortDate;
            this.txtCCCD.Text =
                dgvNhanVien.Rows[r].Cells[4].Value.ToString();
            this.txtQueQuan.Text =
                dgvNhanVien.Rows[r].Cells[5].Value.ToString();
            this.txtLuong.Text =
                dgvNhanVien.Rows[r].Cells[6].Value.ToString();

        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel 
            this.txtMaNV.ResetText();
            this.txtHoTen.ResetText();
            this.panel.ResetText();
            this.dtpNgaySinh.ResetText();
            //this.dtp.ResetText();
            this.cbxGioi.ResetText();
            this.txtCCCD.ResetText();
            this.txtQueQuan.ResetText();
            this.txtLuong.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnQuayLai.Enabled = true;
            //this.btnReload.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = false;
            this.btnHuyBo.Enabled = false;
            this.panel.Enabled = false;
            dgvNhanVien_CellClick(null, null);
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
