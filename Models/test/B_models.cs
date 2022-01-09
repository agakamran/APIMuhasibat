using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIMuhasibat.Models
{
    [Table("B_genders")]
    public class B_gender
    {
        [Key]
        [Required(AllowEmptyStrings = true), MaxLength(36)]
        public string gender_Id { get; set; }
        [Required, MaxLength(20)]
        public string gender_name { get; set; }
    }
    //[Table("B_firmas")]
    //public class B_firma
    //{
    //    [Key]
    //    [Required(AllowEmptyStrings = true), MaxLength(36)]
    //    public string firma_Id { get; set; }
    //    [Required, MaxLength(50)]
    //    public string firma_name { get; set; }
    //    [MaxLength(150)]
    //    public string firma_unvan { get; set; }
    //    [MaxLength(20)]
    //    public string firma_telefon { get; set; }
    //    [Required, MaxLength(50)]
    //    public string firma_email { get; set; }
    //    [Required, MaxLength(36)]
    //    public string userId { get; set; }
    //    public int voen { get; set; }
    //}
}
