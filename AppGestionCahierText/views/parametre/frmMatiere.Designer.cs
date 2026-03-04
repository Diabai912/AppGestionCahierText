namespace AppGestionCahierText.views.parametre
{
    partial class frmMatiere
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
            this.DgMatiere = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLibelleMatiere = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.txtVolumeHoraire = new System.Windows.Forms.TextBox();
            this.txtNiveau = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelectionner = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnRechercher = new System.Windows.Forms.Button();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.cbbProfesseur = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgMatiere)).BeginInit();
            this.SuspendLayout();
            // 
            // DgMatiere
            // 
            this.DgMatiere.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgMatiere.Location = new System.Drawing.Point(435, 95);
            this.DgMatiere.Name = "DgMatiere";
            this.DgMatiere.RowHeadersWidth = 62;
            this.DgMatiere.RowTemplate.Height = 28;
            this.DgMatiere.Size = new System.Drawing.Size(714, 608);
            this.DgMatiere.TabIndex = 0;
            this.DgMatiere.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgMatiere_CellClick);
            this.DgMatiere.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgMatiere_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Libelle";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtLibelleMatiere
            // 
            this.txtLibelleMatiere.BackColor = System.Drawing.Color.Purple;
            this.txtLibelleMatiere.Location = new System.Drawing.Point(19, 127);
            this.txtLibelleMatiere.Name = "txtLibelleMatiere";
            this.txtLibelleMatiere.Size = new System.Drawing.Size(388, 26);
            this.txtLibelleMatiere.TabIndex = 2;
            this.txtLibelleMatiere.TextChanged += new System.EventHandler(this.txtLibelleMatiere_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Volume horaire";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.Color.Purple;
            this.btnAjouter.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.ForeColor = System.Drawing.Color.White;
            this.btnAjouter.Location = new System.Drawing.Point(247, 463);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(160, 44);
            this.btnAjouter.TabIndex = 5;
            this.btnAjouter.Text = "&Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.Purple;
            this.btnModifier.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifier.ForeColor = System.Drawing.Color.White;
            this.btnModifier.Location = new System.Drawing.Point(247, 513);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(160, 44);
            this.btnModifier.TabIndex = 6;
            this.btnModifier.Text = "&Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // txtVolumeHoraire
            // 
            this.txtVolumeHoraire.BackColor = System.Drawing.Color.Purple;
            this.txtVolumeHoraire.Location = new System.Drawing.Point(22, 207);
            this.txtVolumeHoraire.Name = "txtVolumeHoraire";
            this.txtVolumeHoraire.Size = new System.Drawing.Size(385, 26);
            this.txtVolumeHoraire.TabIndex = 3;
            this.txtVolumeHoraire.TextChanged += new System.EventHandler(this.txtVolumeHoraire_TextChanged);
            // 
            // txtNiveau
            // 
            this.txtNiveau.BackColor = System.Drawing.Color.Purple;
            this.txtNiveau.Location = new System.Drawing.Point(19, 288);
            this.txtNiveau.Name = "txtNiveau";
            this.txtNiveau.Size = new System.Drawing.Size(385, 26);
            this.txtNiveau.TabIndex = 9;
            this.txtNiveau.TextChanged += new System.EventHandler(this.txtNiveau_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(24, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Niveau";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnSelectionner
            // 
            this.btnSelectionner.BackColor = System.Drawing.Color.Purple;
            this.btnSelectionner.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectionner.ForeColor = System.Drawing.Color.White;
            this.btnSelectionner.Location = new System.Drawing.Point(19, 28);
            this.btnSelectionner.Name = "btnSelectionner";
            this.btnSelectionner.Size = new System.Drawing.Size(216, 50);
            this.btnSelectionner.TabIndex = 10;
            this.btnSelectionner.Text = "&Selectionner";
            this.btnSelectionner.UseVisualStyleBackColor = false;
            this.btnSelectionner.Click += new System.EventHandler(this.btnSelectionner_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.Purple;
            this.btnSupprimer.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.ForeColor = System.Drawing.Color.White;
            this.btnSupprimer.Location = new System.Drawing.Point(247, 563);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(160, 44);
            this.btnSupprimer.TabIndex = 7;
            this.btnSupprimer.Text = "&Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnRechercher
            // 
            this.btnRechercher.BackColor = System.Drawing.Color.Purple;
            this.btnRechercher.ForeColor = System.Drawing.Color.White;
            this.btnRechercher.Location = new System.Drawing.Point(864, 28);
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Size = new System.Drawing.Size(159, 46);
            this.btnRechercher.TabIndex = 9;
            this.btnRechercher.Text = "&Rechercher";
            this.btnRechercher.UseVisualStyleBackColor = false;
            this.btnRechercher.Click += new System.EventHandler(this.btnRechercher_Click);
            // 
            // txtRecherche
            // 
            this.txtRecherche.Location = new System.Drawing.Point(435, 28);
            this.txtRecherche.Multiline = true;
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(433, 46);
            this.txtRecherche.TabIndex = 8;
            this.txtRecherche.TextChanged += new System.EventHandler(this.txtRecherche_TextChanged);
            // 
            // cbbProfesseur
            // 
            this.cbbProfesseur.BackColor = System.Drawing.Color.Purple;
            this.cbbProfesseur.ForeColor = System.Drawing.SystemColors.Window;
            this.cbbProfesseur.FormattingEnabled = true;
            this.cbbProfesseur.Location = new System.Drawing.Point(19, 363);
            this.cbbProfesseur.Name = "cbbProfesseur";
            this.cbbProfesseur.Size = new System.Drawing.Size(385, 28);
            this.cbbProfesseur.TabIndex = 17;
            this.cbbProfesseur.SelectedIndexChanged += new System.EventHandler(this.cbbNiveauSyllabus_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Professeur";
            // 
            // frmMatiere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 730);
            this.ControlBox = false;
            this.Controls.Add(this.cbbProfesseur);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRechercher);
            this.Controls.Add(this.txtRecherche);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnSelectionner);
            this.Controls.Add(this.txtNiveau);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVolumeHoraire);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLibelleMatiere);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgMatiere);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "frmMatiere";
            this.Text = "Matiere";
            this.Load += new System.EventHandler(this.frmMatiere_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgMatiere)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgMatiere;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLibelleMatiere;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.TextBox txtVolumeHoraire;
        private System.Windows.Forms.TextBox txtNiveau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelectionner;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnRechercher;
        private System.Windows.Forms.TextBox txtRecherche;
        private System.Windows.Forms.ComboBox cbbProfesseur;
        private System.Windows.Forms.Label label4;
    }
}