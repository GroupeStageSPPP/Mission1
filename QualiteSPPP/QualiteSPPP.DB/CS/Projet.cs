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
        public Int32 Identifiant { get; set; }
        public String Nom { get; set; }
        
        public Pos_Gd  pos_Gd{ get; set; }
        public Pos_AvAr  pos_AvAr{ get; set; }
        
        public Int32 FrequenceTest { get; set; }
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
