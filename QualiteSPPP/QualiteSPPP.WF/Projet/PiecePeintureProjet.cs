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
    public partial class PiecePeintureProjet : Form
    {
        public PiecePeintureProjet()
        {
            InitializeComponent();
        }

        private void PiecePeintureProjet_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            TestPiecePeinture TPP = new TestPiecePeinture();
            this.Hide();
            TPP.ShowDialog();
        }
    }
}
