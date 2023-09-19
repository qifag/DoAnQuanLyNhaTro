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
    class BusinessLayerDichVu
    {
        QuanLyNhaTroDataModel dbs = new QuanLyNhaTroDataModel();

        // Lấy danh sách dịch vụ
        public List<DichVu> LayDichVu()
        {
            return dbs.DichVus.ToList();
        }

        // Thêm - Xóa - cập nhật dịch vụ
        // Thêm dịch vụ
        public bool ThemDichVu(ref string err, string MaDV, string MaLoaiDV, string TenDV, int GiaDV, string ChiTietDV)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    DichVu dv = new DichVu();
                    dv.MaDV = MaDV;
                    dv.MaLoaiDV = MaLoaiDV;
                    dv.TenDV = TenDV;
                    dv.GiaDV = GiaDV;
                    dv.ChiTietDV = ChiTietDV;

                    dbs.DichVus.Add(dv);

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
        // Xóa dịch vụ
        public bool XoaDichVu(ref string err, string MaDV)
        {
            bool flag = false;
            // Linq
            var toDelete = dbs.DichVus.Where(x => x.MaDV == MaDV).FirstOrDefault();
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    if (toDelete != null)
                    {
                        dbs.DichVus.Remove(toDelete);
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
        // Câp nhật dịch vụ
        public bool CapNhatDichVu(ref string err, string MaDV, string MaLoaiDV, string TenDV, int GiaDV, string ChiTietDV)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    var dv = dbs.DichVus.Where(x => x.MaDV == MaDV).FirstOrDefault();
                    if (dv != null)
                    {
                        dv.MaDV = MaDV;
                        dv.MaLoaiDV = MaLoaiDV;
                        dv.TenDV = TenDV;
                        dv.GiaDV = GiaDV;
                        dv.ChiTietDV = ChiTietDV;

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
