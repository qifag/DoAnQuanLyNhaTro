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
    class BusinessLayerHopDongThuePhong
    {
        QuanLyNhaTroDataModel dbs = new QuanLyNhaTroDataModel();

        // Lấy danh sách hợp đồng thuê phòng
        public List<HopDongThuePhong> LayHopDongThuePhong()
        {
            return dbs.HopDongThuePhongs.ToList();
        }

        // Thêm - xóa - cập nhật hợp đồng thuê phòng
        // Thêm hợp đồng
        public bool ThemHopDongThuePhong(ref string err, string SoHDThue, string MaKH, string MaNV)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    HopDongThuePhong hdtp = new HopDongThuePhong();
                    hdtp.SoHDThue = SoHDThue;
                    hdtp.MaKH = MaKH;
                    hdtp.MaNV = MaNV;

                    dbs.HopDongThuePhongs.Add(hdtp);

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
        // Xóa hợp đồng 
        public bool XoaHopDongThuePhong(ref string err, string SoHDThue)
        {
            bool flag = false;
            // Linq
            var toDelete = dbs.HopDongThuePhongs.Where(x => x.SoHDThue == SoHDThue).FirstOrDefault();
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    if (toDelete != null)
                    {
                        dbs.HopDongThuePhongs.Remove(toDelete);
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
        // Câp nhật hợp đồng
        public bool CapNhatHopDongThuePhong(ref string err, string SoHDThue, string MaKH, string MaNV)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    var hdtp = dbs.HopDongThuePhongs.Where(x => x.SoHDThue == SoHDThue).FirstOrDefault();
                    if (hdtp != null)
                    {
                        hdtp.SoHDThue = SoHDThue;
                        hdtp.MaKH = MaKH;
                        hdtp.MaNV = MaNV;

                        dbs.SaveChanges();

                        dbContextTransaction.Commit();

                        flag = true;
                    }

                }
                catch (SqlException)
                {
                    err = "Đã xảy ra lỗi!!";
                    dbContextTransaction.Rollback();
                }
            }
            return flag;
        }
    }
}


