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
    public partial class AjoutEchantillon : Form
    {
        public Test_Ctor_Teinte TcT { get; set; }
        public Ech_Resultat EchRes  { get; set; }        

        public AjoutEchantillon()
        {
            InitializeComponent();
            TcT = new Test_Ctor_Teinte();
            EchRes = new Ech_Resultat();
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

        private void BsuivantE1_Click(object sender, EventArgs e)
        {
            panelAjoutEchantillonEtape1.Visible = false;
            panelAjoutEchantillonEtape2.Visible = true;
            InsertER();

        }

        private void CBvehicule_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBpiece.DataSource = PieceDB.List(Int32.Parse(CBvehicule.SelectedValue.ToString()));
            CBpiece.DisplayMember = "Nom";
            CBpiece.ValueMember = "Identifiant";
        }

        private void CBpiece_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBteinte.DataSource = TeinteDB.List(((Vehicule)CBvehicule.SelectedItem).ID_Constructeur);
            CBteinte.DisplayMember = "Nom";
            CBteinte.ValueMember = "Identifiant";
        }

        private void CBteinte_SelectedIndexChanged(object sender, EventArgs e)
        {
            LBproduit.DataSource = ProduitDB.List((Int32)CBpiece.SelectedValue, (Int32)CBteinte.SelectedValue);
            LBproduit.DisplayMember = "Nom";
            LBproduit.ValueMember = "Identifiant";
        }

        private void BaddE1_Click(object sender, EventArgs e)
        {
            Echantillon E= new Echantillon();
            E.ID_Produit = Int32.Parse(LBproduit.SelectedValue.ToString());
            E.ISconforme = -2;
            E.NumLot = TBnumLotE1.Text;
            E.DatePeinture = DTPpeintureE1.Value;
            EchantillonDB.Insert(E);
            RefreshE1();

        }

        public void RefreshE1()
        {
            LBechantillon.DataSource = EchantillonDB.List();
            LBechantillon.DisplayMember = "NumLot";
            LBechantillon.ValueMember = "Identifiant";
        }

        public void RefreshE2()
        {
            LBechantillonE2.DataSource = EchantillonDB.List(-1);
            LBechantillonE2.DisplayMember = "NumLot";
            LBechantillonE2.ValueMember = "Identifiant";
        }

        private void LBechantillonE2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBnumLotE2.Text = ((Echantillon)LBechantillonE2.SelectedItem).NumLot;
            TBdatePeinture.Text = ((Echantillon)LBechantillonE2.SelectedItem).DatePeinture.ToShortDateString();

            LBtestE2.DataSource = Ech_ResultatDB.List(-1);
            LBtestE2.DisplayMember = "NumLot";
            LBtestE2.ValueMember = "Identifiant";
        }
        
        private void LBtestE2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ech_Resultat EchRes = (Ech_Resultat)LBtestE2.SelectedItem;
            Int32 ID_Test = EchRes.ID_Test;
            Int32 ID_Tein = EchRes.ID_Teinte;
            
            TcT = Test_Ctor_TeinteDB.Get(ID_Test, ID_Tein);

            switch (TestDB.Get(TcT.ID_Test).TypeTest)
            {
                case 1:
                    this.TBmin.Text = TcT.Min.ToString();
                    this.TBnorme.Text = TcT.Norme.ToString();
                    this.TBmax.Text = "";
                    break;

                case 2:
                    this.TBmin.Text = TcT.Min.ToString();
                    this.TBnorme.Text = TcT.Norme.ToString();
                    this.TBmax.Text = TcT.Max.ToString();
                    break;
                    
                case 3:
                    this.TBmin.Text = "";
                    this.TBnorme.Text = TcT.Norme.ToString();
                    this.TBmax.Text = TcT.Max.ToString();
                    break;
            }
        }

        public void InsertER()
        {
            List<Echantillon> Lechantillon = EchantillonDB.List(-2);
            
            foreach (Echantillon echantillon in Lechantillon)
            {
                List<Test_Ctor_Piece> Ltcp = Test_Ctor_PieceDB.List(ProduitDB.Get(echantillon.ID_Produit).ID_Piece);

                foreach (Test_Ctor_Piece tcp in Ltcp)
                {
                    Ech_Resultat EchRes = new Ech_Resultat();
                    EchRes.ID_Echantillon = echantillon.Identifiant;
                    EchRes.ID_Constructeur = tcp.ID_Constructeur;
                    EchRes.ID_Teinte = ProduitDB.Get(echantillon.ID_Produit).ID_Teinte;
                    EchRes.ID_Test = tcp.ID_Test;
                    EchRes.ISconforme = -1;
                    Ech_ResultatDB.Insert(EchRes);
                }

                echantillon.ISconforme= -1;
                EchantillonDB.Update(echantillon);
            }
        }

        private void Bvalider_Click(object sender, EventArgs e)
        {
            Double resultat;
            
            if (Double.TryParse(TBresultat.Text.ToString(), out resultat) == true)
            {
               EchRes = (Ech_Resultat)LBtestE2.SelectedItem;
               EchRes.Resultat = resultat;
                
               switch (TestDB.Get(TcT.ID_Test).TypeTest)
               {
                   case 1:
                       if (EchRes.Resultat < TcT.Min)
                       {
                           EchRes.ISconforme = 0;
                       }
                       else
                       {
                           EchRes.ISconforme = 1;
                       }
                       break;

                   case 2:
                       if (EchRes.Resultat < TcT.Min || EchRes.Resultat > TcT.Max)
                       {
                           EchRes.ISconforme = 0;
                       }
                       else
                       {
                           EchRes.ISconforme = 1;
                       }
                       break;

                   case 3:
                       if (EchRes.Resultat > TcT.Max)
                       {
                           EchRes.ISconforme = 0;
                       }
                       else
                       {
                           EchRes.ISconforme = 1;
                       }
                       break;
               }


               if (EchRes.ISconforme == 0)
               {
                   Perror.Visible = true;
                   TBerrorE2.Text = "Le résultat est en dehors des tolérences du test\nVeuillez confirmer la saisie ou l'annuler";
               }
               else
               {
                   Ech_ResultatDB.Update(EchRes);
                   TBresultat.Text = "";

               }
            } 
            
            
            


        }

        private void BconfirmerE2_Click(object sender, EventArgs e)
        {
            Perror.Visible = false;
            TBerrorE2.Text = "";
            Ech_ResultatDB.Update(EchRes);
            TBresultat.Text = "";
        }

        private void BannulerE2_Click(object sender, EventArgs e)
        {
            Perror.Visible = false;
            TBerrorE2.Text = "";
            TBresultat.Text = "";
        }


    }
}
