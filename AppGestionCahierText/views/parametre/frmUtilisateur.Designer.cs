namespace AppGestionCahierText.views.parametre
{
    partial class frmUtilisateur
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
            this.btnRechercher = new System.Windows.Forms.Button();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.btnSelectionner = new System.Windows.Forms.Button();
            this.txtAnneeAcademique = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DgUtilisateurs = new System.Windows.Forms.DataGridView();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.txtAdresse = new System.Windows.Forms.TextBox();
            this.txtIdentifiant = new System.Windows.Forms.TextBox();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbRole = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMotDePasse = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgUtilisateurs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRechercher
            // 
            this.btnRechercher.BackColor = System.Drawing.Color.Purple;
            this.btnRechercher.ForeColor = System.Drawing.Color.White;
            this.btnRechercher.Location = new System.Drawing.Point(840, 12);
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Size = new System.Drawing.Size(159, 46);
            this.btnRechercher.TabIndex = 17;
            this.btnRechercher.Text = "&Rechercher";
            this.btnRechercher.UseVisualStyleBackColor = false;
            this.btnRechercher.Click += new System.EventHandler(this.btnRechercher_Click);
            // 
            // txtRecherche
            // 
            this.txtRecherche.Location = new System.Drawing.Point(422, 10);
            this.txtRecherche.Multiline = true;
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(433, 46);
            this.txtRecherche.TabIndex = 18;
            // 
            // btnSelectionner
            // 
            this.btnSelectionner.BackColor = System.Drawing.Color.Purple;
            this.btnSelectionner.ForeColor = System.Drawing.Color.White;
            this.btnSelectionner.Location = new System.Drawing.Point(32, 10);
            this.btnSelectionner.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelectionner.Name = "btnSelectionner";
            this.btnSelectionner.Size = new System.Drawing.Size(240, 60);
            this.btnSelectionner.TabIndex = 1;
            this.btnSelectionner.Text = "&Selectionner";
            this.btnSelectionner.UseVisualStyleBackColor = false;
            this.btnSelectionner.Click += new System.EventHandler(this.btnSelectionner_Click);
            // 
            // txtAnneeAcademique
            // 
            this.txtAnneeAcademique.AutoSize = true;
            this.txtAnneeAcademique.Location = new System.Drawing.Point(12, 155);
            this.txtAnneeAcademique.Name = "txtAnneeAcademique";
            this.txtAnneeAcademique.Size = new System.Drawing.Size(64, 20);
            this.txtAnneeAcademique.TabIndex = 4;
            this.txtAnneeAcademique.Text = "Prenom";
            // 
            // txtNom
            // 
            this.txtNom.BackColor = System.Drawing.Color.Purple;
            this.txtNom.ForeColor = System.Drawing.Color.White;
            this.txtNom.Location = new System.Drawing.Point(12, 109);
            this.txtNom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(306, 26);
            this.txtNom.TabIndex = 3;
            this.txtNom.TextChanged += new System.EventHandler(this.txtNom_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nom";
            // 
            // DgUtilisateurs
            // 
            this.DgUtilisateurs.BackgroundColor = System.Drawing.Color.White;
            this.DgUtilisateurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgUtilisateurs.Location = new System.Drawing.Point(432, 85);
            this.DgUtilisateurs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DgUtilisateurs.Name = "DgUtilisateurs";
            this.DgUtilisateurs.RowHeadersWidth = 62;
            this.DgUtilisateurs.RowTemplate.Height = 28;
            this.DgUtilisateurs.Size = new System.Drawing.Size(749, 540);
            this.DgUtilisateurs.TabIndex = 19;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.Purple;
            this.btnSupprimer.ForeColor = System.Drawing.Color.White;
            this.btnSupprimer.Location = new System.Drawing.Point(1003, 648);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(178, 53);
            this.btnSupprimer.TabIndex = 16;
            this.btnSupprimer.Text = "&Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.Purple;
            this.btnModifier.ForeColor = System.Drawing.Color.White;
            this.btnModifier.Location = new System.Drawing.Point(724, 648);
            this.btnModifier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(178, 53);
            this.btnModifier.TabIndex = 15;
            this.btnModifier.Text = "&Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.Color.Purple;
            this.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouter.ForeColor = System.Drawing.Color.White;
            this.btnAjouter.Location = new System.Drawing.Point(432, 648);
            this.btnAjouter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(178, 53);
            this.btnAjouter.TabIndex = 14;
            this.btnAjouter.Text = "&Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // txtAdresse
            // 
            this.txtAdresse.BackColor = System.Drawing.Color.Purple;
            this.txtAdresse.ForeColor = System.Drawing.Color.White;
            this.txtAdresse.Location = new System.Drawing.Point(12, 253);
            this.txtAdresse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAdresse.Name = "txtAdresse";
            this.txtAdresse.Size = new System.Drawing.Size(306, 26);
            this.txtAdresse.TabIndex = 7;
            // 
            // txtIdentifiant
            // 
            this.txtIdentifiant.BackColor = System.Drawing.Color.Purple;
            this.txtIdentifiant.ForeColor = System.Drawing.Color.White;
            this.txtIdentifiant.Location = new System.Drawing.Point(16, 456);
            this.txtIdentifiant.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIdentifiant.Name = "txtIdentifiant";
            this.txtIdentifiant.Size = new System.Drawing.Size(306, 26);
            this.txtIdentifiant.TabIndex = 13;
            // 
            // txtTelephone
            // 
            this.txtTelephone.BackColor = System.Drawing.Color.Purple;
            this.txtTelephone.ForeColor = System.Drawing.Color.White;
            this.txtTelephone.Location = new System.Drawing.Point(12, 387);
            this.txtTelephone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(306, 26);
            this.txtTelephone.TabIndex = 11;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.Purple;
            this.txtEmail.ForeColor = System.Drawing.Color.White;
            this.txtEmail.Location = new System.Drawing.Point(12, 320);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(306, 26);
            this.txtEmail.TabIndex = 9;
            // 
            // txtPrenom
            // 
            this.txtPrenom.BackColor = System.Drawing.Color.Purple;
            this.txtPrenom.ForeColor = System.Drawing.SystemColors.Window;
            this.txtPrenom.Location = new System.Drawing.Point(12, 179);
            this.txtPrenom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(306, 26);
            this.txtPrenom.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Adresse";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 432);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Identifiant";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 363);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Téléphone";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 574);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "Role";
            // 
            // cbbRole
            // 
            this.cbbRole.BackColor = System.Drawing.Color.Purple;
            this.cbbRole.ForeColor = System.Drawing.Color.White;
            this.cbbRole.FormattingEnabled = true;
            this.cbbRole.Location = new System.Drawing.Point(16, 597);
            this.cbbRole.Name = "cbbRole";
            this.cbbRole.Size = new System.Drawing.Size(299, 28);
            this.cbbRole.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 502);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "Mot de passe";
            // 
            // txtMotDePasse
            // 
            this.txtMotDePasse.BackColor = System.Drawing.Color.Purple;
            this.txtMotDePasse.ForeColor = System.Drawing.Color.White;
            this.txtMotDePasse.Location = new System.Drawing.Point(20, 526);
            this.txtMotDePasse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMotDePasse.Name = "txtMotDePasse";
            this.txtMotDePasse.Size = new System.Drawing.Size(306, 26);
            this.txtMotDePasse.TabIndex = 22;
            // 
            // frmUtilisateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 714);
            this.ControlBox = false;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMotDePasse);
            this.Controls.Add(this.cbbRole);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPrenom);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.txtIdentifiant);
            this.Controls.Add(this.txtAdresse);
            this.Controls.Add(this.btnRechercher);
            this.Controls.Add(this.txtRecherche);
            this.Controls.Add(this.btnSelectionner);
            this.Controls.Add(this.txtAnneeAcademique);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgUtilisateurs);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUtilisateur";
            this.Text = "Utilisateur";
            this.Load += new System.EventHandler(this.frmUtilisateur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgUtilisateurs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRechercher;
        private System.Windows.Forms.TextBox txtRecherche;
        private System.Windows.Forms.Button btnSelectionner;
        private System.Windows.Forms.Label txtAnneeAcademique;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgUtilisateurs;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.TextBox txtAdresse;
        private System.Windows.Forms.TextBox txtIdentifiant;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbRole;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMotDePasse;
    }
}