using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public class Test_Piece
    {
        public int Identifiant { get; set; }

        public int Min { get; set; }
        public int Moy { get; set; }
        public int Max { get; set; }
        public string Norme { get; set; }

        public Test Test { get; set; }
        public Piece Piece { get; set; }
    }
}
