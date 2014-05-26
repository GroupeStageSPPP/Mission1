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
    public partial class Acceuil : Form
    {
        public Identification Status;
        
        public Acceuil(Identification entreUtilistateur)
        {
            Status = new Identification();

            Status.Identifiant = entreUtilistateur.Identifiant;
            Status.Status = entreUtilistateur.Status;
            Status.AdminAcess = entreUtilistateur.AdminAcess;

            InitializeComponent();
        }
        private void Acceuil_Load(object sender, EventArgs e)
        {
            ouvrirEcran("OPTION_Acceuil");

            if (Status.AdminAcess == true)
	        {
                administrationToolStripMenuItem.Enabled = true;
	        }
            else
            {
                administrationToolStripMenuItem.Enabled = false;
            }
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

                //ouvrir ADMINISTRATION/Nouveau/Echantillion
                if (nomEcran == "ADMINISTRATION_Nouveau_Echantillion")
                {
                    panelAdministrationNouveauEchantillon.Visible = true;
                }
                else
                {
                    panelAdministrationNouveauEchantillon.Visible = false;
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

                //ouvrir OPTION/Acceuil
                if (nomEcran == "OPTION_Acceuil")
                {
                    panelOptionAcceuil.Visible = true;
                }
                else
                {
                    panelOptionAcceuil.Visible = false;
                }

                //ouvrir TEST/Nouveau
                if (nomEcran == "TEST_Nouveau")
                {
                    panelTestNouveau.Visible = true;
                }
                else
                {
                    panelTestNouveau.Visible = false;
                }

                //ouvrir TEST/Consulter
                if (nomEcran == "TEST_Consulter")
                {
                    panelTestConsulter.Visible = true;
                }
                else
                {
                    panelTestConsulter.Visible = false;
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
            #endregion
        #endregion

        #region Fonction de l'onglet : TEST
            #region Fonction de l'onglet : Nouveau
                private void nouveauToolStripMenuItem1_Click(object sender, EventArgs e)
                {
                    //  --> TEST/Nouveau
                    ouvrirEcran("TEST_Nouveau");
                }
                private void listBoxTest_SelectedIndexChanged(object sender, EventArgs e)
                {
                    if (listBoxTest.SelectedItem == "Nouveau")
                    {
                        panelCommencerTest.Enabled = false;
                        panelAjouterTest.Enabled = true;
                        textBoxDescriptionTest.Text = "";  
                    }
                    else
                    {
                        panelCommencerTest.Enabled = true;
                        panelAjouterTest.Enabled = false;
                        textBoxDescriptionTest.Text = "[Description du test sélectionné]";
                    }
                }
                private void buttonCommencerTest_Click(object sender, EventArgs e)
                {
                    if (listBoxTest.SelectedItem != null)
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
                #region Fonction de l'onglet : Nouveau
                #region Type
                    private void categorieToolStripMenuItem_Click(object sender, EventArgs e)
                    {
                        //  --> ADMINISTRATION/Nouveau/Categorie
                        ouvrirEcran("ADMINISTRATION_Nouveau_Type");
                    }
                    private void comboBoxCategorieType_SelectedIndexChanged(object sender, EventArgs e)
                    {
                        if (comboBoxCategorieType.SelectedItem == "Autre")
                        {
                            buttonNouvelleCategorieType.Enabled = true;
                        }
                        else
                        {
                            buttonNouvelleCategorieType.Enabled = false;
                        }
                    }
                #endregion
                #region Client
                    private void clientToolStripMenuItem_Click(object sender, EventArgs e)
                    {
                        //  --> ADMINISTRATION/Nouveau/Client
                        ouvrirEcran("ADMINISTRATION_Nouveau_Client");
                    }
                #endregion
                #region Constructeur
                    private void constructeurToolStripMenuItem_Click(object sender, EventArgs e)
                    {
                        //  --> ADMINISTRATION/Nouveau/Constructeur
                        ouvrirEcran("ADMINISTRATION_Nouveau_Constructeur");
                    }
                #endregion
                #region Echantillon
                    private void echantillonToolStripMenuItem_Click(object sender, EventArgs e)
                    {
                        //  --> ADMINISTRATION/Nouveau/Echantillion
                        ouvrirEcran("ADMINISTRATION_Nouveau_Echantillion");
                    }
                #endregion
                #region Fournisseur
                    private void fournisseurToolStripMenuItem_Click(object sender, EventArgs e)
                    {
                        //  --> ADMINISTRATION/Nouveau/Fournisseur
                        ouvrirEcran("ADMINISTRATION_Nouveau_Fournisseur");
                    }
                    private void comboBoxPaysConstructeur_SelectedIndexChanged(object sender, EventArgs e)
                    {
                        if (comboBoxPaysConstructeur.SelectedItem == "Autre")
                        {
                            textBoxAjoutPays.Enabled = true;
                        }
                        else
                        {
                            textBoxAjoutPays.Enabled = false;
                        }
                    }
                #endregion
                #region Peinture
                    private void peintreToolStripMenuItem_Click(object sender, EventArgs e)
                    {
                        //  --> ADMINISTRATION/Nouveau/Peinture
                        ouvrirEcran("ADMINISTRATION_Nouveau_Peinture");
                    }
                    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
                    {
                        if (comboBoxConstructeurPeinture.SelectedItem == "Autre")
                        {
                            buttonNouveauConstructeurPeinture.Enabled = true;
                        }
                        else
                        {
                            buttonNouveauConstructeurPeinture.Enabled = false;
                        }
                    }
                    private void buttonNouveauConstructeurPeinture_Click(object sender, EventArgs e)
                    {
                        AjouterConstructeur constructeur = new AjouterConstructeur();
                        constructeur.ShowDialog();
                    }
                #endregion
                #region Projet
                    private void ProjetToolStripMenuItem_Click(object sender, EventArgs e)
                    {
                        //  --> ADMINISTRATION/Nouveau/Projet
                        ouvrirEcran("ADMINISTRATION_Nouveau_Projet");
                    }
                    private void checkBoxGaucheDroite_CheckedChanged(object sender, EventArgs e)
                    {
                        if (checkBoxGaucheDroite.Checked == true)
                        {
                            comboBoxGchDrt.Enabled = true;
                        }
                        else
                        {
                            comboBoxGchDrt.Enabled = false;
                            comboBoxGchDrt.Text = ""; 
                        }
                    }
                    private void checkBoxAvantArriere_CheckedChanged(object sender, EventArgs e)
                    {
                        if (checkBoxAvantArriere.Checked == true)
                        {
                            comboBoxAvtArr.Enabled = true;
                        }
                        else
                        {
                            comboBoxAvtArr.Enabled = false;
                            comboBoxAvtArr.Text = ""; 
                        }
                    }
                #endregion
                #region Vehicule
                    private void vehiculeToolStripMenuItem_Click(object sender, EventArgs e)
                    {
                        //  --> ADMINISTRATION/Nouveau/Vehicule
                        ouvrirEcran("ADMINISTRATION_Nouveau_Vehicule");
                    }
                    private void comboBoxConstructeur_SelectedIndexChanged(object sender, EventArgs e)
                    {
                        if (comboBoxConstructeur.SelectedItem == "Autre")
                        {
                            buttonNouveauConstructeur.Enabled = true;
                        }
                        else
                        {
                            buttonNouveauConstructeur.Enabled = false;
                        }
                    }
                    private void buttonNouveauConstructeur_Click(object sender, EventArgs e)
                    {
                        AjouterConstructeur constructeur = new AjouterConstructeur();
                        constructeur.ShowDialog();
                    }
                #endregion
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
            private void toolStripMenuItem2_Click(object sender, EventArgs e)
            {
                //  --> OPTION/Acceuil
                ouvrirEcran("OPTION_Acceuil");
            }
        #endregion
    }
}