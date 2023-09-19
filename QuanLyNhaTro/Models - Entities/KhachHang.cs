namespace QuanLyNhaTro
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            HopDongThuePhongs = new HashSet<HopDongThuePhong>();
        }

        [Key]
        [StringLength(6)]
        public string MaKH { get; set; }

        [Required]
        [StringLength(6)]
        public string MaLoaiKH { get; set; }

        [Required]
        [StringLength(50)]
        public string HovaTenKH { get; set; }

        [StringLength(3)]
        public string GioiTinh { get; set; }

        [StringLength(4)]
        public string NamSinh { get; set; }

        [Required]
        [StringLength(12)]
        public string CCCD { get; set; }

        [StringLength(50)]
        public string QueQuan { get; set; }

        [Required]
        [StringLength(11)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string NgheNghiep { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HopDongThuePhong> HopDongThuePhongs { get; set; }

        public virtual LoaiKhachHang LoaiKhachHang { get; set; }
    }
}
