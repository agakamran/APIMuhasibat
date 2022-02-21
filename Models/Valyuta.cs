using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIMuhasibat.Models
{
    [Table("Valyutas")]
   public class Valyuta
    {
        string _valId = null, _valname = null;
        decimal _valnominal = 0;
        Nullable<DateTime> _tarix = DateTime.Now;
        public Valyuta()
        {
        }
        [Key]
        [MaxLength(36)]
        public string ValId {
            get { return _valId; }
            set { if (value != null) { _valId = value; } }
        }       
        [MaxLength(10)]
        public string Valname {
            get { return _valname; }
            set { if (value != null) { _valname = value; } }
        }
        public decimal Valnominal
        {
            get { return _valnominal; }
            set { if (value >0) { _valnominal = value; } }
        }
        public Nullable<DateTime> Tarix {
            get { return _tarix; }
            set { if (value != null) { _tarix = value; } }
        }
    }
}
