namespace QualiteSPPP.WinForm
{
    partial class Graphiques
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Graphiques));
            this.panelGraphMinMilMax = new System.Windows.Forms.Panel();
            this.panelGraphMinMil = new System.Windows.Forms.Panel();
            this.panelGraphMilMax = new System.Windows.Forms.Panel();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panelGraphMinMilMax.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGraphMinMilMax
            // 
            this.panelGraphMinMilMax.Controls.Add(this.button2);
            this.panelGraphMinMilMax.Controls.Add(this.button1);
            this.panelGraphMinMilMax.Controls.Add(this.label2);
            this.panelGraphMinMilMax.Controls.Add(this.label1);
            this.panelGraphMinMilMax.Controls.Add(this.zedGraphControl1);
            this.panelGraphMinMilMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGraphMinMilMax.Location = new System.Drawing.Point(0, 0);
            this.panelGraphMinMilMax.Name = "panelGraphMinMilMax";
            this.panelGraphMinMilMax.Size = new System.Drawing.Size(1261, 541);
            this.panelGraphMinMilMax.TabIndex = 0;
            // 
            // panelGraphMinMil
            // 
            this.panelGraphMinMil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGraphMinMil.Location = new System.Drawing.Point(0, 0);
            this.panelGraphMinMil.Name = "panelGraphMinMil";
            this.panelGraphMinMil.Size = new System.Drawing.Size(1261, 541);
            this.panelGraphMinMil.TabIndex = 1;
            // 
            // panelGraphMilMax
            // 
            this.panelGraphMilMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGraphMilMax.Location = new System.Drawing.Point(0, 0);
            this.panelGraphMilMax.Name = "panelGraphMilMax";
            this.panelGraphMilMax.Size = new System.Drawing.Size(1261, 541);
            this.panelGraphMilMax.TabIndex = 1;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(12, 12);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(838, 517);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(866, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(866, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(940, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(940, 150);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // Graphiques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 541);
            this.Controls.Add(this.panelGraphMinMilMax);
            this.Controls.Add(this.panelGraphMinMil);
            this.Controls.Add(this.panelGraphMilMax);
            this.Name = "Graphiques";
            this.Text = "Graphiques";
            this.panelGraphMinMilMax.ResumeLayout(false);
            this.panelGraphMinMilMax.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGraphMinMilMax;
        private System.Windows.Forms.Panel panelGraphMinMil;
        private System.Windows.Forms.Panel panelGraphMilMax;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}