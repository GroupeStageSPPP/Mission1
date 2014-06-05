using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QualiteSPPP.DB
{
    public class Utilisateur
    {
        public Int32 Identifiant { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
        public Int32 Groupe { get; set; }
    }
}
