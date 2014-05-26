using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QualiteSPPP.DB
{
    public class Peinture
    {
        #region Attribut

        #endregion

        #region Propriété
        public int Identifiant { get; set; }
        public String Nom { get; set; }
        public String RisqueTeinte { get; set; }
        public Appret appret { get; set; }
        public Color color { get; set; }
        public Vernis vernis { get; set; }

        #endregion

        #region Constructeurs
        public Peinture()
        {

        }
        #endregion

        #region Méthodes

        #endregion
    }
}
