using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMuhasibat.Models
{    
     [Table("Vahids")]
   public class Vahid
    {
        string _vId = null, _vahidadi = null;
        public Vahid() {    }
        public Vahid(string _VId, string _Vahidadi)
        {
            this.VId = _VId;
            this.Vahidadi = _Vahidadi;
        }
        [Key]
        [MaxLength(36)]
        public string VId {
            get { return _vId; }
            set { if (value != null) { _vId = value; } }
        }
        [MaxLength(20)]
        public string Vahidadi {
            get { return _vahidadi; }
            set { if (value != null) { _vahidadi = value; } }
        }        
       // public virtual ICollection<Vergi> Vergis { get; set; }

    }
}
