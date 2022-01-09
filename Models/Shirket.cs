using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMuhasibat.Models
{
    [Table("Shirkets")]
   public class Shirket 
    {
        string _shId = null, _bankadi = null, _bankvoen = null, _sWIFT = null,
            _muxbirhesab = null, _bankkodu = null, _aznhesab = null, _shiricrachi = null,
            _shirvoen = null, _cavabdehshexs=null, _email = null, _unvan = null, _userId = null;
        decimal _shirpercent = 0;       
        public Shirket()
        {
        }

        [Key]
        [MaxLength(36)]
        public string ShId
        {
            get { return _shId; }
            set { if (value != null) { _shId = value; } }
        }
        [MaxLength(50)]
        public string Bankadi
        {
            get { return _bankadi; }
            set { if (value != null) { _bankadi = value; } }
        }
        [MaxLength(15)]
        public string Bankvoen
        {
            get { return _bankvoen; }
            set { if (value != null) { _bankvoen = value; } }
        }
        [MaxLength(50)]
        public string SWIFT
        {
            get { return _sWIFT; }
            set { if (value != null) { _sWIFT = value; } }
        }
        [MaxLength(50)]
        public string Muxbirhesab
        {
            get { return _muxbirhesab; }
            set { if (value != null) { _muxbirhesab = value; } }
        }
        [MaxLength(15)]
        public string Bankkodu
        {
            get { return _bankkodu; }
            set { if (value != null) { _bankkodu = value; } }
        }
        [MaxLength(50)]
        public string Aznhesab
        {
            get { return _aznhesab; }
            set { if (value != null) { _aznhesab = value; } }
        }
        [MaxLength(50)]
        public string Shiricrachi
        {
            get { return _shiricrachi; }
            set { if (value != null) { _shiricrachi = value; } }
        }
        [MaxLength(15)]
        public string Shirvoen
        {
            get { return _shirvoen; }
            set { if (value != null) { _shirvoen = value; } }
        }
        [MaxLength(50)]
        public string Cavabdehshexs
        {
            get { return _cavabdehshexs; }
            set { if (value != null) { _cavabdehshexs = value; } }
        }
        [MaxLength(50)]
        public string Email
        {
            get { return _email; }
            set { if (value != null) { _email = value; } }
        }
        [MaxLength(150)]
        public string Unvan
        {
            get { return _unvan; }
            set { if (value != null) { _unvan = value; } }
        }

        [ MaxLength(36)]
        public string userId
        {
            get { return _userId; }
            set { if (value != null) { _userId = value; } }
        }
        public decimal Shirpercent
        {
            get { return _shirpercent; }
            set { if (value > 0) { _shirpercent = value; } }
        }

    }
}
