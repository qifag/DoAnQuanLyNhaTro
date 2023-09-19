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
    class BusinessLayerPhongTro
    {
        QuanLyNhaTroDataModel dbs = new QuanLyNhaTroDataModel();

        // Lấy danh sách phòng trọ
        public List<PhongTro> LayPhongTro()
        {
            return dbs.PhongTroes.ToList();
        }

        // Thêm - Xóa - Cập nhật phòng trọ
        // Thêm phòng trọ
        public bool ThemPhongTro(ref string err, string MaPhong, string MaLoaiPhong, string TenPhong, string DayPhong)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    PhongTro p = new PhongTro();
                    p.MaPhong = MaPhong;
                    p.MaLoaiPhong = MaLoaiPhong;
                    p.TenPhong = TenPhong;
                    p.DayPhong = DayPhong;

                    dbs.PhongTroes.Add(p);

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
        // Xóa phòng trọ
        public bool XoaPhongTro(ref string err, string MaPhong)
        {
            bool flag = false;
            // Linq
            var toDelete = dbs.PhongTroes.Where(x => x.MaPhong == MaPhong).FirstOrDefault();
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    if (toDelete != null)
                    {
                        dbs.PhongTroes.Remove(toDelete);
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
        // Câp nhật phòng trọ
        public bool CapNhatPhongTro(ref string err, string MaPhong, string MaLoaiPhong, string TenPhong, string DayPhong)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    var p = dbs.PhongTroes.Where(x => x.MaPhong == MaPhong).FirstOrDefault();
                    if (p != null)
                    {
                        p.MaPhong = MaPhong;
                        p.MaLoaiPhong = MaLoaiPhong;
                        p.TenPhong = TenPhong;
                        p.DayPhong = DayPhong;

                        dbs.SaveChanges();

                        dbContextTransaction.Commit();

                        flag = true;
                    }

                }
                catch (SqlException)
                {
                    err = "Lỗi rồi!";
                    dbContextTransaction.Rollback();
                }
            }
            return flag;
        }

        public List<PhongTro> LayDanhSachPhongTrong()
        {
            List<PhongTro> dsptt = new List<PhongTro>();
            List<PhongTro> dspt = dbs.PhongTroes.ToList();

            foreach (var p in dspt)
            {
                bool flag = false; // Kiểm tra tình trạng phòng trọ
                if (p.ChiTietHopDongThuePhongs.Count() == 0) // Phòng chưa có hợp đồng nào
                    dsptt.Add(p);
                else
                {
                    foreach (var x in p.ChiTietHopDongThuePhongs)
                    {
                        if ((!x.NgayDonRa.HasValue || x.NgayDonRa == x.NgayGioDK))
                        {
                            flag = true; // Phòng đang được ở (ngày dọn ra trống hoặc trùng ngày dọn vào)
                            Console.WriteLine(x.SoHDThue);
                        }
                    }
                    if (!flag)
                        dsptt.Add(p);
                }
            }
            return dsptt.ToList();
        }

    }
}
