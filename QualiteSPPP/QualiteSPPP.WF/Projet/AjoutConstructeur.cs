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
            //E1
            RefreshLBctorE1();
            //E2
            RefreshTeinteE2();
            RefreshCBE2();
            //E3
            RefreshCBE3();

            //E4


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
                Ctor.Nom = this.textBoxNomAjoutConstructeurEtape1.Text;
                ConstructeurDB.Insert(Ctor);
                Ctor.Identifiant = ConstructeurDB.LastID();
                panelAjoutConstructeurEtape1.Visible = false;
                panelAjoutConstructeurEtape2.Visible = true;
                panelAjoutConstructeurEtape3.Visible = false;
                panelAjoutConstructeurEtape4.Visible = false;
                RefreshLBctorE1();
                RefreshCBE2();
                RefreshTeinteE2();
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
                    RefreshCBE2();
                    RefreshTeinteE2();
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

            private void BvAddTeinte_Click(object sender, EventArgs e)
            {
                if (this.textBoxNomAddAjoutConstructeurEtape2.Text != ""
                 && this.textBoxRisqueAddAjoutConstructeurEtape2.Text != ""
                 && this.textBoxRefBaseAddAjoutConstructeurEtape2.Text != ""
                 && this.textBoxMinAddAjoutConstructeurEtape2.Text != ""
                 && this.textBoxNormeAddAjoutConstructeurEtape2.Text != ""
                 && this.textBoxMaxAddAjoutConstructeurEtape2.Text != "")
                {
                    Double D;
                    if (Double.TryParse(this.textBoxMinAddAjoutConstructeurEtape2.Text, out D) == true
                     && Double.TryParse(this.textBoxNormeAddAjoutConstructeurEtape2.Text, out D) == true
                     && Double.TryParse(this.textBoxMaxAddAjoutConstructeurEtape2.Text, out D) == true)
                    {
                        this.TeinteError.Text = "";
                        Teinte teinte = new Teinte();
                        teinte.Nom = this.textBoxNomAddAjoutConstructeurEtape2.Text;
                        teinte.RisqueTeinte = this.textBoxRisqueAddAjoutConstructeurEtape2.Text;
                        teinte.ReferenceBase = this.textBoxRefBaseAddAjoutConstructeurEtape2.Text;
                        teinte.L = (Int32)this.NumBNaddAjoutConstructeurEtape2.Value;
                        teinte.A = (Int32)this.NumRVaddAjoutConstructeurEtape2.Value;
                        teinte.B = (Int32)this.NumJBaddAjoutConstructeurEtape2.Value;
                        teinte.Min = Double.Parse                                                         (this.textBoxMinAddAjoutConstructeurEtape2.Text);
                        teinte.Norme = Double.Parse                                                         (this.textBoxNormeAddAjoutConstructeurEtape2.Text);
                        teinte.Max = Double.Parse(this.textBoxMaxAddAjoutConstructeurEtape2.Text);
                        teinte.ID_Appret = Int32.Parse(this.CBappretUpdateE2.SelectedValue.ToString());
                        teinte.ID_Vernis = Int32.Parse(this.CBvernisUpdateE2.SelectedValue.ToString());
                        teinte.ID_Constructeur = Ctor.Identifiant;
                        TeinteDB.Insert(teinte);
                        this.AddTeinte.Visible = false;
                        RefreshTeinteE2();;
                    }
                    else
                    {
                        this.TeinteError.Text = "Erreur de saisie, concernant les champs liés a l'épaisseur ";
                    }
                
                }
                else
                {
                    this.TeinteError.Text = "Il y a des champs nom remplis";
                }
            
            
            }

            private void BaAddTeinte_Click(object sender, EventArgs e)
           {
               this.AddTeinte.Visible = false;
           }

            private void BaUpdateTeinte_Click(object sender, EventArgs e)
            {
                this.UpdateTeinte.Visible = false;
            }

            private void BvUpdateTeinte_Click(object sender, EventArgs e)
            {
                if (this.TBnomUpdateAjoutConstructeurE2.Text != ""
                && this.TBrisqueUpdateAjoutConstructeurEtape2.Text != ""
                && this.TBrefBaseUpdateAjoutConstructeurE2.Text != ""
                && this.TBminUpdateAjoutConstructeurEtape2.Text != ""
                && this.TBnormeUpdateAjoutConstructeurEtape2.Text != ""
                && this.TBmaxUpdateAjoutConstructeurEtape2.Text != "")
                {
                    Double D;
                    if (Double.TryParse(this.TBminUpdateAjoutConstructeurEtape2.Text, out D) == true
                     && Double.TryParse(this.TBnormeUpdateAjoutConstructeurEtape2.Text, out D) == true
                     && Double.TryParse(this.TBmaxUpdateAjoutConstructeurEtape2.Text, out D) == true)
                    {
                        this.TeinteError.Text = "";
                        Teinte teinte = Teinte;
                        teinte.Nom = this.TBnomUpdateAjoutConstructeurE2.Text;
                        teinte.RisqueTeinte =this.TBrisqueUpdateAjoutConstructeurEtape2.Text;
                        teinte.ReferenceBase =this.TBrefBaseUpdateAjoutConstructeurE2.Text;
                        teinte.L = (Int32)this.NumBNupdateAjoutConstructeurEtape2.Value;
                        teinte.A = (Int32)this.NumRVupdateAjoutConstructeurEtape2.Value;
                        teinte.B = (Int32)this.NumJBupdateAjoutConstructeurEtape2.Value;
                        teinte.Min = Double.Parse(this.TBminUpdateAjoutConstructeurEtape2.Text);
                        teinte.Norme = Double.Parse(this.TBnormeUpdateAjoutConstructeurEtape2.Text);
                        teinte.Max = Double.Parse(this.TBmaxUpdateAjoutConstructeurEtape2.Text);
                        teinte.ID_Appret = Int32.Parse(this.CBappretUpdateE2.SelectedValue.ToString());
                        teinte.ID_Vernis = Int32.Parse(this.CBvernisUpdateE2.SelectedValue.ToString());
                        teinte.ID_Constructeur = Ctor.Identifiant;
                        TeinteDB.Update(teinte);
                        this.UpdateTeinte.Visible = false;
                        RefreshTeinteE2();;
                    }
                    else
                    {
                        this.TeinteError.Text = "Erreur de saisie, concernant les champs liés a l'épaisseur ";
                    }

                }
                else
                {
                    this.TeinteError.Text = "Il y a des champs nom remplis";
                }

                this.UpdateTeinte.Visible = false;
            }

            private void buttonAjouterAjoutConstructeurEtape2_Click(object sender, EventArgs e)
            {
                {
                    if (this.UpdateTeinte.Visible == false)
                    {
                        this.UpdateTeinte.Visible = false;
                        this.textBoxNomAddAjoutConstructeurEtape2.Text = "";
                        this.textBoxRisqueAddAjoutConstructeurEtape2.Text = "";
                        this.textBoxRefBaseAddAjoutConstructeurEtape2.Text = "";
                        this.NumBNaddAjoutConstructeurEtape2.Value = 0;
                        this.NumRVaddAjoutConstructeurEtape2.Value = 0;
                        this.NumJBaddAjoutConstructeurEtape2.Value = 0;
                        this.textBoxMinAddAjoutConstructeurEtape2.Text = "0";
                        this.textBoxNormeAddAjoutConstructeurEtape2.Text = "0";
                        this.textBoxMaxAddAjoutConstructeurEtape2.Text = "0";
                        this.CBappretAjoutE2.SelectedIndex = -1;
                        this.CBvernisAjoutE2.SelectedIndex = -1;
                        this.AddTeinte.Visible = true;
                    }
                    else
                    {
                        this.TeinteError.Text = "Veuillez finir de modifier la teinte avant d'en ajouter une nouvelle";
                    }


                }
                
                
            }
            
            private void buttonModifierAjoutConstructeurEtape2_Click(object sender, EventArgs e)
            {
                if (this.listBoxTeinteAjoutConstructeurEtape2.SelectedIndex != -1 && this.AddTeinte.Visible == false)
                {
                    Teinte = TeinteDB.Get(Int32.Parse(this.listBoxTeinteAjoutConstructeurEtape2.SelectedValue.ToString()));
                    this.UpdateTeinte.Visible = false;
                    this.TBnomUpdateAjoutConstructeurE2.Text = Teinte.Nom;
                    this.TBrisqueUpdateAjoutConstructeurEtape2.Text = Teinte.RisqueTeinte;
                    this.TBrefBaseUpdateAjoutConstructeurE2.Text = Teinte.ReferenceBase;
                    this.NumBNupdateAjoutConstructeurEtape2.Value = Teinte.L;
                    this.NumRVupdateAjoutConstructeurEtape2.Value = Teinte.A;
                    this.NumJBupdateAjoutConstructeurEtape2.Value = Teinte.B;
                    this.TBminUpdateAjoutConstructeurEtape2.Text = Teinte.Min.ToString();
                    this.TBnormeUpdateAjoutConstructeurEtape2.Text = Teinte.Norme.ToString();
                    this.TBmaxUpdateAjoutConstructeurEtape2.Text = Teinte.Max.ToString();

                    int i = 0;
                    foreach (Appret appret in AppretDB.List())
                    {
                        if (appret.Identifiant == Teinte.ID_Appret)
                        {
                            this.CBappretUpdateE2.SelectedIndex = i;
                        }
                        else
                        {
                            i++;
                        }
                    }

                    i = 0;
                    foreach (Vernis vernis in VernisDB.List())
                    {
                        if (vernis.Identifiant == Teinte.ID_Vernis)
                        {
                            this.CBvernisUpdateE2.SelectedIndex = i;
                        }
                        else
                        {
                            i++;
                        }
                    }
                    
                    //this.CBappretUpdateE2.SelectedItem = AppretDB.Get(Teinte.ID_Appret);
                    //this.CBvernisUpdateE2.SelectedItem = VernisDB.Get(Teinte.ID_Vernis);

                    this.UpdateTeinte.Visible = true;

                }
                else
                {
                    this.TeinteError.Text = "Veuillez finir la creation d'une nouvelle teinte.\n Ou veuillez selectionner une teinte a modifier";
                }
            }

            private void buttonAnnulerAjoutConstructeurEtape2_Click(object sender, EventArgs e)
            {
                panelAjoutConstructeurEtape1.Visible = true;
                panelAjoutConstructeurEtape2.Visible = false;
                panelAjoutConstructeurEtape3.Visible = false;
                panelAjoutConstructeurEtape4.Visible = false;
            }

            private void buttonSupprimerAjoutConstructeurEtape2_Click(object sender, EventArgs e)
            {
                if (this.listBoxTeinteAjoutConstructeurEtape2.SelectedIndex != -1 && this.AddTeinte.Visible == false && this.UpdateTeinte.Visible == false)
                {
                   TeinteDB.Delete(Int32.Parse(this.listBoxTeinteAjoutConstructeurEtape2.SelectedValue.ToString()));
                    RefreshTeinteE2();
                }
            }

            private void buttonSuivantAjoutConstructeurEtape2_Click(object sender, EventArgs e)
            {
                panelAjoutConstructeurEtape1.Visible = false;
                panelAjoutConstructeurEtape2.Visible = false;
                panelAjoutConstructeurEtape3.Visible = true;
                panelAjoutConstructeurEtape4.Visible = false;
            }
            
            private void RefreshTeinteE2()
            {
                this.TBnomCtorE2.Text = Ctor.Nom;
                this.listBoxTeinteAjoutConstructeurEtape2.DataSource = TeinteDB.List(Ctor.Identifiant);
                this.listBoxTeinteAjoutConstructeurEtape2.DisplayMember = "Nom";
                this.listBoxTeinteAjoutConstructeurEtape2.ValueMember = "Identifiant";

                this.AddTeinte.Visible = false;
                this.UpdateTeinte.Visible = false;
            }

            private void RefreshCBE2()
            {
                this.CBappretAjoutE2.DataSource= AppretDB.List();
                this.CBappretAjoutE2.DisplayMember = "Reference";
                this.CBappretAjoutE2.ValueMember= "Identifiant";

                this.CBvernisAjoutE2.DataSource = VernisDB.List();
                this.CBvernisAjoutE2.DisplayMember = "Reference";
                this.CBvernisAjoutE2.ValueMember = "Identifiant";

                this.CBappretUpdateE2.DataSource = AppretDB.List();
                this.CBappretUpdateE2.DisplayMember = "Reference";
                this.CBappretUpdateE2.ValueMember = "Identifiant";

                this.CBvernisUpdateE2.DataSource = VernisDB.List();
                this.CBvernisUpdateE2.DisplayMember = "Reference";
                this.CBvernisUpdateE2.ValueMember = "Identifiant";

                this.AddTeinte.Visible = false;
                this.UpdateTeinte.Visible = false;
            }
        #endregion
        #region Etape 3

            
            public Test Test { get; set; }
            public Test_Constructeur Tctor { get; set; }

        private void BaddTestCtorE3_Click(object sender, EventArgs e)
        {
            if (this.LBtestE3.SelectedIndex != -1 && this.UpdateTestCtor.Visible == false)
            {
                Tctor = new Test_Constructeur();
                Tctor.ID_Constructeur = Ctor.Identifiant;
                Tctor.ID_Test = (Int32)LBtestE3.SelectedValue;

                TBdescAddE3.Text = ((Test)LBtestE3.SelectedItem).Description;

                switch (((Test)LBtestE3.SelectedItem).TypeTest)
                {
                    case 1:
                        TBtypeAddE3.Text = "Minimum et Norme";
                        TBminAddE3.ReadOnly = false;
                        TBnormeAddE3.ReadOnly = false;
                        TBmaxAddE3.ReadOnly = true;
                        
                        TBminAddE3.Text = "";
                        TBnormeAddE3.Text = "";
                        TBmaxAddE3.Text = "";
                        break;
                    case 2:
                        TBtypeAddE3.Text = "Minimum, Norme et Maximum";
                        TBminAddE3.ReadOnly = false;
                        TBnormeAddE3.ReadOnly = false;
                        TBmaxAddE3.ReadOnly = false;
                        
                        TBminAddE3.Text = "";
                        TBnormeAddE3.Text = "";
                        TBmaxAddE3.Text = "";
                        break;
                    case 3:
                        TBtypeAddE3.Text = "Norme, et Maximum";
                        TBminAddE3.ReadOnly = true;
                        TBnormeAddE3.ReadOnly = false;
                        TBmaxAddE3.ReadOnly = false;
                        
                        TBminAddE3.Text = "";
                        TBnormeAddE3.Text = "";
                        TBmaxAddE3.Text = "";
                        break;
                }
                this.AddTestCtor.Visible = true;
            }
            else
            {
                if (this.UpdateTestCtor.Visible == true)
                {
                    this.TestCtorError.Text = "Finissez de modifier le test!";
                }
                else
                {
                    this.TestCtorError.Text = "Selectionnez un test à ajouter!";
                }

            }
        }

        private void BupdateTestCtorE3_Click(object sender, EventArgs e)
        {
            if (this.LBtestCtorE3.SelectedIndex != -1 && this.AddTestCtor.Visible == false)
            {

                Tctor = (Test_Constructeur)LBtestCtorE3.SelectedItem;
                Test = TestDB.Get(Tctor.ID_Test);
                

                TBdescAddE3.Text = Test.Description;

                switch (Test.TypeTest)
                {
                    case 1:
                        TBtypeAddE3.Text = "Minimum";
                        TBminAddE3.ReadOnly = false;
                        TBnormeAddE3.ReadOnly = false;
                        TBmaxAddE3.ReadOnly = true;

                        TBminAddE3.Text  = Tctor.Min.ToString();
                        TBnormeAddE3.Text= Tctor.Norme.ToString();
                        TBmaxAddE3.Text  = "";
                        break;
                    case 2:
                        TBtypeAddE3.Text = "Minimum et Maximum";
                        TBminAddE3.ReadOnly = false;
                        TBnormeAddE3.ReadOnly = false;
                        TBmaxAddE3.ReadOnly = false;

                        TBminAddE3.Text  = Tctor.Min.ToString();
                        TBnormeAddE3.Text= Tctor.Norme.ToString();
                        TBmaxAddE3.Text  = Tctor.Max.ToString();
                        break;
                    case 3:
                        TBtypeAddE3.Text = "Maximum";
                        TBminAddE3.ReadOnly = true;
                        TBnormeAddE3.ReadOnly = false;
                        TBmaxAddE3.ReadOnly = false;

                        TBminAddE3.Text  = "";
                        TBnormeAddE3.Text= Tctor.Norme.ToString();
                        TBmaxAddE3.Text  = Tctor.Max.ToString();
                        break;
                }

                this.UpdateTestCtor.Visible = true;
            }
            else
            {
                if (this.UpdateTestCtor.Visible == true)
                {
                    this.TestCtorError.Text = "Finissez d\'ajouter le test!";
                }
                else
                {
                    this.TestCtorError.Text = "Selectionnez un test à modifier!";
                }
            }
        }

        private void BvAddE3_Click(object sender, EventArgs e)
        {
            Double D;

            switch (Test.TypeTest)
            {
                case 1:
                    if (Double.TryParse(this.TBminAddE3.Text, out D) == true
                     && Double.TryParse(this.TBnormeAddE3.Text, out D) == true)
                    {
                        this.TestCtorError.Text = "";
                        Tctor.Min = Double.Parse(this.TBminAddE3.Text);
                        Tctor.Norme = Double.Parse(this.TBnormeAddE3.Text);
                        Test_ConstructeurDB.Insert(Tctor);
                        this.AddTestCtor.Visible = false;
                        RefreshCBE3();
                    }
                    else
                    {
                        this.TestCtorError.Text = "Erreur de saisie, concernant les valeurs du test";
                    }
                    break;
                case 2:
                    if (Double.TryParse(this.TBminAddE3.Text, out D) == true
                     && Double.TryParse(this.TBnormeAddE3.Text, out D) == true
                     && Double.TryParse(this.TBmaxAddE3.Text, out D) == true)
                    {
                        this.TestCtorError.Text = "";
                        Tctor.Min = Double.Parse(this.TBminAddE3.Text);
                        Tctor.Norme = Double.Parse(this.TBnormeAddE3.Text);
                        Tctor.Max = Double.Parse(this.TBmaxAddE3.Text);
                        Test_ConstructeurDB.Insert(Tctor);
                        this.AddTestCtor.Visible = false;
                        RefreshCBE3();
                    }
                    else
                    {
                        this.TestCtorError.Text = "Erreur de saisie, concernant les valeurs du test";
                    }
                    break;
                case 3:
                    if (Double.TryParse(this.TBnormeAddE3.Text, out D) == true
                     && Double.TryParse(this.TBmaxAddE3.Text, out D) == true)
                    {
                        this.TestCtorError.Text = "";
                        Tctor.Norme = Double.Parse(this.TBnormeAddE3.Text);
                        Tctor.Max = Double.Parse(this.TBmaxAddE3.Text);
                        Test_ConstructeurDB.Insert(Tctor);
                        this.AddTestCtor.Visible = false;
                        RefreshCBE3();
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

        private void BaAddE3_Click(object sender, EventArgs e)
        {
            this.TestCtorError.Text = "";
            this.AddTestCtor.Visible = false;
        }

        private void BvUpdateE3_Click(object sender, EventArgs e)
        {
            Double D;

            switch (Test.TypeTest)
            {
                case 1:
                    if (Double.TryParse(this.TBminUpdateE3.Text, out D) == true
                     && Double.TryParse(this.TBnormeUpdateE3.Text, out D) == true)
                    {
                        this.TestCtorError.Text = "";
                        Tctor.Min = Double.Parse(this.TBminUpdateE3.Text);
                        Tctor.Norme = Double.Parse(this.TBnormeUpdateE3.Text);
                        Test_ConstructeurDB.Update(Tctor);
                        this.UpdateTestCtor.Visible = false;
                        RefreshCBE3();
                    }
                    else
                    {
                        this.TestCtorError.Text = "Erreur de saisie, concernant les valeurs du test";
                    }
                    break;
                case 2:
                    if (Double.TryParse(this.TBminUpdateE3.Text, out D) == true
                     && Double.TryParse(this.TBnormeUpdateE3.Text, out D) == true
                     && Double.TryParse(this.TBmaxUpdateE3.Text, out D) == true)
                    {
                        this.TestCtorError.Text = "";
                        Tctor.Min = Double.Parse(this.TBminUpdateE3.Text);
                        Tctor.Norme = Double.Parse(this.TBnormeUpdateE3.Text);
                        Tctor.Max = Double.Parse(this.TBmaxUpdateE3.Text);
                        Test_ConstructeurDB.Update(Tctor);
                        this.UpdateTestCtor.Visible = false;
                        RefreshCBE3();
                    }
                    else
                    {
                        this.TestCtorError.Text = "Erreur de saisie, concernant les valeurs du test";
                    }
                    break;
                case 3:
                    if (Double.TryParse(this.TBnormeUpdateE3.Text, out D) == true
                     && Double.TryParse(this.TBmaxUpdateE3.Text, out D) == true)
                    {
                        this.TestCtorError.Text = "";
                        Tctor.Norme = Double.Parse(this.TBnormeUpdateE3.Text);
                        Tctor.Max = Double.Parse(this.TBmaxUpdateE3.Text);
                        Test_ConstructeurDB.Update(Tctor);
                        this.UpdateTestCtor.Visible = false;
                        RefreshCBE3();
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

        private void BaUpdateE3_Click(object sender, EventArgs e)
        {
            this.TestCtorError.Text = "";
            this.UpdateTestCtor.Visible = false;
        }
        
        private void LBtest_SelectedIndexChanged(object sender, EventArgs e)
        {
            Test = (Test)this.LBtestE3.SelectedItem;
            Tctor.ID_Test = Test.Identifiant;

            this.TBdescAddE3.Text = Test.Description;
            switch (Test.TypeTest)
            {
                case 1:
                    this.TBtypeAddE3.Text = "Minimum et Norme";
                    this.TBminAddE3.ReadOnly = false;
                    this.TBnormeAddE3.ReadOnly = false;
                    this.TBmaxAddE3.ReadOnly = true;
                    break;
                case 2:
                    this.TBtypeAddE3.Text = "Minimum, Norme et Maximum";
                    this.TBminAddE3.ReadOnly = false;
                    this.TBnormeAddE3.ReadOnly = false;
                    this.TBmaxAddE3.ReadOnly = false;
                    break;
                case 3:
                    this.TBtypeAddE3.Text = "Norme et Maximum";
                    this.TBminAddE3.ReadOnly = true;
                    this.TBnormeAddE3.ReadOnly = false;
                    this.TBmaxAddE3.ReadOnly = false;
                    break;
                default:
                    break;
            }
            this.TBminAddE3.Text = "";
            this.TBnormeAddE3.Text = "";
            this.TBmaxAddE3.Text = "";
            this.TestCtorError.Text = "";
        }
        
        private void LBtestCtorE3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Test_Constructeur tCtor = (Test_Constructeur)this.LBtestCtorE3.SelectedItem;
            Test = TestDB.Get(tCtor.ID_Test);
            Tctor = tCtor;

            this.TBdescUpdateE3.Text = Test.Description;
            switch (Test.TypeTest)
            {
                case 1:
                    this.TBtypeUpdateE3.Text = "Minimum et Norme";
                    this.TBminUpdateE3.ReadOnly = false;
                    this.TBnormeUpdateE3.ReadOnly = false;
                    this.TBmaxUpdateE3.ReadOnly = true;

                    this.TBminUpdateE3.Text = tCtor.Min.ToString();
                    this.TBnormeUpdateE3.Text = tCtor.Norme.ToString();
                    this.TBmaxUpdateE3.Text = "";
                    break;
                case 2:
                    this.TBtypeUpdateE3.Text = "Minimum, Norme et Maximum";
                    this.TBminUpdateE3.ReadOnly = false;
                    this.TBnormeUpdateE3.ReadOnly = false;
                    this.TBmaxUpdateE3.ReadOnly = false;

                    this.TBminUpdateE3.Text = tCtor.Min.ToString();
                    this.TBnormeUpdateE3.Text = tCtor.Norme.ToString();
                    this.TBmaxUpdateE3.Text = tCtor.Max.ToString();
                    break;
                case 3:
                    this.TBtypeUpdateE3.Text = "Norme et Maximum";
                    this.TBminUpdateE3.ReadOnly = true;
                    this.TBnormeUpdateE3.ReadOnly = false;
                    this.TBmaxUpdateE3.ReadOnly = false;

                    this.TBminUpdateE3.Text = "";
                    this.TBnormeUpdateE3.Text = tCtor.Norme.ToString();
                    this.TBmaxUpdateE3.Text = tCtor.Max.ToString();
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

        private void RefreshCBE3()
        {
            this.LBtestE3.DataSource = TestDB.List();
            this.LBtestE3.DisplayMember = "Nom";
            this.LBtestE3.ValueMember = "Identifiant";

            this.LBtestCtorE3.DataSource = Test_ConstructeurDB.List(Ctor.Identifiant);
            this.LBtestCtorE3.DisplayMember = "Nom";
            this.LBtestCtorE3.ValueMember = "Identifiant";

            this.AddTestCtor.Visible = false;
            this.UpdateTestCtor.Visible = false;
        }

        private void BsuivantAjoutConstructeurEtape3_Click(object sender, EventArgs e)
        {
            panelAjoutConstructeurEtape1.Visible = false;
            panelAjoutConstructeurEtape2.Visible = false;
            panelAjoutConstructeurEtape3.Visible = false;
            panelAjoutConstructeurEtape4.Visible = true;
        }
        #endregion
        #region Etape 4

          
            public Test_Ctor_Teinte TcT { get; set; }
            public List<Teinte> Lteinte { get; set; }
            public List<Test_Constructeur> LtCtor { get; set; }
            public List<Test_Ctor_Teinte> Ltct { get; set; }


        public void  AjouterTestCtorTeinte(Constructeur ctor)
        {
            Ctor = ctor;
            InitializeComponent();
            this.TBnomAjoutConstructeurEtape4.Text = Ctor.Nom;


            Lteinte = TeinteDB.List(Ctor.Identifiant);
            LtCtor = Test_ConstructeurDB.List(Ctor.Identifiant);


            foreach (Teinte teinte in Lteinte)
            {
                foreach (Test_Constructeur tCtor in LtCtor)
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


            this.LBteinteAjoutConstructeurEtape4.DataSource = Lteinte;
            this.LBteinteAjoutConstructeurEtape4.DisplayMember = "Nom";
            this.LBteinteAjoutConstructeurEtape4.ValueMember = "Identifiant";
            
            this.LBtestCtorAjoutConstructeurEtape4.DataSource = LtCtor;
            this.LBtestCtorAjoutConstructeurEtape4.DisplayMember = "Nom";
            this.LBtestCtorAjoutConstructeurEtape4.ValueMember = "Identifiant";
        }
        private void AjouterTestCtorTeinte_Load(object sender, EventArgs e)
        {
            this.UpdateTestCtor.Visible = false;
        }

        private void LBteinte_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TBteinteAjoutConstructeurEtape4.Text = ((Teinte)this.LBteinteAjoutConstructeurEtape4.SelectedItem).Nom;
            this.UpdateTestCtor.Visible = false;
        }

        private void LBtestCtorE4_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TBtestAjoutConstructeurEtape4.Text = ((Test_Constructeur)this.LBtestCtorAjoutConstructeurEtape4.SelectedItem).Nom;

            TcT = new Test_Ctor_Teinte();
            TcT.ID_Constructeur = ((Test_Constructeur)                                                                          this.LBtestCtorAjoutConstructeurEtape4.SelectedItem).ID_Constructeur;
            TcT.ID_Teinte = ((Teinte)this.LBteinteAjoutConstructeurEtape4.SelectedItem).Identifiant;
            TcT.ID_Test = ((Test_Constructeur)this.LBtestCtorAjoutConstructeurEtape4.SelectedItem).ID_Test;
            TcT.Min = ((Test_Constructeur)this.LBtestCtorAjoutConstructeurEtape4.SelectedItem).Min;
            TcT.Norme = ((Test_Constructeur)this.LBtestCtorAjoutConstructeurEtape4.SelectedItem).Norme;
            TcT.Max = ((Test_Constructeur)this.LBtestCtorAjoutConstructeurEtape4.SelectedItem).Max;

            Test = TestDB.Get(TcT.ID_Test);
            this.TBdescUpdateAjoutConstructeurEtape4.Text = Test.Description;

            switch (Test.TypeTest)
            {
                case 1:
                    this.TBtypeUpdateAjoutConstructeurEtape4.Text = "Minimum et Norme";
                    this.TBminUpdateAjoutConstructeurEtape4.ReadOnly = false;
                    this.TBnormeUpdateAjoutConstructeurEtape4.ReadOnly = false;
                    this.TBmaxUpdateAjoutConstructeurEtape4.ReadOnly = true;

                    this.TBminUpdateAjoutConstructeurEtape4.Text = TcT.Min.ToString();
                    this.TBnormeUpdateAjoutConstructeurEtape4.Text = TcT.Norme.ToString();
                    this.TBmaxUpdateAjoutConstructeurEtape4.Text = "";
                    break;
                case 2:
                    this.TBtypeUpdateAjoutConstructeurEtape4.Text = "Minimum, Norme et Maximum";
                    this.TBminUpdateAjoutConstructeurEtape4.ReadOnly = false;
                    this.TBnormeUpdateAjoutConstructeurEtape4.ReadOnly = false;
                    this.TBmaxUpdateAjoutConstructeurEtape4.ReadOnly = false;

                    this.TBminUpdateAjoutConstructeurEtape4.Text = TcT.Min.ToString();
                    this.TBnormeUpdateAjoutConstructeurEtape4.Text = TcT.Norme.ToString();
                    this.TBmaxUpdateAjoutConstructeurEtape4.Text = TcT.Max.ToString();
                    break;
                case 3:
                    this.TBtypeUpdateAjoutConstructeurEtape4.Text = "Norme et Maximum";
                    this.TBminUpdateAjoutConstructeurEtape4.ReadOnly = true;
                    this.TBnormeUpdateAjoutConstructeurEtape4.ReadOnly = false;
                    this.TBmaxUpdateAjoutConstructeurEtape4.ReadOnly = false;

                    this.TBminUpdateAjoutConstructeurEtape4.Text = "";
                    this.TBnormeUpdateAjoutConstructeurEtape4.Text = TcT.Norme.ToString();
                    this.TBmaxUpdateAjoutConstructeurEtape4.Text = TcT.Max.ToString();
                    break;
                default:
                    break;
            }
            this.UpdateTestCtor.Visible = true;


        }

        private void BvUpdateTestCtorE4_Click(object sender, EventArgs e)
        {
            Double D;

            switch (Test.TypeTest)
            {
                case 1:
                    if (Double.TryParse(this.TBminUpdateAjoutConstructeurEtape4.Text, out D) == true
                     && Double.TryParse(this.TBnormeUpdateAjoutConstructeurEtape4.Text, out D) == true)
                    {
                        this.TestCtorError.Text = "";
                        TcT.Min = Double.Parse(this.TBminUpdateAjoutConstructeurEtape4.Text);
                        TcT.Norme = Double.Parse(this.TBnormeUpdateAjoutConstructeurEtape4.Text);
                        Test_Ctor_TeinteDB.Update(TcT);
                        this.UpdateTestCtor.Visible = false;
                    }
                    else
                    {
                        this.TestCtorError.Text = "Erreur de saisie, concernant les valeurs du test";
                    }
                    break;
                case 2:
                    if (Double.TryParse(this.TBminUpdateAjoutConstructeurEtape4.Text, out D) == true
                     && Double.TryParse(this.TBnormeUpdateAjoutConstructeurEtape4.Text, out D) == true
                     && Double.TryParse(this.TBmaxUpdateAjoutConstructeurEtape4.Text, out D) == true)
                    {
                        this.TestCtorError.Text = "";
                        TcT.Min = Double.Parse(this.TBminUpdateAjoutConstructeurEtape4.Text);
                        TcT.Norme = Double.Parse(this.TBnormeUpdateAjoutConstructeurEtape4.Text);
                        TcT.Max = Double.Parse(this.TBmaxUpdateAjoutConstructeurEtape4.Text);
                        Test_Ctor_TeinteDB.Update(TcT);
                        this.UpdateTestCtor.Visible = false;
                    }
                    else
                    {
                        this.TestCtorError.Text = "Erreur de saisie, concernant les valeurs du test";
                    }
                    break;
                case 3:
                    if (Double.TryParse(this.TBnormeUpdateAjoutConstructeurEtape4.Text, out D) == true
                     && Double.TryParse(this.TBmaxUpdateAjoutConstructeurEtape4.Text, out D) == true)
                    {
                        this.TestCtorError.Text = "";
                        TcT.Norme = Double.Parse(this.TBnormeUpdateAjoutConstructeurEtape4.Text);
                        TcT.Max = Double.Parse(this.TBmaxUpdateAjoutConstructeurEtape4.Text);
                        Test_Ctor_TeinteDB.Update(TcT);
                        this.UpdateTestCtor.Visible = false;

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

        private void Bterminer_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            this.Close();
        }

            private void BterminerAjoutConstructeurEtape4_Click(object sender, EventArgs e)
            {
                this.Close();
            }




        #endregion

    }
}
