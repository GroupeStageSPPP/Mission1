using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public class Base
    {
        public int Identifiant { get; set; }
        public string reference { get; set; }

        public int BN { get; set; }
        public int RV { get; set; }
        public int JB { get; set; }

        public int Min { get; set; }
        public int Moy { get; set; }
        public int Max { get; set; }

        public Fournisseur Fournisseur { get; set; }
    }
}
