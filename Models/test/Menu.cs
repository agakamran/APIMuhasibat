using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIMuhasibat.Models
{
    [Table("Menums")]
    public class Menum
    {
        [Key]
        [Required(AllowEmptyStrings = true), MaxLength(36)]
        public string ID { get; set; }
        [StringLength(36)]
        public string Code { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Text { get; set; }
        public int MenuType { get; set; }
        [StringLength(36)]
        public string ParentID { get; set; }
        [StringLength(36)]
        public string Tag { get; set; }
        public int OrderBy { get; set; }
        public bool Enabled { get; set; }
    }
    [Table("Komps")]
    public class Komp
    {
        [Key]
        [Required(AllowEmptyStrings = true), MaxLength(36)]
        public string ID { get; set; }
        [MaxLength(50)]
        public string MacAdd { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        [MaxLength(50)]
        public string MachineName { get; set; }
        public bool Hal { get; set; }
        [MaxLength(50)]
        public string Cod { get; set; }
        public DateTime tar { get; set; }

    }
    [Table("Balans")]
    public class Balans
    {
        [Key]
        [Required(AllowEmptyStrings = true), MaxLength(36)]
        public string bID { get; set; }
        [StringLength(36)]
        public string EdenId { get; set; }
        [StringLength(36)]
        public string kiminId { get; set; }
        public DateTime Nevaxt { get; set; }
        [StringLength(36)]
        public string Tid { get; set; }
        public virtual Tarifim Tarifim { get; set; }
        public int Say { get; set; }
    }

    [Table("Tarifims")]
    public class Tarifim
    {
        [Key]
        [Required(AllowEmptyStrings = true), MaxLength(36)]
        public string Tid { get; set; }
        public decimal TarMeb { get; set; }
        public string Tarad { get; set; }
        public DateTime TarifTar { get; set; }
    }
}
