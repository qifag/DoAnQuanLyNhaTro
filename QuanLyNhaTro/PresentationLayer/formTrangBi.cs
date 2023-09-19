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
    public partial class frmTrangBi : Form
    {
        BusinessLayerTrangBi cttbbusiness = new BusinessLayerTrangBi();
        BusinessLayerThietBi tbbusiness = new BusinessLayerThietBi();
        BusinessLayerPhongTro ptbusiness = new BusinessLayerPhongTro();
        QuanLyNhaTroDataModel db = new QuanLyNhaTroDataModel();
        bool Them = false;
        public frmTrangBi()
        {
            InitializeComponent();
        }


        void LoadCTTB()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView  
                this.dgvCTTB.DataSource = cttbbusiness.LayTrangBi();
                this.dgvCTTB.Columns[3].Visible = false;
                this.dgvCTTB.Columns[4].Visible = false;
                // Thay đổi độ rộng cột 
                this.dgvCTTB.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel 
                this.cbxMaTB.ResetText();
                this.cbxMaPhong.ResetText();
                this.dtpNgayTrangBi.ResetText();
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
                dgvCTTB.Columns[0].HeaderText = "Mã thiết bị";
                dgvCTTB.Columns[1].HeaderText = "Mã phòng";
                dgvCTTB.Columns[2].HeaderText = "Ngày trang bị";
                // Hành động click chuột
                dgvCTTB_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trang bị. Đã xảy ra lỗi!");
            }
        }

        void LoadComboboxMaPhong()
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

        void LoadComboboxMaTB()
        {
            try
            {
                // Load mã phòng vào cbxMaPhong
                this.cbxMaTB.DataSource = tbbusiness.LayThietBi();
                this.cbxMaTB.ValueMember = "MaTB";
                this.cbxMaTB.DisplayMember = "Mã thiết bị";
            }
            catch (SqlException error)  //bắt lỗi sql
            {
                MessageBox.Show("Không truy cập dữ liệu thiết bị được!\rLỗi: " + error.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception er)    //bắt các lỗi khác
            {
                MessageBox.Show("Không truy cập dữ liệu thiết bị được!\rLỗi: " + er.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void LoadPhongTro()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView  
                this.dgvPhong.DataSource = ptbusiness.LayPhongTro();
                this.dgvPhong.Columns[4].Visible = false;
                this.dgvPhong.Columns[5].Visible = false;
                this.dgvPhong.Columns[6].Visible = false;
                // Thay đổi độ rộng cột 
                this.dgvCTTB.AutoResizeColumns();
                // Đặt tên cột
                dgvPhong.Columns[0].HeaderText = "Mã phòng";
                dgvPhong.Columns[1].HeaderText = "Mã loại phòng";
                dgvPhong.Columns[2].HeaderText = "Tên phòng";
                dgvPhong.Columns[3].HeaderText = "Dãy phòng";
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi! Không lấy được dữ liệu phòng trọ!");
            }
        }

        void LoadThietBi()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView  
                this.dgvThietBi.DataSource = tbbusiness.LayThietBi();
                this.dgvThietBi.Columns[5].Visible = false;
                this.dgvThietBi.Columns[6].Visible = false;
                // Thay đổi độ rộng cột 
                this.dgvCTTB.AutoResizeColumns();
                // Đặt tên cột
                dgvThietBi.Columns[0].HeaderText = "Mã thiết bị";
                dgvThietBi.Columns[1].HeaderText = "Mã loại thiết bị";
                dgvThietBi.Columns[2].HeaderText = "Tên thiết bị";
                dgvThietBi.Columns[3].HeaderText = "Thời gian bảo hành (tháng)";
                dgvThietBi.Columns[4].HeaderText = "Giá (VND)";
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi! Không lấy được dữ liệu thiết bị!");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            Them = true;

            // Xóa trống các đối tượng trong Panel 
            this.cbxMaTB.ResetText();
            this.cbxMaPhong.ResetText();
            this.panel.ResetText();
            this.dtpNgayTrangBi.ResetText();
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
            this.cbxMaPhong.Focus();
        }

        private void dgvCTTB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dgvCTTB.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.cbxMaTB.SelectedValue =
            dgvCTTB.Rows[r].Cells[0].Value.ToString();
            this.cbxMaPhong.SelectedValue =
            dgvCTTB.Rows[r].Cells[1].Value.ToString();
            this.dtpNgayTrangBi.Text =
            dgvCTTB.Rows[r].Cells[2].Value.ToString();
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

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadCTTB();
            LoadThietBi();
            LoadPhongTro();
            LoadComboboxMaPhong();
            LoadComboboxMaTB();
        }

        private void formTrangBi_Load(object sender, EventArgs e)
        {
            LoadCTTB();
            LoadThietBi();
            LoadPhongTro();
            LoadComboboxMaPhong();
            LoadComboboxMaTB();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            // Cho phép thao tác trên Panel 
            this.panel.Enabled = true;
            dgvCTTB_CellClick(null, null);
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
            this.cbxMaTB.Enabled = false;   
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
                    kq = cttbbusiness.ThemTrangBi(ref err, cbxMaTB.Text, cbxMaPhong.Text, DateTime.Parse(dtpNgayTrangBi.Text));
                    if (kq)
                    {
                        // Load lại dữ liệu trên DataGridView 
                        LoadCTTB();
                        // Thông báo 
                        MessageBox.Show("Đã thêm trang bị thành công!");
                    }

                }
                catch (SqlException)
                {
                    err = "Đã xảy ra lỗi! Không thêm được trang bị!";
                    MessageBox.Show(err);
                }
            }
            else
            {
                kq = false;
                // Thứ tự dòng hiện hành 
                int r = dgvCTTB.CurrentCell.RowIndex;
                // MaTB hiện hành 
                string strMaTB =
                dgvCTTB.Rows[r].Cells[0].Value.ToString();
                // Câu lệnh SQL 
                kq = cttbbusiness.CapNhatTrangBi(ref err, cbxMaTB.Text, cbxMaPhong.Text, DateTime.Parse(dtpNgayTrangBi.Text));
                if (kq)
                {
                    // Load lại dữ liệu trên DataGridView 
                    LoadCTTB();
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
                int r = dgvCTTB.CurrentCell.RowIndex;
                // Lấy MaTB của record hiện hành 
                string strMaTB =
                dgvCTTB.Rows[r].Cells[0].Value.ToString();
                // Hiện thông báo xác nhận việc xóa mẫu tin 
                // Khai báo biến traloi 
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp 
                traloi = MessageBox.Show("Bạn có chắc muốn xoá trang bị này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không? 
                if (traloi == DialogResult.Yes)
                {
                    // Thực hiện câu lệnh SQL 
                    kq = cttbbusiness.XoaTrangBi(ref err, cbxMaTB.Text);
                    if (kq)
                    {
                        // Cập nhật lại DataGridView 
                        LoadCTTB();
                        // Thông báo 
                        MessageBox.Show("Đã xóa trang bị thành công!");
                    }
                }
                else
                {

                    // Thông báo 
                    MessageBox.Show("Huỷ bỏ việc xoá trang bị!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi! Không xoá được trang bị!");
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng 
            this.cbxMaTB.ResetText();
            this.cbxMaPhong.ResetText();
            this.panel.ResetText();
            this.dtpNgayTrangBi.ResetText();
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
            dgvCTTB_CellClick(null, null);
        }
    }
}
