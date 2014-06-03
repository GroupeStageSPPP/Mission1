namespace QualiteSPPP.Travail
{
    partial class GestionConstructeur
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Bdelete = new System.Windows.Forms.Button();
            this.Bupdate = new System.Windows.Forms.Button();
            this.Badd = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.Badd, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Bupdate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Bdelete, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(522, 230);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Bdelete
            // 
            this.Bdelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bdelete.Location = new System.Drawing.Point(3, 155);
            this.Bdelete.Name = "Bdelete";
            this.Bdelete.Size = new System.Drawing.Size(516, 72);
            this.Bdelete.TabIndex = 0;
            this.Bdelete.Text = "Supprimer";
            this.Bdelete.UseVisualStyleBackColor = true;
            // 
            // Bupdate
            // 
            this.Bupdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bupdate.Location = new System.Drawing.Point(3, 79);
            this.Bupdate.Name = "Bupdate";
            this.Bupdate.Size = new System.Drawing.Size(516, 70);
            this.Bupdate.TabIndex = 0;
            this.Bupdate.Text = "Modifier";
            this.Bupdate.UseVisualStyleBackColor = true;
            // 
            // Badd
            // 
            this.Badd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Badd.Location = new System.Drawing.Point(3, 3);
            this.Badd.Name = "Badd";
            this.Badd.Size = new System.Drawing.Size(516, 70);
            this.Badd.TabIndex = 0;
            this.Badd.Text = "Ajouter";
            this.Badd.UseVisualStyleBackColor = true;
            this.Badd.Click += new System.EventHandler(this.Badd_Click);
            // 
            // GestionConstructeur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 230);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GestionConstructeur";
            this.Text = "GestionConstructeur";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Bdelete;
        private System.Windows.Forms.Button Badd;
        private System.Windows.Forms.Button Bupdate;

    }
}