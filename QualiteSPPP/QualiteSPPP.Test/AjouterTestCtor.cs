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

namespace QualiteSPPP.Alpha
{
    public partial class AjouterTestCtor : Form
    {
        public Constructeur Ctor { get; set; }
        public Test Test { get; set; }
        public Test_Constructeur Tctor { get; set; }
        
        public AjouterTestCtor(Constructeur ctor)
        {
            Ctor = ctor;
            Tctor = new Test_Constructeur();
            Test = new Test();
            Tctor.ID_Constructeur = Ctor.Identifiant;
            
            InitializeComponent();
            this.TBnom.Text = Ctor.Nom;
            this.AddTestCtor.Visible = false;
            this.UpdateTestCtor.Visible = false;
        }

        private void AjouterTestCtor_Load(object sender, EventArgs e)
        {
            RefreshListeEtComboBox();

        }

        private void RefreshListeEtComboBox()
        {
            this.LBtest.DataSource = TestDB.List();
            this.LBtest.DisplayMember = "Nom";
            this.LBtest.ValueMember = "Identifiant";

            this.LBtestCtor.DataSource = Test_ConstructeurDB.List(Ctor.Identifiant);
            this.LBtestCtor.DisplayMember = "Nom";
            this.LBtestCtor.ValueMember = "Identifiant";

        }

        private void BaddTestCtor_Click(object sender, EventArgs e)
        {
            if (this.LBtest.SelectedIndex != -1 && this.UpdateTestCtor.Visible == false)
            {
                this.AddTestCtor.Visible = true;
            }
            else
            {
                if ( this.UpdateTestCtor.Visible == true)
                {
                    this.TestCtorError.Text = "Finissez de modifier le test!";
                }
                else
                {
                    this.TestCtorError.Text = "Selectionnez un test à ajouter!";
                }
                
            }
        }

        private void BupdateTestCtor_Click(object sender, EventArgs e)
        {
            if (this.LBtestCtor.SelectedIndex != -1 && this.AddTestCtor.Visible == false)
            {

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

        private void BvAddTestCtor_Click(object sender, EventArgs e)
        {
            Double D;

            switch (Test.TypeTest)
            {
                case 1:
                    if (Double.TryParse(this.TBminAdd.Text, out D) == true
                     && Double.TryParse(this.TBnormeAdd.Text, out D) == true)
                    {
                        this.TestCtorError.Text = "";
                        Tctor.Min = Double.Parse(this.TBminAdd.Text);
                        Tctor.Norme = Double.Parse(this.TBnormeAdd.Text);
                        Test_ConstructeurDB.Insert(Tctor);
                        this.AddTestCtor.Visible = false;
                        RefreshListeEtComboBox();
                    }
                    else
                    {
                        this.TestCtorError.Text = "Erreur de saisie, concernant les valeurs du test";
                    }
                    break;
                case 2:
                    if (Double.TryParse(this.TBminAdd.Text, out D) == true
                     && Double.TryParse(this.TBnormeAdd.Text, out D) == true
                     && Double.TryParse(this.TBmaxAdd.Text, out D) == true)
                    {
                        this.TestCtorError.Text = "";
                        Tctor.Min = Double.Parse(this.TBminAdd.Text);
                        Tctor.Norme = Double.Parse(this.TBnormeAdd.Text);
                        Tctor.Max =Double.Parse(this.TBmaxAdd.Text); 
                        Test_ConstructeurDB.Insert(Tctor);
                        this.AddTestCtor.Visible = false;
                        RefreshListeEtComboBox();
                    }
                    else
                    {
                        this.TestCtorError.Text = "Erreur de saisie, concernant les valeurs du test";
                    }
                    break;
                case 3:
                    if (Double.TryParse(this.TBnormeAdd.Text, out D) == true
                     && Double.TryParse(this.TBmaxAdd.Text, out D) == true)
                    {
                        this.TestCtorError.Text = "";
                        Tctor.Norme = Double.Parse(this.TBnormeAdd.Text);
                        Tctor.Max =Double.Parse(this.TBmaxAdd.Text); 
                        Test_ConstructeurDB.Insert(Tctor);
                        this.AddTestCtor.Visible = false;
                        RefreshListeEtComboBox();
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

        private void BaAddTestCtor_Click(object sender, EventArgs e)
        {
            this.TestCtorError.Text = "";
            this.AddTestCtor.Visible = false;
        }

        private void BvUpdateTestCtor_Click(object sender, EventArgs e)
        {
            Double D;

            switch (Test.TypeTest)
            {
                case 1:
                    if (Double.TryParse(this.TBminUpdate.Text, out D) == true
                     && Double.TryParse(this.TBnormeUpdate.Text, out D) == true)
                    {
                        this.TestCtorError.Text = "";
                        Tctor.Min = Double.Parse(this.TBminUpdate.Text);
                        Tctor.Norme = Double.Parse(this.TBnormeUpdate.Text);
                        Test_ConstructeurDB.Insert(Tctor);
                        this.UpdateTestCtor.Visible = false;
                        RefreshListeEtComboBox();
                    }
                    else
                    {
                        this.TestCtorError.Text = "Erreur de saisie, concernant les valeurs du test";
                    }
                    break;
                case 2:
                    if (Double.TryParse(this.TBminUpdate.Text, out D) == true
                     && Double.TryParse(this.TBnormeUpdate.Text, out D) == true
                     && Double.TryParse(this.TBmaxUpdate.Text, out D) == true)
                    {
                        this.TestCtorError.Text = "";
                        Tctor.Min = Double.Parse(this.TBminUpdate.Text);
                        Tctor.Norme = Double.Parse(this.TBnormeUpdate.Text);
                        Tctor.Max = Double.Parse(this.TBmaxUpdate.Text);
                        Test_ConstructeurDB.Insert(Tctor);
                        this.UpdateTestCtor.Visible = false;
                        RefreshListeEtComboBox();
                    }
                    else
                    {
                        this.TestCtorError.Text = "Erreur de saisie, concernant les valeurs du test";
                    }
                    break;
                case 3:
                    if (Double.TryParse(this.TBnormeUpdate.Text, out D) == true
                     && Double.TryParse(this.TBmaxUpdate.Text, out D) == true)
                    {
                        this.TestCtorError.Text = "";
                        Tctor.Norme = Double.Parse(this.TBnormeUpdate.Text);
                        Tctor.Max = Double.Parse(this.TBmaxUpdate.Text);
                        Test_ConstructeurDB.Insert(Tctor);
                        this.UpdateTestCtor.Visible = false;
                        RefreshListeEtComboBox();
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

        private void BaUpdateTestCtor_Click(object sender, EventArgs e)
        {
            this.TestCtorError.Text = "";
            this.UpdateTestCtor.Visible = false;
        }

        private void LBtest_SelectedIndexChanged(object sender, EventArgs e)
        {
            Test = (Test)this.LBtest.SelectedItem;
            Tctor.ID_Test = Test.Identifiant;

            this.TBdescAdd.Text = Test.Description;
            switch (Test.TypeTest)
            {
                case 1:
                    this.TBtypeAdd.Text = "Minimum et Norme";
                    this.TBminAdd.ReadOnly = false;
                    this.TBnormeAdd.ReadOnly = false;
                    this.TBmaxAdd.ReadOnly = true;
                    break;
                case 2:
                    this.TBtypeAdd.Text = "Minimum, Norme et Maximum";
                    this.TBminAdd.ReadOnly = false;
                    this.TBnormeAdd.ReadOnly = false;
                    this.TBmaxAdd.ReadOnly = false;
                    break;
                case 3:
                    this.TBtypeAdd.Text = "Norme et Maximum";
                    this.TBminAdd.ReadOnly = true;
                    this.TBnormeAdd.ReadOnly = false;
                    this.TBmaxAdd.ReadOnly = false;
                    break;
                default:
                    break;
            }
            this.TBminAdd.Text = "";
            this.TBnormeAdd.Text = "";
            this.TBmaxAdd.Text = "";
            this.TestCtorError.Text = "";
        }

        private void LBtestCtor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Test_Constructeur tCtor = (Test_Constructeur)this.LBtestCtor.SelectedItem;
            Test = TestDB.Get(tCtor.ID_Test);
            Tctor = tCtor;

            this.TBdescUpdate.Text = Test.Description;
            switch (Test.TypeTest)
            {
                case 1:
                    this.TBtypeUpdate.Text = "Minimum et Norme";
                    this.TBminUpdate.ReadOnly = false;
                    this.TBnormeUpdate.ReadOnly = false;
                    this.TBmaxUpdate.ReadOnly = true;

                    this.TBminUpdate.Text = tCtor.Min.ToString();
                    this.TBnormeUpdate.Text = tCtor.Norme.ToString();
                    this.TBmaxUpdate.Text = "";
                    break;
                case 2:
                    this.TBtypeUpdate.Text = "Minimum, Norme et Maximum";
                    this.TBminUpdate.ReadOnly = false;
                    this.TBnormeUpdate.ReadOnly = false;
                    this.TBmaxUpdate.ReadOnly = false;

                    this.TBminUpdate.Text = tCtor.Min.ToString();
                    this.TBnormeUpdate.Text = tCtor.Norme.ToString();
                    this.TBmaxUpdate.Text = tCtor.Max.ToString();
                    break;
                case 3:
                    this.TBtypeUpdate.Text = "Norme et Maximum";
                    this.TBminUpdate.ReadOnly = true;
                    this.TBnormeUpdate.ReadOnly = false;
                    this.TBmaxUpdate.ReadOnly = false;

                    this.TBminUpdate.Text = "";
                    this.TBnormeUpdate.Text = tCtor.Norme.ToString();
                    this.TBmaxUpdate.Text = tCtor.Max.ToString();
                    break;
                default:
                    break;
            }

            this.TestCtorError.Text = "";
        }

        private void Bsuivant_Click(object sender, EventArgs e)
        {
            this.Close();
            AjouterTestCtor ATC = new AjouterTestCtor(Ctor);
            ATC.ShowDialog();
        }
    }
}
