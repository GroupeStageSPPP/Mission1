using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QualiteSPPP.DB
{
    public class Piece
    {
        public Int32 Identifiant { get; set; }
        public String Nom { get; set; }
        public Int32 ID_Vehicule { get; set; }
        public Int32 ID_SousCat { get; set; }
    }
}
