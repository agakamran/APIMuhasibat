using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIMuhasibat.Models
{
    class _Accounting
    {
    }
    [Table("qrups")]//ALIŞ satish
    public class _qrup
    {
        public _qrup() { }
        public _qrup(string _qId, string _qrupname)
        {
            this.qId = _qId;
            this.qrupname = _qrupname;
        }

        [Key]
        [MaxLength(36)]
        public string qId { get; set; }
        [MaxLength(50)]
        public string qrupname { get; set; }
        [MaxLength(50)]
        public string qeyd { get; set; }
    }
    [Table("tips")]// ƏKS AKTİV
    public class _tip
    {
        [Key]
        [MaxLength(36)]
        public string tipId { get; set; }
        [MaxLength(50)]
        public string tipname { get; set; }
    }
    [Table("maddes")]
    public class _madde
    {
        [Key]
        [MaxLength(36)]
        public string mId { get; set; }
        [MaxLength(5)]
        public string mname { get; set; }
    }
    [Table("aktivs")]
    public class _aktiv
    {
        public _aktiv() { }
        public _aktiv(string _aId, string _aktivname)
        {
            aId = _aId;
            aktivname = _aktivname;
        }
        [Key]
        [MaxLength(36)]
        public string aId { get; set; }
        [MaxLength(50)]
        public string aktivname { get; set; }

    }
    [Table("hesabs")]
    public class hesab
    {
        public hesab() { }
        public hesab(string _hesId, string _hesnom)
        {
            hesId = _hesId;
            hesnom = _hesnom;
        }
        [Key]
        [MaxLength(36)]
        public string hesId { get; set; }
        [MaxLength(10)]
        public string hesnom { get; set; }
        [MaxLength(100)]
        public string hesname { get; set; }
        [MaxLength(36)]
        public string bId { get; set; }
        [MaxLength(36)]
        public string mId { get; set; }
        [MaxLength(36)]
        public string tipId { get; set; }
    }

    [Table("shirkets")]
    public class shirket
    {
        [Key]
        [MaxLength(36)]
        public string shId { get; set; }
        [MaxLength(50)]
        public string bankadi { get; set; }
        [MaxLength(15)]
        public string bankvoen { get; set; }
        [MaxLength(50)]
        public string SWIFT { get; set; }
        [MaxLength(50)]
        public string muxbirhesab { get; set; }
        [MaxLength(15)]
        public string bankkodu { get; set; }
        [MaxLength(50)]
        public string aznhesab { get; set; }

        [MaxLength(50)]
        public string shiricrachi { get; set; }
        [MaxLength(15)]
        public string shirvoen { get; set; }
        [MaxLength(50)]
        public string cavabdehshexs { get; set; }
        [MaxLength(50)]
        public string email { get; set; }
        [MaxLength(150)]
        public string unvan { get; set; }
    }
    [Table("mushteris")]
    public class mushteri
    {
        public mushteri() { }
        public mushteri(string _mushId, string _firma)
        {
            this.mushId = _mushId;
            this.firma = _firma;
        }
        [Key]
        [MaxLength(36)]
        public string mushId { get; set; }
        [MaxLength(100)]
        public string firma { get; set; }
        [MaxLength(15)]
        public string voen { get; set; }
        [MaxLength(15)]
        public string muqavilenom { get; set; }
        public DateTime muqaviletar { get; set; }
        [MaxLength(10)]
        public string valyuta { get; set; }
        [MaxLength(50)]
        public string odemesherti { get; set; }
        [MaxLength(100)]
        public string temsilchi { get; set; }

    }
    [Table("vahids")]
    public class _vahid
    {
        public _vahid() { }
        public _vahid(string _vId, string _vahidadi)
        {
            this.vId = _vId;
            this.vahidadi = _vahidadi;
        }
        [Key]
        [MaxLength(36)]
        public string vId { get; set; }
        [MaxLength(20)]
        public string vahidadi { get; set; }
    }
    [Table("vergis")]
    public class _vergi
    {
        public _vergi() { }
        public _vergi(string vergiId, string vergikodununadi)
        {
            this.vergiId = vergiId;
            this.vergikodununadi = vergikodununadi;
        }
        [Key]
        [MaxLength(36)]
        public string vergiId { get; set; }
        [MaxLength(20)]
        public string vergikodu { get; set; }
        [MaxLength(36)]
        public string vId { get; set; }
        // [MaxLength(550)]
        public string vergikodununadi { get; set; }
        public DateTime edv_tar { get; set; }
    }

    [Table("bashkitabs")]//herbir emeliyyat jurnalda yazilir
    public class _bashkitab
    {
        [Key]
        [MaxLength(36)]
        public string bId { get; set; }
        [MaxLength(200)]
        public string b_izah { get; set; }//izahlar birinci debitin sonra  10 simvol buraxib kredit yazaq  
        [MaxLength(36)]
        public string qId { get; set; }
        [MaxLength(36)]
        public string aId { get; set; }
        public int dhesId { get; set; }//alacaq +       
        public int khesId { get; set; }//verecek -
        public decimal mebleg { get; set; }
        public decimal kurs { get; set; }
        [MaxLength(10)]
        public string val { get; set; }
        public DateTime tarix { get; set; }
        [MaxLength(200)]
        public string qeyd { get; set; }
        [MaxLength(36)]
        public string emdetId { get; set; }
    }

    [Table("emeliyyatdets")]
    public class _emeliyyatdet
    {
        [Key]
        [MaxLength(36)]
        public string emdetId { get; set; }
        [MaxLength(36)]
        public string mastId { get; set; }//masterid
        [MaxLength(36)]
        public string qId { get; set; } //qruplar alish satish
        [MaxLength(36)]
        public string aId { get; set; }
        public int dhesId { get; set; }//alacaq +
        public int khesId { get; set; }//verecek -
        [MaxLength(36)]
        public string mushId { get; set; }//temsilchi
        [MaxLength(36)]
        public string vergiId { get; set; }
        [MaxLength(36)]
        public string vId { get; set; }//vahid
        public decimal miqdar { get; set; }
        public int submiqdar { get; set; }
        public decimal vahidqiymeti_alish { get; set; }
        public decimal vahidqiymeti_satish { get; set; }   //   hemde mebleg
        public decimal edv { get; set; }
        public int edvye_celbedilen { get; set; }
        public int edvye_celbedilmeyen { get; set; }
        public DateTime emeltarixi { get; set; }

        [MaxLength(100)]
        public string qeyd { get; set; }

    }
    [Table("testabs")]
    public class testab
    {
        [Key]
        [MaxLength(36)]
        public string tesId { get; set; }
        [MaxLength(36)]
        public string qId { get; set; } //qruplar alish satish
        [MaxLength(36)]
        public string aId { get; set; }
        public int dhesId { get; set; }//alacaq +
        public int khesId { get; set; }//verecek -
        [MaxLength(36)]
        public string mushId { get; set; }//temsilchi
        [MaxLength(36)]
        public string vergiId { get; set; }
        [MaxLength(36)]
        public string vId { get; set; }//vahid
        public decimal miqdar { get; set; }
        public int submiqdar { get; set; }
        public decimal vahidqiymeti_alish { get; set; }
        public decimal vahidqiymeti_satish { get; set; }   //   hemde mebleg
        public decimal edv { get; set; }
    }

    //[Table("muxabirs")]
    //public class muxabir
    //{
    //    [Key]
    //    [MaxLength(36)]
    //    public string muxId { get; set; }
    //    public int emelnom { get; set; }
    //    // public int qId { get; set; }
    //    public int de_hesId { get; set; }
    //    public int kr_hesId { get; set; }
    //    public decimal mebleg { get; set; }
    //    public int miqdar { get; set; }
    //    public decimal kurs { get; set; }
    //    [MaxLength(10)]
    //    public string valyuta { get; set; }
    //    [MaxLength(100)]
    //    public string emelmezmunu { get; set; }
    //    public DateTime mux_tar { get; set; }

    //}

}
//------------------------------
// [Table("herekets")]
//public class _hereket
//{
//    [Key]
//    public int hId { get; set; }
//    [MaxLength(20)]
//    public string hname { get; set; }
//    [MaxLength(50)]
//    public string qeyd { get; set; }
//}
//[Table("malqrups")]//un,makaron,et
//public class _malqrup
//{
//    [Key]
//    public int malqId { get; set; }
//    [MaxLength(200)]
//    public string malqrupuadi { get; set; }
//}
//[Table("mallars")]
//public class mallar
//{
//    [Key]
//    public int malId { get; set; }
//    [MaxLength(20)]
//    public string malkodu { get; set; }
//    [MaxLength(100)]
//    public string maladi { get; set; }
//   // public int malqId { get; set; }
//    public int vergiId { get; set; }
//    public int vId { get; set; }//vahid
//    public string edv { get; set; }
//    public int edvye_celbedilen { get; set; }
//    public int edvye_celbedilmeyen { get; set; }

//}
//[Table("banks")]
//public class _bank
//{
//    [Key]
//    public int bId { get; set; }
//    public int hesId { get; set; }//hesab
//    public int emdetId { get; set; } //emeldet
//    public int qId { get; set; } //qruplar alish satish
//    public DateTime emeltarixi { get; set; }
//    public decimal mebleg { get; set; }
//    [MaxLength(1)]
//    public string vez { get; set; }
//    [MaxLength(200)]
//    public string qeyd { get; set; }
//}
//==============================
//[Table("aktivlers")]//
//public class _aktivler
//{
//    [Key]
//    public int akId { get; set; }
//    [MaxLength(50)]
//    public string aktivname { get; set; }
//    public int A_DebhesId { get; set; }//alacaq +
//    public int A_KredhesId { get; set; }//verecek -
//    public decimal mebleg { get; set; }
//    public decimal kurs { get; set; }
//    [MaxLength(10)]
//    public string valyuta { get; set; }
//    public DateTime emeltarixi { get; set; }
//    //[MaxLength(200)]
//    //public string qeyd { get; set; }
//}
//[Table("ohdeliks")]//
//public class _ohdelik
//{
//    [Key]
//    public int ohId { get; set; }
//    [MaxLength(50)]
//    public string ohdelname { get; set; }
//    public int Oh_DebhesId { get; set; }//alacaq  -
//    public int Oh_KredhesId { get; set; }//verecek +
//    public decimal mebleg { get; set; }
//    public decimal kurs { get; set; }
//    [MaxLength(10)]
//    public string valyuta { get; set; }
//    public DateTime emeltarixi { get; set; }
//    //[MaxLength(200)]
//    //public string qeyd { get; set; }
//}
//[Table("kapitals")]//
//public class _kapital
//{
//    [Key]
//    public int kapId { get; set; }
//    [MaxLength(50)]
//    public string kapitlname { get; set; }
//    public int K_DebhesId { get; set; } //alacaq  -
//    public int K_KredhesId { get; set; } //verecek +
//    public decimal mebleg { get; set; }
//    public decimal kurs { get; set; }
//    [MaxLength(10)]
//    public string valyuta { get; set; }
//    public DateTime emeltarixi { get; set; }
//    //[MaxLength(200)]
//    //public string qeyd { get; set; }
//}
//[Table("gelirs")]//
//public class _gelir
//{
//    [Key]
//    public int gelId { get; set; }
//    [MaxLength(50)]
//    public string gelirname { get; set; }
//    public int G_DebhesId { get; set; }//alacaq  -
//    public int G_KredhesId { get; set; } //verecek +
//    public decimal mebleg { get; set; }
//    public decimal kurs { get; set; }
//    [MaxLength(10)]
//    public string valyuta { get; set; }
//    public DateTime emeltarixi { get; set; }
//    //[MaxLength(200)]
//    //public string qeyd { get; set; }
//}
//[Table("xercs")]//
//public class _xerc
//{
//    [Key]
//    public int xeId { get; set; }
//    [MaxLength(50)]
//    public string xercname { get; set; }
//    public int Xe_DebhesId { get; set; }//alacaq  +
//    public int Xe_KredhesId { get; set; } //verecek -
//    public decimal mebleg { get; set; }
//    public decimal kurs { get; set; }
//    [MaxLength(10)]
//    public string valyuta { get; set; }
//    public DateTime emeltarixi { get; set; }
//    //[MaxLength(200)]
//    //public string qeyd { get; set; }
//}
//[Table("dividents")]//
//public class _divident
//{
//    [Key]
//    public int divId { get; set; }
//    [MaxLength(50)]
//    public string divname { get; set; }
//    public int D_DebhesId { get; set; }//alacaq +
//    public int D_KredhesId { get; set; }//verecek -
//    public decimal mebleg { get; set; }
//    public decimal kurs { get; set; }
//    [MaxLength(10)]
//    public string valyuta { get; set; }
//    public DateTime emeltarixi { get; set; }
//    //[MaxLength(200)]
//    //public string qeyd { get; set; }
//}
