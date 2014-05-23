using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public class Echantillon
    {
        public int Identifiant { get; set; }
        public string NumLot { get; set; }
        public DateTime DatePeinture { get; set; }

        public Projet Projet { get; set; }
        public Peinture Peinture { get; set; }
    }
}
