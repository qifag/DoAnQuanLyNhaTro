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
    public partial class frmDichVu : Form
    {
        BusinessLayerDichVu nvbusiness =
            new BusinessLayerDichVu();
        BusinessLayerLoaiDichVu ldvbusiness =
            new BusinessLayerLoaiDichVu();
        QuanLyNhaTroDataModel db = new QuanLyNhaTroDataModel();
        bool Them = false;
        public frmDichVu()
        {
            InitializeComponent();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            // Khai báo biến traloi 
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp 
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không? 
            if (traloi == DialogResult.OK) this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            Them = true;

            // Xóa trống các đối tượng trong Panel 
            this.panel.ResetText();

            //this.dtp.ResetText();
            this.txtMaDV.ResetText();
            this.txtMaLoaiDV.ResetText();
            this.txtGiaDV.ResetText();
            this.txtTenDV.ResetText();
            this.txtChiTietDV.ResetText();

            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;

            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnTroVe.Enabled = false;
            // Đưa con trỏ đến TextField txtMaNV
            this.txtMaDV.Focus();
        }
        void LoadData()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView  
                dgvDichVu.DataSource = nvbusiness.LayDichVu();
                dgvDichVu.Columns[5].Visible = false;
                dgvDichVu.Columns[6].Visible = false;
                // Thay đổi độ rộng cột 
                dgvDichVu.AutoResizeColumns();

                // Xóa trống các đối tượng trong Panel
                this.panel.ResetText();

                //this.dtp.ResetText()
                this.txtMaDV.ResetText();
                this.txtMaLoaiDV.ResetText();
                this.txtTenDV.ResetText();
                this.txtGiaDV.ResetText();
                this.txtChiTietDV.ResetText();

                // Không cho thao tác trên các nút Lưu / Hủy 
                this.btnLuu.Enabled = false;
                this.btnHuyBo.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát 
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnTroVe.Enabled = true;
                // Đặt tên cột
                dgvDichVu.Columns[0].HeaderText = "Mã dịch vụ";
                dgvDichVu.Columns[1].HeaderText = "Mã loại dịch vụ";
                dgvDichVu.Columns[2].HeaderText = "Tên dịch vụ";
                dgvDichVu.Columns[3].HeaderText = "Giá (VND)";
                dgvDichVu.Columns[4].HeaderText = "Chi tiết";
                // Sự kiện click chuột
                dgvDichVu_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung dịch vụ. Lỗi rồi!!!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            // Cho phép thao tác trên Panel 
            this.panel.Enabled = true;
            dgvDichVu_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnTroVe.Enabled = false;
            // Đưa con trỏ đến TextField txtMaNV 
            this.txtMaDV.Enabled = false;
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
                    kq = nvbusiness.ThemDichVu(ref err, txtMaDV.Text, txtMaLoaiDV.Text, txtTenDV.Text, int.Parse(txtGiaDV.Text), txtChiTietDV.Text);
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
                int r = dgvDichVu.CurrentCell.RowIndex;
                // MaKH hiện hành 
                string strMaNV =
                dgvDichVu.Rows[r].Cells[0].Value.ToString();

                // Câu lệnh SQL 
                kq = nvbusiness.CapNhatDichVu(ref err, txtMaDV.Text, txtMaLoaiDV.Text, txtTenDV.Text, int.Parse(txtGiaDV.Text), txtChiTietDV.Text);
                if (kq)
                {
                    // Load lại dữ liệu trên DataGridView 
                    LoadData();
                    // Thông báo 
                    MessageBox.Show("Đã cập nhật xong!");
                }
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel 
            //this.dtp.ResetText();
            this.txtMaDV.ResetText();
            this.txtMaLoaiDV.ResetText();
            this.panel.ResetText();
            this.txtTenDV.ResetText();
            this.txtGiaDV.ResetText();
            this.txtChiTietDV.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnTroVe.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = false;
            this.btnHuyBo.Enabled = false;
            this.panel.Enabled = false;
            dgvDichVu_CellClick(null, null);
        }

        void LoadLDV()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView  
                this.dgvLoaiDichVu.DataSource = ldvbusiness.LayLoaiDichVu();
                this.dgvLoaiDichVu.Columns[2].Visible = false;
                // Thay đổi độ rộng cột 
                this.dgvLoaiDichVu.AutoResizeColumns();
                // Đặt tên cột
                dgvLoaiDichVu.Columns[0].HeaderText = "Mã loại dịch vụ";
                dgvLoaiDichVu.Columns[1].HeaderText = "Loại dịch vụ";
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung loại dịch vụ. Lỗi rồi!!!");
            }
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dgvDichVu.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtMaDV.Text =
            dgvDichVu.Rows[r].Cells[0].Value.ToString();
            this.txtMaLoaiDV.Text =
            dgvDichVu.Rows[r].Cells[1].Value.ToString();
            this.txtTenDV.Text =
            dgvDichVu.Rows[r].Cells[2].Value.ToString();
            this.txtGiaDV.Text =
            dgvDichVu.Rows[r].Cells[3].Value.ToString();
            this.txtChiTietDV.Text =
            dgvDichVu.Rows[r].Cells[4].Value.ToString();
        }

        private void dgvDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadLDV();
        }
    }
}
