using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QualiteSPPP.WinForm
{
    public partial class AjouterPieces : Form
    {
        public AjouterPieces()
        {
            InitializeComponent();
        }

        private void buttonAjouterADMINISTRATIONPiece_Click(object sender, EventArgs e)
        {
            if (false)
            {
                //fonction ajout pièce puis refresh listbox
            }
            else
            {
                MessageBox.Show("Veuillez remplir tout les champs.");
            }
        }
        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            //fonction suppression selectedValue
        }
        private void buttonFinalisationAjoutPiece_Click(object sender, EventArgs e)
        {
            if (LBCategorie.Items.Count != 0)
            {
                //fonction creer pièces pour vehicule
            }
            else
            {
                MessageBox.Show("Veuillez entrer au moin une pièce pour le vehicule");
            }
        }
        private void buttonAnnulationPieces_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Annulation de la création du véhicule.");
            this.Close();
        }
    }
}
