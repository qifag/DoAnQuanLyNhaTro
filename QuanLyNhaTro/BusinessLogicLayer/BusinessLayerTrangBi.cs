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
    class BusinessLayerTrangBi
    {
        QuanLyNhaTroDataModel dbs = new QuanLyNhaTroDataModel();

        // Lấy danh sách trang bị
        public List<TrangBi> LayTrangBi()
        {
            return dbs.TrangBis.ToList();
        }

        // Thêm - xóa - cập nhật trang bị
        // Thêm trang bị
        public bool ThemTrangBi(ref string err, string MaTB, string MaPhong, DateTime NgayTrangBi)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    TrangBi tb = new TrangBi();
                    tb.MaTB = MaTB;
                    tb.MaPhong = MaPhong;
                    tb.NgayTrangBi = NgayTrangBi;

                    dbs.TrangBis.Add(tb);

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
        // Xóa trang bị
        public bool XoaTrangBi(ref string err, string MaTB)
        {
            bool flag = false;
            // Linq
            var toDelete = dbs.TrangBis.Where(x => x.MaTB == MaTB).FirstOrDefault();
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    if (toDelete != null)
                    {
                        dbs.TrangBis.Remove(toDelete);
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
        // Câp nhật trang bị
        public bool CapNhatTrangBi(ref string err, string MaTB, string MaPhong, DateTime NgayTrangBi)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    var tb = dbs.TrangBis.Where(x => x.MaTB == MaTB).FirstOrDefault();
                    if (tb != null)
                    {
                        tb.MaTB = MaTB;
                        tb.MaPhong = MaPhong;
                        tb.NgayTrangBi = NgayTrangBi;

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


