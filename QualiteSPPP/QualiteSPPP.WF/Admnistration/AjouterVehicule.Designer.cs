namespace QualiteSPPP.WinForm
{
    partial class AjouterVehicule
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
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxConstructeurAjouterVehicule = new System.Windows.Forms.ComboBox();
            this.buttonAjouterConstructeurAjouterVehicule = new System.Windows.Forms.Button();
            this.textBoxLibelleAjouterVehicule = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.AjoutVehicule = new System.Windows.Forms.Label();
            this.buttonSuivantAjouterVehicule = new System.Windows.Forms.Button();
            this.buttonAnnulerAjouterVehicule = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Constructeur";
            // 
            // comboBoxConstructeurAjouterVehicule
            // 
            this.comboBoxConstructeurAjouterVehicule.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxConstructeurAjouterVehicule.FormattingEnabled = true;
            this.comboBoxConstructeurAjouterVehicule.Items.AddRange(new object[] {
            "",
            "Autre"});
            this.comboBoxConstructeurAjouterVehicule.Location = new System.Drawing.Point(9, 90);
            this.comboBoxConstructeurAjouterVehicule.Name = "comboBoxConstructeurAjouterVehicule";
            this.comboBoxConstructeurAjouterVehicule.Size = new System.Drawing.Size(216, 21);
            this.comboBoxConstructeurAjouterVehicule.TabIndex = 19;
            // 
            // buttonAjouterConstructeurAjouterVehicule
            // 
            this.buttonAjouterConstructeurAjouterVehicule.Enabled = false;
            this.buttonAjouterConstructeurAjouterVehicule.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAjouterConstructeurAjouterVehicule.Location = new System.Drawing.Point(32, 110);
            this.buttonAjouterConstructeurAjouterVehicule.Name = "buttonAjouterConstructeurAjouterVehicule";
            this.buttonAjouterConstructeurAjouterVehicule.Size = new System.Drawing.Size(171, 23);
            this.buttonAjouterConstructeurAjouterVehicule.TabIndex = 18;
            this.buttonAjouterConstructeurAjouterVehicule.Text = "Ajouter un constructeur";
            this.buttonAjouterConstructeurAjouterVehicule.UseVisualStyleBackColor = true;
            this.buttonAjouterConstructeurAjouterVehicule.Click += new System.EventHandler(this.buttonAjouterConstructeurAjouterVehicule_Click);
            // 
            // textBoxLibelleAjouterVehicule
            // 
            this.textBoxLibelleAjouterVehicule.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLibelleAjouterVehicule.Location = new System.Drawing.Point(9, 50);
            this.textBoxLibelleAjouterVehicule.Name = "textBoxLibelleAjouterVehicule";
            this.textBoxLibelleAjouterVehicule.Size = new System.Drawing.Size(216, 21);
            this.textBoxLibelleAjouterVehicule.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Libelle";
            // 
            // AjoutVehicule
            // 
            this.AjoutVehicule.AutoSize = true;
            this.AjoutVehicule.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.AjoutVehicule.Location = new System.Drawing.Point(42, 9);
            this.AjoutVehicule.Name = "AjoutVehicule";
            this.AjoutVehicule.Size = new System.Drawing.Size(159, 17);
            this.AjoutVehicule.TabIndex = 70;
            this.AjoutVehicule.Text = "Ajout d\'un vehicule";
            // 
            // buttonSuivantAjouterVehicule
            // 
            this.buttonSuivantAjouterVehicule.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSuivantAjouterVehicule.Location = new System.Drawing.Point(150, 145);
            this.buttonSuivantAjouterVehicule.Name = "buttonSuivantAjouterVehicule";
            this.buttonSuivantAjouterVehicule.Size = new System.Drawing.Size(75, 23);
            this.buttonSuivantAjouterVehicule.TabIndex = 71;
            this.buttonSuivantAjouterVehicule.Text = "Suivant";
            this.buttonSuivantAjouterVehicule.UseVisualStyleBackColor = true;
            this.buttonSuivantAjouterVehicule.Click += new System.EventHandler(this.buttonSuivantAjouterVehicule_Click);
            // 
            // buttonAnnulerAjouterVehicule
            // 
            this.buttonAnnulerAjouterVehicule.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAnnulerAjouterVehicule.Location = new System.Drawing.Point(12, 145);
            this.buttonAnnulerAjouterVehicule.Name = "buttonAnnulerAjouterVehicule";
            this.buttonAnnulerAjouterVehicule.Size = new System.Drawing.Size(75, 23);
            this.buttonAnnulerAjouterVehicule.TabIndex = 72;
            this.buttonAnnulerAjouterVehicule.Text = "Annuler";
            this.buttonAnnulerAjouterVehicule.UseVisualStyleBackColor = true;
            this.buttonAnnulerAjouterVehicule.Click += new System.EventHandler(this.buttonAnnulerAjouterVehicule_Click);
            // 
            // AjouterVehicule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(239, 176);
            this.Controls.Add(this.buttonAnnulerAjouterVehicule);
            this.Controls.Add(this.buttonSuivantAjouterVehicule);
            this.Controls.Add(this.AjoutVehicule);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxConstructeurAjouterVehicule);
            this.Controls.Add(this.buttonAjouterConstructeurAjouterVehicule);
            this.Controls.Add(this.textBoxLibelleAjouterVehicule);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AjouterVehicule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AjouterVehicule";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxConstructeurAjouterVehicule;
        private System.Windows.Forms.Button buttonAjouterConstructeurAjouterVehicule;
        private System.Windows.Forms.TextBox textBoxLibelleAjouterVehicule;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label AjoutVehicule;
        private System.Windows.Forms.Button buttonSuivantAjouterVehicule;
        private System.Windows.Forms.Button buttonAnnulerAjouterVehicule;
    }
}