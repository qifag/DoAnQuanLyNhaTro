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
    class BusinessLayerLoaiKhachHang
    {
        QuanLyNhaTroDataModel dbs = new QuanLyNhaTroDataModel();

        // Lấy danh Loại Khách hàng
        public List<LoaiKhachHang> LayLoaiKhachHang()
        {
            return dbs.LoaiKhachHangs.ToList();
        }

        // Thực hiên các thao tác: thêm - xóa - cập nhật loại khách hàng
        // Thêm loại khách hàng
        public bool ThemLoaiKhachHang(ref string err, string MaLoaiKH, string TenLoaiKH)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    LoaiKhachHang lkh = new LoaiKhachHang();
                    lkh.MaLoaiKH = MaLoaiKH;
                    lkh.TenLoaiKH = TenLoaiKH;

                    dbs.LoaiKhachHangs.Add(lkh);

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
        // Xóa loại khách hàng
        public bool XoaKhachHang(ref string err, string MaLoaiKH)
        {
            bool flag = false;
            // Linq
            var toDelete = dbs.LoaiKhachHangs.Where(x => x.MaLoaiKH == MaLoaiKH).FirstOrDefault();
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    if (toDelete != null)
                    {
                        dbs.LoaiKhachHangs.Remove(toDelete);
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
        // Cập nhật danh sách loại khách hàng
        public bool CapNhatKhachHang(ref string err, string MaLoaiKH, string TenLoaiKH)

        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    var lkh = dbs.LoaiKhachHangs.Where(x => x.MaLoaiKH == MaLoaiKH).FirstOrDefault();
                    if (lkh != null)
                    {
                        lkh.MaLoaiKH = MaLoaiKH;
                        lkh.TenLoaiKH = TenLoaiKH;

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
