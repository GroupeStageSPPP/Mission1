using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public class Identification : IdentificationDB
    {
        public String Identifiant { get; set; }
        public Boolean Status { get; set; }
        public Boolean AdminAcess { get; set; }

        public Identification()
        {
            this.Identifiant = null;
            this.Status = false;
            this.AdminAcess = false;
        }
    }
}
