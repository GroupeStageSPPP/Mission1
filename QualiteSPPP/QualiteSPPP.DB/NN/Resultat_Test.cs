using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QualiteSPPP.DB
{
    public class Resultat_Test
    {
        #region Attribut

        #endregion

        #region Propriété
        public int Identifiant { get; set; }
        public bool Valeur { get; set; }
        public Echantillon echantillon { get; set; }
        public Test test { get; set; }

        #endregion

        #region Constructeurs
        public Resultat_Test()
        {

        }
        #endregion

        #region Méthodes

        #endregion
    }
}
