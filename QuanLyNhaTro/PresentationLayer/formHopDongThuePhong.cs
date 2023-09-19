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
    public partial class formHopDongThuePhong : Form
    {
        BusinessLayerHopDongThuePhong hdbusiness = new BusinessLayerHopDongThuePhong();
        QuanLyNhaTroDataModel db = new QuanLyNhaTroDataModel();
        bool Them = false;
        public formHopDongThuePhong()
        {
            InitializeComponent();
        }

        private void formHopDongThuePhong_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            // Khai báo biến traloi 
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp 
            traloi = MessageBox.Show("Bạn có muốn quay về trang chủ?", "Trả lời",
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
            this.txtMaKH.ResetText();
            this.txtMaNV.ResetText();
            this.txtSoHD.ResetText();


            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnTroVe.Enabled = false;
            // Đưa con trỏ đến TextField txtMaNV
            this.txtMaNV.Focus();
        }
        void LoadData()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView  
                dgvHopDongThuePhong.DataSource = hdbusiness.LayHopDongThuePhong();
                dgvHopDongThuePhong.Columns[4].Visible = false;
                dgvHopDongThuePhong.Columns[5].Visible = false;
                dgvHopDongThuePhong.Columns[6].Visible = false;
                dgvHopDongThuePhong.Columns[3].Visible = false;
                // Thay đổi độ rộng cột 
                dgvHopDongThuePhong.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel
                this.txtSoHD.ResetText();
                this.txtMaKH.ResetText();
                this.txtMaNV.ResetText();

                this.panel.ResetText();

                // Không cho thao tác trên các nút Lưu / Hủy 
                this.btnLuu.Enabled = false;
                this.btnHuyBo.Enabled = false;
                this.panel.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát 
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnTroVe.Enabled = true;
                // Đặt tên cột
                dgvHopDongThuePhong.Columns[0].HeaderText = "Số hợp đồng";
                dgvHopDongThuePhong.Columns[1].HeaderText = "Mã khách hàng";
                dgvHopDongThuePhong.Columns[2].HeaderText = "Mã nhân viên";
                // Sự kiện click chuột
                dgvHopDongThuePhong_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung hợp đồng thuê phòng. Đã xảy ra lỗi!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            // Cho phép thao tác trên Panel 
            this.panel.Enabled = true;
            dgvHopDongThuePhong_CellContentClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnTroVe.Enabled = false;
            // Đưa con trỏ đến TextField txtMaNV 
            this.txtSoHD.Enabled = false;
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
                    kq = hdbusiness.ThemHopDongThuePhong(ref err, txtSoHD.Text, txtMaKH.Text, txtMaNV.Text);
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
                int r = dgvHopDongThuePhong.CurrentCell.RowIndex;
                // MaKH hiện hành 
                string strMaNV =
                dgvHopDongThuePhong.Rows[r].Cells[0].Value.ToString();

                // Câu lệnh SQL 
                kq = hdbusiness.CapNhatHopDongThuePhong(ref err, txtSoHD.Text, txtMaKH.Text, txtMaNV.Text);
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
            this.txtSoHD.ResetText();
            this.txtMaKH.ResetText();
            this.txtMaNV.ResetText();
            this.panel.ResetText();

            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnTroVe.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = false;
            this.btnHuyBo.Enabled = false;
            this.panel.Enabled = false;
            dgvHopDongThuePhong_CellClick(null, null);
        }

        private void dgvHopDongThuePhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void formHopDongThuePhong_Load_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvHopDongThuePhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dgvHopDongThuePhong.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtSoHD.Text =
            dgvHopDongThuePhong.Rows[r].Cells[0].Value.ToString();
            this.txtMaKH.Text =
            dgvHopDongThuePhong.Rows[r].Cells[1].Value.ToString();
            this.txtMaNV.Text =
            dgvHopDongThuePhong.Rows[r].Cells[2].Value.ToString();
        }
    }
}
