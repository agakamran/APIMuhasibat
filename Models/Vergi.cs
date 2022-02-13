using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMuhasibat.Models
{
    [Table("Vergis")]
    public class Vergi
    {
        string _vergiId = null, _vergikodu = null, _vergikodununadi = null, _vId = null;
        Nullable<DateTime> _edv_tar = null; int _STATE = 0;
        public Vergi() { }
        public Vergi(string vergiId, string vergikodununadi)
        {
            this.VergiId = vergiId;
            this.Vergikodununadi = vergikodununadi;
        }
        [Key]
        [MaxLength(36)]
        public string VergiId
        {
            get { return _vergiId; }
            set { if (value != null) { _vergiId = value; } }
        }
        [MaxLength(20)]
        public string Vergikodu
        {
            get { return _vergikodu; }
            set { if (value != null) { _vergikodu = value; } }
        }
        [MaxLength(36)]
        public string VId
        {
            get { return _vId; }
            set { if (value != null) { _vId = value; } }
        }
        // [MaxLength(550)]
        public string Vergikodununadi
        {
            get { return _vergikodununadi; }
            set { if (value != null) { _vergikodununadi = value; } }
        }
        public int State
        {
            get { return _STATE; }
            set { if (value > 0) { _STATE = value; } }
        }
        public Nullable<DateTime> Edv_tar
        {
            get { return _edv_tar; }
            set { if (value != null) { _edv_tar = value; } }
        }
    }

    public class verg
    {
        public string CODE { get; set; }
        public string ADI { get; set; }
        public string VAHID { get; set; }
        public string STATE { get; set; }
    }
}
