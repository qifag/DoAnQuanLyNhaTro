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
    class BusinessLayerLoaiDichVu
    {
        QuanLyNhaTroDataModel dbs = new QuanLyNhaTroDataModel();

        // Lấy danh sách loại dịch vụ
        public List<LoaiDichVu> LayLoaiDichVu()
        {
            return dbs.LoaiDichVus.ToList();
        }

        // Thêm - Xóa - cập nhật loại dịch vụ
        // Thêm loại dịch vụ
        public bool ThemLoaiDichVu(ref string err, string MaLoaiDV, string TenLoaiDV)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    LoaiDichVu ldv = new LoaiDichVu();
                    ldv.MaLoaiDV = MaLoaiDV;
                    ldv.TenLoaiDV = TenLoaiDV;
                    dbs.LoaiDichVus.Add(ldv);

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
        // Xóa loại dịch vụ
        public bool XoaLoaiDichVu(ref string err, string MaLoaiDV)
        {
            bool flag = false;
            // Linq
            var toDelete = dbs.LoaiDichVus.Where(x => x.MaLoaiDV == MaLoaiDV).FirstOrDefault();
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    if (toDelete != null)
                    {
                        dbs.LoaiDichVus.Remove(toDelete);
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
        // Câp nhật loại dịch vụ
        public bool CapNhatDichVu(ref string err, string MaDV, string MaLoaiDV, string TenLoaiDV)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    var ldv = dbs.LoaiDichVus.Where(x => x.MaLoaiDV == MaLoaiDV).FirstOrDefault();
                    if (ldv != null)
                    {
                        ldv.MaLoaiDV = MaLoaiDV;
                        ldv.TenLoaiDV = TenLoaiDV;

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
