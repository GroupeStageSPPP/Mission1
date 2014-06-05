using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QualiteSPPP.DB;

namespace QualiteSPPP.WinForm
{
    public partial class AjoutProjet : Form
    {
        public Vehicule Vehicule { get; set; }

        public AjoutProjet()
        {
            InitializeComponent();

            //E1
            RefreshE1();
            CBctorE1.DataSource = ConstructeurDB.List();
            CBctorE1.DisplayMember = "Nom";
            CBctorE1.ValueMember = "Identifiant";

            CBcatE2.DataSource = CategorieDB.List();
            CBcatE2.DisplayMember = "Nom";
            CBcatE2.ValueMember = "Identifiant";

        }
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuitterConfirmation quitterConfirmation = new QuitterConfirmation();
            quitterConfirmation.ShowDialog();
        }
        private void AjoutProjet_Load(object sender, EventArgs e)
        {
            panelE1.Enabled = true;
            panelE2.Enabled = false;
            panelE3.Enabled = false;

            panelGestionProjet.Visible = true;
            panelGestionProjetAjouter.Visible = false;
        }

        #region Etape 1
            private void BaddE1_Click(object sender, EventArgs e)
            {
                if ( CBctorE1.SelectedItem != null
                  && TBvehiculeE1.Text != null)
                {
                    Vehicule = new Vehicule();
                    Vehicule.Nom = TBvehiculeE1.Text;
                    Vehicule.ID_Constructeur = (Int32)CBctorE1.SelectedValue;
                    VehiculeDB.Insert(Vehicule);
                    Vehicule.Identifiant = VehiculeDB.LastID();
                    SuivantE1('a');
                }
            }

            private void BupdateE1_Click(object sender, EventArgs e)
            {
                if (LBvehiculeE1.SelectedItem != null)
                {
                    Vehicule = VehiculeDB.Get((Int32)LBvehiculeE1.SelectedValue);
                    SuivantE1('u');
                }
            }

            private void BdeleteE1_Click(object sender, EventArgs e)
            {
                if (LBvehiculeE1.SelectedItem != null)
                {
                    VehiculeDB.Delete((Int32)LBvehiculeE1.SelectedValue);
                    RefreshE1();
                }
            }
            private void BannulerE1_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void RefreshE1()
            {
                LBvehiculeE1.DataSource = VehiculeDB.List();
                LBvehiculeE1.DisplayMember = "Nom";
                LBvehiculeE1.ValueMember = "Identifiant";
            }

            private void SuivantE1(char mod)
            {
                RefreshE1();
                TBnomVehicule.Text = Vehicule.Nom;
                TBnomCtor.Text = ConstructeurDB.Get(Vehicule.ID_Constructeur).Nom;

                panelGestionProjet.Visible = false;
                panelGestionProjetAjouter.Visible = true;
                if (mod == 'a')
                {
                    panelE1.Enabled = false;
                    panelE2.Enabled = true;
                    panelE3.Enabled = false;
                }
                if (mod == 'u')
                {
                    panelE1.Enabled = true;
                    panelE2.Enabled = true;
                    panelE3.Enabled = false;
                }

                CBtestE2.DataSource = Test_ConstructeurDB.List(Vehicule.ID_Constructeur);
                CBtestE2.DisplayMember = "Nom";
                CBtestE2.ValueMember = "ID_Test";


                RefreshE1();
                RefreshPieceE2();
                RefreshPieceE3();
                RefreshProduit();
                RefreshE3();
            }
            
        #endregion
        
        #region Etape 2
        
            private void RefreshPieceE2()
            { 
                LBpieceE2.DataSource = PieceDB.List(Vehicule.Identifiant);
                LBpieceE2.DisplayMember = "Nom";    
                LBpieceE2.ValueMember = "Identifiant";  
            }

            private void LBpieceE2_SelectedIndexChanged(object sender, EventArgs e)
            {
                LBtcpE2.DataSource = Test_Ctor_PieceDB.List(((Piece)LBpieceE2.SelectedItem).Identifiant);
                LBpieceE2.DisplayMember = "Nom";    
                LBpieceE2.ValueMember = "Identifiant";  
            }            
            
            private void CBcatE2_SelectedIndexChanged(object sender, EventArgs e)
            {
                CBtypeE2.DataSource = SousCatDB.List(((Categorie)CBcatE2.SelectedItem).Identifiant);
                CBtypeE2.DisplayMember = "Nom";    
                CBtypeE2.ValueMember = "Identifiant";
            }

            private void BaddPieceE2_Click(object sender, EventArgs e)
            {
                if (CBtypeE2.SelectedItem != null)
                {
                    Piece piece = new Piece();
                    piece.ID_Vehicule = Vehicule.Identifiant;
                    piece.ID_SousCat = (Int32)CBtypeE2.SelectedValue;
                    PieceDB.Insert(piece);
                    RefreshPieceE2();
                }
            }

            private void BdeletePieceE2_Click(object sender, EventArgs e)
            {
                if (LBpieceE2.SelectedItem != null)
                {
                    PieceDB.Delete((Int32)LBpieceE2.SelectedValue);
                    RefreshPieceE2();
                }
            }

            private void BaddTcpE2_Click(object sender, EventArgs e)
            {
                if (LBpieceE2.SelectedItem != null
                  && CBtestE2.SelectedItem != null)
                {
                    Test_Ctor_Piece tcp = new Test_Ctor_Piece();
                    tcp.ID_Constructeur = Vehicule.ID_Constructeur;
                    tcp.ID_Test = (Int32)LBpieceE2.SelectedValue;
                    tcp.ID_Piece = (Int32)CBtestE2.SelectedValue;
                    Test_Ctor_PieceDB.Insert(tcp);

                    RefreshTcpE2();
                }
            }

            private void BdeleteTcpE2_Click(object sender, EventArgs e)
            {
                if (LBtcpE2.SelectedItem != null)
                {
                    Test_Ctor_PieceDB.Delete((Int32)LBtcpE2.SelectedValue);

                    RefreshTcpE2();
                }
            }

            private void RefreshTcpE2()
            { 
                    LBtcpE2.DataSource = Test_Ctor_PieceDB.List((Int32)LBpieceE2.SelectedValue);
                    LBtcpE2.DisplayMember = "Nom";
                    LBtcpE2.ValueMember = "Identifiant";            
            }
            private void BcE2_Click(object sender, EventArgs e)
            {
                panelE1.Enabled = false;
                panelE2.Enabled = false;
                panelE3.Enabled = true;

                RefreshPieceE3();

            }
            private void BrE2_Click(object sender, EventArgs e)
            {
                panelE1.Enabled = false;
                panelE2.Enabled = false;
                panelE3.Enabled = false;

                panelGestionProjet.Visible = true;
                panelGestionProjetAjouter.Visible = false;

            }         


        #endregion

        #region Etape 3
            private void RefreshPieceE3()
            {
                LBpieceE3.DataSource = PieceDB.List(Vehicule.Identifiant);
                LBpieceE3.DisplayMember = "Nom";
                LBpieceE3.ValueMember = "Identifiant";
            }

            private void RefreshE3()
            {
                LBteinteE3.DataSource = TeinteDB.List(Vehicule.ID_Constructeur);
                LBteinteE3.DisplayMember = "Nom";
                LBteinteE3.ValueMember = "Identifiant";

                CBAvArE3.DataSource = Pos_AvArDB.List();
                CBAvArE3.DisplayMember = "Position";
                CBAvArE3.ValueMember = "Identifiant";

                CBgdE3.DataSource = Pos_GdDB.List();
                CBgdE3.DisplayMember = "Position";
                CBgdE3.ValueMember = "Identifiant";
            }

            private void RefreshProduit(object sender, EventArgs e)
            {
                if ( LBpieceE3.SelectedItem != null 
                  && LBteinteE3.SelectedItem != null)
                {
                    LBproduitE3.DataSource = ProduitDB.List(((Piece)LBpieceE3.SelectedItem).Identifiant, ((Teinte)LBteinteE3.SelectedItem).Identifiant);
                    LBproduitE3.DisplayMember = "Nom";
                    LBproduitE3.ValueMember = "Identifiant";
                }

            }

            private void RefreshProduit()
            {
                if (LBpieceE3.SelectedItem != null
                  && LBteinteE3.SelectedItem != null)
                {
                    LBproduitE3.DataSource = ProduitDB.List((Int32)LBpieceE3.SelectedValue, (Int32)LBteinteE3.SelectedValue);
                    LBproduitE3.DisplayMember = "Nom";
                    LBproduitE3.ValueMember = "Identifiant";
                }

            }

            private void BaddE3_Click(object sender, EventArgs e)
            {
                if (LBpieceE3.SelectedItem != null
                  && LBteinteE3.SelectedItem != null
                  && CBAvArE3.SelectedItem != null
                  && CBgdE3.SelectedItem != null)
                {
                    Produit produit = new Produit();
                    produit.ID_Piece = (Int32)LBpieceE3.SelectedValue;
                    produit.ID_Teinte = (Int32)LBteinteE3.SelectedValue;
                    produit.ID_PosAvAr = (Int32)CBAvArE3.SelectedValue;
                    produit.ID_PosGD = (Int32)CBgdE3.SelectedValue;

                    produit.ISconforme = 0;
                    produit.ISactif = 1;

                    ProduitDB.Insert(produit);

                    RefreshProduit();

                }
            }

            private void BdeleteE3_Click(object sender, EventArgs e)
            {
                if (LBproduitE3.SelectedItem != null)
                {
                    ProduitDB.Delete((Int32)LBproduitE3.SelectedValue);

                    RefreshProduit();
                }
            }

            private void BrE3_Click(object sender, EventArgs e)
            {
                panelE2.Enabled = true;
                panelE3.Enabled = false;
            }

        #endregion
    }
}
