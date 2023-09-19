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
    class BusinessLayerSoThuTien
    {
        QuanLyNhaTroDataModel dbs = new QuanLyNhaTroDataModel();

        // Lấy sổ thu tiền
        public List<SoThuTien> LaySoThuTien()
        {
            return dbs.SoThuTiens.ToList();
        }

        // Thêm - xóa - cập nhật phiếu thu
        // Thêm phiếu thu
        public bool ThemPhieuThu(ref string err, string MaPhieuThu, string SoHDThue, int SoTienThu, DateTime NgayThu)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    SoThuTien stt = new SoThuTien();
                    stt.MaPhieuThu = MaPhieuThu;
                    stt.SoHDThue = SoHDThue;
                    stt.SoTienThu = SoTienThu;
                    stt.NgayThu = NgayThu;

                    dbs.SoThuTiens.Add(stt);

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
        // Xóa phiếu thu
        public bool XoaPhieuThu(ref string err, string MaPhieuThu)
        {
            bool flag = false;
            // Linq
            var toDelete = dbs.SoThuTiens.Where(x => x.MaPhieuThu == MaPhieuThu).FirstOrDefault();
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    if (toDelete != null)
                    {
                        dbs.SoThuTiens.Remove(toDelete);
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
        // Câp nhật số thu tiền
        public bool CapNhatSoThuTien(ref string err, string MaPhieuThu, string SoHDThue, int SoTienThu, DateTime NgayThu)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    var stt = dbs.SoThuTiens.Where(x => x.MaPhieuThu == MaPhieuThu).FirstOrDefault();
                    if (stt != null)
                    {
                        stt.MaPhieuThu = MaPhieuThu;
                        stt.SoHDThue = SoHDThue;
                        stt.SoTienThu = SoTienThu;
                        stt.NgayThu = NgayThu;

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


