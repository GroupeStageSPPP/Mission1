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
    public partial class AjouterCategorie : Form
    {
        public AjouterCategorie()
        {
            InitializeComponent();
        }

        private void buttonRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            Categorie C = new Categorie();
            C.Nom = this.TBnom.Text;
            CategorieDB.Insert(C);
            this.Close();
        }
    }
}
