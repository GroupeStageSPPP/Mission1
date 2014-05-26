using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QualiteSPPP.DB
{
    public class Test
    {
        #region Attribut

        #endregion

        #region Propriété
        public Int32 Identifiant { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        
        //'c'= code
        //'1'=     Moy
        //'2'= Min Moy
        //'3'= Min Moy Max
        //'4'=     Moy Max
        public char TypeTest { get; set; }

        #endregion

        #region Constructeurs
        public Test()
        {

        }
        #endregion

        #region Méthodes

        #endregion
    }
}
