using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QualiteSPPP.WinForm
{
    public partial class AjoutEchantillon : Form
    {
        public AjoutEchantillon()
        {
            InitializeComponent();
        }
        private void AjoutEchantillon_Load(object sender, EventArgs e)
        {
            panelAjoutEchantillonEtape1.Visible = true;
            panelAjoutEchantillonEtape2.Visible = false;
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuitterConfirmation quitterConfirmation = new QuitterConfirmation();
            quitterConfirmation.ShowDialog();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            panelAjoutEchantillonEtape1.Visible = false;
            panelAjoutEchantillonEtape2.Visible = true;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            panelAjoutEchantillonEtape1.Visible = true;
            panelAjoutEchantillonEtape2.Visible = false;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            //fonction valider
            this.Close();
        }
    }
}
