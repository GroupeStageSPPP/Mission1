namespace QualiteSPPP.Travail
{
    partial class AjouterTestCtorTeinte
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
            this.TestCtorError = new System.Windows.Forms.Label();
            this.Bsuivant = new System.Windows.Forms.Button();
            this.LBtestCtor = new System.Windows.Forms.ListBox();
            this.LBteinte = new System.Windows.Forms.ListBox();
            this.LBtest = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBnom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UpdateTestCtor = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TBmaxUpdate = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TBnormeUpdate = new System.Windows.Forms.TextBox();
            this.TBminUpdate = new System.Windows.Forms.TextBox();
            this.TBtypeUpdate = new System.Windows.Forms.TextBox();
            this.TBdescUpdate = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.BvUpdateTestCtor = new System.Windows.Forms.Button();
            this.TBteinte = new System.Windows.Forms.TextBox();
            this.TBtest = new System.Windows.Forms.TextBox();
            this.UpdateTestCtor.SuspendLayout();
            this.SuspendLayout();
            // 
            // TestCtorError
            // 
            this.TestCtorError.AutoSize = true;
            this.TestCtorError.ForeColor = System.Drawing.Color.Red;
            this.TestCtorError.Location = new System.Drawing.Point(495, 50);
            this.TestCtorError.Name = "TestCtorError";
            this.TestCtorError.Size = new System.Drawing.Size(29, 13);
            this.TestCtorError.TabIndex = 106;
            this.TestCtorError.Text = "Error";
            // 
            // Bsuivant
            // 
            this.Bsuivant.Location = new System.Drawing.Point(475, 357);
            this.Bsuivant.Name = "Bsuivant";
            this.Bsuivant.Size = new System.Drawing.Size(257, 107);
            this.Bsuivant.TabIndex = 102;
            this.Bsuivant.Text = "Suivant";
            this.Bsuivant.UseVisualStyleBackColor = true;
            // 
            // LBtestCtor
            // 
            this.LBtestCtor.FormattingEnabled = true;
            this.LBtestCtor.Location = new System.Drawing.Point(245, 73);
            this.LBtestCtor.Name = "LBtestCtor";
            this.LBtestCtor.Size = new System.Drawing.Size(157, 394);
            this.LBtestCtor.TabIndex = 100;
            this.LBtestCtor.SelectedIndexChanged += new System.EventHandler(this.LBtestCtor_SelectedIndexChanged);
            // 
            // LBteinte
            // 
            this.LBteinte.FormattingEnabled = true;
            this.LBteinte.Location = new System.Drawing.Point(7, 73);
            this.LBteinte.Name = "LBteinte";
            this.LBteinte.Size = new System.Drawing.Size(157, 394);
            this.LBteinte.TabIndex = 101;
            this.LBteinte.SelectedIndexChanged += new System.EventHandler(this.LBteinte_SelectedIndexChanged);
            // 
            // LBtest
            // 
            this.LBtest.AutoSize = true;
            this.LBtest.Location = new System.Drawing.Point(242, 50);
            this.LBtest.Name = "LBtest";
            this.LBtest.Size = new System.Drawing.Size(77, 13);
            this.LBtest.TabIndex = 98;
            this.LBtest.Text = "Liste des tests ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 99;
            this.label2.Text = "Liste des teintes";
            // 
            // TBnom
            // 
            this.TBnom.Location = new System.Drawing.Point(120, 9);
            this.TBnom.Name = "TBnom";
            this.TBnom.ReadOnly = true;
            this.TBnom.Size = new System.Drawing.Size(114, 20);
            this.TBnom.TabIndex = 97;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 96;
            this.label1.Text = "Nom du constructeur";
            // 
            // UpdateTestCtor
            // 
            this.UpdateTestCtor.Controls.Add(this.TBtest);
            this.UpdateTestCtor.Controls.Add(this.TBteinte);
            this.UpdateTestCtor.Controls.Add(this.label9);
            this.UpdateTestCtor.Controls.Add(this.label10);
            this.UpdateTestCtor.Controls.Add(this.TBmaxUpdate);
            this.UpdateTestCtor.Controls.Add(this.label11);
            this.UpdateTestCtor.Controls.Add(this.TBnormeUpdate);
            this.UpdateTestCtor.Controls.Add(this.TBminUpdate);
            this.UpdateTestCtor.Controls.Add(this.TBtypeUpdate);
            this.UpdateTestCtor.Controls.Add(this.TBdescUpdate);
            this.UpdateTestCtor.Controls.Add(this.label12);
            this.UpdateTestCtor.Controls.Add(this.label13);
            this.UpdateTestCtor.Controls.Add(this.BvUpdateTestCtor);
            this.UpdateTestCtor.Location = new System.Drawing.Point(475, 73);
            this.UpdateTestCtor.Margin = new System.Windows.Forms.Padding(0);
            this.UpdateTestCtor.Name = "UpdateTestCtor";
            this.UpdateTestCtor.Size = new System.Drawing.Size(257, 281);
            this.UpdateTestCtor.TabIndex = 108;
            this.UpdateTestCtor.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 100;
            this.label9.Text = "Maximum";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 13);
            this.label10.TabIndex = 101;
            this.label10.Text = "Recommandation";
            // 
            // TBmaxUpdate
            // 
            this.TBmaxUpdate.Location = new System.Drawing.Point(104, 203);
            this.TBmaxUpdate.Name = "TBmaxUpdate";
            this.TBmaxUpdate.Size = new System.Drawing.Size(150, 20);
            this.TBmaxUpdate.TabIndex = 97;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(50, 151);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 102;
            this.label11.Text = "Minimum";
            // 
            // TBnormeUpdate
            // 
            this.TBnormeUpdate.Location = new System.Drawing.Point(104, 177);
            this.TBnormeUpdate.Name = "TBnormeUpdate";
            this.TBnormeUpdate.Size = new System.Drawing.Size(150, 20);
            this.TBnormeUpdate.TabIndex = 98;
            // 
            // TBminUpdate
            // 
            this.TBminUpdate.Location = new System.Drawing.Point(104, 151);
            this.TBminUpdate.Name = "TBminUpdate";
            this.TBminUpdate.Size = new System.Drawing.Size(150, 20);
            this.TBminUpdate.TabIndex = 99;
            // 
            // TBtypeUpdate
            // 
            this.TBtypeUpdate.Location = new System.Drawing.Point(104, 117);
            this.TBtypeUpdate.Name = "TBtypeUpdate";
            this.TBtypeUpdate.ReadOnly = true;
            this.TBtypeUpdate.Size = new System.Drawing.Size(150, 20);
            this.TBtypeUpdate.TabIndex = 96;
            // 
            // TBdescUpdate
            // 
            this.TBdescUpdate.Location = new System.Drawing.Point(104, 64);
            this.TBdescUpdate.Name = "TBdescUpdate";
            this.TBdescUpdate.ReadOnly = true;
            this.TBdescUpdate.Size = new System.Drawing.Size(150, 47);
            this.TBdescUpdate.TabIndex = 95;
            this.TBdescUpdate.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(67, 121);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 93;
            this.label12.Text = "Type";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(38, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 13);
            this.label13.TabIndex = 94;
            this.label13.Text = "Description";
            // 
            // BvUpdateTestCtor
            // 
            this.BvUpdateTestCtor.Location = new System.Drawing.Point(163, 250);
            this.BvUpdateTestCtor.Name = "BvUpdateTestCtor";
            this.BvUpdateTestCtor.Size = new System.Drawing.Size(91, 23);
            this.BvUpdateTestCtor.TabIndex = 83;
            this.BvUpdateTestCtor.Text = "Valider";
            this.BvUpdateTestCtor.UseVisualStyleBackColor = true;
            this.BvUpdateTestCtor.Click += new System.EventHandler(this.BvUpdateTestCtor_Click);
            // 
            // TBteinte
            // 
            this.TBteinte.Location = new System.Drawing.Point(3, 3);
            this.TBteinte.Name = "TBteinte";
            this.TBteinte.ReadOnly = true;
            this.TBteinte.Size = new System.Drawing.Size(114, 20);
            this.TBteinte.TabIndex = 109;
            // 
            // TBtest
            // 
            this.TBtest.Location = new System.Drawing.Point(140, 3);
            this.TBtest.Name = "TBtest";
            this.TBtest.ReadOnly = true;
            this.TBtest.Size = new System.Drawing.Size(114, 20);
            this.TBtest.TabIndex = 109;
            // 
            // AjouterTestCtorTeinte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 476);
            this.Controls.Add(this.UpdateTestCtor);
            this.Controls.Add(this.TestCtorError);
            this.Controls.Add(this.Bsuivant);
            this.Controls.Add(this.LBtestCtor);
            this.Controls.Add(this.LBteinte);
            this.Controls.Add(this.LBtest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TBnom);
            this.Controls.Add(this.label1);
            this.Name = "AjouterTestCtorTeinte";
            this.Text = "AjouterTestCtorTeinte";
            this.Load += new System.EventHandler(this.AjouterTestCtorTeinte_Load);
            this.UpdateTestCtor.ResumeLayout(false);
            this.UpdateTestCtor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TestCtorError;
        private System.Windows.Forms.Button Bsuivant;
        private System.Windows.Forms.ListBox LBtestCtor;
        private System.Windows.Forms.ListBox LBteinte;
        private System.Windows.Forms.Label LBtest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBnom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel UpdateTestCtor;
        private System.Windows.Forms.TextBox TBtest;
        private System.Windows.Forms.TextBox TBteinte;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TBmaxUpdate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TBnormeUpdate;
        private System.Windows.Forms.TextBox TBminUpdate;
        private System.Windows.Forms.TextBox TBtypeUpdate;
        private System.Windows.Forms.RichTextBox TBdescUpdate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button BvUpdateTestCtor;

    }
}