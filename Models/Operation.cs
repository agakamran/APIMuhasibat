using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIMuhasibat.Models
{
    [Table("operations")]
    public class operation
    {
        string _opId = null, _pdetId = null, _qeyd = null;//,  _pmasId = null
        Nullable<int> _submiqdar = null;
        Nullable<decimal> _miqdar = null, _alishqiy = null, _satishqiy = null;
        decimal  _aksizderecesi = 0, _yolvergisi = 0;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public operation()  
        {
            this.Productdetals = new HashSet<Productdetal>();         
        }
        [Key]
        [MaxLength(36)]
        public string OpId //id
        {
            get { return _opId; }
            set { if (value != null) { _opId = value; } }
        }        
        [Column(TypeName = "decimal(18,2)")]
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
        [Column(TypeName = "decimal(18,2)")]
        public Nullable<decimal> Alishqiy
        {
            get { return _alishqiy; }
            set { if (value != null) { _alishqiy = value; } }
        }
        [Column(TypeName = "decimal(18,2)")]
        public Nullable<decimal> Satishqiy
        {
            get { return _satishqiy; }
            set { if (value != null) { _satishqiy = value; } }
        }   //   hemde mebleg
        
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Aksizderecesi
        {
            get { return _aksizderecesi; }
            set { if (value > 0) { _aksizderecesi = value; } }
        }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Yolvergisi
        {
            get { return _yolvergisi; }
            set { if (value > 0) { _yolvergisi = value; } }
        }
        [MaxLength(36)]
        public string PdetId
        {
            get { return _pdetId; }
            set { if (value != null) { _pdetId = value; } }
        }
        [MaxLength(150)]
        public string Qeyd  //izahlar birinci debitin sonra  10 simvol buraxib kredit yazaq  
        {
            get { return _qeyd; }
            set { if (value != null) { _qeyd = value; } }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Productdetal> Productdetals { get; set; }   

    }
}
