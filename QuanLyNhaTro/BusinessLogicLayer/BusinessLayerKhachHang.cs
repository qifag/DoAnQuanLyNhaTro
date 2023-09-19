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
    class BusinessLayerKhachHang
    {
        QuanLyNhaTroDataModel dbs = new QuanLyNhaTroDataModel();

        // Lấy danh sách hàng
        public List<KhachHang> LayKhachHang()
        {
            return dbs.KhachHangs.ToList();
        }
        // Thực hiên các thao tác: thêm - xóa - cập nhật khách hàng

        // Thêm khách hàng
        public bool ThemKhachHang(ref string err, string MaKH, string MaLoaiKH, string HovaTenKH,
                    string GioiTinh, string NamSinh, string CCCD, string QueQuan, string SDT, string NgheNghiep)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    KhachHang kh = new KhachHang();
                    kh.MaKH = MaKH;
                    kh.MaLoaiKH = MaLoaiKH;
                    kh.HovaTenKH = HovaTenKH;
                    kh.GioiTinh = GioiTinh;
                    kh.NamSinh = NamSinh;
                    kh.CCCD = CCCD;
                    kh.QueQuan = QueQuan;
                    kh.SDT = SDT;
                    kh.NgheNghiep = NgheNghiep;

                    dbs.KhachHangs.Add(kh);

                    dbs.SaveChanges();

                    dbContextTransaction.Commit();

                    flag = true;
                }

                catch (SqlException)
                {
                    err = "Lỗi rồi!";
                    dbContextTransaction.Rollback();
                }
                return flag;
            }
        }
        // Xóa khách hàng
        public bool XoaKhachHang(ref string err, string MaKH)
        {
            bool flag = false;
            // Linq
            var toDelete = dbs.KhachHangs.Where(x => x.MaKH == MaKH).FirstOrDefault();
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    if (toDelete != null)
                    {
                        dbs.KhachHangs.Remove(toDelete);
                        dbs.SaveChanges();
                        dbContextTransaction.Commit();
                        flag = true;
                    }
                    else
                        err = "Không tìm thấy!";

                }
                catch (SqlException)
                {
                    err = "Không xoá được!";
                    dbContextTransaction.Rollback();
                }
                return flag;
            }
        }
        // Cập nhật danh sách khách hàng
        public bool CapNhatKhachHang(ref string err, string MaKH, string MaLoaiKH, string HovaTenKH,
                    string GioiTinh, string NamSinh, string CCCD, string QueQuan, string SDT, string NgheNghiep)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    var kh = dbs.KhachHangs.Where(x => x.MaKH == MaKH).FirstOrDefault();
                    if (kh != null)
                    {
                        kh.MaLoaiKH = MaLoaiKH;
                        kh.HovaTenKH = HovaTenKH;
                        kh.GioiTinh = GioiTinh;
                        kh.NamSinh = NamSinh;
                        kh.CCCD = CCCD;
                        kh.QueQuan = QueQuan;
                        kh.SDT = SDT;
                        kh.NgheNghiep = NgheNghiep;

                        dbs.SaveChanges();

                        dbContextTransaction.Commit();

                        flag = true;
                    }

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
