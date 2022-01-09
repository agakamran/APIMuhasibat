using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMuhasibat.Models
{    
    [Table("Emeliyyatdets")]
   public class Emeliyyatdet
    {
        string _emdetId = null, _qId = null, _aId = null, _userId = null,
         _mushId = null, _vergiId = null, _vId = null, _qeyd = null, _valId = null;
        Nullable<int> _dhesId = null, _khesId = null, _submiqdar = null,
        _edvye_celbedilen = null, _edvye_celbedilmeyen = null;
        Nullable<decimal> _miqdar =null, _vahidqiymeti_alish = null,
            _vahidqiymeti_satish = null, _edv = null;
        decimal _kurs = 0;
        Nullable<DateTime> _emeltarixi = DateTime.Now;
        ICollection<Qrup> _qrups = null;
        ICollection<Activler> _activs = null;
        ICollection<Vergi> _vergis = null;
        ICollection<Vahid> _vahids = null;
        ICollection<Valyuta> _valyuts = null;
        ICollection<Mushteri> _mushteris = null;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Emeliyyatdet()
        {
            this.mushteris = new HashSet<Mushteri>();
            this.qrups = new HashSet<Qrup>();
            this.activs = new HashSet<Activler>();
            this.vergis = new HashSet<Vergi>();
            this.vahids = new HashSet<Vahid>();
            this.valyuts = new HashSet<Valyuta>();
        }
        [Key]
        [MaxLength(36)]
        public string EmdetId //id
        {
            get { return _emdetId; }
            set { if (value != null) { _emdetId = value; } }
        }
        [MaxLength(36)]
        public string UserId //user
        {
            get { return _userId; }
            set { if (value != null) { _userId = value; } }
        }
        [MaxLength(36)]
        public string QId  //Qrupid
        {
            get { return _qId; }
            set { if (value != null) { _qId = value; } }
        } //qruplar alish satish
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Qrup> qrups
        {
            get { return _qrups; }
            set { if (value != null) { _qrups = value; } }
        }
        [MaxLength(36)]
        public string AId  //activler
        {
            get { return _aId; }
            set { if (value != null) { _aId = value; } }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activler> activs
        {
            get { return _activs; }
            set { if (value != null) { _activs = value; } }
        }
        public Nullable<int> DhesId //alacaq +
        {
            get { return _dhesId; }
            set { if (value != null) { _dhesId = value; } }
        }
        public Nullable<int> KhesId //verecek -
        {
            get { return _khesId; }
            set { if (value != null) { _khesId = value; } }
        }
        [MaxLength(36)]
        public string MushId  //temsilchi
        {
            get { return _mushId; }
            set { if (value != null) { _mushId = value; } }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mushteri> mushteris
        {
            get { return _mushteris; }
            set { if (value != null) { _mushteris = value; } }
        }
        [MaxLength(36)]
        public string VergiId //vergi
        {
            get { return _vergiId; }
            set { if (value != null) { _vergiId = value; } }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vergi> vergis
        {
            get { return _vergis; }
            set { if (value != null) { _vergis = value; } }
        }
        [MaxLength(36)]
        public string VId //vahid
        {
            get { return _vId; }
            set { if (value != null) { _vId = value; } }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vahid> vahids
        {
            get { return _vahids; }
            set { if (value != null) { _vahids = value; } }
        }
        public Nullable<decimal> Miqdar
        {
            get { return _miqdar; }
            set { if (value != null) { _miqdar = value; } }
        }
        public Nullable<int> Submiqdar
        {
            get { return _submiqdar; }
            set { if (value != null) { _submiqdar = value; } }
        }    
        public Nullable<decimal> Vahidqiymeti_alish
        {
            get { return _vahidqiymeti_alish; }
            set { if (value !=null) { _vahidqiymeti_alish = value; } }
        }
        public Nullable<decimal> Vahidqiymeti_satish
        {
            get { return _vahidqiymeti_satish; }
            set { if (value !=null) { _vahidqiymeti_satish = value; } }
        }   //   hemde mebleg
        public Nullable<decimal> Edv
        {
            get { return _edv; }
            set { if (value !=null) { _edv = value; } }
        }
        public Nullable<int> Edvye_celbedilen {
             get { return _edvye_celbedilen; }
            set { if (value != null) { _edvye_celbedilen = value; } }
        }
        public Nullable<int> Edvye_celbedilmeyen
        {
            get { return _edvye_celbedilmeyen; }
            set { if (value != null) { _edvye_celbedilmeyen = value; } }
        }
        public Nullable<DateTime> Emeltarixi
        {
            get { return _emeltarixi; }
            set { if (value != null) { _emeltarixi = value; } }
        }
        [MaxLength(36)]
        public string ValId
        {
            get { return _valId; }
            set { if (value != null) { _valId = value; } }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Valyuta> valyuts
        {
            get { return _valyuts; }
            set { if (value != null) { _valyuts = value; } }
        }
        public decimal Kurs
        {
            get { return _kurs; }
            set { if (value > 0) { _kurs = value; } }
        }
        [MaxLength(250)]
        public string Qeyd  //izahlar birinci debitin sonra  10 simvol buraxib kredit yazaq  
        {
            get { return _qeyd; }
            set { if (value != null) { _qeyd = value; } }
        }        
    }
}
