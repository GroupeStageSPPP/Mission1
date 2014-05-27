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
    public partial class AjouterProjet : Form
    {
        public AjouterProjet()
        {
            InitializeComponent();
        }

        private void buttonAjouterPieceAjouterProjet_Click(object sender, EventArgs e)
        {
            this.Hide();
            AjouterPieces ajouterPiece = new AjouterPieces();
            ajouterPiece.ShowDialog();
            this.Show();
        }

        private void buttonAjouterPeintureAjouterProjet_Click(object sender, EventArgs e)
        {
            this.Hide();
            AjouterPeinture ajouterPeinture = new AjouterPeinture();
            ajouterPeinture.ShowDialog();
            this.Show();
        }
    }
}
