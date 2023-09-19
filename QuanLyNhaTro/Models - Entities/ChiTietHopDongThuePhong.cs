namespace QuanLyNhaTro
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHopDongThuePhong")]
    public partial class ChiTietHopDongThuePhong
    {
        [Key]
        [StringLength(6)]
        public string SoHDThue { get; set; }

        [Required]
        [StringLength(6)]
        public string MaPhong { get; set; }

        public int TienDatCoc { get; set; }

        public DateTime NgayGioDK { get; set; }

        public DateTime? NgayDonVao { get; set; }

        public DateTime? NgayDonRa { get; set; }

        public virtual PhongTro PhongTro { get; set; }

        public virtual HopDongThuePhong HopDongThuePhong { get; set; }

        public virtual ICollection<ChiTietSuDungDV> ChiTietSuDungDVs { get; set; }
    }
}
