using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebsiteBalo.Models
{
    [Table("HOADON")]
    public partial class Hoadon
    {
        public Hoadon()
        {
            Cthoadons = new HashSet<Cthoadon>();
        }

        [Key]
        [Column("MaHD")]
        public int MaHd { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Ngay { get; set; }
        public int? TongTien { get; set; }
        [Column("MaND")]
        public int MaNd { get; set; }
        public int? TrangThai { get; set; }

        [ForeignKey("MaNd")]
        [InverseProperty("Hoadons")]
        public virtual Nguoidung MaNdNavigation { get; set; } = null!;
        [InverseProperty("MaHdNavigation")]
        public virtual ICollection<Cthoadon> Cthoadons { get; set; }
    }
}
