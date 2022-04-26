namespace FreshFoodHTH.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MaGiamGia")]
    public partial class MaGiamGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MaGiamGia()
        {
            MaGiamGiaKhachHangs = new HashSet<MaGiamGiaKhachHang>();
        }

        [Key]
        public Guid IDMaGiamGia { get; set; }

        [Column("MaGiamGia")]
        [Required]
        [StringLength(10)]
        public string MaGiamGia1 { get; set; }

        public decimal TienGiam { get; set; }

        public Guid? IDLoaiKhachHang { get; set; }

        public string DieuKienApDung { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanSuDung { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(200)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(200)]
        public string ModifiedBy { get; set; }

        public virtual PhanLoaiKhachHang PhanLoaiKhachHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaGiamGiaKhachHang> MaGiamGiaKhachHangs { get; set; }
    }
}
