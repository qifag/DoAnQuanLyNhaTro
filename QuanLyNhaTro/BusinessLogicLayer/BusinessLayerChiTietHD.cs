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
    public class BusinessLayerChiTietHD
    {
        QuanLyNhaTroDataModel dbs = new QuanLyNhaTroDataModel();

        public List<ChiTietHopDongThuePhong> LayChiTietHopDongThuePhong()
        {
            return dbs.ChiTietHopDongThuePhongs.ToList();
        }

        public bool KiemTraHopDong(string SoHDThue)
        {
            var tim = dbs.ChiTietHopDongThuePhongs.Where(x => x.SoHDThue == SoHDThue).FirstOrDefault();
            if (tim.NgayDonRa == null)
                return true;
            return false;
        }

        public bool ThemChiTietHopDongThuePhong(ref string err, string SoHDThue, string MaPhong, int TienCoc, DateTime NgayGioDK,
            DateTime NgayDonVao, DateTime NgayDonRa)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    ChiTietHopDongThuePhong cthd = new ChiTietHopDongThuePhong();
                    cthd.SoHDThue = SoHDThue;
                    cthd.MaPhong = MaPhong;
                    cthd.TienDatCoc = TienCoc;
                    cthd.NgayGioDK = NgayGioDK; 
                    cthd.NgayDonVao = NgayDonVao;
                    cthd.NgayDonRa = NgayDonRa;

                    dbs.ChiTietHopDongThuePhongs.Add(cthd);

                    dbs.SaveChanges();

                    dbContextTransaction.Commit();

                    flag = true;
                }

                catch (SqlException)
                {
                    err = "Đã xảy ra lỗi!";
                    dbContextTransaction.Rollback();
                }
                return flag;
            }
        }
        public bool XoaChiTietHopDongThuePhong(ref string err, string SoHDThue)
        {
            bool flag = false;
            // Linq
            var toDelete = dbs.ChiTietHopDongThuePhongs.Where(x => x.SoHDThue == SoHDThue).FirstOrDefault();

            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    if (toDelete != null)
                    {
                        dbs.ChiTietHopDongThuePhongs.Remove(toDelete);
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

        public bool CapNhatChiTietHopDongThuePhong(ref string err, string SoHDThue, string MaPhong, int TienCoc, DateTime NgayGioDK,
            DateTime NgayDonVao, DateTime NgayDonRa)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    var cthd = dbs.ChiTietHopDongThuePhongs.Where(x => x.SoHDThue == SoHDThue).FirstOrDefault();
                    if (cthd != null)
                    {
                        cthd.SoHDThue = SoHDThue;
                        cthd.MaPhong = MaPhong;
                        cthd.TienDatCoc = TienCoc;
                        cthd.NgayGioDK = NgayGioDK;
                        cthd.NgayDonVao = NgayDonVao;
                        cthd.NgayDonRa = NgayDonRa;

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

        public List<SubClass_ChiTietDichVu_ChiTietHD> LayChiTietSuDungDV_CTHopDong (string SoHDThue)
        {
            // SoHDThue = "": liệt kê tất cả chi tiết hợp đồng cùng với số hợp đồng
            // SoHDThue != "": liệt kê tất cả chi tiết hợp đồng ứng với số hợp đồng trên textbox 
            List<ChiTietSuDungDV> ctdv = new List<ChiTietSuDungDV>();
            List<SubClass_ChiTietDichVu_ChiTietHD> myList = new List<SubClass_ChiTietDichVu_ChiTietHD>();

            if (SoHDThue != "")
            {
                var timcthd = dbs.ChiTietHopDongThuePhongs.Where(x => x.SoHDThue == SoHDThue).FirstOrDefault();
                if (timcthd == null)
                    return myList.ToList();
                else
                    ctdv = timcthd.ChiTietSuDungDVs.ToList();
            }
            else
            {
                ctdv = dbs.ChiTietSuDungDVs.ToList();
            }
            Console.WriteLine("a");
            var result = ctdv.Join(
                                    dbs.DichVus,
                                    c => c.MaDV,
                                    d => d.MaDV,
                                    (c, d) => new SubClass_ChiTietDichVu_ChiTietHD
                                    {
                                        SoHDThue = c.SoHDThue,
                                        MaDV = c.MaDV,
                                        TenDV = d.TenDV,
                                        NgayGioDK = (DateTime)c.NgayGioDK,
                                        NgayGioHuy = (DateTime)c.NgayGioHuy
                                    });
            return result.ToList();
        }

        public List<SubClass_Phong_Khach_ChiTietHD> LayPhong_Khach_ChiTietHD(string SoHDThue)
        {
            // SoHDThue = "": liệt kê tất cả phòng và khách cùng với số hợp đồng
            // SoHDThue != "": liệt kê tất cả phòng và khách ứng với số hợp đồng trên textbox 
            List<ChiTietHopDongThuePhong> cthd = new List<ChiTietHopDongThuePhong>();

            if (SoHDThue != "")
            {
                var timcthd = dbs.ChiTietHopDongThuePhongs.Where(x => x.SoHDThue == SoHDThue).FirstOrDefault();

                cthd.Add(timcthd);
            }
            else
            {
                cthd = dbs.ChiTietHopDongThuePhongs.ToList();
            }

            var myList = cthd
                                .Join(
                                    dbs.PhongTroes,
                                    c => c.MaPhong,
                                    p => p.MaPhong,
                                    (c, p) => new
                                    {
                                        SoHDThue = c.SoHDThue,
                                        MaPhong = c.MaPhong,
                                        TenPhong = p.TenPhong,
                                        MaKH = c.HopDongThuePhong.MaKH
                                    })
                                .Join(
                                    dbs.KhachHangs,
                                    ct => ct.MaKH,
                                    k => k.MaKH,
                                    (ct, k) => new SubClass_Phong_Khach_ChiTietHD
                                    {
                                        SoHDThue = ct.SoHDThue,
                                        MaPhong = ct.MaPhong,
                                        TenPhong = ct.TenPhong,
                                        MaKH = k.MaKH,
                                        HoTen = k.HovaTenKH
                                    });
            return myList.ToList();
        }
    }
}

