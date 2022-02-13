using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIMuhasibat.Models
{
    [Table("fealsahes")]//fealiyyet sahesi kodlari
    public class fealsahe
    {
        string _fsId = null, _fs_CODE = null, _fsADI = null;
        public fealsahe() { }
        public fealsahe(string fsId, string fs_CODE, string fsADI)
        {
            this.fsId = fsId;
            this.fs_CODE = fs_CODE;
            this.fsADI= fsADI;
        }
        [Key]
        [MaxLength(36)]
        public string fsId
        {
            get { return _fsId; }
            set { if (value != null) { _fsId = value; } }
        }
        [MaxLength(20)]
        public string fs_CODE
        {
            get { return _fs_CODE; }
            set { if (value != null) { _fs_CODE = value; } }
        }
        [MaxLength(500)]
        public string fsADI
        {
            get { return _fsADI; }
            set { if (value != null) { _fsADI = value; } }
        }
    }
}
