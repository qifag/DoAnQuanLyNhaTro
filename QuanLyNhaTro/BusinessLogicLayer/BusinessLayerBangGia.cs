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
    public class BusinessLayerBangGia
    {
        QuanLyNhaTroDataModel dbs = new QuanLyNhaTroDataModel();

        public List<BangGia> LayBangGia()
        {
            return dbs.BangGias.ToList();
        }

        public bool ThemBangGia(ref string err, string MaBG, int Gia)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    BangGia bg = new BangGia();
                    bg.MaBG = MaBG;
                    bg.Gia = Gia;

                    dbs.BangGias.Add(bg);

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
        public bool XoaBangGia(ref string err, string MaBG)
        {
            bool flag = false;
            // Linq
            var toDelete = dbs.BangGias.Where(x => x.MaBG == MaBG).FirstOrDefault();

            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    if (toDelete != null)
                    {
                        dbs.BangGias.Remove(toDelete);
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

        public bool CapNhatBangGia(ref string err, string MaBG, int Gia)
        {
            bool flag = false;
            using (var dbContextTransaction = dbs.Database.BeginTransaction())
            {
                try
                {
                    var bg = dbs.BangGias.Where(x => x.MaBG == MaBG).FirstOrDefault();
                    if (bg != null)
                    {
                        bg.MaBG = MaBG;
                        bg.Gia = Gia;

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
    }
}

