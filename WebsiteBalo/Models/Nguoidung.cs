using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebsiteBalo.Models
{
    [Table("NGUOIDUNG")]
    public partial class Nguoidung
    {
        public Nguoidung()
        {
            Hoadons = new HashSet<Hoadon>();
        }

        [Key]
        [Column("MaND")]
        public int MaNd { get; set; }
        [StringLength(100)]
        public string Ten { get; set; } = null!;
        [StringLength(20)]
        [Unicode(false)]
        public string? DienThoai { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Email { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? MatKhau { get; set; }

        public int Quyen { get; set; } 

        [InverseProperty("MaNdNavigation")]
        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
