using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIMuhasibat.Models
{
    [Table("loggers")]
    public class logger
    {
        int _lId = 0;
        string _entityname, _opername, _description, _createduser;
        Nullable<DateTime> _createdate = null;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int lId
        {
            get { return _lId; }
            set { if (value != 0) { _lId = value; } }
        }
        [Required, MaxLength(150)]//sehife adi
        public string entityname
        {
            get { return _entityname; }
            set { if (value != null) { _entityname = value; } }
        }
        [Required, MaxLength(100)]
        public string opername
        {
            get { return _opername; }
            set { if (value != null) { _opername = value; } }
        }
        [Required]
        public string description
        {
            get { return _description; }
            set { if (value != null) { _description = value; } }
        }
        [Required]
        public string createduser
        {
            get { return _createduser; }
            set { if (value != null) { _createduser = value; } }
        }
        public Nullable<DateTime> createdate
        {
            get { return _createdate; }
            set { if (value != null) { _createdate = value; } }
        }

    }
}
