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

namespace QualiteSPPP.WF
{
    public partial class CreerConstructeur : Form
    {
        public Constructeur Ctor { get; set; }
        public Teinte Teinte { get; set; }
        public List<Teinte> LTeinte { get; set; }
        public List<Appret> LAppret { get; set; }
        public List<Vernis> LVernis { get; set; }
        public int SizeLT { get; set; }

        public CreerConstructeur()
        {
            Ctor = new Constructeur();
            Teinte = new Teinte();
            Ctor.Nom = "DEFAULT";
            ConstructeurDB.Insert(Ctor);
            Ctor.Identifiant = ConstructeurDB.LastID();
            InitializeComponent();
        }

        private void CreerConstructeur_Load(object sender, EventArgs e)
        {
            this.LBteinte.DataSource = TeinteDB.List(Ctor.Identifiant);
            this.LBteinte.DisplayMember = "Nom";
            this.LBteinte.ValueMember = "Identifiant";

            this.CBappretAdd.DataSource = AppretDB.List();
            this.CBappretAdd.DisplayMember = "Reference";
            this.CBappretAdd.ValueMember = "Identifiant";

            this.CBvernisAdd.DataSource = VernisDB.List();
            this.CBvernisAdd.DisplayMember = "Reference";
            this.CBvernisAdd.ValueMember = "Identifiant";

            this.CBappretUpdate.DataSource = AppretDB.List();
            this.CBappretUpdate.DisplayMember = "Reference";
            this.CBappretUpdate.ValueMember = "Identifiant";
            this.CBvernisUpdate.DataSource = VernisDB.List();
            this.CBvernisUpdate.DisplayMember = "Reference";
            this.CBvernisUpdate.ValueMember = "Identifiant";

            this.TeinteError.Text = "";
        }



        private void BaddTeinte_Click(object sender, EventArgs e)
        {
            if (this.UpdateTeinte.Visible == false)
            {
                this.UpdateTeinte.Visible = false;
                this.TBnomAdd.Text = "";
                this.TBrisqueAdd.Text = "";
                this.TBrefBaseAdd.Text = "";
                this.NumBNadd.Value = 0;
                this.NumRVadd.Value = 0;
                this.NumJBadd.Value = 0;
                this.TBminAdd.Text = "0";
                this.TBnormeAdd.Text = "0";
                this.TBmaxAdd.Text = "0";
                this.CBappretAdd.SelectedIndex = 0;
                this.CBvernisAdd.SelectedIndex = 0;
                this.AddTeinte.Visible = true;  
            }
            else
            {
                this.TeinteError.Text = "Veuillez finir de modifier la teinte avant d'en ajouter une nouvelle";
            }    
                
            
        }

        private void BupdateTeinte_Click(object sender, EventArgs e)
        {
            if (this.LBteinte.SelectedIndex != -1 && this.AddTeinte.Visible == false)
            {
                Teinte = TeinteDB.Get(Int32.Parse(this.LBteinte.SelectedValue.ToString()));
                this.UpdateTeinte.Visible = false;
                this.TBnomUpdate.Text = Teinte.Nom;
                this.TBrisqueUpdate.Text = Teinte.RisqueTeinte;
                this.TBrefBaseUpdate.Text = Teinte.ReferenceBase;
                this.NumBNupdate.Value = Teinte.L;
                this.NumRVupdate.Value = Teinte.A;
                this.NumJBupdate.Value = Teinte.B;
                this.TBminUpdate.Text = Teinte.Min.ToString();
                this.TBnormeUpdate.Text = Teinte.Norme.ToString();
                this.TBmaxUpdate.Text = Teinte.Max.ToString();
                this.TBupdateAppret.Text = (AppretDB.Get(Teinte.ID_Appret)).Reference;
                this.TBupdateVernis.Text = (VernisDB.Get(Teinte.ID_Vernis)).Reference;
                this.UpdateTeinte.Visible = true;

            }
            else
            {
                this.TeinteError.Text = "Veuillez finir la creation d'une nouvelle teinte.\n Ou veuillez selectionner une teinte a modifier";
            }
                
                
                

        }

        private void Bsuivant_Click(object sender, EventArgs e)
        {
            if (this.TBnom.Text != "")
            {
                Ctor.Nom = this.TBnom.Text;
                ConstructeurDB.Update(Ctor);
                this.Close();
                //AjouterTestCtor ATC = new AjouterTestCtor(Ctor);
                //ATC.ShowDialog();
            }
            else
            {
                this.TeinteError.Text = "Veuillez renseigner le nom du constructeur";
            }
        }

        private void BvAddTeinte_Click(object sender, EventArgs e)
        {
            if (this.TBnomAdd.Text != "" 
             && this.TBrisqueAdd.Text != "" 
             && this.TBrefBaseAdd.Text != "" 
             && this.TBminAdd.Text != "" 
             && this.TBnormeAdd.Text != "" 
             && this.TBmaxAdd.Text != "")
            {
                Double D;
                if (Double.TryParse(this.TBminAdd.Text, out D) == true
                 && Double.TryParse(this.TBnormeAdd.Text, out D) == true
                 && Double.TryParse(this.TBmaxAdd.Text, out D) == true)
                {
                    this.TeinteError.Text = "";
                    Teinte teinte = new Teinte();
                    teinte.Nom = this.TBnomAdd.Text;
                    teinte.RisqueTeinte = this.TBrisqueAdd.Text;
                    teinte.ReferenceBase = this.TBrefBaseAdd.Text;
                    teinte.L = (Int32)this.NumBNadd.Value;
                    teinte.A = (Int32)this.NumRVadd.Value;
                    teinte.B = (Int32)this.NumJBadd.Value;
                    teinte.Min   = Double.Parse(this.TBminAdd.Text);
                    teinte.Norme = Double.Parse(this.TBnormeAdd.Text);
                    teinte.Max   = Double.Parse(this.TBmaxAdd.Text);
                    teinte.ID_Appret = Int32.Parse(this.CBappretAdd.SelectedValue.ToString());
                    teinte.ID_Vernis = Int32.Parse(this.CBvernisAdd.SelectedValue.ToString());
                    teinte.ID_Constructeur = Ctor.Identifiant;
                    TeinteDB.Insert(teinte);
                    this.AddTeinte.Visible = false;
                    RefreshListeTeinte();
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
                if (this.TBnomUpdate.Text != ""
                && this.TBrisqueUpdate.Text != ""
                && this.TBrefBaseUpdate.Text != ""
                && this.TBminUpdate.Text != ""
                && this.TBnormeUpdate.Text != ""
                && this.TBmaxUpdate.Text != "")
                {
                    Double D;
                    if (Double.TryParse(this.TBminUpdate.Text, out D) == true
                     && Double.TryParse(this.TBnormeUpdate.Text, out D) == true
                     && Double.TryParse(this.TBmaxUpdate.Text, out D) == true)
                    {
                        this.TeinteError.Text = "";
                        Teinte teinte = Teinte;
                        teinte.Nom = this.TBnomUpdate.Text;
                        teinte.RisqueTeinte = this.TBrisqueUpdate.Text;
                        teinte.ReferenceBase = this.TBrefBaseUpdate.Text;
                        teinte.L = (Int32)this.NumBNadd.Value;
                        teinte.A = (Int32)this.NumRVadd.Value;
                        teinte.B = (Int32)this.NumJBadd.Value;
                        teinte.Min = Double.Parse(this.TBminUpdate.Text);
                        teinte.Norme = Double.Parse(this.TBnormeUpdate.Text);
                        teinte.Max = Double.Parse(this.TBmaxUpdate.Text);
                        teinte.ID_Appret = Int32.Parse(this.CBappretUpdate.SelectedValue.ToString());
                        teinte.ID_Vernis = Int32.Parse(this.CBvernisUpdate.SelectedValue.ToString());
                        teinte.ID_Constructeur = Ctor.Identifiant;
                        TeinteDB.Update(teinte);
                        this.UpdateTeinte.Visible = false;
                        RefreshListeTeinte();
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

            private void RefreshListeTeinte()
            {
                this.LBteinte.DataSource = TeinteDB.List(Ctor.Identifiant);
                this.LBteinte.DisplayMember = "Nom";
                this.LBteinte.ValueMember = "Identifiant";
            }
    }
}
