using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QualiteSPPP.DB
{
    public class Ech_Resultat
    {
        public Int32 Identifiant { get; set; }

        public Double Resultat { get; set; }

        public Int32 ID_Echantillon { get; set; }
        public Int32 ID_Test { get; set; }
        public Int32 ID_Constructeur { get; set; }
        public Int32 ID_Teinte { get; set; }
    }
}
