using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMuhasibat.Models
{
    [Table("Hesabs")]
    public class Hesab
    {
        string _hesId = null, _hesnom = null, _hesname = null,
            _bId = null, _mId = null, _tipId = null, _activId = null;
        //Madde _madde = null;
        //Tipler _tipler = null;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hesab()
        {
            this.Activlers = new HashSet<Activler>();
            this.Bolmes = new HashSet<Bolme>();
            this.Maddes = new HashSet<Madde>();
            this.Tiplers = new HashSet<Tipler>();
        }
        public Hesab(string _HesId, string _Hesnom)
        {
            HesId = _HesId;
            Hesnom = _Hesnom;
        }
        [Key]
        [MaxLength(36)]
        public string HesId
        {
            get { return _hesId; }
            set
            {
                if (value != null) { _hesId = value; }
            }
        }
        [MaxLength(10)]
        public string Hesnom
        {
            get { return _hesnom; }
            set
            {
                if (value != null) { _hesnom = value; }
            }
        }
        [MaxLength(100)]
        public string Hesname
        {
            get { return _hesname; }
            set
            {
                if (value != null) { _hesname = value; }
            }
        }
        [MaxLength(36)]
        public string BId
        {
            get { return _bId; }
            set
            {
                if (value != null) { _bId = value; }
            }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bolme> Bolmes { get; set; }
        [MaxLength(36)]
        public string MId
        {
            get { return _mId; }
            set
            {
                if (value != null) { _mId = value; }
            }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Madde> Maddes { get; set; }
        [MaxLength(36)]
        public string ActivId
        {
            get { return _activId; }
            set { if (value != null) { _activId = value; } }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activler> Activlers { get; set; }
        [MaxLength(36)]
        public string TipId
        {
            get { return _tipId; }
            set
            {
                if (value != null) { _tipId = value; }
            }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tipler> Tiplers { get; set; }
    }
    public class hesb
    {
        public string hesId { get; set; }
        public string hesnom { get; set; }
        public string hesname { get; set; }
        public int bId { get; set; }
        public string mId { get; set; }
        public string tipId { get; set; }
        public string activId { get; set; }

    }
}
