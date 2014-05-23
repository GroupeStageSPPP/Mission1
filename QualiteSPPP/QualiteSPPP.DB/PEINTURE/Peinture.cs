using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public class Peinture
    {
        public int Identifiant { get; set; }
        public string Nom { get; set; }

        public Appret Appret { get; set; }
        public Base Base { get; set; }
        public Vernis Vernis { get; set; }

    }
}
