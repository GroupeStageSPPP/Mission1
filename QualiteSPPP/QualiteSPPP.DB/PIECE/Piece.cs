﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public class Piece
    {
        public int Identifiant { get; set; }

        public Vehicule Vehicule { get; set; }
        public SousCat SousCat { get; set; }
    }
}