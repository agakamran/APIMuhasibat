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
        string _activId = null;
        string _activName = null;
       // Nullable<decimal> _activdeyeri = 0;
       // Nullable<DateTime> _tarix = DateTime.Now;
        string _description = null;

        public Activler()
        {
        }

        public Activler(string _ActivId, string _ActivName,// decimal _Activdeyeri,DateTime _Tarix,
            string _Description)
        {
           this.ActivId = _ActivId;
           this.ActivName = _ActivName;
            //  this.Activdeyeri = _Activdeyeri;
           // this.Tarix= _Tarix;
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
        //public Nullable<decimal> Activdeyeri
        //{
        //    get { return _activdeyeri; }
        //    set { if (_activdeyeri != null) { _activdeyeri = value; } }
        //}
        //public Nullable<DateTime> Tarix
        //{
        //    get { return _tarix; }
        //    set { if (_tarix != null) { _tarix = value; } }
        //}
        [MaxLength(50)]
        public string Description {
             get { return _description; }
            set { if (value != null) { _description = value; } }
        }
    }    
}
