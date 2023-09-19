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
    public partial class frmPhongTro : Form
    {
        BusinessLayerPhongTro nvbusiness = new BusinessLayerPhongTro();
        BusinessLayerLoaiPhong lpbusiness = new BusinessLayerLoaiPhong();
        BusinessLayerBangGia bgbusiness = new BusinessLayerBangGia();
        QuanLyNhaTroDataModel db = new QuanLyNhaTroDataModel();
        bool Them = false;
        public frmPhongTro()
        {
            InitializeComponent();
        }

        private void frmPhongTro_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadLP();
            LoadBG();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            Them = true;

            // Xóa trống các đối tượng trong Panel 
            //this.dtp.ResetText();
            this.txtMaPhong.ResetText();
            this.txtMaLoaiPhong.ResetText();
            this.panel.ResetText();
            this.txtTenPhong.ResetText();
            this.txtDayPhong.ResetText();

            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnTroVe.Enabled = false;
            // Đưa con trỏ đến TextField txtMaNV
            this.txtMaPhong.Focus();
        }
        void LoadData()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView  
                dgvPhongTro.DataSource = nvbusiness.LayPhongTro();
                dgvPhongTro.Columns[4].Visible = false;
                dgvPhongTro.Columns[5].Visible = false;
                dgvPhongTro.Columns[6].Visible = false;
                // Thay đổi độ rộng cột 
                dgvPhongTro.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel 
                //this.dtp.ResetText();
                this.txtMaPhong.ResetText();
                this.txtMaLoaiPhong.ResetText();
                this.panel.ResetText();
                this.txtTenPhong.ResetText();
                this.txtDayPhong.ResetText();

                // Không cho thao tác trên các nút Lưu / Hủy 
                this.btnLuu.Enabled = false;
                this.btnHuyBo.Enabled = false;
                this.panel.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát 
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnTroVe.Enabled = true;
                // Đặt tên cột
                dgvPhongTro.Columns[0].HeaderText = "Mã phòng";
                dgvPhongTro.Columns[1].HeaderText = "Mã loại phòng";
                dgvPhongTro.Columns[2].HeaderText = "Tên phòng";
                dgvPhongTro.Columns[3].HeaderText = "Dãy phòng";
                // Sự kiện click chuột
                dgvPhongTro_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung phòng trọ. Đã xảy ra lỗi!");
            }
        }

        // Load danh sách phòng trọ trống
        private void LoadPTT()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView  
                dgvPTT.DataSource = nvbusiness.LayDanhSachPhongTrong();
                dgvPTT.Columns[4].Visible = false;
                dgvPTT.Columns[5].Visible = false;
                dgvPTT.Columns[6].Visible = false;
                // Thay đổi độ rộng cột 
                dgvPhongTro.AutoResizeColumns();
                // Đặt tên cột
                dgvPTT.Columns[0].HeaderText = "Mã phòng";
                dgvPTT.Columns[1].HeaderText = "Mã loại phòng";
                dgvPTT.Columns[2].HeaderText = "Tên phòng";
                dgvPTT.Columns[3].HeaderText = "Dãy phòng";
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được danh sách phòng trọ trống. Đã xảy ra lỗi!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            // Cho phép thao tác trên Panel 
            this.panel.Enabled = true;
            dgvPhongTro_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnTroVe.Enabled = false;
            // Đưa con trỏ đến TextField txtMaNV 
            this.txtMaPhong.Enabled = false;
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
                    kq = nvbusiness.ThemPhongTro(ref err, txtMaPhong.Text, txtMaLoaiPhong.Text, txtTenPhong.Text, txtDayPhong.Text);

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
                int r = dgvPhongTro.CurrentCell.RowIndex;
                // MaKH hiện hành 
                string strMaNV =
                dgvPhongTro.Rows[r].Cells[0].Value.ToString();

                // Câu lệnh SQL 
                kq = nvbusiness.CapNhatPhongTro(ref err, txtMaPhong.Text, txtMaLoaiPhong.Text, txtTenPhong.Text, txtDayPhong.Text);

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
            this.txtMaPhong.ResetText();
            this.txtMaLoaiPhong.ResetText();
            this.panel.ResetText();
            this.txtTenPhong.ResetText();
            this.txtDayPhong.ResetText();

            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnTroVe.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = false;
            this.btnHuyBo.Enabled = false;
            this.panel.Enabled = false;
            dgvPhongTro_CellClick(null, null);
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            // Khai báo biến traloi 
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp 
            traloi = MessageBox.Show("Bạn có muốn trở về trang chủ?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không? 
            if (traloi == DialogResult.OK) this.Close();
        }
        
        // Load loại phòng trọ
        void LoadLP()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView  
                this.dgvLoaiPhong.DataSource = lpbusiness.LayLoaiPhong();
                this.dgvLoaiPhong.Columns[4].Visible = false;
                this.dgvLoaiPhong.Columns[5].Visible = false;
                // Thay đổi độ rộng cột 
                this.dgvLoaiPhong.AutoResizeColumns();
                // Đặt tên cột
                dgvLoaiPhong.Columns[0].HeaderText = "Mã loại phòng";
                dgvLoaiPhong.Columns[1].HeaderText = "Tên loại phòng";
                dgvLoaiPhong.Columns[2].HeaderText = "Diện tích phòng (m2)";
                dgvLoaiPhong.Columns[3].HeaderText = "Mã giá";
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung loại phòng trọ. Lỗi rồi!!!");
            }
        }

        // Load bảng giá
        void LoadBG()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView  
                this.dgvBangGia.DataSource = bgbusiness.LayBangGia();
                this.dgvBangGia.Columns[2].Visible = false;
                // Thay đổi độ rộng cột 
                this.dgvLoaiPhong.AutoResizeColumns();
                // Đặt tên cột
                dgvBangGia.Columns[0].HeaderText = "Mã giá";
                dgvBangGia.Columns[1].HeaderText = "Giá phòng (VND)";
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi! Không lấy được nội dung bảng giá!");
            }
        }

        private void dgvPhongTro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dgvPhongTro.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtMaPhong.Text =
            dgvPhongTro.Rows[r].Cells[0].Value.ToString();
            this.txtMaLoaiPhong.Text =
            dgvPhongTro.Rows[r].Cells[1].Value.ToString();
            this.txtTenPhong.Text =
            dgvPhongTro.Rows[r].Cells[2].Value.ToString();
            this.txtDayPhong.Text =
            dgvPhongTro.Rows[r].Cells[3].Value.ToString();
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            LoadPTT();
        }
    }
}
