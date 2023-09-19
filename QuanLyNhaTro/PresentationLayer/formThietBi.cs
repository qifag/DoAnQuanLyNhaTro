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
    public partial class frmThietBi : Form
    {
        BusinessLayerThietBi tbbusiness = new BusinessLayerThietBi();
        BusinessLayerLoaiThietBi ltbbusiness = new BusinessLayerLoaiThietBi();
        QuanLyNhaTroDataModel db = new QuanLyNhaTroDataModel();
        bool Them = false;
        public frmThietBi()
        {
            InitializeComponent();
        }

        void LoadTB()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView  
                this.dgvThietBi.DataSource = tbbusiness.LayThietBi();
                this.dgvThietBi.Columns[5].Visible = false;
                this.dgvThietBi.Columns[6].Visible = false;
                // Thay đổi độ rộng cột 
                this.dgvThietBi.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel 
                this.txtMaTB.ResetText();
                this.cbxMaLTB.ResetText();
                this.txtTenTB.ResetText();
                this.txtTGBH.ResetText();
                this.txtGia.ResetText();
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
                dgvThietBi.Columns[0].HeaderText = "Mã thiết bị";
                dgvThietBi.Columns[1].HeaderText = "Mã loại thiết bị";
                dgvThietBi.Columns[2].HeaderText = "Tên thiết bị";
                dgvThietBi.Columns[3].HeaderText = "Thời gian bảo hành (tháng)";
                dgvThietBi.Columns[4].HeaderText = "Giá (VND)";
                // Hành động click chuột
                dgvThietBi_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung thiết bị. Đã xảy ra lỗi!");
            }
        }

        void LoadLTB()
        {
            try
            {
                // Đưa dữ liệu lên DataGridView  
                this.dgvLoaiTB.DataSource = ltbbusiness.LayLoaiThietBi();
                this.dgvLoaiTB.Columns[2].Visible = false;
                // Thay đổi độ rộng cột 
                this.dgvLoaiTB.AutoResizeColumns();
                // Đặt tên cột
                dgvLoaiTB.Columns[0].HeaderText = "Mã loại thiết bị";
                dgvLoaiTB.Columns[1].HeaderText = "Loại thiết bị";
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung loại thiết bị. Đã xảy ra lỗi!");
            }
        }

        public void LoadCombobox()
        {
            try
            {
                //load ds Mã hđ, mã khách, tên khách vào cbxTenKhach
                this.cbxMaLTB.DataSource = ltbbusiness.LayLoaiThietBi();
                this.cbxMaLTB.ValueMember = "MaLoaiTB";
                this.cbxMaLTB.DisplayMember = "Mã loại thiết bị";
            }
            catch (SqlException error)  //bắt lỗi sql
            {
                MessageBox.Show("Không truy cập dữ liệu loại thiết bị được!\rLỗi: " + error.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception er)    //bắt các lỗi khác
            {
                MessageBox.Show("Không truy cập dữ liệu loại thiết bị được!\rLỗi: " + er.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvThietBi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dgvThietBi.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtMaTB.Text =
            dgvThietBi.Rows[r].Cells[0].Value.ToString();
            this.cbxMaLTB.Text =
            dgvThietBi.Rows[r].Cells[1].Value.ToString();
            this.txtTenTB.Text =
            dgvThietBi.Rows[r].Cells[2].Value.ToString();
            this.txtTGBH.Text =
            dgvThietBi.Rows[r].Cells[3].Value.ToString();
            this.txtGia.Text =
            dgvThietBi.Rows[r].Cells[4].Value.ToString();
        }

        private void frmThietBi_Load(object sender, EventArgs e)
        {
            LoadCombobox();
            LoadLTB();
            LoadTB();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            Them = true;

            // Xóa trống các đối tượng trong Panel 
            this.txtMaTB.ResetText();
            this.cbxMaLTB.ResetText();
            this.panel.ResetText();
            this.txtTenTB.ResetText();
            this.txtTGBH.ResetText();
            this.txtGia.ResetText();
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
            this.txtMaTB.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Them = false;
            // Cho phép thao tác trên Panel 
            this.panel.Enabled = true;
            dgvThietBi_CellClick(null, null);
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
            // Đưa con trỏ đến TextField txtMaNV 
            this.txtMaTB.Enabled = false;
            this.cbxMaLTB.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool kq = false;
            string err = "";
            try
            {
                // Lấy thứ tự record hiện hành 
                int r = dgvThietBi.CurrentCell.RowIndex;
                // Lấy MaTB của record hiện hành 
                string strMaTB =
                dgvThietBi.Rows[r].Cells[0].Value.ToString();
                // Hiện thông báo xác nhận việc xóa mẫu tin 
                // Khai báo biến traloi 
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp 
                traloi = MessageBox.Show("Bạn có chắc muốn xoá thiết bị này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không? 
                if (traloi == DialogResult.Yes)
                {
                    // Thực hiện câu lệnh SQL 
                    kq = tbbusiness.XoaThietBi(ref err, txtMaTB.Text);
                    if (kq)
                    {
                        // Cập nhật lại DataGridView 
                        LoadTB();
                        // Thông báo 
                        MessageBox.Show("Đã xóa thành công!");
                    }
                }
                else
                {

                    // Thông báo 
                    MessageBox.Show("Huỷ bỏ việc xoá thiết bị!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được thiết bị này. Lỗi rồi!");
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
                    kq = tbbusiness.ThemThietBi(ref err, txtMaTB.Text, cbxMaLTB.Text, txtTenTB.Text, int.Parse(txtGia.Text), int.Parse(txtTGBH.Text));
                    if (kq)
                    {
                        // Load lại dữ liệu trên DataGridView 
                        LoadTB();
                        // Thông báo 
                        MessageBox.Show("Đã thêm thiết bị thành công!");
                    }

                }
                catch (SqlException)
                {
                    err = "Không thêm được thiết bị này. Lỗi rồi!";
                    MessageBox.Show(err);
                }
            }
            else
            {
                kq = false;
                // Thứ tự dòng hiện hành 
                int r = dgvThietBi.CurrentCell.RowIndex;
                // MaTB hiện hành 
                string strMaTB =
                dgvThietBi.Rows[r].Cells[0].Value.ToString();
                // Câu lệnh SQL 
                kq = tbbusiness.CapNhatThietBi(ref err, txtMaTB.Text, cbxMaLTB.Text, txtTenTB.Text, int.Parse(txtGia.Text), int.Parse(txtTGBH.Text));
                if (kq)
                {
                    // Load lại dữ liệu trên DataGridView 
                    LoadTB();
                    // Thông báo 
                    MessageBox.Show("Đã cập nhật xong!");
                }
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng 
            this.txtMaTB.ResetText();
            this.cbxMaLTB.ResetText();
            this.panel.ResetText();
            this.txtTenTB.ResetText();
            this.txtTGBH.ResetText();
            this.txtGia.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát / Reload
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnQuayLai.Enabled = true;
            this.btnReload.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnLuu.Enabled = false;
            this.btnHuyBo.Enabled = false;
            this.panel.Enabled = false;
            dgvThietBi_CellClick(null, null);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadTB();
            LoadLTB();
            LoadCombobox();
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
