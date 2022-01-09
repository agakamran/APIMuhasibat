using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMuhasibat.Models
{ 
    [Table("Maddes")]
    public class Madde
    {
        string _mId=null, _maddeName = null;

        public Madde()
        {
        }

        [Key]
        [MaxLength(36)]
        public string MId {
            get { return _mId; }
            set{if (value != null) { _mId = value; } }
        }
        [MaxLength(5)]
        public string MaddeName {
            get { return _maddeName; }
            set { if (value != null) { _maddeName = value; } }
        }        
    }
}
