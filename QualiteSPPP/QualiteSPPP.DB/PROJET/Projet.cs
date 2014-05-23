﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteSPPP.DB
{
    public class Projet
    {
        public int Identifiant { get; set; }
        public string Nom { get; set; }

        public Piece Piece { get; set; }
        public Pos_Avar Pos_Avar { get; set; }
        public Pos_Gd Pos_Gd { get; set; }
    }
}