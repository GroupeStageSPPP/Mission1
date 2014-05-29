using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QualiteSPPP.DB
{
    public class Alerte_Pro
    {
        public Int32 Identifiant { get; set; }
        public String Message { get; set; }
        public DateTime Date { get; set; }
        public Int32 ID_Produit { get; set; }

    }
}
