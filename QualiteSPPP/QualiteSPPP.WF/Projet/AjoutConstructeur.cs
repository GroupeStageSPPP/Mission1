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
    public partial class AjoutConstructeur : Form
    {
        public Constructeur Ctor { get; set; }
        public Teinte Teinte { get; set; }
        public List<Teinte> LTeinte { get; set; }
        public List<Appret> LAppret { get; set; }
        public List<Vernis> LVernis { get; set; }
        public int SizeLT { get; set; }

        public AjoutConstructeur()
        {
            Ctor = new Constructeur();
            Teinte = new Teinte();
            
            InitializeComponent();

            RefreshLBctorE1();
        }

        private void AjoutConstructeur_Load(object sender, EventArgs e)
        {
            panelAjoutConstructeurEtape1.Visible = true;
            panelAjoutConstructeurEtape2.Visible = false;
            panelAjoutConstructeurEtape3.Visible = false;
            panelAjoutConstructeurEtape4.Visible = false;

            this.TeinteError.Text = "";
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuitterConfirmation quitterConfirmation = new QuitterConfirmation();
            quitterConfirmation.ShowDialog();
        }

        #region Etape 1
      
            private void buttonAjouterAjoutConstructeurEtape1_Click(object sender, EventArgs e)
            {
                Ctor = new Constructeur();
                Ctor.Nom = this.TBnomE1.Text;
                ConstructeurDB.Insert(Ctor);
                Ctor.Identifiant = ConstructeurDB.LastID();
                panelAjoutConstructeurEtape1.Visible = false;
                panelAjoutConstructeurEtape2.Visible = true;
                panelAjoutConstructeurEtape3.Visible = false;
                panelAjoutConstructeurEtape4.Visible = false;
                RefreshLBctorE1();
                TBnomE1.Text = "";
                TBnomE2.Text = Ctor.Nom;
            }
            
            private void buttonAnnulerAjoutConstructeurEtape1_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void buttonModifierAjoutConstructeurEtape1_Click(object sender, EventArgs e)
            {
                if (Ctor != null)
                {
                    Ctor = (Constructeur)listBoxConstructeurAjoutConstructeurEtape1.SelectedItem;
                
                    panelAjoutConstructeurEtape1.Visible = false;
                    panelAjoutConstructeurEtape2.Visible = true;
                    panelAjoutConstructeurEtape3.Visible = false;
                    panelAjoutConstructeurEtape4.Visible = false;
                    TBnomE1.Text = "";
                    TBnomE2.Text = Ctor.Nom;
                }
                
            }

            private void buttonSupprimerAjoutConstructeurEtape1_Click(object sender, EventArgs e)
            {
                Ctor = (Constructeur)listBoxConstructeurAjoutConstructeurEtape1.SelectedItem;
                ConstructeurDB.Delete(Ctor.Identifiant);
                Ctor = null;
                RefreshLBctorE1();
            }
            
            private void RefreshLBctorE1()
            {
                this.listBoxConstructeurAjoutConstructeurEtape1.DataSource = ConstructeurDB.List();
                this.listBoxConstructeurAjoutConstructeurEtape1.DisplayMember = "Nom";
                this.listBoxConstructeurAjoutConstructeurEtape1.ValueMember = "Identifiant";
            }
        #endregion
        
        #region Etape 2
            
            private void LBteinteE2_SelectedIndexChanged(object sender, EventArgs e)
            {
                Teinte = (Teinte)LBteinteE2.SelectedItem;

                TBrefBaseE2.Text = Teinte.ReferenceBase;
                TBminE2.Text =  Teinte.Min.ToString();
                TBnormeE2.Text= Teinte.Norme.ToString();
                TBmaxE2.Text =  Teinte.Max.ToString();
                
                NumBNe2.Value = Teinte.L;
                NumRVe2.Value = Teinte.A;
                NumJBe2.Value = Teinte.B;

                CBappretE2.SelectedIndex = ResearchAppretE2();
                CBvernisE2.SelectedIndex = ResearchVernisE2();

            }

            private void BresetE2_Click(object sender, EventArgs e)
            {
                Teinte = new Teinte();
                TBrefBaseE2.Text = "";
                TBminE2.Text = "";
                TBnormeE2.Text = "";
                TBmaxE2.Text = "";

                NumBNe2.Value = 0;
                NumRVe2.Value = 0;
                NumJBe2.Value = 0;

                CBappretE2.SelectedIndex = 0;
                CBvernisE2.SelectedIndex = 0;  
            }

            private void BaddE2_Click(object sender, EventArgs e)
            {
                Int32 I;
                if ( Int32.TryParse(TBminE2.Text.ToString(), out I )== true 
                  && Int32.TryParse(TBnormeE2.Text.ToString(), out I )== true
                  && Int32.TryParse(TBmaxE2.Text.ToString(), out I)== true
                  && TBnomE2.Text != ""
                  && TBminE2.Text != ""
                  && TBnormeE2.Text != ""
                  && TBmaxE2.Text != "")
                {
                    Teinte = new Teinte();

                    Teinte.ReferenceBase = TBrefBaseE2.Text;
                    
                    Teinte.Min  = Int32.Parse(TBminE2.Text);
                    Teinte.Norme= Int32.Parse(TBnormeE2.Text);
                    Teinte.Max  = Int32.Parse(TBmaxE2.Text);

                    Teinte.L = (Int32)NumBNe2.Value;
                    Teinte.A = (Int32)NumRVe2.Value;
                    Teinte.B = (Int32)NumJBe2.Value;

                    Teinte.ID_Appret = ((Vernis)CBappretE2.SelectedItem).Identifiant;
                    Teinte.ID_Vernis = ((Vernis)CBvernisE2.SelectedItem).Identifiant;

                    TeinteDB.Insert(Teinte);
                    RefreshE2();
                }
            }

            private void BupdateE2_Click(object sender, EventArgs e)
            {
                Int32 I;
                if (
                     Int32.TryParse(TBminE2.Text.ToString(), out I) == true
                  && Int32.TryParse(TBnormeE2.Text.ToString(), out I) == true
                  && Int32.TryParse(TBmaxE2.Text.ToString(), out I) == true
                  && TBnomE2.Text != ""
                  && TBminE2.Text != ""
                  && TBnormeE2.Text != ""
                  && TBmaxE2.Text != ""
                  && Teinte != null)
                {
                    Teinte.ReferenceBase = TBrefBaseE2.Text;

                    Teinte.Min = Int32.Parse(TBminE2.Text);
                    Teinte.Norme = Int32.Parse(TBnormeE2.Text);
                    Teinte.Max = Int32.Parse(TBmaxE2.Text);

                    Teinte.L = (Int32)NumBNe2.Value;
                    Teinte.A = (Int32)NumRVe2.Value;
                    Teinte.B = (Int32)NumJBe2.Value;

                    Teinte.ID_Appret = ((Vernis)CBappretE2.SelectedItem).Identifiant;
                    Teinte.ID_Vernis = ((Vernis)CBvernisE2.SelectedItem).Identifiant;
                    
                    TeinteDB.Update(Teinte);
                    RefreshE2();
                }

            }

            private void BdeleteE2_Click(object sender, EventArgs e)
            {
                if (Teinte != null)
                {
                    TeinteDB.Delete(Teinte.Identifiant);
                    RefreshE2();
                }
            }

            private void BannulerE2_Click(object sender, EventArgs e)
            {
                panelAjoutConstructeurEtape2.Visible = false;
                panelAjoutConstructeurEtape1.Visible = true;
                
            }

            private void BsuivantE2_Click(object sender, EventArgs e)
            {
                panelAjoutConstructeurEtape2.Visible = false;
                panelAjoutConstructeurEtape3.Visible = true;
            }
            
            private void RefreshE2()
            {
                LBteinteE2.DataSource = TeinteDB.List(Ctor.Identifiant);
                LBteinteE2.DisplayMember = "ReferenceBase";
            }

            private int ResearchAppretE2()
            {
                int i = 0;
                foreach (Appret A in AppretDB.List())
                {
                    if (A.Identifiant != Teinte.ID_Appret)
                    {
                        i++;                        
                    }
                }

                return i;
            }
            
            private int ResearchVernisE2()
            {
                int i = 0;
                foreach (Appret V in AppretDB.List())
                {
                    if (V.Identifiant != Teinte.ID_Vernis)
                    {
                        i++;
                    }
                }

                return i;
            }
                   
        #endregion
        
        #region Etape 3

            
            public Test Test { get; set; }
            public Test_Constructeur Tctor { get; set; }

            private void BaddTestCtorE3_Click(object sender, EventArgs e)
            {
                Double D;
                if ( Double.TryParse(TBminE3.Text, out D) == true
                  && Double.TryParse(TBnormeE3.Text, out D) == true
                  && Double.TryParse(TBminE3.Text, out D) == true
                  && LBtestE3.SelectedItem != null)
                {
                
                    Test = (Test)LBtestE3.SelectedItem;
                    Tctor = new Test_Constructeur();
                    Tctor.ID_Test = Test.Identifiant;
                    Tctor.ID_Constructeur = Ctor.Identifiant;
                    this.TBdescE3.Text = Test.Description;
                    switch (Test.TypeTest)
                    {
                        case 1:
                            Tctor.Min = Double.Parse(TBminE3.Text);
                            Tctor.Norme = Double.Parse(TBnormeE3.Text);
                            Tctor.Max = 0;
                            break;
                        case 2:
                            Tctor.Min = Double.Parse(TBminE3.Text);
                            Tctor.Norme = Double.Parse(TBnormeE3.Text);
                            Tctor.Max = Double.Parse(TBmaxE3.Text);
                            break;
                        case 3:
                            Tctor.Min = 0;
                            Tctor.Norme = Double.Parse(TBnormeE3.Text);
                            Tctor.Max = Double.Parse(TBmaxE3.Text);
                            break;
                        default:
                            break;
                    }
                    Test_ConstructeurDB.Insert(Tctor);
                    RefreshE3();
                }
            }

            private void BupdateTestCtorE3_Click(object sender, EventArgs e)
            {
                Double D;
                if (Double.TryParse(TBminE3.Text, out D) == true
                  && Double.TryParse(TBnormeE3.Text, out D) == true
                  && Double.TryParse(TBminE3.Text, out D) == true
                  && LBtestCtorE3.SelectedItem != null)
                {
                    Tctor = (Test_Constructeur)LBtestCtorE3.SelectedItem;
                    Tctor.ID_Test = Test.Identifiant;
                    Tctor.ID_Constructeur = Ctor.Identifiant;
                    this.TBdescE3.Text = Test.Description;
                    switch (Test.TypeTest)
                    {
                        case 1:
                            Tctor.Min = Double.Parse(TBminE3.Text);
                            Tctor.Norme = Double.Parse(TBnormeE3.Text);
                            Tctor.Max = 0;
                            break;
                        case 2:
                            Tctor.Min = Double.Parse(TBminE3.Text);
                            Tctor.Norme = Double.Parse(TBnormeE3.Text);
                            Tctor.Max = Double.Parse(TBmaxE3.Text);
                            break;
                        case 3:
                            Tctor.Min = 0;
                            Tctor.Norme = Double.Parse(TBnormeE3.Text);
                            Tctor.Max = Double.Parse(TBmaxE3.Text);
                            break;
                        default:
                            break;
                    }
                    Test_ConstructeurDB.Update(Tctor);
                    RefreshE3();
                }
            }

            private void BdeleteTestCtorE3_Click(object sender, EventArgs e)
            {

            }

            private void LBtestE3_SelectedIndexChanged(object sender, EventArgs e)
            {
                Test = (Test)LBtestE3.SelectedItem;

                this.TBdescE3.Text = Test.Description;
                switch (Test.TypeTest)
                {
                    case 1:
                        this.TBtypeE3.Text = "Minimum et Norme";
                        this.TBminE3.ReadOnly = false;
                        this.TBnormeE3.ReadOnly = false;
                        this.TBmaxE3.ReadOnly = true;
                        break;
                    case 2:
                        this.TBtypeE3.Text = "Minimum, Norme et Maximum";
                        this.TBminE3.ReadOnly = false;
                        this.TBnormeE3.ReadOnly = false;
                        this.TBmaxE3.ReadOnly = false;
                        break;
                    case 3:
                        this.TBtypeE3.Text = "Norme et Maximum";
                        this.TBminE3.ReadOnly = true;
                        this.TBnormeE3.ReadOnly = false;
                        this.TBmaxE3.ReadOnly = false;
                        break;
                    default:
                        break;
                }
                this.TBminE3.Text = "";
                this.TBnormeE3.Text = "";
                this.TBmaxE3.Text = "";
                this.TestCtorError.Text = "";
            }
        
            private void LBtestCtorE3_SelectedIndexChanged(object sender, EventArgs e)
            {
                Test_Constructeur tCtor = (Test_Constructeur)this.LBtestCtorE3.SelectedItem;
                Test = TestDB.Get(tCtor.ID_Test);
                Tctor = tCtor;

                this.TBdescE3.Text = Test.Description;
                switch (Test.TypeTest)
                {
                    case 1:
                        this.TBtypeE3.Text = "Minimum et Norme";
                        this.TBminE3.ReadOnly = false;
                        this.TBnormeE3.ReadOnly = false;
                        this.TBmaxE3.ReadOnly = true;

                        this.TBminE3.Text = tCtor.Min.ToString();
                        this.TBnormeE3.Text = tCtor.Norme.ToString();
                        this.TBmaxE3.Text = "";
                        break;
                    case 2:
                        this.TBtypeE3.Text = "Minimum, Norme et Maximum";
                        this.TBminE3.ReadOnly = false;
                        this.TBnormeE3.ReadOnly = false;
                        this.TBmaxE3.ReadOnly = false;

                        this.TBminE3.Text = tCtor.Min.ToString();
                        this.TBnormeE3.Text = tCtor.Norme.ToString();
                        this.TBmaxE3.Text = tCtor.Max.ToString();
                        break;
                    case 3:
                        this.TBtypeE3.Text = "Norme et Maximum";
                        this.TBminE3.ReadOnly = true;
                        this.TBnormeE3.ReadOnly = false;
                        this.TBmaxE3.ReadOnly = false;

                        this.TBminE3.Text = "";
                        this.TBnormeE3.Text = tCtor.Norme.ToString();
                        this.TBmaxE3.Text = tCtor.Max.ToString();
                        break;
                    default:
                        break;
                }

                this.TestCtorError.Text = "";
            }

            private void BAnnulerAjoutConstructeurEtape3_Click(object sender, EventArgs e)
            {
                panelAjoutConstructeurEtape1.Visible = false;
                panelAjoutConstructeurEtape2.Visible = true;
                panelAjoutConstructeurEtape3.Visible = false;
                panelAjoutConstructeurEtape4.Visible = false;
            
            }

            private void RefreshE3()
            {
                this.LBtestE3.DataSource = TestDB.List();
                this.LBtestE3.DisplayMember = "Nom";
                this.LBtestE3.ValueMember = "Identifiant";

                this.LBtestCtorE3.DataSource = Test_ConstructeurDB.List(Ctor.Identifiant);
                this.LBtestCtorE3.DisplayMember = "Nom";
                this.LBtestCtorE3.ValueMember = "Identifiant";
            }

            private void BsuivantAjoutConstructeurEtape3_Click(object sender, EventArgs e)
            {
                panelAjoutConstructeurEtape1.Visible = false;
                panelAjoutConstructeurEtape2.Visible = false;
                panelAjoutConstructeurEtape3.Visible = false;
                panelAjoutConstructeurEtape4.Visible = true;
                this.TBnomE4.Text = Ctor.Nom;
                RefreshE4();
            }
        #endregion

        #region Etape 4
        public Test_Ctor_Teinte TcT { get; set; }
        public List<Teinte> Lteinte { get; set; }
        public List<Test_Constructeur> LtCtor { get; set; }
        public List<Test_Ctor_Teinte> Ltct { get; set; }

        private void LBteinteE4_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TBteinteE4.Text = ((Teinte)this.LBteinteE4.SelectedItem).ReferenceBase;
        }

        private void LBtestE4_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TBtestE4.Text = ((Test_Constructeur)this.LBtestE4.SelectedItem).Nom;

            TcT = new Test_Ctor_Teinte();
            TcT.ID_Constructeur = ((Test_Constructeur)this.LBtestE4.SelectedItem).ID_Constructeur;
            TcT.ID_Teinte = ((Teinte)this.LBteinteE4.SelectedItem).Identifiant;
            TcT.ID_Test = ((Test_Constructeur)this.LBtestE4.SelectedItem).ID_Test;
            TcT.Min = ((Test_Constructeur)this.LBtestE4.SelectedItem).Min;
            TcT.Norme = ((Test_Constructeur)this.LBtestE4.SelectedItem).Norme;
            TcT.Max = ((Test_Constructeur)this.LBtestE4.SelectedItem).Max;

            Test = TestDB.Get(TcT.ID_Test);
            this.TBdescE4.Text = Test.Description;

            switch (Test.TypeTest)
            {
                case 1:
                    this.TBtypeE4.Text = "Minimum et Norme";
                    this.TBminE4.ReadOnly = false;
                    this.TBnormeE4.ReadOnly = false;
                    this.TBmaxE4.ReadOnly = true;

                    this.TBminE4.Text = TcT.Min.ToString();
                    this.TBnormeE4.Text = TcT.Norme.ToString();
                    this.TBmaxE4.Text = "";
                    break;
                case 2:
                    this.TBtypeE4.Text = "Minimum, Norme et Maximum";
                    this.TBminE4.ReadOnly = false;
                    this.TBnormeE4.ReadOnly = false;
                    this.TBmaxE4.ReadOnly = false;

                    this.TBminE4.Text = TcT.Min.ToString();
                    this.TBnormeE4.Text = TcT.Norme.ToString();
                    this.TBmaxE4.Text = TcT.Max.ToString();
                    break;
                case 3:
                    this.TBtypeE4.Text = "Norme et Maximum";
                    this.TBminE4.ReadOnly = true;
                    this.TBnormeE4.ReadOnly = false;
                    this.TBmaxE4.ReadOnly = false;

                    this.TBminE4.Text = "";
                    this.TBnormeE4.Text = TcT.Norme.ToString();
                    this.TBmaxE4.Text = TcT.Max.ToString();
                    break;
                default:
                    break;
            }
        } 
        
        private void BvaliderE4_Click(object sender, EventArgs e)
        {
            Double D;

            switch (Test.TypeTest)
            {
                case 1:
                    if (Double.TryParse(this.TBminE4.Text, out D) == true
                     && Double.TryParse(this.TBnormeE4.Text, out D) == true)
                    {
                        this.TestCtorError.Text = "";
                        TcT.Min = Double.Parse(this.TBminE4.Text);
                        TcT.Norme = Double.Parse(this.TBnormeE4.Text);
                        Test_Ctor_TeinteDB.Update(TcT);
                        RefreshE4();
                    }
                    else
                    {
                        this.TestCtorError.Text = "Erreur de saisie, concernant les valeurs du test";
                    }
                    break;
                case 2:
                    if (Double.TryParse(this.TBminE4.Text, out D) == true
                     && Double.TryParse(this.TBnormeE4.Text, out D) == true
                     && Double.TryParse(this.TBmaxE4.Text, out D) == true)
                    {
                        this.TestCtorError.Text = "";
                        TcT.Min = Double.Parse(this.TBminE4.Text);
                        TcT.Norme = Double.Parse(this.TBnormeE4.Text);
                        TcT.Max = Double.Parse(this.TBmaxE4.Text);
                        Test_Ctor_TeinteDB.Update(TcT);
                    }
                    else
                    {
                        this.TestCtorError.Text = "Erreur de saisie, concernant les valeurs du test";
                    }
                    break;
                case 3:
                    if (Double.TryParse(this.TBnormeE4.Text, out D) == true
                     && Double.TryParse(this.TBmaxE4.Text, out D) == true)
                    {
                        this.TestCtorError.Text = "";
                        TcT.Norme = Double.Parse(this.TBnormeE4.Text);
                        TcT.Max = Double.Parse(this.TBmaxE4.Text);
                        Test_Ctor_TeinteDB.Update(TcT);
                    }
                    else
                    {
                        this.TestCtorError.Text = "Erreur de saisie, concernant les valeurs du test";
                    }
                    break;
                default:
                    break;
            }
        }
        
        private void BterminerE4_Click(object sender, EventArgs e)
        {
            panelAjoutConstructeurEtape1.Visible = true;
            panelAjoutConstructeurEtape2.Visible = false;
            panelAjoutConstructeurEtape3.Visible = false;
            panelAjoutConstructeurEtape4.Visible = false;

        }        
       
        private void RefreshE4()
        {
            InitializeComponent();
            this.TBnomE4.Text = Ctor.Nom;


            Lteinte = TeinteDB.List(Ctor.Identifiant);
            LtCtor = Test_ConstructeurDB.List(Ctor.Identifiant);

            foreach (Teinte teinte in Lteinte)
            {
                foreach (Test_Constructeur tCtor in LtCtor)
                {

                    List<Test_Ctor_Teinte> ListTCT = Test_Ctor_TeinteDB.List(tCtor);
                    Boolean Exist = false;
                    foreach (Test_Ctor_Teinte TcTexistant in ListTCT)
                    {
                        if (teinte.Identifiant == TcTexistant.ID_Teinte)
                        {
                            Exist = true;
                        }
                    }

                    if (Exist == false)
                    {
                        Test_Ctor_Teinte tCt = new Test_Ctor_Teinte();
                        tCt.ID_Constructeur = tCtor.ID_Constructeur;
                        tCt.ID_Teinte = teinte.Identifiant;
                        tCt.ID_Test = tCtor.ID_Test;
                        tCt.Min = tCtor.Min;
                        tCt.Norme = tCtor.Norme;
                        tCt.Max = tCtor.Max;

                    Test_Ctor_TeinteDB.Insert(tCt);
                    }

                }
            }


            this.LBteinteE4.DataSource = Lteinte;
            this.LBteinteE4.DisplayMember = "ReferenceBase";
            this.LBteinteE4.ValueMember = "Identifiant";
            
            this.LBtestE4.DataSource = LtCtor;
            this.LBtestE4.DisplayMember = "Nom";
            this.LBtestE4.ValueMember = "Identifiant";
        }
        #endregion
    }
}
