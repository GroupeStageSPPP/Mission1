using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QualiteSPPP.DB
{
    public class Echantillon
    {
        public Int32 Identifiant { get; set; }
        
        public String NumLot { get; set; }
        public DateTime DatePeinture { get; set; }
        public Int16 ISconforme { get; set; }
        
        public Int32 ID_Produit { get; set; }

    }
}
