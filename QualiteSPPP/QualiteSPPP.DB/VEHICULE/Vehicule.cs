using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public class Vehicule
    {
        public int Identifiant { get; set; }
        public int Nom { get; set; }

        public Constructeur Constructeur { get; set; }
        public Client Client { get; set; }
    }
}
