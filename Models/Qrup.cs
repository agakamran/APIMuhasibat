using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMuhasibat.Models
{
    [Table("Qrups")]//ALIŞ satish
   public class Qrup
    {
        string _qId = null, _qrupname = null, _description = null;
        public Qrup() { }
        public Qrup(string _QId, string _Qrupname, string _Description)
        {
            this.QId = _QId;
            this.Qrupname = _Qrupname;
            this.Description = _Description;
        }

        [Key]
        [MaxLength(36)]
        public string QId
        {
            get { return _qId; }
            set { if (value != null) { _qId = value; } }
        }
        [MaxLength(50)]
        public string Qrupname
        {
            get { return _qrupname; }
            set { if (value != null) { _qrupname = value; } }
        }
        [MaxLength(50)]
        public string Description
        {
            get { return _description; }
            set { if (value != null) { _description = value; } }
        }


    }
}
