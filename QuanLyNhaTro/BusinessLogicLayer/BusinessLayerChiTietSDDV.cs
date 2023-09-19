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
    public class BusinessLayerChiTietSDDV
    {
        QuanLyNhaTroDataModel dbs = new QuanLyNhaTroDataModel();

        public List<ChiTietSuDungDV> LayChiTietSuDungDV()
        {
            return dbs.ChiTietSuDungDVs.ToList();
        }

        public string LayMaPhong_CTSDDV(string SoHDThue)
        {
            var tim2 = dbs.HopDongThuePhongs.Where(x => x.SoHDThue == SoHDThue).FirstOrDefault();
            return tim2.ChiTietHopDongThuePhong.PhongTro.MaPhong.ToString();
        }

        public string LayTenPhong_CTSDDV(string SoHDThue)
        {
            var tim = dbs.ChiTietHopDongThuePhongs.Where(x => x.SoHDThue == SoHDThue).FirstOrDefault();
            return tim.PhongTro.TenPhong.ToString();
        }

        public string LayMaKH_CTSDDV(string SoHDThue)
        {
            var tim = dbs.ChiTietHopDongThuePhongs.Where(x => x.SoHDThue == SoHDThue).FirstOrDefault();
            return tim.HopDongThuePhong.MaKH.ToString();
        }

        public string LayHoTenKH_CTSDDV(string SoHDThue)
        {
            var tim = dbs.ChiTietHopDongThuePhongs.Where(x => x.SoHDThue == SoHDThue).FirstOrDefault();
            if (tim != null)
                return tim.HopDongThuePhong.KhachHang.HovaTenKH.ToString();
            else
            {
                var tim2 = dbs.HopDongThuePhongs.Where(x => x.SoHDThue == SoHDThue).FirstOrDefault();
                return tim2.KhachHang.HovaTenKH.ToString();
            }
        }

        public string LayTenDV_CTSDDV(string SoHDThue, string MaDV)
        {
            var tim = dbs.ChiTietHopDongThuePhongs.Where(x => x.SoHDThue == SoHDThue).FirstOrDefault();
            var timdv = tim.ChiTietSuDungDVs.Where(x => x.DichVu.MaDV == MaDV).FirstOrDefault();
            return timdv.DichVu.TenDV.ToString();
        }

        public bool ThemChiTietSuDungDV(ref string err, string SoHDThue, string MaDV, DateTime NgayGioDK, DateTime NgayGioHuy)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    ChiTietSuDungDV ctdv = new ChiTietSuDungDV();
                    ctdv.SoHDThue = SoHDThue;
                    ctdv.MaDV = MaDV;
                    ctdv.NgayGioDK = NgayGioDK;
                    ctdv.NgayGioHuy = NgayGioHuy;

                    dbs.ChiTietSuDungDVs.Add(ctdv);

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
        public bool XoaChiTietSuDungDV(ref string err, string SoHDThue, string MaDV)
        {
            bool flag = false;
            // Linq
            var toDelete = dbs.ChiTietSuDungDVs.Where(x => (x.SoHDThue == SoHDThue && x.MaDV == MaDV)).FirstOrDefault();

            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    if (toDelete != null)
                    {
                        dbs.ChiTietSuDungDVs.Remove(toDelete);
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

        public bool CapNhatChiTietSuDungDV(ref string err, string SoHDThue, string MaDV, DateTime NgayGioDK, DateTime NgayGioHuy)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    var ctdv = dbs.ChiTietSuDungDVs.Where(x => (x.SoHDThue == SoHDThue && x.MaDV == MaDV)).FirstOrDefault();
                    if (ctdv != null)
                    {
                        ctdv.SoHDThue = SoHDThue;
                        ctdv.MaDV = MaDV;
                        ctdv.NgayGioDK = NgayGioDK;
                        ctdv.NgayGioHuy = NgayGioHuy;

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

