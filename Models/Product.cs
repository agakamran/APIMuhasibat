using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIMuhasibat.Models
{
    [Table("Productmasters")]
    public class Productmaster
    {
        string _pmasId = null, _userId = null, _kimden_voen = null, _serial = null, _mushId = null, _vo =null,
            _activId = null, _dhesId = null, _khesId = null, _valId = null,_qrupId = null, _shId = null;
        decimal _kurs = 1, _kimden_sum =0;bool _pay = false;
        Nullable<DateTime> _emeltarixi = DateTime.Now;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Productmaster()
        {
            this.Shirkets = new HashSet<Shirket>();
            this.Mushteris = new HashSet<Mushteri>();
            this.Activlers = new HashSet<Activler>();
            this.DHesabs = new HashSet<Hesab>();
            this.KHesabs = new HashSet<Hesab>();
            this.Activlers = new HashSet<Activler>();
            this.Valyutas = new HashSet<Valyuta>();
            this.Qrups = new HashSet<Qrup>();
        }
        [Key]
        [MaxLength(36)]
        public string PmasId
        {
            get { return _pmasId; }
            set { if (value != null) { _pmasId = value; } }
        }
        [MaxLength(36)]
        public string Serial
        {
            get { return _serial; }
            set { if (value != null) { _serial = value; } }
        }
        [MaxLength(36)]
        public string UserId //user
        {
            get { return _userId; }
            set { if (value != null) { _userId = value; } }
        }
        [MaxLength(36)]
        public string MushId  //temsilchi
        {
            get { return _mushId; }
            set { if (value != null) { _mushId = value; } }
        }
        
        [MaxLength(10)]
        public string Kimden_voen
        {
            get { return _kimden_voen; }
            set { if (value != null) { _kimden_voen = value; } }
        }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Kimden_sum
        {
            get { return _kimden_sum; }
            set { if (value > 0) { _kimden_sum = value; } }
        }        
        public Nullable<DateTime> Emeltarixi
        {
            get { return _emeltarixi; }
            set { if (value != null) { _emeltarixi = value; } }
        }
        public bool Pay
        {
            get { return _pay; }
            set { if (value != false) { _pay = value; } }
        }
        [MaxLength(15)]
        public string Vo
        {
            get { return _vo; }
            set { if (value != null) { _vo = value; } }
        }
        [MaxLength(36)]
        public string ActivId  //activler
        {
            get { return _activId; }
            set { if (value != null) { _activId = value; } }
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

        [MaxLength(36)]
        public string ValId
        {
            get { return _valId; }
            set { if (value != null) { _valId = value; } }
        }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Kurs
        {
            get { return _kurs; }
            set { if (value > 1) { _kurs = value; } }
        }
        [MaxLength(36)]
        public string QrupId  //Qrupid
        {
            get { return _qrupId; }
            set { if (value != null) { _qrupId = value; } }
        } //qruplar alish satish
        [MaxLength(36)]
        public string ShId
        {
            get { return _shId; }
            set { if (value != null) { _shId = value; } }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shirket> Shirkets { get; set; }
        public virtual ICollection<Activler> Activlers { get; set; }
        public virtual ICollection<Valyuta> Valyutas { get; set; }
        public virtual ICollection<Mushteri> Mushteris { get; set; }
        public virtual ICollection<Hesab> DHesabs { get; set; }
        public virtual ICollection<Hesab> KHesabs { get; set; }
        public virtual ICollection<Qrup> Qrups { get; set; }
    }

    [Table("Productdetals")]
    public class Productdetal
    {
        string _pdetId = null,  _maladi=null, _barkod=null, _vergiId=null, _vId = null,_qeyd=null, _edv=null, _pmasId=null;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Productdetal()
        {
            this.Vahids = new HashSet<Vahid>();
            this.vergis = new HashSet<Vergi>();
            this.Productmasters = new HashSet<Productmaster>(); 
        }
        [Key]
        [MaxLength(36)]
        public string PdetId
        {
            get { return _pdetId; }
            set { if (value != null) { _pdetId = value; } }
        }
        [MaxLength(36)]
        public string PmasId
        {
            get { return _pmasId; }
            set { if (value != null) { _pmasId = value; } }
        }
        [MaxLength(150)]
        public string Maladi
        {
            get { return _maladi; }
            set { if (value != null) { _maladi = value; } }
        }
        [MaxLength(50)]
        public string Barkod
        {
            get { return _barkod; }
            set { if (value != null) { _barkod = value; } }
        }
        [MaxLength(36)]
        public string VergiId //vergi
        {
            get { return _vergiId; }
            set { if (value != null) { _vergiId = value; } }
        }        
        [MaxLength(36)]
        public string VId //vahid
        {
            get { return _vId; }
            set { if (value != null) { _vId = value; } }
        }       
        [MaxLength(10)]
        public string Edv
        {
            get { return _edv; }
            set { if (value != null) { _edv = value; } }
        }
        [MaxLength(150)]
        public string Qeyd    
        {
            get { return _qeyd; }
            set { if (value != null) { _qeyd = value; } }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vergi> vergis { get; set; }
        public virtual ICollection<Productmaster> Productmasters { get; set; }
        public virtual ICollection<Vahid> Vahids { get; set; }
    }
    public class axtar
    {
        public string userId { get; set; }
        public DateTime t1 { get; set; }
        public DateTime t2 { get; set; }        
    }
}
