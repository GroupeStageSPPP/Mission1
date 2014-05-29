using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QualiteSPPP.DB
{
    public class Produit
    {
        public Int32 Identifiant { get; set; }
        public String Nom { get; set; }
        public Int16 ISconforme { get; set; }
        public Int32 SuiteConforme { get; set; }
        public Int16 ISactif { get; set; }

        public Int32 ID_Piece { get; set; }
        public Int32 ID_Teinte { get; set; }
        public Int32 ID_PosAvAr { get; set; }
        public Int32 ID_PosGD { get; set; }
    }
}
