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
    public partial class frmSoThuTien : Form
    {
        BusinessLayerSoThuTien sttbusiness =
            new BusinessLayerSoThuTien();
        QuanLyNhaTroDataModel db = new QuanLyNhaTroDataModel();
        bool Them = false;
        public frmSoThuTien()
        {
            InitializeComponent();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
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
        void LoadData()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView  
                dgvSoThuTien.DataSource = sttbusiness.LaySoThuTien();
                dgvSoThuTien.Columns[4].Visible = false;
                // Thay đổi độ rộng cột 
                dgvSoThuTien.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel
                //this.dtp.ResetText();
                this.txtMaPT.ResetText();
                this.txtSoHD.ResetText();
                this.panel.ResetText();
                this.txtSoTienThu.ResetText();
                this.txtNgayThu.ResetText();

                // Không cho thao tác trên các nút Lưu / Hủy 
                this.btnLuu.Enabled = false;
                this.btnHuyBo.Enabled = false;
                this.panel.Enabled = false;

                // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát 
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnTroVe.Enabled = true;

                // Đặt tên cột
                dgvSoThuTien.Columns[0].HeaderText = "Mã phiếu thu";
                dgvSoThuTien.Columns[1].HeaderText = "Số hợp đồng";
                dgvSoThuTien.Columns[2].HeaderText = "Số tiền thu (VND)";
                dgvSoThuTien.Columns[3].HeaderText = "Ngày thu";

                // Sự kiện click chuột
                dgvSoThuTien_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung sổ thu tiền. Đã xảy ra lỗi!");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            Them = true;

            // Xóa trống các đối tượng trong Panel 
            //this.dtp.ResetText();
            this.txtMaPT.ResetText();
            this.txtSoHD.ResetText();
            this.panel.ResetText();
            this.txtSoTienThu.ResetText();
            this.txtNgayThu.ResetText();

            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnTroVe.Enabled = false;
            // Đưa con trỏ đến TextField txtMaNV
            this.txtMaPT.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            // Cho phép thao tác trên Panel 
            this.panel.Enabled = true;
            dgvSoThuTien_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnTroVe.Enabled = false;
            // Đưa con trỏ đến TextField txtMaNV 
            this.txtMaPT.Enabled = false;

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
                    kq = sttbusiness.ThemPhieuThu(ref err, txtMaPT.Text, txtSoHD.Text, int.Parse(txtSoTienThu.Text), DateTime.Parse(txtNgayThu.Text));
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
                int r = dgvSoThuTien.CurrentCell.RowIndex;
                // MaKH hiện hành 
                string strMaNV =
                dgvSoThuTien.Rows[r].Cells[0].Value.ToString();

                // Câu lệnh SQL 
                kq = sttbusiness.CapNhatSoThuTien(ref err, txtMaPT.Text, txtSoHD.Text, int.Parse(txtSoTienThu.Text), DateTime.Parse(txtNgayThu.Text));
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
            this.txtMaPT.ResetText();
            this.txtSoHD.ResetText();
            this.panel.ResetText();
            this.txtSoTienThu.ResetText();
            this.txtNgayThu.ResetText();

            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnTroVe.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = false;
            this.btnHuyBo.Enabled = false;
            this.panel.Enabled = false;
            dgvSoThuTien_CellClick(null, null);
        }

        private void dgvSoThuTien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmSoThuTien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvSoThuTien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dgvSoThuTien.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtMaPT.Text =
            dgvSoThuTien.Rows[r].Cells[0].Value.ToString();
            this.txtSoHD.Text =
            dgvSoThuTien.Rows[r].Cells[1].Value.ToString();
            this.txtSoTienThu.Text =
            dgvSoThuTien.Rows[r].Cells[2].Value.ToString();
            DateTime dt = DateTime.Parse(dgvSoThuTien.Rows[r].Cells[3].Value.ToString());
            this.txtNgayThu.Text = dt.ToString("dd'/'MM'/'yyyy", CultureInfo.InvariantCulture);
            //string shortDate = dtp.Value.ToShortDateString();
            //this.dtp.Text = shortDate;

        }
    }
}
