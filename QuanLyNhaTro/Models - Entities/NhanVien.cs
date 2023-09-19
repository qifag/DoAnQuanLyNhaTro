namespace QuanLyNhaTro
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            HopDongThuePhongs = new HashSet<HopDongThuePhong>();
        }

        [Key]
        [StringLength(6)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(50)]
        public string HovaTenNV { get; set; }

        [StringLength(3)]
        public string GioiTinh { get; set; }

        public DateTime? NamSinh { get; set; }

        [Required]
        [StringLength(12)]
        public string CCCD { get; set; }

        [StringLength(50)]
        public string QueQuan { get; set; }

        public int? Luong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HopDongThuePhong> HopDongThuePhongs { get; set; }
    }
}
