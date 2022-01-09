using APIMuhasibat.Data;
using APIMuhasibat.Models.ViewModels;
using APIMuhasibat.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace APIMuhasibat.Models
{
    public class MyClass
    {
    }
    /* [Table("pages")]//счета-фактуры
     public class Page
     {
         [Key]
         [Required(AllowEmptyStrings = true), MaxLength(36)]
         public string Pid { get; set; }
         public string pagename { get; set; }


     }*/

    [Table("Carts")]
    public class Cart
    {
        [Key]
        [Required(AllowEmptyStrings = true), MaxLength(36)]
        public string cid { get; set; }
        [MaxLength(50)]
        public string csubject { get; set; }
        [MaxLength(50)]
        public string charda { get; set; }
        [MaxLength(2)]
        public string clan { get; set; }
        public int csira { get; set; }
        [MaxLength(150)]
        public string cheader { get; set; }
        public string ctex { get; set; }
        public float cpris { get; set; }
        [MaxLength(50)]
        public string cbuton { get; set; }
        [MaxLength(36)]
        public string nid { get; set; }
        public virtual Navbar navbars { get; set; }
        [MaxLength(36)]
        public string vid { get; set; }
        public virtual vido vidos { get; set; }
        public DateTime ctarix { get; set; }
    }
    [Table("vidos")]
    public class vido
    {
        [Key]
        [Required(AllowEmptyStrings = true), MaxLength(36)]
        public string vid { get; set; }
        public Byte[] vidio { get; set; }
        [MaxLength(150)]
        public string url { get; set; }
    }
    [Table("conts")]
    public class Cont
    {
        [Key]
        [Required(AllowEmptyStrings = true), MaxLength(36)]
        public string cid { get; set; }
        [MaxLength(36)]
        public string userId { get; set; }
        [StringLength(150)]
        public string yourname { get; set; }
        [StringLength(250)]
        public string subject { get; set; }
        public string message { get; set; }
        // [StringLength(10)]
        public DateTime tarix { get; set; }
        public bool isdelete { get; set; }
    }
   

   
}
