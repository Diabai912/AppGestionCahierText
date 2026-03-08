namespace AppGestionCahierText
{
    partial class frmMDI
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
            this.menuMatiere = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSyllabus = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seDeconnecterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClasse = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAnneeAcademique = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCahierTexte = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuUtilisateur = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDetailsSyllabus = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMatiere
            // 
            this.menuMatiere.Name = "menuMatiere";
            this.menuMatiere.Size = new System.Drawing.Size(270, 34);
            this.menuMatiere.Text = "&Matiere";
            this.menuMatiere.Visible = false;
            this.menuMatiere.Click += new System.EventHandler(this.menuMatiere_Click);
            // 
            // menuSyllabus
            // 
            this.menuSyllabus.Name = "menuSyllabus";
            this.menuSyllabus.Size = new System.Drawing.Size(270, 34);
            this.menuSyllabus.Text = "Syllabus";
            this.menuSyllabus.Visible = false;
            this.menuSyllabus.Click += new System.EventHandler(this.menuSyllabus_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripMenuItem,
            this.parametreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seDeconnecterToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(79, 29);
            this.actionToolStripMenuItem.Text = "&Action";
            // 
            // seDeconnecterToolStripMenuItem
            // 
            this.seDeconnecterToolStripMenuItem.Name = "seDeconnecterToolStripMenuItem";
            this.seDeconnecterToolStripMenuItem.Size = new System.Drawing.Size(235, 34);
            this.seDeconnecterToolStripMenuItem.Text = "&Se deconnecter";
            this.seDeconnecterToolStripMenuItem.Click += new System.EventHandler(this.seDeconnecterToolStripMenuItem_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(235, 34);
            this.quitterToolStripMenuItem.Text = "&Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // parametreToolStripMenuItem
            // 
            this.parametreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMatiere,
            this.menuClasse,
            this.MenuAnneeAcademique,
            this.menuCahierTexte,
            this.menuSyllabus,
            this.MenuUtilisateur,
            this.menuDetailsSyllabus});
            this.parametreToolStripMenuItem.Name = "parametreToolStripMenuItem";
            this.parametreToolStripMenuItem.Size = new System.Drawing.Size(107, 29);
            this.parametreToolStripMenuItem.Text = "&Parametre";
            // 
            // menuClasse
            // 
            this.menuClasse.Name = "menuClasse";
            this.menuClasse.Size = new System.Drawing.Size(270, 34);
            this.menuClasse.Text = "&Classe";
            this.menuClasse.Visible = false;
            this.menuClasse.Click += new System.EventHandler(this.menuClasse_Click);
            // 
            // MenuAnneeAcademique
            // 
            this.MenuAnneeAcademique.Name = "MenuAnneeAcademique";
            this.MenuAnneeAcademique.Size = new System.Drawing.Size(270, 34);
            this.MenuAnneeAcademique.Text = "&Annee academique";
            this.MenuAnneeAcademique.Visible = false;
            this.MenuAnneeAcademique.Click += new System.EventHandler(this.menuAnneeAcademique_Click);
            // 
            // menuCahierTexte
            // 
            this.menuCahierTexte.Name = "menuCahierTexte";
            this.menuCahierTexte.Size = new System.Drawing.Size(270, 34);
            this.menuCahierTexte.Text = "Cahier de Texte";
            this.menuCahierTexte.Visible = false;
            this.menuCahierTexte.Click += new System.EventHandler(this.menuCahierTexte_Click);
            // 
            // MenuUtilisateur
            // 
            this.MenuUtilisateur.Name = "MenuUtilisateur";
            this.MenuUtilisateur.Size = new System.Drawing.Size(270, 34);
            this.MenuUtilisateur.Text = "Utilisateur";
            this.MenuUtilisateur.Visible = false;
            this.MenuUtilisateur.Click += new System.EventHandler(this.menuUtilisateur_Click);
            // 
            // menuDetailsSyllabus
            // 
            this.menuDetailsSyllabus.Name = "menuDetailsSyllabus";
            this.menuDetailsSyllabus.Size = new System.Drawing.Size(270, 34);
            this.menuDetailsSyllabus.Text = "Details syllabus";
            this.menuDetailsSyllabus.Visible = false;
            this.menuDetailsSyllabus.Click += new System.EventHandler(this.menuDetailsSyllabus_Click);
            // 
            // frmMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMDI";
            this.Text = "Gestion cahier de texte::";
            this.Load += new System.EventHandler(this.frmMDI_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seDeconnecterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parametreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuClasse;
        private System.Windows.Forms.ToolStripMenuItem MenuAnneeAcademique;
        private System.Windows.Forms.ToolStripMenuItem menuCahierTexte;
        private System.Windows.Forms.ToolStripMenuItem MenuUtilisateur;
        private System.Windows.Forms.ToolStripMenuItem menuDetailsSyllabus;
        private System.Windows.Forms.ToolStripMenuItem menuMatiere;
        private System.Windows.Forms.ToolStripMenuItem menuSyllabus;
    }
}