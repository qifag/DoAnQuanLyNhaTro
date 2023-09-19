namespace QuanLyNhaTro
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhongTro")]
    public partial class PhongTro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhongTro()
        {
            ChiTietHopDongThuePhongs = new HashSet<ChiTietHopDongThuePhong>();
            TrangBis = new HashSet<TrangBi>();
        }

        [Key]
        [StringLength(6)]
        public string MaPhong { get; set; }

        [Required]
        [StringLength(6)]
        public string MaLoaiPhong { get; set; }

        [Required]
        [StringLength(10)]
        public string TenPhong { get; set; }

        [Required]
        [StringLength(20)]
        public string DayPhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHopDongThuePhong> ChiTietHopDongThuePhongs { get; set; }

        public virtual LoaiPhong LoaiPhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrangBi> TrangBis { get; set; }
    }
}
