using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIMuhasibat.Models
{
    [Table("Bolmes")]
    public class Bolme
    {
        string _bId = null, _bolmeName = null;

        public Bolme()
        {
        }

        [Key]
        [MaxLength(36)]
        public string bId
        {
            get { return _bId; }
            set { if (value != null) { _bId = value; } }
        }
        [MaxLength(5)]
        public string bolmeName
        {
            get { return _bolmeName; }
            set { if (value != null) { _bolmeName = value; } }
        }
    }
}
