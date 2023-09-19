namespace QuanLyNhaTro
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiPhong")]
    public partial class LoaiPhong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiPhong()
        {
            PhongTroes = new HashSet<PhongTro>();
        }

        [Key]
        [StringLength(6)]
        public string MaLoaiPhong { get; set; }

        [Required]
        [StringLength(50)]
        public string TenLoaiPhong { get; set; }

        public int? DienTichPhong { get; set; }

        [StringLength(6)]
        public string MaBG { get; set; }

        public virtual BangGia BangGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhongTro> PhongTroes { get; set; }
    }
}
