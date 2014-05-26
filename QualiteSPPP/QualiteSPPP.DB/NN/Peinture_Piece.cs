using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    class Peinture_Piece
    {
        public Int32 Identifiant { get; set; }
        public Peinture peinture { get; set; }
        public Piece piece { get; set; }
    }
}
