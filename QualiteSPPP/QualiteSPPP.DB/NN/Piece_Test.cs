using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QualiteSPPP.DB
{
    public class Piece_Test
    {
        #region Attribut

        #endregion

        #region Propriété
        public int Identifiant { get; set; }
        public string Min { get; set; }
        public string Max { get; set; }
        public string Moy { get; set; }
        public Piece piece { get; set; }
        public Test test { get; set; }
        #endregion

        #region Constructeurs
        public Piece_Test()
        {

        }
        #endregion

        #region Méthodes

        #endregion
    }
}
