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
    public partial class frmKhachHang : Form
    {
        BusinessLayerKhachHang nvbusiness =
            new BusinessLayerKhachHang();
        BusinessLayerLoaiKhachHang lkhbusiness =
            new BusinessLayerLoaiKhachHang();
        QuanLyNhaTroDataModel db = new QuanLyNhaTroDataModel();
        bool Them = false;
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void formKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            Them = true;

            // Xóa trống các đối tượng trong Panel 
            this.txtMaKH.ResetText();
            this.txtMaLoaiKH.ResetText();
            this.txtHovaTen.ResetText();
            this.panel.ResetText();
            this.txtNamSinh.ResetText();
            //this.dtp.ResetText();
            this.txtGioiTinh.ResetText();
            this.txtCCCD.ResetText();
            this.txtQueQuan.ResetText();
            this.txtSoDT.ResetText();
            this.txtNgheNghiep.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;
            // Đưa con trỏ đến TextField txtMaNV
            this.txtMaKH.Focus();
        }
        void LoadData()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView  
                dgvKhachHang.DataSource = nvbusiness.LayKhachHang();
                dgvKhachHang.Columns[9].Visible = false;
                dgvKhachHang.Columns[10].Visible = false;
                // Thay đổi độ rộng cột 
                dgvKhachHang.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel 
                this.txtMaKH.ResetText();
                this.txtMaLoaiKH.ResetText();
                this.txtHovaTen.ResetText();
                this.panel.ResetText();
                this.txtNamSinh.ResetText();
                //this.dtp.ResetText();
                this.txtGioiTinh.ResetText();
                this.txtCCCD.ResetText();
                this.txtQueQuan.ResetText();
                this.txtSoDT.ResetText();
                this.txtNgheNghiep.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy 
                this.btnLuu.Enabled = false;
                this.btnHuyBo.Enabled = false;
                this.panel.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát 
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnTroVe.Enabled = true;
                // Đặt tên cột
                dgvKhachHang.Columns[0].HeaderText = "Mã khách hàng";
                dgvKhachHang.Columns[1].HeaderText = "Mã loại khách hàng";
                dgvKhachHang.Columns[2].HeaderText = "Tên";
                dgvKhachHang.Columns[3].HeaderText = "Giới tính";
                dgvKhachHang.Columns[4].HeaderText = "Năm sinh";
                dgvKhachHang.Columns[5].HeaderText = "CCCD/CMND";
                dgvKhachHang.Columns[6].HeaderText = "Quê quán";
                dgvKhachHang.Columns[7].HeaderText = "Số điện thoại";
                dgvKhachHang.Columns[8].HeaderText = "Nghề nghiệp";
                // Sự kiện click chuột
                dgvKhachHang_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung khách hàng. Đã xảy ra lỗi!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            // Cho phép thao tác trên Panel 
            this.panel.Enabled = true;
            dgvKhachHang_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;
            // Đưa con trỏ đến TextField txtMaNV 
            this.txtMaKH.Enabled = false;
            this.txtHovaTen.Focus();
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
                    kq = nvbusiness.ThemKhachHang(ref err, txtMaKH.Text, txtMaLoaiKH.Text, txtHovaTen.Text, txtGioiTinh.Text,
                        txtNamSinh.Text, txtCCCD.Text, txtQueQuan.Text, txtSoDT.Text, txtNgheNghiep.Text);
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
                    err = "Đã xảy ra lỗi! Không thể thêm!";
                    MessageBox.Show(err);
                }
            }
            else
            {
                kq = false;
                // Thứ tự dòng hiện hành 
                int r = dgvKhachHang.CurrentCell.RowIndex;
                // MaKH hiện hành 
                string strMaNV =
                dgvKhachHang.Rows[r].Cells[0].Value.ToString();

                // Câu lệnh SQL 
                kq = nvbusiness.CapNhatKhachHang(ref err, txtMaKH.Text, txtMaLoaiKH.Text, txtHovaTen.Text, txtGioiTinh.Text,
                        txtNamSinh.Text, txtCCCD.Text, txtQueQuan.Text, txtSoDT.Text, txtNgheNghiep.Text);
                if (kq)
                {
                    // Load lại dữ liệu trên DataGridView 
                    LoadData();
                    // Thông báo 
                    MessageBox.Show("Đã cập nhật xong!");
                }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool kq = false;
            string err = "";
            try
            {

                // Lấy thứ tự record hiện hành 
                int r = dgvKhachHang.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành 
                string strKhachHang =
                dgvKhachHang.Rows[r].Cells[0].Value.ToString();

                // Hiện thông báo xác nhận việc xóa mẫu tin 
                // Khai báo biến traloi 
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp 
                traloi = MessageBox.Show("Bạn có chắc chắn xóa khách hàng này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không? 
                if (traloi == DialogResult.Yes)
                {
                    // Thực hiện câu lệnh SQL 
                    kq = nvbusiness.XoaKhachHang(ref err, txtMaKH.Text);
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

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel 
            this.txtMaKH.ResetText();
            this.txtMaLoaiKH.ResetText();
            this.txtHovaTen.ResetText();
            this.panel.ResetText();
            this.txtNamSinh.ResetText();
            //this.dtp.ResetText();
            this.txtGioiTinh.ResetText();
            this.txtCCCD.ResetText();
            this.txtQueQuan.ResetText();
            this.txtNgheNghiep.ResetText();
            this.txtSoDT.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnTroVe.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = false;
            this.btnHuyBo.Enabled = false;
            this.panel.Enabled = false;
            // Sự kiện click chuột
            dgvKhachHang_CellClick(null, null);
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            // Khai báo biến traloi 
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp 
            traloi = MessageBox.Show("Bạn có chắc chắn muốn trở về trang chủ không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không? 
            if (traloi == DialogResult.OK) this.Close();
        }

        void LoadLKH()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView  
                this.dgvLoaiKhachHang.DataSource = lkhbusiness.LayLoaiKhachHang();
                this.dgvLoaiKhachHang.Columns[2].Visible = false;
                // Thay đổi độ rộng cột 
                this.dgvLoaiKhachHang.AutoResizeColumns();
                // Đặt tên cột
                dgvLoaiKhachHang.Columns[0].HeaderText = "Mã loại khách hàng";
                dgvLoaiKhachHang.Columns[1].HeaderText = "Loại khách hàng";
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung loại khách hàng. Đã xảy ra lỗi!");
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dgvKhachHang.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtMaKH.Text =
            dgvKhachHang.Rows[r].Cells[0].Value.ToString();
            this.txtMaLoaiKH.Text =
            dgvKhachHang.Rows[r].Cells[1].Value.ToString();
            this.txtHovaTen.Text =
            dgvKhachHang.Rows[r].Cells[2].Value.ToString();
            this.txtGioiTinh.Text =
            dgvKhachHang.Rows[r].Cells[3].Value.ToString();
            this.txtNamSinh.Text =
            dgvKhachHang.Rows[r].Cells[4].Value.ToString();
            this.txtCCCD.Text =
            dgvKhachHang.Rows[r].Cells[5].Value.ToString();
            this.txtQueQuan.Text =
            dgvKhachHang.Rows[r].Cells[6].Value.ToString();
            this.txtSoDT.Text =
            dgvKhachHang.Rows[r].Cells[7].Value.ToString();
            this.txtNgheNghiep.Text =
            dgvKhachHang.Rows[r].Cells[8].Value.ToString();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadLKH();
        }
    }
}
