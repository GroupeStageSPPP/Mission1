using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QualiteSPPP.WinForm
{
    public partial class QuitterConfirmation : Form
    {
        public QuitterConfirmation()
        {
            InitializeComponent();
        }

        private void buttonQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
