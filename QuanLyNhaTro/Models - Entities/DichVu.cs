namespace QuanLyNhaTro
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DichVu")]
    public partial class DichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DichVu()
        {
            ChiTietSuDungDVs = new HashSet<ChiTietSuDungDV>();
        }

        [Key]
        [StringLength(6)]
        public string MaDV { get; set; }

        [Required]
        [StringLength(6)]
        public string MaLoaiDV { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDV { get; set; }

        public int GiaDV { get; set; }

        [StringLength(50)]
        public string ChiTietDV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSuDungDV> ChiTietSuDungDVs { get; set; }

        public virtual LoaiDichVu LoaiDichVu { get; set; }
    }
}
