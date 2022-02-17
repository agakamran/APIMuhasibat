using System.Collections.Generic;

namespace APIMuhasibat.Models
{
    class Qaime
    {
        public string kod { get; set; }
        public string qaimeKime { get; set; }
        public string qaimeKimden { get; set; }
        public string ds { get; set; }
        public string dn { get; set; }
        public string des { get; set; }
        public string des2 { get; set; }
        public string ma { get; set; }
        public string mk { get; set; }
        public string mediator { get; set; }
        public List<QaimeTable> qaimeTables { get; set; } = new List<QaimeTable>();
        public List<QaimeTable> qaimeYekunTables { get; set; } = new List<QaimeTable>();
    }
    class QaimeTable
    {


        public string c1 { get; set; }

        public string c2 { get; set; }

        public string c3 { get; set; }

        public string c4 { get; set; }

        public string c5 { get; set; }

        public string c6 { get; set; }

        public string c7 { get; set; }

        public string c8 { get; set; }

        public string c9 { get; set; }

        public string c10 { get; set; }

        public string c11 { get; set; }

        public string c12 { get; set; }

        public string c13 { get; set; }
        public string c14 { get; set; }
        public string c15 { get; set; }
        public string c16 { get; set; }
        public string c17 { get; set; }

    }
}
