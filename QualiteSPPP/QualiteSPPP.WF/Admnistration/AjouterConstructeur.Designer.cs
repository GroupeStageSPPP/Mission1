namespace QualiteSPPP.WinForm
{
    partial class AjouterConstructeur
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
            this.TBnom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAjoutConstructeur = new System.Windows.Forms.Button();
            this.buttonretour = new System.Windows.Forms.Button();
            this.label53 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TBnom
            // 
            this.TBnom.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBnom.Location = new System.Drawing.Point(24, 62);
            this.TBnom.Name = "TBnom";
            this.TBnom.Size = new System.Drawing.Size(155, 21);
            this.TBnom.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Nom";
            // 
            // buttonAjoutConstructeur
            // 
            this.buttonAjoutConstructeur.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAjoutConstructeur.Location = new System.Drawing.Point(144, 151);
            this.buttonAjoutConstructeur.Name = "buttonAjoutConstructeur";
            this.buttonAjoutConstructeur.Size = new System.Drawing.Size(75, 23);
            this.buttonAjoutConstructeur.TabIndex = 37;
            this.buttonAjoutConstructeur.Text = "Ajouter";
            this.buttonAjoutConstructeur.UseVisualStyleBackColor = true;
            this.buttonAjoutConstructeur.Click += new System.EventHandler(this.buttonAjoutConstructeur_Click);
            // 
            // buttonretour
            // 
            this.buttonretour.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonretour.Location = new System.Drawing.Point(12, 153);
            this.buttonretour.Name = "buttonretour";
            this.buttonretour.Size = new System.Drawing.Size(75, 23);
            this.buttonretour.TabIndex = 36;
            this.buttonretour.Text = "Retour";
            this.buttonretour.UseVisualStyleBackColor = true;
            this.buttonretour.Click += new System.EventHandler(this.buttonretour_Click);
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label53.Location = new System.Drawing.Point(24, 9);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(195, 17);
            this.label53.TabIndex = 70;
            this.label53.Text = "Ajout d\'un constructeur";
            // 
            // AjouterConstructeur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 186);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.TBnom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAjoutConstructeur);
            this.Controls.Add(this.buttonretour);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AjouterConstructeur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AjouterConstructeur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBnom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAjoutConstructeur;
        private System.Windows.Forms.Button buttonretour;
        private System.Windows.Forms.Label label53;
    }
}