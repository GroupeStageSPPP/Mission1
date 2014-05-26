using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public class Test_Echantillon
    {
        public Int32 Identifiant { get; set; }
        public String Resultat { get; set; }
        public Char ISconforme { get; set; }
        public Test test { get; set; }
        public Echantillon echantillon { get; set; }

    }
}
