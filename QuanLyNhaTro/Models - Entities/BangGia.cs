namespace QuanLyNhaTro
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BangGia")]
    public partial class BangGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BangGia()
        {
            LoaiPhongs = new HashSet<LoaiPhong>();
        }

        [Key]
        [StringLength(6)]
        public string MaBG { get; set; }

        public int Gia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoaiPhong> LoaiPhongs { get; set; }
    }
}
