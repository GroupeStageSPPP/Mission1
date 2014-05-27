using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public class Color
    {
        #region Attribut

        #endregion

        #region Propriété
        public Int32 Identifiant { get; set; }
        public string Reference { get; set; }
        public Int16 L { get; set; }
        public Int16 A { get; set; }
        public Int16 B { get; set; }
        public float Min { get; set; }
        public float Moy { get; set; }
        public float Max { get; set; }

        #endregion

        #region Constructeur
        public Color()
        {

        }
        #endregion

        #region Méthodes

        #endregion
    }
}
