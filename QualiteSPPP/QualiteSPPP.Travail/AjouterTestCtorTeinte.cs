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

namespace QualiteSPPP.Travail
{
    public partial class AjouterTestCtorTeinte : Form
    {
        public Constructeur Ctor { get; set; }
        public Test Test { get; set; }
        public Teinte Teinte { get; set; }
        public Test_Constructeur Tctor { get; set; }
        public Test_Ctor_Teinte TcT { get; set; }
        
        public List<Teinte> Lteinte { get; set; }
        public List<Test_Constructeur> LtCtor { get; set; }
        public List<Test_Ctor_Teinte> Ltct { get; set; }


        public AjouterTestCtorTeinte(Constructeur ctor)
        {
            Ctor = ctor;
            InitializeComponent();
            this.TBnom.Text = Ctor.Nom;


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


            this.LBteinte.DataSource = Lteinte;
            this.LBteinte.ValueMember= "Nom";
            this.LBteinte.DisplayMember = "Identifiant";
            
            this.LBtestCtor.DataSource = LtCtor;
            this.LBtestCtor.ValueMember = "Nom";
            this.LBtestCtor.DisplayMember = "Identifiant";
        }


        private void AjouterTestCtorTeinte_Load(object sender, EventArgs e)
        {
            this.UpdateTestCtor.Visible = false;
        }

        private void LBteinte_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TBteinte.Text = ((Teinte)this.LBteinte.SelectedItem).Nom;
            this.UpdateTestCtor.Visible = false;
        }

        private void LBtestCtor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TBtest.Text = ((Test_Constructeur)this.LBtestCtor.SelectedItem).Nom;

            TcT = new Test_Ctor_Teinte();
            TcT.ID_Constructeur = ((Test_Constructeur)this.LBtestCtor.SelectedItem).ID_Constructeur;
            TcT.ID_Teinte = ((Teinte)this.LBteinte.SelectedItem).Identifiant;
            TcT.ID_Test = ((Test_Constructeur)this.LBtestCtor.SelectedItem).ID_Test;
            TcT.Min = ((Test_Constructeur)this.LBtestCtor.SelectedItem).Min;
            TcT.Norme = ((Test_Constructeur)this.LBtestCtor.SelectedItem).Norme;
            TcT.Max = ((Test_Constructeur)this.LBtestCtor.SelectedItem).Max;

            Test = TestDB.Get(TcT.ID_Test);
            this.TBdescUpdate.Text = Test.Description;
            
            switch (Test.TypeTest)
            {
                case 1:
                    this.TBtypeUpdate.Text = "Minimum et Norme";
                    this.TBminUpdate.ReadOnly = false;
                    this.TBnormeUpdate.ReadOnly = false;
                    this.TBmaxUpdate.ReadOnly = true;

                    this.TBminUpdate.Text = TcT.Min.ToString();
                    this.TBnormeUpdate.Text = TcT.Norme.ToString();
                    this.TBmaxUpdate.Text = "";
                    break;
                case 2:
                    this.TBtypeUpdate.Text = "Minimum, Norme et Maximum";
                    this.TBminUpdate.ReadOnly = false;
                    this.TBnormeUpdate.ReadOnly = false;
                    this.TBmaxUpdate.ReadOnly = false;

                    this.TBminUpdate.Text = TcT.Min.ToString();
                    this.TBnormeUpdate.Text = TcT.Norme.ToString();
                    this.TBmaxUpdate.Text = TcT.Max.ToString();
                    break;
                case 3:
                    this.TBtypeUpdate.Text = "Norme et Maximum";
                    this.TBminUpdate.ReadOnly = true;
                    this.TBnormeUpdate.ReadOnly = false;
                    this.TBmaxUpdate.ReadOnly = false;

                    this.TBminUpdate.Text = "";
                    this.TBnormeUpdate.Text = TcT.Norme.ToString();
                    this.TBmaxUpdate.Text = TcT.Max.ToString();
                    break;
                default:
                    break;
            }
            this.UpdateTestCtor.Visible = true;


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
                        TcT.Min = Double.Parse(this.TBminUpdate.Text);
                        TcT.Norme = Double.Parse(this.TBnormeUpdate.Text);
                        Test_Ctor_TeinteDB.Update(TcT);
                        this.UpdateTestCtor.Visible = false;
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
                        TcT.Min = Double.Parse(this.TBminUpdate.Text);
                        TcT.Norme = Double.Parse(this.TBnormeUpdate.Text);
                        TcT.Max = Double.Parse(this.TBmaxUpdate.Text);
                        Test_Ctor_TeinteDB.Update(TcT);
                        this.UpdateTestCtor.Visible = false;
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
                        TcT.Norme = Double.Parse(this.TBnormeUpdate.Text);
                        TcT.Max = Double.Parse(this.TBmaxUpdate.Text);
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
    }
}
