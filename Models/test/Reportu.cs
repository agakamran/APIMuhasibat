using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIMuhasibat.Models
{
    [Table("RepoMass")]
    public class RepoMas
    {
        [Key]
        [Required(AllowEmptyStrings = true), MaxLength(36)]
        public string MasId { get; set; }
        [MaxLength(36)]
        public string UserId { get; set; }
       // public virtual User AspNetUsers { get; set; }
        [MaxLength(36)]
        public string BId { get; set; }
        [MaxLength(6)]
        public string dil { get; set; }
        public DateTime Tarix { get; set; }
        public int Trint { get; set; }
    }
    [Table("RepoDets")]
    public class RepoDet
    {
        [Key]
        [Required(AllowEmptyStrings = true), MaxLength(36)]
        public string DetId { get; set; }
        [MaxLength(36)]
        public string MasId { get; set; }
        public virtual RepoMas RepoMas { get; set; }
        [MaxLength(36)]
        public string SuId1 { get; set; }
        public int SuId11 { get; set; }
        [MaxLength(36)]
        public string SuId2 { get; set; }
        public int SuId22 { get; set; }
        [MaxLength(36)]
        public string SuId3 { get; set; }
        public int SuId33 { get; set; }
        [MaxLength(36)]
        public string SuId4 { get; set; }
        public int SuId44 { get; set; }
        [MaxLength(36)]
        public string SuId5 { get; set; }
        public int SuId55 { get; set; }
        [MaxLength(36)]
        public string SuId6 { get; set; }
        public int SuId66 { get; set; }
        [MaxLength(36)]
        public string SuId7 { get; set; }
        public int SuId77 { get; set; }
        [MaxLength(36)]
        public string SuId8 { get; set; }
        public int SuId88 { get; set; }
        [MaxLength(36)]
        public string SuId9 { get; set; }
        public int SuId99 { get; set; }
        [MaxLength(36)]
        public string SuId10 { get; set; }
        public int SuId100 { get; set; }
        [MaxLength(20)]
        public string veziyet { get; set; }
    }
}
