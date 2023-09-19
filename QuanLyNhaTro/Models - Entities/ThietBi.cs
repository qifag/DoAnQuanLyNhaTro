namespace QuanLyNhaTro
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThietBi")]
    public partial class ThietBi
    {
        [Key]
        [StringLength(6)]
        public string MaTB { get; set; }

        [Required]
        [StringLength(6)]
        public string MaLoaiTB { get; set; }

        [Required]
        [StringLength(50)]
        public string TenTB { get; set; }

        public int? ThoiGianBaoHanh { get; set; }

        public int? Gia { get; set; }

        public virtual LoaiThietBi LoaiThietBi { get; set; }

        public virtual TrangBi TrangBi { get; set; }
    }
}
