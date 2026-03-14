namespace AppGestionCahierText.views.parametre
{
    partial class frmSyllabus
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
            this.txtLibelle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DgSyllabus = new System.Windows.Forms.DataGridView();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVolumeHoraire = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbNiveauSyllabus = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgSyllabus)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRechercher
            // 
            this.btnRechercher.BackColor = System.Drawing.Color.Purple;
            this.btnRechercher.ForeColor = System.Drawing.Color.White;
            this.btnRechercher.Location = new System.Drawing.Point(854, 24);
            this.btnRechercher.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Size = new System.Drawing.Size(159, 46);
            this.btnRechercher.TabIndex = 3;
            this.btnRechercher.Text = "&Rechercher";
            this.btnRechercher.UseVisualStyleBackColor = false;
            this.btnRechercher.Click += new System.EventHandler(this.btnRechercher_Click);
            // 
            // txtRecherche
            // 
            this.txtRecherche.Location = new System.Drawing.Point(425, 24);
            this.txtRecherche.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRecherche.Multiline = true;
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(433, 46);
            this.txtRecherche.TabIndex = 2;
            // 
            // btnSelectionner
            // 
            this.btnSelectionner.BackColor = System.Drawing.Color.Purple;
            this.btnSelectionner.ForeColor = System.Drawing.Color.White;
            this.btnSelectionner.Location = new System.Drawing.Point(36, 24);
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
            this.txtAnneeAcademique.Location = new System.Drawing.Point(32, 214);
            this.txtAnneeAcademique.Name = "txtAnneeAcademique";
            this.txtAnneeAcademique.Size = new System.Drawing.Size(89, 20);
            this.txtAnneeAcademique.TabIndex = 10;
            this.txtAnneeAcademique.Text = "Description";
            // 
            // txtLibelle
            // 
            this.txtLibelle.BackColor = System.Drawing.Color.Purple;
            this.txtLibelle.ForeColor = System.Drawing.SystemColors.Window;
            this.txtLibelle.Location = new System.Drawing.Point(29, 160);
            this.txtLibelle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLibelle.Name = "txtLibelle";
            this.txtLibelle.Size = new System.Drawing.Size(306, 26);
            this.txtLibelle.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Libelle";
            // 
            // DgSyllabus
            // 
            this.DgSyllabus.BackgroundColor = System.Drawing.Color.White;
            this.DgSyllabus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgSyllabus.Location = new System.Drawing.Point(411, 86);
            this.DgSyllabus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DgSyllabus.Name = "DgSyllabus";
            this.DgSyllabus.RowHeadersWidth = 62;
            this.DgSyllabus.RowTemplate.Height = 28;
            this.DgSyllabus.Size = new System.Drawing.Size(961, 558);
            this.DgSyllabus.TabIndex = 4;
            this.DgSyllabus.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgSyllabus_CellClick);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.Purple;
            this.btnSupprimer.ForeColor = System.Drawing.Color.White;
            this.btnSupprimer.Location = new System.Drawing.Point(933, 657);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(178, 52);
            this.btnSupprimer.TabIndex = 7;
            this.btnSupprimer.Text = "&Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.Purple;
            this.btnModifier.ForeColor = System.Drawing.Color.White;
            this.btnModifier.Location = new System.Drawing.Point(668, 656);
            this.btnModifier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(178, 52);
            this.btnModifier.TabIndex = 6;
            this.btnModifier.Text = "&Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.Color.Purple;
            this.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouter.ForeColor = System.Drawing.Color.White;
            this.btnAjouter.Location = new System.Drawing.Point(411, 656);
            this.btnAjouter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(178, 52);
            this.btnAjouter.TabIndex = 5;
            this.btnAjouter.Text = "&Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.Purple;
            this.txtDescription.ForeColor = System.Drawing.SystemColors.Window;
            this.txtDescription.Location = new System.Drawing.Point(29, 238);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(306, 26);
            this.txtDescription.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Volume Horaire";
            // 
            // txtVolumeHoraire
            // 
            this.txtVolumeHoraire.BackColor = System.Drawing.Color.Purple;
            this.txtVolumeHoraire.ForeColor = System.Drawing.SystemColors.Window;
            this.txtVolumeHoraire.Location = new System.Drawing.Point(29, 316);
            this.txtVolumeHoraire.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVolumeHoraire.Multiline = true;
            this.txtVolumeHoraire.Name = "txtVolumeHoraire";
            this.txtVolumeHoraire.Size = new System.Drawing.Size(306, 26);
            this.txtVolumeHoraire.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 382);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Niveau";
            // 
            // cbbNiveauSyllabus
            // 
            this.cbbNiveauSyllabus.BackColor = System.Drawing.Color.Purple;
            this.cbbNiveauSyllabus.ForeColor = System.Drawing.SystemColors.Window;
            this.cbbNiveauSyllabus.FormattingEnabled = true;
            this.cbbNiveauSyllabus.Location = new System.Drawing.Point(29, 405);
            this.cbbNiveauSyllabus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbNiveauSyllabus.Name = "cbbNiveauSyllabus";
            this.cbbNiveauSyllabus.Size = new System.Drawing.Size(306, 28);
            this.cbbNiveauSyllabus.TabIndex = 15;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Purple;
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(1194, 657);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(178, 52);
            this.btnPrint.TabIndex = 59;
            this.btnPrint.Text = "&Imprimer";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmSyllabus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 722);
            this.ControlBox = false;
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cbbNiveauSyllabus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVolumeHoraire);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnRechercher);
            this.Controls.Add(this.txtRecherche);
            this.Controls.Add(this.btnSelectionner);
            this.Controls.Add(this.txtAnneeAcademique);
            this.Controls.Add(this.txtLibelle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgSyllabus);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSyllabus";
            this.Text = "Syllabus";
            this.Load += new System.EventHandler(this.frmSyllabus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgSyllabus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRechercher;
        private System.Windows.Forms.TextBox txtRecherche;
        private System.Windows.Forms.Button btnSelectionner;
        private System.Windows.Forms.Label txtAnneeAcademique;
        private System.Windows.Forms.TextBox txtLibelle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgSyllabus;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVolumeHoraire;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbNiveauSyllabus;
        private System.Windows.Forms.Button btnPrint;
    }
}