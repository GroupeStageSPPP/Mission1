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
            this.Badd = new System.Windows.Forms.Button();
            this.Bupdate = new System.Windows.Forms.Button();
            this.Bdelete = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.Badd, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Bupdate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Bdelete, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(522, 221);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Badd
            // 
            this.Badd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Badd.Location = new System.Drawing.Point(3, 3);
            this.Badd.Name = "Badd";
            this.Badd.Size = new System.Drawing.Size(167, 215);
            this.Badd.TabIndex = 0;
            this.Badd.Text = "Ajouter";
            this.Badd.UseVisualStyleBackColor = true;
            this.Badd.Click += new System.EventHandler(this.Badd_Click);
            // 
            // Bupdate
            // 
            this.Bupdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bupdate.Location = new System.Drawing.Point(176, 3);
            this.Bupdate.Name = "Bupdate";
            this.Bupdate.Size = new System.Drawing.Size(167, 215);
            this.Bupdate.TabIndex = 0;
            this.Bupdate.Text = "Modifier";
            this.Bupdate.UseVisualStyleBackColor = true;
            // 
            // Bdelete
            // 
            this.Bdelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bdelete.Location = new System.Drawing.Point(349, 3);
            this.Bdelete.Name = "Bdelete";
            this.Bdelete.Size = new System.Drawing.Size(170, 215);
            this.Bdelete.TabIndex = 0;
            this.Bdelete.Text = "Supprimer";
            this.Bdelete.UseVisualStyleBackColor = true;
            // 
            // GestionConstructeur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 221);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GestionConstructeur";
            this.Text = "GestionConstructeur";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Badd;
        private System.Windows.Forms.Button Bupdate;
        private System.Windows.Forms.Button Bdelete;

    }
}