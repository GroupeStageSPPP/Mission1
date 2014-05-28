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
    public partial class AjouterVehicule : Form
    {
        public AjouterVehicule()
        {
            InitializeComponent();
        }

        private void buttonAnnulerAjouterVehicule_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSuivantAjouterVehicule_Click(object sender, EventArgs e)
        {
            this.Close();
            AjouterPieces ajoutetPiece = new AjouterPieces();
            ajoutetPiece.ShowDialog();
        }

        private void buttonAjouterConstructeurAjouterVehicule_Click(object sender, EventArgs e)
        {
            AjouterConstructeur ajouterConstructeur = new AjouterConstructeur();
            ajouterConstructeur.ShowDialog();
        }
    }
}
