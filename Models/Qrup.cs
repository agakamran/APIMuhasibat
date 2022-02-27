using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIMuhasibat.Models
{
    [Table("Qrups")]//ALIŞ satish
   public class Qrup
    {
        string _qId = null, _qrupname = null, _dhesId = null, _khesId = null;
        public Qrup() { }
        public Qrup(string _QId, string _Qrupname)
        {
            this.QId = _QId;
            this.Qrupname = _Qrupname;
        }
        [Key]
        [MaxLength(36)]
        public string QId
        {
            get { return _qId; }
            set { if (value != null) { _qId = value; } }
        }
        [MaxLength(100)]
        public string Qrupname
        {
            get { return _qrupname; }
            set { if (value != null) { _qrupname = value; } }
        }
        [MaxLength(36)]
        public string DhesId //alacaq +
        {
            get { return _dhesId; }
            set { if (value != null) { _dhesId = value; } }
        }
        [MaxLength(36)]
        public string KhesId //verecek -
        {
            get { return _khesId; }
            set { if (value != null) { _khesId = value; } }
        }


    }
}
