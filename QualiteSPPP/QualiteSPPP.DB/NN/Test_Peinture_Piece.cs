using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    class Test_Peinture_Piece
    {
        public Int32 Identifiant { get; set; }
        public Int32 Min { get; set; }
        public Int32 Moy { get; set; }
        public Int32 Max { get; set; }
        public String Norme { get; set; }

        public Test test { get; set; }
        public Peinture peinture { get; set; }
        public Piece piece { get; set; }

    }
}
