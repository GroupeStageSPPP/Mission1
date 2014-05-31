using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace QualiteSPPP.WinForm
{
    public partial class GraphiquePeinture : Form
    {
        public GraphiquePeinture()
        {
            InitializeComponent();
        }

        public void Page_Load(object sender, EventArgs e)
        {
            Double donnéeDeCourbe = 6.5;

            double[] x        = new double[100];
            double[] maximum  = new double[100];
            double[] minimum  = new double[100];
            double[] moyenne  = new double[100];
            double[] variable = new double[100];

            for (int i = 0; i < x.Length; i++)
            {
                x[i] = i;
                maximum[i] = 9;
                minimum[i] = 3;
                moyenne[i] = 6;
                variable[i] = donnéeDeCourbe;
            }

            // This is to remove all plots
            zedGraphControl1.GraphPane.CurveList.Clear();


            GraphPane myPane = zedGraphControl1.GraphPane;



            // Définis la liste des points
            PointPairList spl1 = new PointPairList(x, maximum);
            PointPairList spl2 = new PointPairList(x, minimum);
            PointPairList spl3 = new PointPairList(x, moyenne);
            PointPairList spl4 = new PointPairList(x, variable);



            // Ajouter les lignes a mon graphique
            LineItem myCurve1 = myPane.AddCurve("", spl1, Color.DarkBlue, SymbolType.None);
            LineItem myCurve2 = myPane.AddCurve("Minimum Maximum", spl2, Color.DarkBlue, SymbolType.None);
            LineItem myCurve3 = myPane.AddCurve("moyenne", spl3, Color.Black, SymbolType.None);
            LineItem myCurve4 = myPane.AddCurve("Resultat", spl4, Color.ForestGreen, SymbolType.Diamond);


            myCurve1.Line.Width = 2.0F;
            myCurve2.Line.Width = 2.0F;
            myCurve3.Line.Width = 2.0F;
            myCurve4.Line.Width = 2.0F;

            myPane.Title.Text = "Graphique épaisseur peinture";
            myPane.XAxis.Title.Text = "Test";
            myPane.YAxis.Title.Text = "Epaisseur peinture";
            myPane.Legend.Position = ZedGraph.LegendPos.Bottom;

            // I add all three functions just to be sure it refeshes the plot.   
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl1.Refresh();
        }
    }
}
