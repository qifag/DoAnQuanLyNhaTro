using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyNhaTro
{
    public partial class QuanLyNhaTroDataModel : DbContext
    {
        public QuanLyNhaTroDataModel()
            : base("name=QuanLyNhaTroEntities")
        {
        }

        public virtual DbSet<BangGia> BangGias { get; set; }
        public virtual DbSet<ChiTietHopDongThuePhong> ChiTietHopDongThuePhongs { get; set; }
        public virtual DbSet<ChiTietSuDungDV> ChiTietSuDungDVs { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<HopDongThuePhong> HopDongThuePhongs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiDichVu> LoaiDichVus { get; set; }
        public virtual DbSet<LoaiKhachHang> LoaiKhachHangs { get; set; }
        public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }
        public virtual DbSet<LoaiThietBi> LoaiThietBis { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhongTro> PhongTroes { get; set; }
        public virtual DbSet<SoThuTien> SoThuTiens { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThietBi> ThietBis { get; set; }
        public virtual DbSet<TrangBi> TrangBis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BangGia>()
                .Property(e => e.MaBG)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietHopDongThuePhong>()
                .Property(e => e.MaPhong)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietHopDongThuePhong>()
                .Property(e => e.SoHDThue)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietHopDongThuePhong>()
                .HasMany(e => e.ChiTietSuDungDVs)
                .WithRequired(e => e.ChiTietHopDongThuePhong)
                .WillCascadeOnDelete(false); ;

            modelBuilder.Entity<ChiTietSuDungDV>()
                .Property(e => e.SoHDThue)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietSuDungDV>()
                .Property(e => e.MaDV)
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.MaDV)
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.MaLoaiDV)
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .HasMany(e => e.ChiTietSuDungDVs)
                .WithRequired(e => e.DichVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HopDongThuePhong>()
                .Property(e => e.SoHDThue)
                .IsUnicode(false);

            modelBuilder.Entity<HopDongThuePhong>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<HopDongThuePhong>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<HopDongThuePhong>()
                .HasOptional(e => e.ChiTietHopDongThuePhong)
                .WithRequired(e => e.HopDongThuePhong);

            modelBuilder.Entity<HopDongThuePhong>()
                .HasMany(e => e.SoThuTiens)
                .WithRequired(e => e.HopDongThuePhong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaLoaiKH)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.NamSinh)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.CCCD)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.HopDongThuePhongs)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiDichVu>()
                .Property(e => e.MaLoaiDV)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiDichVu>()
                .HasMany(e => e.DichVus)
                .WithRequired(e => e.LoaiDichVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiKhachHang>()
                .Property(e => e.MaLoaiKH)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiKhachHang>()
                .HasMany(e => e.KhachHangs)
                .WithRequired(e => e.LoaiKhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiPhong>()
                .Property(e => e.MaLoaiPhong)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiPhong>()
                .Property(e => e.MaBG)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiPhong>()
                .HasMany(e => e.PhongTroes)
                .WithRequired(e => e.LoaiPhong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiThietBi>()
                .Property(e => e.MaLoaiTB)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiThietBi>()
                .HasMany(e => e.ThietBis)
                .WithRequired(e => e.LoaiThietBi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.CCCD)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.HopDongThuePhongs)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhongTro>()
                .Property(e => e.MaPhong)
                .IsUnicode(false);

            modelBuilder.Entity<PhongTro>()
                .Property(e => e.MaLoaiPhong)
                .IsUnicode(false);

            modelBuilder.Entity<PhongTro>()
                .Property(e => e.TenPhong)
                .IsUnicode(false);

            modelBuilder.Entity<PhongTro>()
                .HasMany(e => e.ChiTietHopDongThuePhongs)
                .WithRequired(e => e.PhongTro)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhongTro>()
                .HasMany(e => e.TrangBis)
                .WithRequired(e => e.PhongTro)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SoThuTien>()
                .Property(e => e.MaPhieuThu)
                .IsUnicode(false);

            modelBuilder.Entity<SoThuTien>()
                .Property(e => e.SoHDThue)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TenNguoiDung)
                .IsFixedLength();

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsFixedLength();

            modelBuilder.Entity<ThietBi>()
                .Property(e => e.MaTB)
                .IsUnicode(false);

            modelBuilder.Entity<ThietBi>()
                .Property(e => e.MaLoaiTB)
                .IsUnicode(false);

            modelBuilder.Entity<ThietBi>()
                .HasOptional(e => e.TrangBi)
                .WithRequired(e => e.ThietBi);

            modelBuilder.Entity<TrangBi>()
                .Property(e => e.MaTB)
                .IsUnicode(false);

            modelBuilder.Entity<TrangBi>()
                .Property(e => e.MaPhong)
                .IsUnicode(false);
        }
    }
}
