namespace QuanLyNhaTro
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SoThuTien")]
    public partial class SoThuTien
    {
        [Key]
        [StringLength(6)]
        public string MaPhieuThu { get; set; }

        [Required]
        [StringLength(6)]
        public string SoHDThue { get; set; }

        public int SoTienThu { get; set; }

        public DateTime NgayThu { get; set; }

        public virtual HopDongThuePhong HopDongThuePhong { get; set; }
    }
}
