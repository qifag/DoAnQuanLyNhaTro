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
    public class BusinessLayerThietBi
    {
        QuanLyNhaTroDataModel dbs = new QuanLyNhaTroDataModel();

        public List<ThietBi> LayThietBi()
        {
            return dbs.ThietBis.ToList();
        }

        public bool ThemThietBi(ref string err, string MaTB, string MaLoaiTB,
                    string TenTB, int Gia, int ThoiGianBaoHanh)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    ThietBi tb = new ThietBi();
                    tb.MaTB = MaTB;
                    tb.MaLoaiTB = MaLoaiTB;
                    tb.TenTB = TenTB;
                    tb.Gia = Gia;
                    tb.ThoiGianBaoHanh = ThoiGianBaoHanh;

                    dbs.ThietBis.Add(tb);

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
        public bool XoaThietBi(ref string err, string MaTB)
        {
            bool flag = false;
            // Linq
            var toDelete = dbs.ThietBis.Where(x => x.MaTB == MaTB).FirstOrDefault();

            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    if (toDelete != null)
                    {
                        dbs.ThietBis.Remove(toDelete);
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

        public bool CapNhatThietBi(ref string err, string MaTB, string MaLoaiTB,
                    string TenTB, int Gia, int ThoiGianBaoHanh)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    var tb = dbs.ThietBis.Where(x => x.MaTB == MaTB).FirstOrDefault();
                    if (tb != null)
                    {
                        tb.MaTB = MaTB;
                        tb.MaLoaiTB = MaLoaiTB;
                        tb.TenTB = TenTB;
                        tb.Gia = Gia;
                        tb.ThoiGianBaoHanh = ThoiGianBaoHanh;

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

