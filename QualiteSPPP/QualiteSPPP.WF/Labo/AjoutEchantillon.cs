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
    public partial class AjoutEchantillon : Form
    {
        public AjoutEchantillon()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResultatTest RT = new ResultatTest();
            this.Hide();
            RT.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
