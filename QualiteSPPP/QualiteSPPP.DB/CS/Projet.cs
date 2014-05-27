using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QualiteSPPP.DB
{
    public class Projet
    {
        #region Attribut

        #endregion

        #region Propriété
        public int Identifiant { get; set; }
        public string PositionGD { get; set; }
        public string PositionAVAR { get; set; }
        public Piece piece { get; set; }
        public Peinture peinture { get; set; }

        #endregion

        #region Constructeurs
        public Projet()
        {

        }
        #endregion

        #region Méthodes

        #endregion
    }
}
