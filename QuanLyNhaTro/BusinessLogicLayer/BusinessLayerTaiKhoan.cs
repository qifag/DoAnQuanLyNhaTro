using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Collections;

namespace QuanLyNhaTro
{
    public class BusinessLayerTaiKhoan
    {
        QuanLyNhaTroDataModel dbs = new QuanLyNhaTroDataModel();

        public List<TaiKhoan> LayTaiKhoan()
        {
            return dbs.TaiKhoans.ToList();
        }

        public bool DangNhap(ref string err, string TenNguoiDung, string MatKhau)
        {
            var tk = dbs.TaiKhoans.Where(x => x.TenNguoiDung == TenNguoiDung.Trim()).FirstOrDefault();
            if (tk == null)
            {
                err = "Tài khoản không tồn tại!";
                return false;
            }
            else if (tk.MatKhau.Trim() != MatKhau.Trim())
            {
                err = "Mật khẩu không đúng!";
                return false;
            }
            else
            {
                return true;
            }
        }

        // Tài khoản đã có chưa
        public bool KiemTraTaiKhoan(ref string err, string TenNguoiDung)
        {
            var tk = dbs.TaiKhoans.Where(x => x.TenNguoiDung == TenNguoiDung.Trim()).FirstOrDefault();
            if (tk != null)
            {
                err = "Tài khoản đã tồn tại!";
                return true;
            }
            return false;
        }

        // Kiểm tra mật khẩu cũ
        public bool KiemTraMatKhau(ref string err, string TenNguoiDung, string MatKhauCu)
        {
            var tk = dbs.TaiKhoans.Where(x => x.TenNguoiDung == TenNguoiDung).FirstOrDefault();
            if (tk.MatKhau.Trim() != MatKhauCu.Trim())
            {
                err = "Mật khẩu cũ không đúng!";
                return true;
            }
            return false;
        }

        public bool ThemTaiKhoan(ref string err, string TenNguoiDung, string MatKhau)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    TaiKhoan tk = new TaiKhoan();
                    tk.TenNguoiDung = TenNguoiDung;
                    tk.MatKhau = MatKhau;

                    dbs.TaiKhoans.Add(tk);

                    dbs.SaveChanges();

                    dbContextTransaction.Commit();

                    flag = true;
                }

                catch (SqlException)
                {
                    err = "Đã xảy ra lỗi khi thêm tài khoản!";
                    dbContextTransaction.Rollback();
                }
                return flag;
            }
        }
        public bool XoaTaiKhoan(ref string err, string TenNguoiDung)
        {
            bool flag = false;
            // Linq
            var toDelete = dbs.TaiKhoans.Where(x => x.TenNguoiDung == TenNguoiDung).FirstOrDefault();
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    if (toDelete != null)
                    {
                        dbs.TaiKhoans.Remove(toDelete);
                        dbs.SaveChanges();
                        dbContextTransaction.Commit();
                        flag = true;
                    }
                    else
                        err = "Không tìm thấy tài khoản!";
                }
                catch (SqlException)
                {
                    err = "Không thể xoá tài khoản!";
                    dbContextTransaction.Rollback();
                }
                return flag;
            }
        }

        public bool DoiMatKhau(ref string err, string TenNguoiDung, string MatKhauMoi)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    var tk = dbs.TaiKhoans.Where(x => x.TenNguoiDung == TenNguoiDung).FirstOrDefault();

                    tk.MatKhau = MatKhauMoi;
                    
                    dbs.SaveChanges();

                    dbContextTransaction.Commit();

                    flag = true;
                        
                }
                catch (SqlException)
                {
                    err = "Đã xảy ra lỗi!";
                    dbContextTransaction.Rollback();
                }
            }
            return flag;
        }
    }
}

