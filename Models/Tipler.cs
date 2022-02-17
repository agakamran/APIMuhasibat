using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMuhasibat.Models
{   
    [Table("Tiplers")]// ƏKS AKTİV
   public class Tipler
    {
        string _tipId = null;
        string _tipName = null;

        public Tipler()
        {
        }

        [Key]
        [MaxLength(36)]
        public string TipId {
            get { return _tipId; }
            set { if (value != null) { _tipId = value; } }
        }
        [MaxLength(50)]
        public string TipName
        {
            get { return _tipName; }
            set { if (value != null) { _tipName = value; } }
        }
       // public virtual ICollection<Hesab> Hesabs { get; set; }
    }
}
