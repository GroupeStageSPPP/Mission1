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
    public partial class AjouterPeinture : Form
    {
        public AjouterPeinture()
        {
            InitializeComponent();
        }

        private void buttonAjouterADMINISTRATIONPeinture_Click(object sender, EventArgs e)
        {
            Teinte T = new Teinte();
            T.RisqueTeinte = this.TBrisque.Text;
            T.ReferenceBase = this.TBrefBase.Text;
            T.L = (Int32)this.NumBN.Value;
            T.A = (Int32)this.NumRV.Value;
            T.B = (Int32)this.NumJB.Value;
            T.Min = Int32.Parse(this.TBmin.Text);
            T.Norme = Int32.Parse(this.TBnorme.Text);
            T.Max = Int32.Parse(this.TBmax.Text);
            T.ID_Constructeur = (Int32)this.CBctor.SelectedValue;
            T.ID_Appret = (Int32)this.CBappret.SelectedValue;
            T.ID_Vernis = (Int32)this.CBvernis.SelectedValue;
            TeinteDB.Insert(T);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
