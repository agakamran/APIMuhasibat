using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMuhasibat.Models
{
    [Table("Aktivs")]
   public class Activler
    {
        string _activId = null, _activName = null, _description = null;
        public Activler()
        {
        }

        public Activler(string _ActivId, string _ActivName,// decimal _Activdeyeri,DateTime _Tarix,
            string _Description)
        {
           this.ActivId = _ActivId;
           this.ActivName = _ActivName;
           this.Description = _Description;
        }
        [Key]
        [MaxLength(36)]
        public string  ActivId
        {
            get { return _activId; }
            set { if (value != null) { _activId = value; } }
        }
        [MaxLength(50)]
        public string ActivName
        {
            get { return _activName; }
            set { if (value != null) { _activName = value; } }
        }       
        [MaxLength(50)]
        public string Description {
             get { return _description; }
            set { if (value != null) { _description = value; } }
        }
       // public virtual ICollection<Hesab> Hesabs { get; set; }
    }    
}
