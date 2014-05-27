using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public class Alerte
    {
        public Int32 IdentifiantEchantillon { get; set; }
        public DateTime DateAlerte { get; set; }
        public String Message { get; set; }
        public Char Type { get; set; }

    }
}
