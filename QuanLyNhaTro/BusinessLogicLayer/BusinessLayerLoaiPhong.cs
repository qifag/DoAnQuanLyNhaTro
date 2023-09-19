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
    class BusinessLayerLoaiPhong
    {
        QuanLyNhaTroDataModel dbs = new QuanLyNhaTroDataModel();

        // Lấy danh sách loại phòng
        public List<LoaiPhong> LayLoaiPhong()
        {
            return dbs.LoaiPhongs.ToList();
        }

        // Thêm - xóa - cập nhật loại phòng 
        // Thêm loại phòng
        public bool ThemLoaiPhong(ref string err, string MaLoaiPhong, string TenLoaiPhong, int DienTichPhong)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    LoaiPhong lp = new LoaiPhong();
                    lp.MaLoaiPhong = MaLoaiPhong;
                    lp.TenLoaiPhong = TenLoaiPhong;
                    lp.DienTichPhong = DienTichPhong;

                    dbs.LoaiPhongs.Add(lp);

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
        // Xóa loại phòng
        public bool XoaLoaiPhong(ref string err, string MaLoaiPhong)
        {
            bool flag = false;
            // Linq
            var toDelete = dbs.LoaiPhongs.Where(x => x.MaLoaiPhong == MaLoaiPhong).FirstOrDefault();
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    if (toDelete != null)
                    {
                        dbs.LoaiPhongs.Remove(toDelete);
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
        // Cập nhật loại phòng
        public bool CapNhatLoaiPhong(ref string err, string MaLoaiPhong, string TenLoaiPhong, int DienTichPhong)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    var lp = dbs.LoaiPhongs.Where(x => x.MaLoaiPhong == MaLoaiPhong).FirstOrDefault();
                    if (lp != null)
                    {
                        lp.MaLoaiPhong = MaLoaiPhong;
                        lp.TenLoaiPhong = TenLoaiPhong;
                        lp.DienTichPhong = DienTichPhong;

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


