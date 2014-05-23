using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public class Test_Echantillon
    {
        public int Identifiant { get; set; }
        public string Resultat { get; set; }
        public char ISconforme { get; set; }

        public Test Test { get; set; }
        public Echantillon Echantillon { get; set; }
    }
}
