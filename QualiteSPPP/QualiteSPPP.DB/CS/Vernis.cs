using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public class Vernis
    {
        #region Attribut

        #endregion

        #region Propriété
        public Int32 Identifiant { get; set; }
        public string Reference { get; set; }
        public float Min { get; set; }
        public float Moy { get; set; }
        public float Max { get; set; }

        #endregion

        #region Constructeur
        public Vernis()
        {

        }
        #endregion

        #region Méthodes

        #endregion
    }
}
