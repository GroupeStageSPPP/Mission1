using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public class Alerte
    {
        public Int32 Identifiant { get; set; }
        public DateTime DateAlerte { get; set; }
        public String Message { get; set; }
        public Char Type { get; set; }
        public Test_Echantillon test_echantillon { get; set; }
    }
}
