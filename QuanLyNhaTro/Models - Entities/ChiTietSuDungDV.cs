namespace QuanLyNhaTro
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietSuDungDV")]
    public partial class ChiTietSuDungDV
    {
        [Key]
        [StringLength(6)]
        [Column(Order = 0)]
        public string SoHDThue { get; set; }

        [Key]
        [Required]
        [StringLength(6)]
        [Column(Order = 1)]
        public string MaDV { get; set; }

        public DateTime? NgayGioDK { get; set; }

        public DateTime? NgayGioHuy { get; set; }

        public virtual ChiTietHopDongThuePhong ChiTietHopDongThuePhong { get; set; }

        public virtual DichVu DichVu { get; set; }
    }
}
