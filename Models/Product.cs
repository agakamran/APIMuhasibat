using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIMuhasibat.Models
{
    [Table("Productmasters")]
    public class Productmaster
    {
        string _pmasId = null, _opdetId = null, _userId=null, _kimden_voen=null;
        decimal _kimden_sum=0;bool _pay = false;
        Nullable<DateTime> _emeltarixi = DateTime.Now;
        [Key]
        [MaxLength(36)]
        public string PmasId
        {
            get { return _pmasId; }
            set { if (value != null) { _pmasId = value; } }
        }
        [MaxLength(36)]
        public string OpdetId
        {
            get { return _opdetId; }
            set { if (value != null) { _opdetId = value; } }
        }
        [MaxLength(36)]
        public string UserId //user
        {
            get { return _userId; }
            set { if (value != null) { _userId = value; } }
        }
        [MaxLength(10)]
        public string Kimden_voen
        {
            get { return _kimden_voen; }
            set { if (value != null) { _kimden_voen = value; } }
        }
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
        public List<Productdetal> productdetals { get; set; } = new List<Productdetal>();
    }

    [Table("Productdetals")]
    public class Productdetal
    {
        string _pdetId = null,  _maladi=null, _barkod=null, _vergiId=null, _vId = null,_qeyd=null, _edv=null;
        [Key]
        [MaxLength(36)]
        public string PdetId
        {
            get { return _pdetId; }
            set { if (value != null) { _pdetId = value; } }
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
        public virtual ICollection<Vergi> vergis  { get; set; }
       
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
        [MaxLength(250)]
        public string Qeyd    
        {
            get { return _qeyd; }
            set { if (value != null) { _qeyd = value; } }
        }
    }
}
