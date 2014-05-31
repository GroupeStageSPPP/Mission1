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
    public partial class AjoutProjet : Form
    {
        public AjoutProjet()
        {
            InitializeComponent();
        }
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuitterConfirmation quitterConfirmation = new QuitterConfirmation();
            quitterConfirmation.ShowDialog();
        }
        private void AjoutProjet_Load(object sender, EventArgs e)
        {
            panelAjoutProjetEtape1.Visible = true;
            panelAjoutProjetEtape2.Visible = false;
            panelAjoutProjetEtape3.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panelAjoutProjetEtape1.Visible = true;
            panelAjoutProjetEtape2.Visible = false;
            panelAjoutProjetEtape3.Visible = false;
        }
        private void buttonRetourAjoutProjetEtape1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            panelAjoutProjetEtape1.Visible = false;
            panelAjoutProjetEtape2.Visible = true;
            panelAjoutProjetEtape3.Visible = false;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            panelAjoutProjetEtape1.Visible = false;
            panelAjoutProjetEtape2.Visible = false;
            panelAjoutProjetEtape3.Visible = true;
        }
        private void buttonRetourAjoutProjetEtape3_Click(object sender, EventArgs e)
        {
            panelAjoutProjetEtape1.Visible = false;
            panelAjoutProjetEtape2.Visible = true;
            panelAjoutProjetEtape3.Visible = false;
        }
        private void buttonSuivantAjoutProjetEtape2_Click(object sender, EventArgs e)
        {
            panelAjoutProjetEtape1.Visible = false;
            panelAjoutProjetEtape2.Visible = false;
            panelAjoutProjetEtape3.Visible = true;
        }
        private void buttonTerminerAjoutProjetEtape3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
