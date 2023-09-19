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
    public partial class frmChiTietHopDongThuePhong : Form
    {
        BusinessLayerChiTietHD cthdbusiness = new BusinessLayerChiTietHD(); 
        BusinessLayerChiTietSDDV ctdvbusiness = new BusinessLayerChiTietSDDV();
        BusinessLayerHopDongThuePhong hdbusiness = new BusinessLayerHopDongThuePhong();
        BusinessLayerPhongTro ptbusiness = new BusinessLayerPhongTro(); 
        QuanLyNhaTroDataModel db = new QuanLyNhaTroDataModel();

        bool Them = false;
        public frmChiTietHopDongThuePhong()
        {
            InitializeComponent();
        }

        void LoadCTHD()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView  
                this.dgvCTHD.DataSource = cthdbusiness.LayChiTietHopDongThuePhong();
                this.dgvCTHD.Columns[6].Visible = false;
                this.dgvCTHD.Columns[7].Visible = false;
                this.dgvCTHD.Columns[8].Visible = false;
                // Thay đổi độ rộng cột 
                this.dgvCTHD.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel 
                this.txtSoHDThue.ResetText();
                this.cbxMaPhong.ResetText();
                this.txtTienCoc.ResetText();
                this.dtpNgayThue.ResetText();
                this.dtpNgayDonVao.ResetText();
                this.dtpNgayChuyenDi.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy 
                this.btnLuu.Enabled = false;
                this.btnHuyBo.Enabled = false;
                //this.panel.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát 
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnQuayLai.Enabled = true;
                this.btnReload.Enabled = true;
                // Đặt tên cột
                dgvCTHD.Columns[0].HeaderText = "Số hợp đồng";
                dgvCTHD.Columns[1].HeaderText = "Mã phòng";
                dgvCTHD.Columns[2].HeaderText = "Tiền cọc (VND)";
                dgvCTHD.Columns[3].HeaderText = "Ngày đăng ký";
                dgvCTHD.Columns[4].HeaderText = "Ngày dọn vào";
                dgvCTHD.Columns[5].HeaderText = "Ngày dọn ra";
                // Sự kiện click chuột
                dgvCTHD_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung chi tiết hợp đồng. Đã xảy ra lỗi");
            }
        }

        void LoadCombobox()
        {
            try
            {
                // Load mã phòng vào cbxMaPhong
                this.cbxMaPhong.DataSource = ptbusiness.LayPhongTro();
                this.cbxMaPhong.ValueMember = "MaPhong";
                this.cbxMaPhong.DisplayMember = "Mã phòng";
            }
            catch (SqlException error)  //bắt lỗi sql
            {
                MessageBox.Show("Không truy cập dữ liệu phòng trọ được!\rLỗi: " + error.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception er)    //bắt các lỗi khác
            {
                MessageBox.Show("Không truy cập dữ liệu phòng trọ được!\rLỗi: " + er.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void LoadPhongKhach_HD(string SoHDThue)
        {
            try
            {
                // Đưa dữ liệu lên DataGridView  
                this.dgvPhongKhach.DataSource = cthdbusiness.LayPhong_Khach_ChiTietHD(SoHDThue);
                // Thay đổi độ rộng cột 
                this.dgvPhongKhach.AutoResizeColumns();
                // Đặt tên cột
                dgvPhongKhach.Columns[0].HeaderText = "Số hợp đồng";
                dgvPhongKhach.Columns[1].HeaderText = "Mã phòng";
                dgvPhongKhach.Columns[2].HeaderText = "Tên phòng";
                dgvPhongKhach.Columns[3].HeaderText = "Mã khách";
                dgvPhongKhach.Columns[4].HeaderText = "Tên khách";
                // Sự kiện click chuột
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi! Không lấy được dữ liệu phòng - khách!");
            }
        }

        void LoadCTDV(string SoHDThue)
        {
            try
            {
                // Đưa dữ liệu lên DataGridView  
                this.dgvCTDV.DataSource = cthdbusiness.LayChiTietSuDungDV_CTHopDong(SoHDThue);
                // Thay đổi độ rộng cột 
                this.dgvCTDV.AutoResizeColumns();
                // Đặt tên cột
                dgvCTDV.Columns[0].HeaderText = "Số hợp đồng";
                dgvCTDV.Columns[1].HeaderText = "Mã dịch vụ";
                dgvCTDV.Columns[2].HeaderText = "Tên dịch vụ";
                dgvCTDV.Columns[3].HeaderText = "Ngày đăng ký";
                dgvCTDV.Columns[4].HeaderText = "Ngày huỷ";
                // Sự kiện click chuột
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi! Không lấy được nội dung chi tiết sử dụng dịch vụ!");
            }
        }

        private void dgvCTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dgvCTHD.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtSoHDThue.Text =
            dgvCTHD.Rows[r].Cells[0].Value.ToString();
            this.cbxMaPhong.SelectedValue =
            dgvCTHD.Rows[r].Cells[1].Value.ToString();
            this.txtTienCoc.Text =
            dgvCTHD.Rows[r].Cells[2].Value.ToString();
            this.dtpNgayThue.Text =
            dgvCTHD.Rows[r].Cells[3].Value.ToString();
            this.dtpNgayDonVao.Text =
            dgvCTHD.Rows[r].Cells[4].Value.ToString();
            if (cthdbusiness.KiemTraHopDong(txtSoHDThue.Text))
                this.dtpNgayChuyenDi.Text = "";
            else
                this.dtpNgayChuyenDi.Text = 
                dgvCTHD.Rows[r].Cells[5].Value.ToString();
            LoadCTDV(txtSoHDThue.Text);
            LoadPhongKhach_HD(txtSoHDThue.Text);
    }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            Them = true;

            // Xóa trống các đối tượng trong Panel 
            this.txtSoHDThue.ResetText();
            this.cbxMaPhong.ResetText();
            this.panel.ResetText();
            this.txtTienCoc.ResetText();
            this.dtpNgayThue.ResetText();
            this.dtpNgayDonVao.ResetText();
            this.dtpNgayChuyenDi.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnQuayLai.Enabled = false;
            this.btnReload.Enabled = false;
            // Đưa con trỏ đến TextField SoHDThue
            this.txtSoHDThue.Focus();
            MessageBox.Show("Chọn ngày chuyển đi và ngày thuê trọ trùng nhau để thêm hợp đồng mới!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            // Cho phép thao tác trên Panel 
            this.panel.Enabled = true;
            dgvCTHD_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnQuayLai.Enabled = false;
            this.btnReload.Enabled = false;
            // Đưa con trỏ đến TextField txtMaNV 
            this.txtSoHDThue.Enabled = false;
            this.cbxMaPhong.Focus();
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
                    kq = cthdbusiness.ThemChiTietHopDongThuePhong(ref err, txtSoHDThue.Text, cbxMaPhong.Text, int.Parse(txtTienCoc.Text), DateTime.Parse(dtpNgayThue.Text), 
                        DateTime.Parse(dtpNgayDonVao.Text), DateTime.Parse(dtpNgayChuyenDi.Text));
                    if (kq)
                    {
                        // Load lại dữ liệu trên DataGridView 
                        LoadCTHD();
                        // Thông báo 
                        MessageBox.Show("Đã thêm chi tiết hợp đồng thành công!");
                    }

                }
                catch (SqlException)
                {
                    err = "Đã xảy ra lỗi! Không thêm được chi tiết hợp đồng!";
                    MessageBox.Show(err);
                }
            }
            else
            {
                kq = false;
                // Thứ tự dòng hiện hành 
                int r = dgvCTHD.CurrentCell.RowIndex;
                // MaTB hiện hành 
                string strMaTB =
                dgvCTHD.Rows[r].Cells[0].Value.ToString();
                // Câu lệnh SQL 
                kq = cthdbusiness.CapNhatChiTietHopDongThuePhong(ref err, txtSoHDThue.Text, cbxMaPhong.Text, int.Parse(txtTienCoc.Text), DateTime.Parse(dtpNgayThue.Text),
                        DateTime.Parse(dtpNgayDonVao.Text), DateTime.Parse(dtpNgayChuyenDi.Text));
                if (kq)
                {
                    // Load lại dữ liệu trên DataGridView 
                    LoadCTHD();
                    // Thông báo 
                    MessageBox.Show("Đã sửa xong!");
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
                int r = dgvCTHD.CurrentCell.RowIndex;
                // Lấy SoHDThue của record hiện hành 
                string strSoHDThue =
                dgvCTHD.Rows[r].Cells[0].Value.ToString();
                // Hiện thông báo xác nhận việc xóa mẫu tin 
                // Khai báo biến traloi 
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp 
                traloi = MessageBox.Show("Bạn có chắc muốn xoá chi tiết hợp đồng này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không? 
                if (traloi == DialogResult.Yes)
                {
                    // Thực hiện câu lệnh SQL 
                    kq = cthdbusiness.XoaChiTietHopDongThuePhong(ref err, txtSoHDThue.Text);
                    if (kq)
                    {
                        // Cập nhật lại DataGridView 
                        LoadCTHD();
                        // Thông báo 
                        MessageBox.Show("Đã xóa thành công!");
                    }
                }
                else
                {

                    // Thông báo 
                    MessageBox.Show("Huỷ bỏ việc xoá chi tiết hợp đồng!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi! Không xóa được chi tiết hợp đồng!");
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng 
            this.txtSoHDThue.ResetText();
            this.cbxMaPhong.ResetText();
            this.panel.ResetText();
            this.txtTienCoc.ResetText();
            this.dtpNgayThue.ResetText();
            this.dtpNgayDonVao.ResetText();
            this.dtpNgayChuyenDi.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát / Reload
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnQuayLai.Enabled = true;
            this.btnReload.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = false;
            this.btnHuyBo.Enabled = false;
            //this.panel.Enabled = false;
            dgvCTHD_CellClick(null, null);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadCTHD();
            LoadCombobox();
            LoadCTDV("");
            LoadPhongKhach_HD("");
        }

        private void formChiTietHopDongThuePhong_Load(object sender, EventArgs e)
        {
            LoadCTHD();
            LoadCombobox();
            LoadCTDV("");
            LoadPhongKhach_HD("");
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
