namespace QuanLyNhaTro
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrangBi")]
    public partial class TrangBi
    {
        [Key]
        [StringLength(6)]
        public string MaTB { get; set; }

        [Required]
        [StringLength(6)]
        public string MaPhong { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayTrangBi { get; set; }

        public virtual PhongTro PhongTro { get; set; }

        public virtual ThietBi ThietBi { get; set; }
    }
}
