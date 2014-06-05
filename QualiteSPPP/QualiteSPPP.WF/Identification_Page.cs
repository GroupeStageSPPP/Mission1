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
            Boolean Status = false;
            Utilisateur User = new Utilisateur();

            foreach (Utilisateur user in UtilisateurDB.List())
            {
                if (user.Login == TBlogin.Text&& user.Password == TBpassword.Text)
                {
                    User = user;
                    Status = true;
                }
            }
            if (Status == true)
            {
                this.Hide();
                Acceuil acceuil = new Acceuil(User);
                acceuil.ShowDialog();
                this.Close();
            }
            //Sinon l'accès est refuser et un message d'erreur s'affiche.
            else
            {
                TBpassword.Text = ""; 
                MessageBox.Show("Identifiants incorrect !");
            }
        }
    }
}