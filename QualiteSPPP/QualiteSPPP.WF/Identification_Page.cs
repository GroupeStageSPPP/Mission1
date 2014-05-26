using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QualiteSPPP.DB;

namespace QualiteSPPP.WinForm
{
    public partial class Identification_Page : Form
    {
        public Identification StatusActuel { get; set; }

        public Identification_Page()
        {
            InitializeComponent();
        }

        private void pictureBoxButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBoxButtonSeConnecter_Click(object sender, EventArgs e)
        {
            StatusActuel = new Identification();

            //Methode de verification des Identifiants  -->  EntretienSPPP.DB/IdentificationDB.cs
            StatusActuel.Status = StatusActuel.Verification(textBoxIdentifiant.Text.ToString(), textBoxMotDePasse.Text.ToString());

            //Methode de verification si accès ADMIN ou non  -->  EntretienSPPP.DB/IdentificationDB.cs
            StatusActuel.AdminAcess = StatusActuel.VerificationAdminAcess(textBoxIdentifiant.Text.ToString());

            //Garde en mémoire l'Identifiant de la personne
            StatusActuel.Identifiant = textBoxIdentifiant.Text.ToString();


            //Si la methode de verification des Identifiants renvois TRUE, Accès est autorisé et la page Acceuil ce lance.
            if (StatusActuel.Status == true)
            {
                this.Hide();
                Acceuil acceuil = new Acceuil(StatusActuel);
                acceuil.ShowDialog();
                this.Close();
            }
            //Sinon l'accès est refuser et un message d'erreur s'affiche.
            else
            {
                textBoxMotDePasse.Text = "";
                MessageBox.Show("Identifiants incorrect !");
            }
        }
    }
}