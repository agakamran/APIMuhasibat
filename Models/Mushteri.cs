using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMuhasibat.Models
{
    [Table("Mushteris")]
   public class Mushteri 
    {
       string _mushId =null,_firma =null,_voen =null,
        _muqavilenom =null, _valyuta =null,_odemesherti =null, _temsilchi =null;
       Nullable<DateTime> _muqaviletar = DateTime.Now;
        public Mushteri() { }
        public Mushteri(string _MushId, string _Firma)
        {
            this.MushId = _MushId;
            this.Firma = _Firma;
        }
        [Key]
        [MaxLength(36)]
        public string MushId {
            get { return _mushId; }
            set { if (value != null) { _mushId = value; } }
        }
        [MaxLength(100)]
        public string Firma {
            get { return _firma; }
            set { if (value != null) { _firma = value; } }
        }
        [MaxLength(15)]
        public string Voen {
            get { return _voen; }
            set { if (value != null) { _voen = value; } }
        }
        [MaxLength(15)]
        public string Muqavilenom {
            get { return _muqavilenom; }
            set { if (value != null) { _muqavilenom = value; } }
        }
        public Nullable<DateTime> Muqaviletar {
            get { return _muqaviletar; }
            set { if (value != null) { _muqaviletar = value; } }
        }
        [MaxLength(10)]
        public string Valyuta {
            get { return _valyuta; }
            set { if (value != null) { _valyuta = value; } }
        }
        [MaxLength(50)]
        public string Odemesherti {
            get { return _odemesherti; }
            set { if (value != null) { _odemesherti = value; } }
        }
        [MaxLength(100)]
        public string Temsilchi {
            get { return _temsilchi; }
            set { if (value != null) { _temsilchi = value; } }
        }


        
    }
}
