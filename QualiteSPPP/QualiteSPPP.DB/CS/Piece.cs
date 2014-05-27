using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QualiteSPPP.DB
{
    public class Piece
    {
        #region Attribut

        #endregion

        #region Propriété
        public Int32 Identifiant { get; set; }
        public Vehicule vehicule { get; set; }
        public SousCat sousCat { get; set; }

        #endregion

        #region Constructeurs
        public Piece()
        {

        }
        #endregion

        #region Méthodes

        #endregion
    }
}
