namespace AppGestionCahierText.views.parametre
{
    partial class frmCahierTexte
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
            this.cbbAnneeAcademique = new System.Windows.Forms.ComboBox();
            this.btnSelectionner = new System.Windows.Forms.Button();
            this.txtAnneeAcademique = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DgCahierTexte = new System.Windows.Forms.DataGridView();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbClasse = new System.Windows.Forms.ComboBox();
            this.Responsable = new System.Windows.Forms.Label();
            this.cbbResponsable = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgCahierTexte)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRechercher
            // 
            this.btnRechercher.BackColor = System.Drawing.Color.Purple;
            this.btnRechercher.ForeColor = System.Drawing.Color.White;
            this.btnRechercher.Location = new System.Drawing.Point(758, 38);
            this.btnRechercher.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Size = new System.Drawing.Size(141, 37);
            this.btnRechercher.TabIndex = 13;
            this.btnRechercher.Text = "&Rechercher";
            this.btnRechercher.UseVisualStyleBackColor = false;
            this.btnRechercher.Click += new System.EventHandler(this.btnRechercher_Click);
            // 
            // txtRecherche
            // 
            this.txtRecherche.Location = new System.Drawing.Point(377, 38);
            this.txtRecherche.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRecherche.Multiline = true;
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(385, 38);
            this.txtRecherche.TabIndex = 14;
            // 
            // cbbAnneeAcademique
            // 
            this.cbbAnneeAcademique.BackColor = System.Drawing.Color.Purple;
            this.cbbAnneeAcademique.ForeColor = System.Drawing.Color.White;
            this.cbbAnneeAcademique.FormattingEnabled = true;
            this.cbbAnneeAcademique.Location = new System.Drawing.Point(28, 357);
            this.cbbAnneeAcademique.Name = "cbbAnneeAcademique";
            this.cbbAnneeAcademique.Size = new System.Drawing.Size(267, 24);
            this.cbbAnneeAcademique.TabIndex = 9;
            // 
            // btnSelectionner
            // 
            this.btnSelectionner.BackColor = System.Drawing.Color.Purple;
            this.btnSelectionner.ForeColor = System.Drawing.Color.White;
            this.btnSelectionner.Location = new System.Drawing.Point(34, 38);
            this.btnSelectionner.Name = "btnSelectionner";
            this.btnSelectionner.Size = new System.Drawing.Size(213, 48);
            this.btnSelectionner.TabIndex = 1;
            this.btnSelectionner.Text = "&Selectionner";
            this.btnSelectionner.UseVisualStyleBackColor = false;
            this.btnSelectionner.Click += new System.EventHandler(this.btnSelectionner_Click);
            // 
            // txtAnneeAcademique
            // 
            this.txtAnneeAcademique.AutoSize = true;
            this.txtAnneeAcademique.Location = new System.Drawing.Point(25, 338);
            this.txtAnneeAcademique.Name = "txtAnneeAcademique";
            this.txtAnneeAcademique.Size = new System.Drawing.Size(131, 17);
            this.txtAnneeAcademique.TabIndex = 8;
            this.txtAnneeAcademique.Text = "Annee Academique";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Titre";
            // 
            // DgCahierTexte
            // 
            this.DgCahierTexte.BackgroundColor = System.Drawing.Color.White;
            this.DgCahierTexte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgCahierTexte.Location = new System.Drawing.Point(364, 92);
            this.DgCahierTexte.Name = "DgCahierTexte";
            this.DgCahierTexte.RowHeadersWidth = 62;
            this.DgCahierTexte.RowTemplate.Height = 28;
            this.DgCahierTexte.Size = new System.Drawing.Size(821, 450);
            this.DgCahierTexte.TabIndex = 15;
            this.DgCahierTexte.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgCahierTexte_CellClick);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.Purple;
            this.btnSupprimer.ForeColor = System.Drawing.Color.White;
            this.btnSupprimer.Location = new System.Drawing.Point(104, 508);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(158, 42);
            this.btnSupprimer.TabIndex = 12;
            this.btnSupprimer.Text = "&Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.Purple;
            this.btnModifier.ForeColor = System.Drawing.Color.White;
            this.btnModifier.Location = new System.Drawing.Point(104, 459);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(158, 42);
            this.btnModifier.TabIndex = 11;
            this.btnModifier.Text = "&Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.Color.Purple;
            this.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouter.ForeColor = System.Drawing.Color.White;
            this.btnAjouter.Location = new System.Drawing.Point(104, 410);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(158, 42);
            this.btnAjouter.TabIndex = 10;
            this.btnAjouter.Text = "&Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.Purple;
            this.txtDescription.ForeColor = System.Drawing.Color.White;
            this.txtDescription.Location = new System.Drawing.Point(24, 242);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(272, 22);
            this.txtDescription.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CalendarMonthBackground = System.Drawing.Color.Purple;
            this.dateTimePicker.Location = new System.Drawing.Point(25, 299);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(273, 22);
            this.dateTimePicker.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Date de création";
            // 
            // cbbClasse
            // 
            this.cbbClasse.BackColor = System.Drawing.Color.Purple;
            this.cbbClasse.ForeColor = System.Drawing.SystemColors.Window;
            this.cbbClasse.FormattingEnabled = true;
            this.cbbClasse.Location = new System.Drawing.Point(28, 183);
            this.cbbClasse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbClasse.Name = "cbbClasse";
            this.cbbClasse.Size = new System.Drawing.Size(268, 24);
            this.cbbClasse.TabIndex = 17;
            // 
            // Responsable
            // 
            this.Responsable.AutoSize = true;
            this.Responsable.Location = new System.Drawing.Point(31, 100);
            this.Responsable.Name = "Responsable";
            this.Responsable.Size = new System.Drawing.Size(91, 17);
            this.Responsable.TabIndex = 18;
            this.Responsable.Text = "Responsable";
            // 
            // cbbResponsable
            // 
            this.cbbResponsable.BackColor = System.Drawing.Color.Purple;
            this.cbbResponsable.ForeColor = System.Drawing.SystemColors.Window;
            this.cbbResponsable.FormattingEnabled = true;
            this.cbbResponsable.Location = new System.Drawing.Point(28, 121);
            this.cbbResponsable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbResponsable.Name = "cbbResponsable";
            this.cbbResponsable.Size = new System.Drawing.Size(274, 24);
            this.cbbResponsable.TabIndex = 19;
            // 
            // frmCahierTexte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1197, 574);
            this.ControlBox = false;
            this.Controls.Add(this.Responsable);
            this.Controls.Add(this.cbbResponsable);
            this.Controls.Add(this.cbbClasse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRechercher);
            this.Controls.Add(this.txtRecherche);
            this.Controls.Add(this.cbbAnneeAcademique);
            this.Controls.Add(this.btnSelectionner);
            this.Controls.Add(this.txtAnneeAcademique);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgCahierTexte);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCahierTexte";
            this.Text = "CahierTexte";
            this.Load += new System.EventHandler(this.CahierTexte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgCahierTexte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnRechercher;
        private System.Windows.Forms.TextBox txtRecherche;
        private System.Windows.Forms.ComboBox cbbAnneeAcademique;
        private System.Windows.Forms.Button btnSelectionner;
        private System.Windows.Forms.Label txtAnneeAcademique;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgCahierTexte;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbClasse;
        private System.Windows.Forms.Label Responsable;
        private System.Windows.Forms.ComboBox cbbResponsable;
    }
}