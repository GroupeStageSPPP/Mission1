﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QualiteSPPP.DB
{
    public class Vehicule
    {
        #region Attribut

        #endregion

        #region Propriété

        public Int32 Identifiant { get; set; }
        public string Libelle { get; set; }
        public string Version { get; set; }
        public Constructeur constructeur { get; set; }

        #endregion

        #region Constructeurs
        public Vehicule()
        {

        }
        #endregion

        #region Méthodes

        #endregion
    }
}