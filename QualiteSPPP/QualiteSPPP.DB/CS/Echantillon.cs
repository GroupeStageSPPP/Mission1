using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QualiteSPPP.DB
{
    public class Echantillon
    {
        #region Attribut

        #endregion

        #region Propriété
        public int Identifiant { get; set; }
        public string NumLot { get; set; }
        public DateTime DatePeinture { get; set; }
        public Projet projet { get; set; }
        public Peinture peinture { get; set; }
        #endregion

        #region Constructeurs
        public Echantillon()
        {


        }
        #endregion

        #region Méthodes

        #endregion
    }
}
