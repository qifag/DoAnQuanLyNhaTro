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
    class BusinessLayerLoaiThietBi
    {
        QuanLyNhaTroDataModel dbs = new QuanLyNhaTroDataModel();

        // Lấy danh sách loại thiết bị
        public List<LoaiThietBi> LayLoaiThietBi()
        {
            return dbs.LoaiThietBis.ToList();
        }

        // Thêm - xóa - cập nhật loại thiết bị
        // Thêm loại thiết bị
        public bool ThemLoaiThietBi(ref string err, string MaLoaiTB, string TenLoaiTB)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    LoaiThietBi ltb = new LoaiThietBi();
                    ltb.MaLoaiTB = MaLoaiTB;
                    ltb.TenLoaiTB = TenLoaiTB;

                    dbs.LoaiThietBis.Add(ltb);

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
        // Xóa loại thiết bị
        public bool XoaLoaiPhong(ref string err, string MaLoaiTB)
        {
            bool flag = false;
            // Linq
            var toDelete = dbs.LoaiThietBis.Where(x => x.MaLoaiTB == MaLoaiTB).FirstOrDefault();
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    if (toDelete != null)
                    {
                        dbs.LoaiThietBis.Remove(toDelete);
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
        // Cập nhật loại thiết bị
        public bool CapNhatLoaiPhong(ref string err, string MaLoaiTB, string TenLoaiTB)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    var ltb = dbs.LoaiThietBis.Where(x => x.MaLoaiTB == MaLoaiTB).FirstOrDefault();
                    if (ltb != null)
                    {
                        ltb.MaLoaiTB = MaLoaiTB;
                        ltb.TenLoaiTB = TenLoaiTB;

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


