using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QualiteSPPP.WinForm
{
    public partial class AjoutProjet : Form
    {
        public AjoutProjet()
        {
            InitializeComponent();
        }

        private void AjoutProjet_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PiecePeintureProjet PPP = new PiecePeintureProjet();
            this.Hide();
            PPP.ShowDialog();
        }
    }
}
