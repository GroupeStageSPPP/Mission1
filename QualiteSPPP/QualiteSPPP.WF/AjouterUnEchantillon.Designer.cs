namespace QualiteSPPP.WinForm
{
    partial class AjouterUnEchantillon
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
            this.buttonNewProjet = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonRetour = new System.Windows.Forms.Button();
            this.buttonAJouter = new System.Windows.Forms.Button();
            this.comboBoxProjet = new System.Windows.Forms.ComboBox();
            this.textBoxNumLot = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerDatePeinture = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // buttonNewProjet
            // 
            this.buttonNewProjet.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewProjet.Location = new System.Drawing.Point(141, 62);
            this.buttonNewProjet.Name = "buttonNewProjet";
            this.buttonNewProjet.Size = new System.Drawing.Size(124, 23);
            this.buttonNewProjet.TabIndex = 20;
            this.buttonNewProjet.Text = "Ajouter un Projet";
            this.buttonNewProjet.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Projet";
            // 
            // buttonRetour
            // 
            this.buttonRetour.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRetour.Location = new System.Drawing.Point(12, 130);
            this.buttonRetour.Name = "buttonRetour";
            this.buttonRetour.Size = new System.Drawing.Size(75, 23);
            this.buttonRetour.TabIndex = 18;
            this.buttonRetour.Text = "Retour";
            this.buttonRetour.UseVisualStyleBackColor = true;
            // 
            // buttonAJouter
            // 
            this.buttonAJouter.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAJouter.Location = new System.Drawing.Point(190, 130);
            this.buttonAJouter.Name = "buttonAJouter";
            this.buttonAJouter.Size = new System.Drawing.Size(75, 23);
            this.buttonAJouter.TabIndex = 17;
            this.buttonAJouter.Text = "Ajouter";
            this.buttonAJouter.UseVisualStyleBackColor = true;
            // 
            // comboBoxProjet
            // 
            this.comboBoxProjet.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxProjet.FormattingEnabled = true;
            this.comboBoxProjet.Items.AddRange(new object[] {
            "",
            "Autre"});
            this.comboBoxProjet.Location = new System.Drawing.Point(12, 64);
            this.comboBoxProjet.Name = "comboBoxProjet";
            this.comboBoxProjet.Size = new System.Drawing.Size(121, 21);
            this.comboBoxProjet.TabIndex = 16;
            this.comboBoxProjet.SelectedIndexChanged += new System.EventHandler(this.comboBoxProjet_SelectedIndexChanged);
            // 
            // textBoxNumLot
            // 
            this.textBoxNumLot.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNumLot.Location = new System.Drawing.Point(12, 25);
            this.textBoxNumLot.Name = "textBoxNumLot";
            this.textBoxNumLot.Size = new System.Drawing.Size(121, 21);
            this.textBoxNumLot.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "N° de lot";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Date de peinture";
            // 
            // dateTimePickerDatePeinture
            // 
            this.dateTimePickerDatePeinture.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDatePeinture.Location = new System.Drawing.Point(12, 104);
            this.dateTimePickerDatePeinture.Name = "dateTimePickerDatePeinture";
            this.dateTimePickerDatePeinture.Size = new System.Drawing.Size(208, 21);
            this.dateTimePickerDatePeinture.TabIndex = 12;
            // 
            // AjouterUnEchantillon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(277, 165);
            this.Controls.Add(this.buttonNewProjet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonRetour);
            this.Controls.Add(this.buttonAJouter);
            this.Controls.Add(this.comboBoxProjet);
            this.Controls.Add(this.textBoxNumLot);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerDatePeinture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AjouterUnEchantillon";
            this.Text = "AjouterUnEchantillon";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNewProjet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonRetour;
        private System.Windows.Forms.Button buttonAJouter;
        private System.Windows.Forms.ComboBox comboBoxProjet;
        private System.Windows.Forms.TextBox textBoxNumLot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerDatePeinture;
    }
}