using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public class Peinture_Projet
    {
        public int Identifiant { get; set; }

        public Peinture Peinture { get; set; }
        public Projet Projet { get; set; }
    }
}
