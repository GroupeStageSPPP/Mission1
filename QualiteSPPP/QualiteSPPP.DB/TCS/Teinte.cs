using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QualiteSPPP.DB
{
    public class Teinte
    {
        public Int32 Identifiant { get; set; }
        public String Nom { get; set; }
        public String RisqueTeinte { get; set; }
        
        public String ReferenceBase { get; set; }
        public Int32 L { get; set; }
        public Int32 A { get; set; }
        public Int32 B { get; set; }
        public Double Min { get; set; }
        public Double Norm { get; set; }
        public Double Max { get; set; }
        
        public Int32 ID_Constructeur { get; set; }
        public Int32 ID_Appret { get; set; }
        public Int32 ID_Vernis { get; set; }

    }
}
