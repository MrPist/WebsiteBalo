using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebsiteBalo.Models
{
    [Table("DANHMUC")]
    public partial class Danhmuc
    {
        public Danhmuc()
        {
            Mathangs = new HashSet<Mathang>();
        }

        [Key]
        [Column("MaDM")]
        public int MaDm { get; set; }
        [StringLength(100)]
        public string Ten { get; set; } = null!;

        [InverseProperty("MaDmNavigation")]
        public virtual ICollection<Mathang> Mathangs { get; set; }
    }
}
