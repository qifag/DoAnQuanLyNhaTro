namespace QuanLyNhaTro
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HopDongThuePhong")]
    public partial class HopDongThuePhong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HopDongThuePhong()
        {
            SoThuTiens = new HashSet<SoThuTien>();
        }

        [Key]
        [StringLength(6)]
        public string SoHDThue { get; set; }

        [Required]
        [StringLength(6)]
        public string MaKH { get; set; }

        [Required]
        [StringLength(6)]
        public string MaNV { get; set; }

        public virtual ChiTietHopDongThuePhong ChiTietHopDongThuePhong { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SoThuTien> SoThuTiens { get; set; }
    }
}
