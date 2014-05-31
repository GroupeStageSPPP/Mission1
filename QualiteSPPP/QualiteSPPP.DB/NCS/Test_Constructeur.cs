using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QualiteSPPP.DB
{
    public class Test_Constructeur
    {
        public Int32 Identifiant { get; set; }
        public String Nom { get; set; }
        public Double Min { get; set; }
        public Double Norme { get; set; }
        public Double Max { get; set; }

        public Int32 ID_Test { get; set; }
        public Int32 ID_Constructeur { get; set; }
    }
}
