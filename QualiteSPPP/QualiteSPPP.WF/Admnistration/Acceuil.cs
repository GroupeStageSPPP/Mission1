﻿using System;
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
    public partial class Acceuil : Form
    {
        public Utilisateur Status;

        public Acceuil(Utilisateur entreUtilistateur)
        {
            Status = new Utilisateur();

            Status.Identifiant = entreUtilistateur.Identifiant;
            Status.Password = entreUtilistateur.Password;
            Status.Groupe = entreUtilistateur.Groupe;

            InitializeComponent();
        }
        private void Acceuil_Load(object sender, EventArgs e)
        {
            ouvrirEcran("OPTION_Acceuil");
        }

        #region Fonctions
            private void ouvrirEcran(string nomEcran)
        {
            //ouvrir ADMINISTRATION/Nouveau/Categorie
            if (nomEcran == "ADMINISTRATION_Nouveau_Type")
            {
                panelAsministrationNouveauType.Visible = true;
            }
            else
            {
                panelAsministrationNouveauType.Visible = false;
            }

            //ouvrir ADMINISTRATION/Nouveau/Client
            if (nomEcran == "ADMINISTRATION_Nouveau_Client")
            {
                panelAdministrationNouveauClient.Visible = true;
            }
            else
            {
                panelAdministrationNouveauClient.Visible = false;
            }

            //ouvrir ADMINISTRATION/Nouveau/Constructeur
            if (nomEcran == "ADMINISTRATION_Nouveau_Constructeur")
            {
                panelAdministrationNouveauConstructeur.Visible = true;
            }
            else
            {
                panelAdministrationNouveauConstructeur.Visible = false;
            }

            //ouvrir ADMINISTRATION/Nouveau/Categorie
            if (nomEcran == "ADMINISTRATION_Nouveau_Categorie")
            {
                panelAdministrationNouveauCategorie.Visible = true;
            }
            else
            {
                panelAdministrationNouveauCategorie.Visible = false;
            }

            //ouvrir ADMINISTRATION/Nouveau/Fournisseur
            if (nomEcran == "ADMINISTRATION_Nouveau_Fournisseur")
            {
                panelAdministrationNouveauFournisseur.Visible = true;
            }
            else
            {
                panelAdministrationNouveauFournisseur.Visible = false;
            }

            //ouvrir ADMINISTRATION/Nouveau/Peinture
            if (nomEcran == "ADMINISTRATION_Nouveau_Peinture")
            {
                panelAdministartionNouveauPeinture.Visible = true;
            }
            else
            {
                panelAdministartionNouveauPeinture.Visible = false;
            }

            //ouvrir ADMINISTRATION/Nouveau/Projet
            if (nomEcran == "ADMINISTRATION_Nouveau_Projet")
            {
                panelAdministrationNouveauProjet.Visible = true;
            }
            else
            {
                panelAdministrationNouveauProjet.Visible = false;
            }

            //ouvrir ADMINISTRATION/Nouveau/Vehicule
            if (nomEcran == "ADMINISTRATION_Nouveau_Vehicule")
            {
                panelAdministrationNouveauVehicule.Visible = true;
            }
            else
            {
                panelAdministrationNouveauVehicule.Visible = false;
            }

            //ouvrir ADMINISTRATION/Nouveau/Piece
            if (nomEcran == "ADMINISTRATION_Nouveau_Piece")
            {
                panelAdministrationNouveauPiece.Visible = true;
            }
            else
            {
                panelAdministrationNouveauPiece.Visible = false;
            }

            //ouvrir OPTION/Acceuil
            if (nomEcran == "OPTION_Acceuil")
            {
                panelOptionAcceuil.Visible = true;
            }
            else
            {
                panelOptionAcceuil.Visible = false;
            }

            //ouvrir LABORATOIRE/Nouvel Echantillon
            if (nomEcran == "LABORATOIRE_NouvelEchantillon")
            {
                panelLABORATOIRENouvelEchantillon.Visible = true;
            }
            else
            {
                panelLABORATOIRENouvelEchantillon.Visible = false;
            }

            //ouvrir TEST/Consulter
            if (nomEcran == "TEST_Consulter")
            {
                panelLABORATOIREConsulterEchantillon.Visible = true;
            }
            else
            {
                panelLABORATOIREConsulterEchantillon.Visible = false;
            }
        }
        #endregion
        #region ToolStripMenu
        #region Couleur : ToolStripMenuItem
        private void tESTToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {

            tESTToolStripMenuItem.ForeColor = System.Drawing.Color.White;
        }
        private void tESTToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            tESTToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
        }
        private void administrationToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            administrationToolStripMenuItem.ForeColor = System.Drawing.Color.White;
        }
        private void administrationToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            administrationToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
        }
        private void optionToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            optionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
        }
        private void optionToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            optionToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
        }
        private void toolStripMenuItemEchantillon_DropDownClosed(object sender, EventArgs e)
        {
            toolStripMenuItemPROJET.ForeColor = System.Drawing.Color.White;
        }
        private void toolStripMenuItemEchantillon_DropDownOpened(object sender, EventArgs e)
        {
            toolStripMenuItemPROJET.ForeColor = System.Drawing.Color.Black;
        }
        #endregion
        #endregion

        #region Fonction de l'onglet : PROJET
            #region Véhicule
                private void vehiculeToolStripMenuItem_Click(object sender, EventArgs e)
            {
                ouvrirEcran("ADMINISTRATION_Nouveau_Vehicule");
            }
            #endregion
            #region Pièce
                private void pieceToolStripMenuItem1_Click(object sender, EventArgs e)
                {
                    ouvrirEcran("ADMINISTRATION_Nouveau_Piece");
                }
            #endregion
        #endregion
        #region Fonction de l'onglet : LABORATOIRE
            #region Fonction de l'onglet : Ajouter un échantillon
                private void nouveauToolStripMenuItem1_Click(object sender, EventArgs e)
                {
                    //  --> LABORATOIRE/Nouvel Echantillon
                    ouvrirEcran("LABORATOIRE_NouvelEchantillon");
                }
                private void buttonCommencerTest_Click(object sender, EventArgs e)
                {
                    if (listBoxEchantillon.SelectedItem != null)
                    {
                        // Fonction isTestNumerique à creer pour verifier si le test es numerique ou non.
                        bool boolTestNumerique = false;      //isTestNumerique(listBoxTest.SelectedItem);
                        if (boolTestNumerique == true)
                        {
                            NouveauTestNumerique testNumerique = new NouveauTestNumerique();
                            testNumerique.ShowDialog();
                        }
                        else
                        {
                            NouveauTestNonNumerique testNonNumerique = new NouveauTestNonNumerique();
                            testNonNumerique.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Veuillez choisir un test");
                    }
                }
                private void buttonNewProjetLABORATOIREAjouterEchantillon_Click(object sender, EventArgs e)
            {
                AjouterProjet ajouterProjet = new AjouterProjet();
                ajouterProjet.ShowDialog();
            }
            #endregion
            #region Fonction de l'onglet : Consulter
        private void consulterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  --> TEST/Consulter
            ouvrirEcran("TEST_Consulter");
        }
        #endregion
        #endregion
        #region Fonction de l'onglet : ADMINISTRATION
            #region Categorie
            private void ajouterUneCategorieToolStripMenuItem_Click(object sender, EventArgs e)
            {
                //ouvrir ADMINISTRATION/Nouveau/Categorie
                ouvrirEcran("ADMINISTRATION_Nouveau_Categorie");
            }
            #endregion
            #region Client
            private void ajouterUnClientToolStripMenuItem_Click(object sender, EventArgs e)
            {
                //  --> ADMINISTRATION/Nouveau/Client
                ouvrirEcran("ADMINISTRATION_Nouveau_Client");
            }
            #endregion
            #region Constructeur
            private void ajouterUnConstructeurToolStripMenuItem_Click(object sender, EventArgs e)
            {
                //  --> ADMINISTRATION/Nouveau/Constructeur
                ouvrirEcran("ADMINISTRATION_Nouveau_Constructeur");
            }
            #endregion
            #region Fournisseur
            private void ajouterUnFournisseurToolStripMenuItem_Click(object sender, EventArgs e)
            {
                //  --> ADMINISTRATION/Nouveau/Fournisseur
                ouvrirEcran("ADMINISTRATION_Nouveau_Fournisseur");
            }
            private void comboBoxPaysConstructeur_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (comboBoxPaysADMINISTRATIONFournisseur.SelectedItem == "Autre")
                {
                    textBoxAjoutPaysADMINISTRATIONFournisseur.Enabled = true;
                }
                else
                {
                    textBoxAjoutPaysADMINISTRATIONFournisseur.Enabled = false;
                }
            }
            #endregion
            #region Peinture
                private void ajouterUnePeintureToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    //  --> ADMINISTRATION/Nouveau/Peinture
                    ouvrirEcran("ADMINISTRATION_Nouveau_Peinture");
                }
                private void buttonNouveauConstructeurPeinture_Click(object sender, EventArgs e)
                {
                    AjoutConstructeur constructeur = new AjoutConstructeur();
                    constructeur.ShowDialog();
                }
            #endregion
            #region Projet
            private void ajouterUnProjetToolStripMenuItem_Click(object sender, EventArgs e)
            {
                //  --> ADMINISTRATION/Nouveau/Projet
                ouvrirEcran("ADMINISTRATION_Nouveau_Projet");
            }
            private void checkBoxGaucheDroite_CheckedChanged(object sender, EventArgs e)
            {
                if (checkBoxGaucheDroiteADMINISTRATIONProjet.Checked == true)
                {
                    comboBoxGaucheDroiteADMINISTRATIONProjet.Enabled = true;
                }
                else
                {
                    comboBoxGaucheDroiteADMINISTRATIONProjet.Enabled = false;
                    comboBoxGaucheDroiteADMINISTRATIONProjet.Text = "";
                }
            }
            private void checkBoxAvantArriere_CheckedChanged(object sender, EventArgs e)
            {
                if (checkBoxAvantArriereADMINISTRATIONProjet.Checked == true)
                {
                    comboBoxAvantArriereADMINISTRATIONProjet.Enabled = true;
                }
                else
                {
                    comboBoxAvantArriereADMINISTRATIONProjet.Enabled = false;
                    comboBoxAvantArriereADMINISTRATIONProjet.Text = "";
                }
            }
            #endregion
            #region Vehicule
                private void ajouterUnVehiculeToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    //  --> ADMINISTRATION/Nouveau/Vehicule
                    ouvrirEcran("ADMINISTRATION_Nouveau_Vehicule");
                }
                private void comboBoxConstructeur_SelectedIndexChanged(object sender, EventArgs e)
                {
                    if (comboBoxConstructeurADMINISTRATIONVehicule.SelectedItem == "Autre")
                    {
                        buttonAjouterConstructeurADMINISTRATIONVehicule.Enabled = true;
                    }
                    else
                    {
                        buttonAjouterConstructeurADMINISTRATIONVehicule.Enabled = false;
                    }
                }
                private void buttonNouveauConstructeur_Click(object sender, EventArgs e)
                {
                    AjoutConstructeur constructeur = new AjoutConstructeur();
                    constructeur.ShowDialog();
                }
                private void buttonAjouterADMINISTRATIONVehicule_Click(object sender, EventArgs e)
                {
                    MessageBox.Show("           Véhicule Enregistré.\nVeuillez maintenant entrer les pièces de ce véhicule.");
                    AjouterPieces ajouterPieces = new AjouterPieces();
                    ajouterPieces.ShowDialog();
                }
            #endregion
            #region Type
            private void ajouterUnTypeToolStripMenuItem_Click(object sender, EventArgs e)
            {
                //  --> ADMINISTRATION/Nouveau/Type
                ouvrirEcran("ADMINISTRATION_Nouveau_Type");
            }
            private void comboBoxCategorieType_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (comboBoxCategorieADMINISTRATIONType.SelectedItem == "Autre")
                {
                    buttonNouvelleCategorieADMINISTRATIONType.Enabled = true;
                }
                else
                {
                    buttonNouvelleCategorieADMINISTRATIONType.Enabled = false;
                }
            }
            private void buttonNouvelleCategorieType_Click(object sender, EventArgs e)
            {
                AjouterCategorie ajouterCategorie = new AjouterCategorie();
                ajouterCategorie.ShowDialog();
            }
            #endregion
            #region Piece
                private void ajouterUnePièceToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    //ouvrir ADMINISTRATION/Ajouter une pièce
                    ouvrirEcran("ADMINISTRATION_Nouveau_Piece");
                }
            #endregion
        #endregion
        #region Fonction de l'onglet : OPTION
            private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
            {
                //  --> OPTION/Quitter
                QuitterConfirmation quitter = new QuitterConfirmation();
                quitter.ShowDialog();
            }
            private void pleinÉcranToolStripMenuItem_Click(object sender, EventArgs e)
            {
                //  --> OPTION/Plein écran
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                pleinÉcranToolStripMenuItem.Checked = true;
                fenêtréToolStripMenuItem.Checked = false;
            }
            private void fenêtréToolStripMenuItem_Click(object sender, EventArgs e)
            {
                //  --> OPTION/Fenetre
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Maximized;
                pleinÉcranToolStripMenuItem.Checked = false;
                fenêtréToolStripMenuItem.Checked = true;
            }
            #region Accueil
                private void toolStripMenuItem2_Click(object sender, EventArgs e)
                {
                    //  --> OPTION/Acceuil
                    ouvrirEcran("OPTION_Acceuil");
                }

                private void label36_Click(object sender, EventArgs e)
                {
                    //-->  Gestion des Projets
                    AjoutProjet ajoutProjet = new AjoutProjet();
                    this.Hide();
                    ajoutProjet.ShowDialog();
                    this.Show();
                }
                private void panelGestionProjetsOPTIONAccueil_MouseEnter(object sender, EventArgs e)
                {
                    panel10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                }
                private void panelGestionProjetsOPTIONAccueil_MouseLeave(object sender, EventArgs e)
                {
                    panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                }

                private void label37_Click(object sender, EventArgs e)
                {
                    //-->  Gestion des Echantillons
                    AjoutEchantillon ajoutEchantillon = new AjoutEchantillon();
                    this.Hide();
                    ajoutEchantillon.ShowDialog();
                    this.Show();
                }
                private void panelGestionEchantillonsOPTIONAccueil_MouseEnter(object sender, EventArgs e)
                {
                    panel13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                }
                private void panelGestionEchantillonsOPTIONAccueil_MouseLeave(object sender, EventArgs e)
                {
                    panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                }

                private void label38_Click(object sender, EventArgs e)
                {
                    //-->  Gestion des Constructeurs
                    AjoutConstructeur ajoutConstructeur = new AjoutConstructeur();
                    this.Hide();
                    ajoutConstructeur.ShowDialog();
                    this.Show();
                }
                private void panelGestionConstructeurOPTIONAccueil_MouseEnter(object sender, EventArgs e)
                {
                    panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                }
                private void panelGestionConstructeurOPTIONAccueil_MouseLeave(object sender, EventArgs e)
                {
                    panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                }

                private void label48_Click(object sender, EventArgs e)
                {
                    //-->  Affichage des alertes;
                    Alerte alerte = new Alerte();
                    alerte.Show();
                }
                private void panelGestionAlertesOPTIONAccueil_MouseEnter(object sender, EventArgs e)
                {
                    panel16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                }
                private void panelGestionAlertesOPTIONAccueil_MouseLeave(object sender, EventArgs e)
                {
                    panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                }
            #endregion
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            AjoutProjet ajoutProjet = new AjoutProjet();
            ajoutProjet.ShowDialog();
        }
        private void buttonAjoutEchantillionOPTIONAccueil_Click(object sender, EventArgs e)
        {
            AjoutEchantillon ajoutEchantillon = new AjoutEchantillon();
            ajoutEchantillon.ShowDialog();
        }
    }
}