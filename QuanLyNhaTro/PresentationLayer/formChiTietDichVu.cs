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
    public partial class frmChiTietDichVu : Form
    {
        BusinessLayerChiTietSDDV ctdvbusiness = new BusinessLayerChiTietSDDV();
        BusinessLayerDichVu dvbusiness = new BusinessLayerDichVu();
        BusinessLayerHopDongThuePhong hdbusiness = new BusinessLayerHopDongThuePhong();
        QuanLyNhaTroDataModel db = new QuanLyNhaTroDataModel();
        bool Them = false;

        public frmChiTietDichVu()
        {
            InitializeComponent();
        }

        void LoadCTDV()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView  
                this.dgvCTDV.DataSource = ctdvbusiness.LayChiTietSuDungDV();
                this.dgvCTDV.Columns[4].Visible = false;
                this.dgvCTDV.Columns[5].Visible = false;
                // Thay đổi độ rộng cột 
                this.dgvCTDV.AutoResizeColumns();
                // Đặt tên cột
                dgvCTDV.Columns[0].HeaderText = "Số hợp đồng";
                dgvCTDV.Columns[1].HeaderText = "Mã dịch vụ";
                dgvCTDV.Columns[2].HeaderText = "Ngày đăng ký";
                dgvCTDV.Columns[3].HeaderText = "Ngày huỷ";
                // Xóa trống các đối tượng trong Panel 
                this.txtSoHDThue.ResetText();
                this.cbxMaDV.ResetText();
                this.dtpNgayGioDangKy.ResetText();
                this.dtpNgayGioHuy.ResetText();
                this.txtHoTen.ResetText();
                this.txtMaKH.ResetText();
                this.txtMaPhong.ResetText();
                this.txtTenDV.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy 
                this.btnLuu.Enabled = false;
                this.btnHuyBo.Enabled = false;
                //this.panel.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát 
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnQuayLai.Enabled = true;
                //
                dgvCTDV_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung chi tiết dịch vụ. Đã xảy ra lỗi!");
            }
        }

        void LoadDV()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView  
                this.dgvDV.DataSource = dvbusiness.LayDichVu();
                this.dgvDV.Columns[5].Visible = false;
                this.dgvDV.Columns[6].Visible = false;
                // Thay đổi độ rộng cột 
                this.dgvDV.AutoResizeColumns();
                // Đặt tên cột
                dgvDV.Columns[0].HeaderText = "Mã dịch vụ";
                dgvDV.Columns[1].HeaderText = "Mã loại dịch vụ";
                dgvDV.Columns[2].HeaderText = "Tên dịch vụ";
                dgvDV.Columns[3].HeaderText = "Giá (VND)";
                dgvDV.Columns[4].HeaderText = "Chi tiết";
                // Sự kiện click chuột
                dgvDV_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung dịch vụ. Đã xảy ra lỗi!");
            }
        }

        void LoadHD()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView  
                this.dgvHD.DataSource = hdbusiness.LayHopDongThuePhong();
                this.dgvHD.Columns[2].Visible = false;
                this.dgvHD.Columns[3].Visible = false;
                this.dgvHD.Columns[4].Visible = false;
                this.dgvHD.Columns[5].Visible = false;
                this.dgvHD.Columns[6].Visible = false;
                // Thay đổi độ rộng cột 
                this.dgvHD.AutoResizeColumns();
                // Đặt tên cột
                dgvHD.Columns[0].HeaderText = "Số hợp đồng";
                dgvHD.Columns[1].HeaderText = "Mã khách hàng";
                // Sự kiện click chuột
                dgvHD_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong bảng Hợp đồng. Đã xảy ra lỗi!");
            }
        }

        public void LoadCombobox()
        {
            try
            {
                // Load MaDV vào cbxTenKhach
                this.cbxMaDV.DataSource = dvbusiness.LayDichVu();
                this.cbxMaDV.ValueMember = "MaDV";
                this.cbxMaDV.DisplayMember = "Mã dịch vụ";
            }
            catch (SqlException error)  //bắt lỗi sql
            {
                MessageBox.Show("Không truy cập dữ liệu chi tiết dịch vụ được!\rLỗi: " + error.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception er)    //bắt các lỗi khác
            {
                MessageBox.Show("Không truy cập dữ liệu chi tiết dịch vụ được!\rLỗi: " + er.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            Them = true;

            // Xóa trống các đối tượng trong Panel 
            this.dtpNgayGioDangKy.ResetText();
            this.dtpNgayGioHuy.ResetText();

            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnQuayLai.Enabled = false;
            // Đưa con trỏ đến NgayGioDangKy
            this.dtpNgayGioDangKy.Focus();
            MessageBox.Show("Chọn ngày huỷ và ngày đăng ký trùng nhau để đăng ký dịch vụ mới!");
        }
        
        private void dgvCTDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {   //khi click record trong dgvCTDV thì thông tin sẽ đc đưa lên các textbox và combobox
                int r = dgvCTDV.CurrentCell.RowIndex;
                //hiển thị 
                this.txtSoHDThue.Text = dgvCTDV.Rows[r].Cells[0].Value.ToString();
                this.cbxMaDV.SelectedValue = dgvCTDV.Rows[r].Cells[1].Value.ToString();
                this.dtpNgayGioDangKy.Value = DateTime.Parse(dgvCTDV.Rows[r].Cells[2].Value.ToString());
                this.dtpNgayGioHuy.Value = DateTime.Parse(dgvCTDV.Rows[r].Cells[3].Value.ToString());
                this.txtMaKH.Text = ctdvbusiness.LayMaKH_CTSDDV(txtSoHDThue.Text);
                this.txtHoTen.Text = ctdvbusiness.LayHoTenKH_CTSDDV(txtSoHDThue.Text);
                this.txtTenDV.Text = ctdvbusiness.LayTenDV_CTSDDV(txtSoHDThue.Text, dgvCTDV.Rows[r].Cells[1].Value.ToString());
                this.txtMaPhong.Text = ctdvbusiness.LayMaPhong_CTSDDV(txtSoHDThue.Text);
                this.txtTenPhong.Text = ctdvbusiness.LayTenPhong_CTSDDV(txtSoHDThue.Text);
            }
            catch   //TH click row ko có data
            {
                this.txtSoHDThue.ResetText();
                this.cbxMaDV.ResetText();
                this.dtpNgayGioDangKy.ResetText();
                this.dtpNgayGioHuy.ResetText();
            }
        }

        private void formChiTietDichVu_Load(object sender, EventArgs e)
        {
            LoadCTDV();
            LoadCombobox();
            LoadDV();
            LoadHD();
        }

        private void dgvCTDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {   //khi click record trong dgvDV thì thông tin sẽ đc đưa lên các textbox và combobox
                int r = dgvDV.CurrentCell.RowIndex;
                //hiển thị mã dv và tên dv
                this.txtTenDV.Text = dgvDV.Rows[r].Cells[2].Value.ToString();
                this.cbxMaDV.SelectedValue = dgvDV.Rows[r].Cells[0].Value.ToString();
                //Lưu giá trị MaCTHD record hiện hành
                //MaCthd = dgvCTDV.Rows[r].Cells[1].Value.ToString();
            }
            catch   //TH click row ko có data
            {
                this.txtTenDV.ResetText();
                this.cbxMaDV.ResetText();
            }
        }

        private void dgvHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {   //khi click record trong dgvHD thì thông tin sẽ đc đưa lên các textbox và combobox
                int r = dgvHD.CurrentCell.RowIndex;
                //hiển thị 
                this.txtSoHDThue.Text = dgvHD.Rows[r].Cells[0].Value.ToString();
                this.txtMaKH.Text = dgvHD.Rows[r].Cells[1].Value.ToString();

                this.txtHoTen.Text = ctdvbusiness.LayHoTenKH_CTSDDV(dgvHD.Rows[r].Cells[0].Value.ToString());
            }
            catch   //TH click row ko có data
            {
                this.txtSoHDThue.ResetText();
                this.txtMaKH.ResetText();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadCombobox();
            LoadDV();
            LoadHD();
            LoadCTDV();
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
                    kq = ctdvbusiness.ThemChiTietSuDungDV(ref err, txtSoHDThue.Text, cbxMaDV.Text, 
                        DateTime.Parse(dtpNgayGioDangKy.Text), DateTime.Parse(dtpNgayGioHuy.Text));
                    if (kq)
                    {
                        // Load lại dữ liệu trên DataGridView 
                        LoadCTDV();
                        // Thông báo 
                        MessageBox.Show("Đã thêm xong chi tiết dịch vụ!");
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
                int r = dgvCTDV.CurrentCell.RowIndex;
                // SoHDThue và MaDV hiện hành 
                string strSoHDThue =
                dgvCTDV.Rows[r].Cells[0].Value.ToString();
                string strMaDV =
                dgvCTDV.Rows[r].Cells[1].Value.ToString();

                // Câu lệnh SQL 
                kq = ctdvbusiness.CapNhatChiTietSuDungDV(ref err, txtSoHDThue.Text, cbxMaDV.Text,
                        DateTime.Parse(dtpNgayGioDangKy.Text), DateTime.Parse(dtpNgayGioHuy.Text));
                if (kq)
                {
                    // Load lại dữ liệu trên DataGridView 
                    LoadCTDV();
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
                int r = dgvCTDV.CurrentCell.RowIndex;
                // Lấy SoHDThue và MaDV của record hiện hành 
                string strSoHDThue =
                dgvCTDV.Rows[r].Cells[0].Value.ToString();
                string strMaDV =
                dgvCTDV.Rows[r].Cells[1].Value.ToString();

                // Hiện thông báo xác nhận việc xóa mẫu tin 
                // Khai báo biến traloi 
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp 
                traloi = MessageBox.Show("Bạn có chắc xóa chi tiết dịch vụ này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không? 
                if (traloi == DialogResult.Yes)
                {
                    // Thực hiện câu lệnh SQL 
                    kq = ctdvbusiness.XoaChiTietSuDungDV(ref err, txtSoHDThue.Text, cbxMaDV.Text);
                    if (kq)
                    {
                        // Cập nhật lại DataGridView 
                        LoadCTDV();
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
            // Xóa trống các đối tượng 
            this.txtSoHDThue.ResetText();
            this.cbxMaDV.ResetText();
            this.dtpNgayGioDangKy.ResetText();
            this.dtpNgayGioHuy.ResetText();
            this.txtMaKH.ResetText();
            this.txtHoTen.ResetText();
            this.txtMaPhong.ResetText();
            this.txtTenPhong.ResetText();
            this.txtTenDV.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát 
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnQuayLai.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = false;
            this.btnHuyBo.Enabled = false;
            this.panel.Enabled = false;
            dgvCTDV_CellClick(null, null);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            // Cho phép thao tác trên Panel 
            this.panel.Enabled = true;
            dgvCTDV_CellClick(null, null);
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
            this.txtSoHDThue.Enabled = false;
            this.txtSoHDThue.Focus();
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
    }
}

