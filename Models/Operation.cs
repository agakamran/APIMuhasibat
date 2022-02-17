using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIMuhasibat.Models
{
    [Table("operations")]
    public class operation
    {
        string _opId = null, _pmasId = null, _qrupId = null, _activId = null, _dhesId = null, _khesId = null, _edv = null,
              _mushId = null, _qeyd = null, _valId = null;
        Nullable<int> _submiqdar = null;
        Nullable<decimal> _miqdar = null, _alishqiy = null, _satishqiy = null;
        decimal _kurs = 1, _aksizderecesi = 0, _yolvergisi = 0;

        public operation()        {
           
        }
        [Key]
        [MaxLength(36)]
        public string OpId //id
        {
            get { return _opId; }
            set { if (value != null) { _opId = value; } }
        }
        [MaxLength(36)]
        public string PmasId
        {
            get { return _pmasId; }
            set { if (value != null) { _pmasId = value; } }
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
        public Nullable<decimal> Alishqiy
        {
            get { return _alishqiy; }
            set { if (value != null) { _alishqiy = value; } }
        }
        public Nullable<decimal> Satishqiy
        {
            get { return _satishqiy; }
            set { if (value != null) { _satishqiy = value; } }
        }   //   hemde mebleg
        [MaxLength(36)]
        public string QrupId  //Qrupid
        {
            get { return _qrupId; }
            set { if (value != null) { _qrupId = value; } }
        } //qruplar alish satish
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
        public decimal Kurs
        {
            get { return _kurs; }
            set { if (value > 1) { _kurs = value; } }
        }

        public decimal Aksizderecesi
        {
            get { return _aksizderecesi; }
            set { if (value > 0) { _aksizderecesi = value; } }
        }
        public decimal Yolvergisi
        {
            get { return _yolvergisi; }
            set { if (value > 0) { _yolvergisi = value; } }
        }
        [MaxLength(36)]
        public string MushId  //temsilchi
        {
            get { return _mushId; }
            set { if (value != null) { _mushId = value; } }
        }

        [MaxLength(250)]
        public string Qeyd  //izahlar birinci debitin sonra  10 simvol buraxib kredit yazaq  
        {
            get { return _qeyd; }
            set { if (value != null) { _qeyd = value; } }
        }       

    }
}
