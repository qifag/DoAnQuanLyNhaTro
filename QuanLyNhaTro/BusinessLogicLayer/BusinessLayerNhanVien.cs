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
    public class BusinessLayerNhanVien
    {
        QuanLyNhaTroDataModel dbs = new QuanLyNhaTroDataModel();

        public List<NhanVien> LayNhanVien()
        {
            return dbs.NhanViens.ToList();
        }

        public bool ThemNhanVien(ref string err, string MaNV, string HovaTenNV,
                    string GioiTinh, DateTime NamSinh, string QueQuan, string CCCD, int Luong)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    NhanVien nv = new NhanVien();
                    nv.MaNV = MaNV;
                    nv.HovaTenNV = HovaTenNV;
                    nv.GioiTinh = GioiTinh;
                    nv.NamSinh = NamSinh;
                    nv.CCCD = CCCD;
                    nv.QueQuan = QueQuan;
                    nv.Luong = Luong;

                    dbs.NhanViens.Add(nv);

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
        public bool XoaNhanVien(ref string err, string MaNV)
        {
            bool flag = false;
            // Linq
            var toDelete = dbs.NhanViens.Where(x => x.MaNV == MaNV).FirstOrDefault();
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    if (toDelete != null)
                    {
                        dbs.NhanViens.Remove(toDelete);
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

        public bool CapNhatNhanVien(ref string err, string MaNV, string HovaTenNV,
                    string GioiTinh, DateTime NamSinh, string QueQuan, string CCCD, int Luong)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    var nv = dbs.NhanViens.Where(x => x.MaNV == MaNV).FirstOrDefault();
                    if (nv != null)
                    {
                        nv.HovaTenNV = HovaTenNV;
                        nv.GioiTinh = GioiTinh;
                        nv.NamSinh = NamSinh;
                        nv.CCCD = CCCD;
                        nv.QueQuan = QueQuan;
                        nv.Luong = Luong;

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

