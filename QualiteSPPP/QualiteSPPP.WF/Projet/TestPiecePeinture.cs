﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QualiteSPPP.WinForm
{
    public partial class TestPiecePeinture : Form
    {
        public TestPiecePeinture()
        {
            InitializeComponent();
        }

        private void TestPiecePeinture_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            AjoutProduit AP = new AjoutProduit();
            this.Hide();
            AP.ShowDialog();
        }
    }
}
