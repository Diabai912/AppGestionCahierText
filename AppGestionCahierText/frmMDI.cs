using AppGestionCahierText.views.Models;
using AppGestionCahierText.views.parametre;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGestionCahierText
{
    public partial class frmMDI : Form
    {
        private string _role;
        private int idClasseConnectee;

        public frmMDI(string role, int idClasse)
        {
            InitializeComponent();
            _role = role;
            idClasseConnectee = idClasse;
        }

        private void fermer()
        {
            var panelAccueil = this.Controls["panelAccueil"];
            if (panelAccueil != null) panelAccueil.Visible = false;

            if (this.MdiChildren.Length == 0)
                return;

            foreach (Form chform in this.MdiChildren)
            {
                if (!chform.IsDisposed)
                    chform.Close();
            }
        }

        private void menuMatiere_Click(object sender, EventArgs e)
        {
            fermer();
            frmMatiere f = new frmMatiere();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void menuClasse_Click(object sender, EventArgs e)
        {
            fermer();
            frmClasse f = new frmClasse();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void menuAnneeAcademique_Click(object sender, EventArgs e)
        {
            fermer();
            frmAnneeAcademique f = new frmAnneeAcademique();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void menuCahierTexte_Click(object sender, EventArgs e)
        {
            fermer();
            frmCahierTexte f = new frmCahierTexte();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void menuUtilisateur_Click(object sender, EventArgs e)
        {
            fermer();
            frmUtilisateur f = new frmUtilisateur();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void menuSyllabus_Click(object sender, EventArgs e)
        {
            fermer();
            frmSyllabus f = new frmSyllabus();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void seDeconnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConnexion f = new frmConnexion();
            f.Show();
            this.Close();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMDI_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Location = new Point(0, 0);

            // ✅ Fond gris clair
            this.BackColor = Color.FromArgb(248, 247, 255);

            // ✅ MdiClient gris clair
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient mdiClient)
                {
                    mdiClient.BackColor = Color.FromArgb(248, 247, 255);
                    break;
                }
            }

            // ✅ MenuStrip Purple
            menuStrip1.BackColor = Color.Purple;
            menuStrip1.ForeColor = Color.White;
            menuStrip1.Padding = new Padding(8, 6, 0, 6);
            menuStrip1.Font = new Font("Segoe UI", 10f);

            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.ForeColor = Color.White;
                item.BackColor = Color.Purple;
                foreach (ToolStripItem sub in item.DropDownItems)
                {
                    sub.ForeColor = Color.FromArgb(60, 52, 137);
                    sub.BackColor = Color.White;
                }
            }

            // ✅ Page d'accueil
            ChargerAccueil();

            // Gestion des rôles
            if (_role == "Admin")
            {
                menuMatiere.Visible = true;
                menuClasse.Visible = true;
                MenuAnneeAcademique.Visible = true;
                menuCahierTexte.Visible = true;
                MenuUtilisateur.Visible = true;
                menuSyllabus.Visible = true;
                menuDetailsSyllabus.Visible = true;
                menuDetailsCahierDeTexte.Visible = true;
            }
            else if (_role == "Responsable")
            {
                menuCahierTexte.Visible = true;
                menuDetailsCahierDeTexte.Visible = true;
            }
            else if (_role == "Professeur")
            {
                menuMatiere.Visible = true;
                menuSyllabus.Visible = true;
                menuDetailsSyllabus.Visible = true;
            }
        }

        private void menuDetailsSyllabus_Click(object sender, EventArgs e)
        {
            fermer();
            frmDetailsSyllabus frm = new frmDetailsSyllabus();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void menuDetailsCahierDeTexte_Click(object sender, EventArgs e)
        {
            fermer();
            int idCahierTexte = 1;
            frmDetailsCahierTexte frm = new frmDetailsCahierTexte();
            frm.SetCahierTexteId(idCahierTexte);
            frm.ShowDialog();
        }

        private void ChargerAccueil()
        {
            Panel accueil = new Panel();
            accueil.BackColor = Color.FromArgb(248, 247, 255); // ✅ Fond gris clair
            accueil.Dock = DockStyle.Fill;
            accueil.Name = "panelAccueil";

            // ✅ Bannière Purple
            Panel banner = new Panel();
            banner.BackColor = Color.Purple;
            banner.Height = 90;
            banner.Dock = DockStyle.Top;

            Label lblTitre = new Label();
            lblTitre.Text = "Gestion Cahier de Texte";
            lblTitre.ForeColor = Color.White;
            lblTitre.Font = new Font("Segoe UI", 20f);
            lblTitre.AutoSize = true;
            lblTitre.Location = new Point(24, 16);

            Label lblSous = new Label();
            lblSous.Text = "Bienvenue — " + _role;
            lblSous.ForeColor = Color.FromArgb(206, 203, 246);
            lblSous.Font = new Font("Segoe UI", 10f);
            lblSous.AutoSize = true;
            lblSous.Location = new Point(26, 52);

            banner.Controls.Add(lblTitre);
            banner.Controls.Add(lblSous);
            accueil.Controls.Add(banner);

            // Label modules
            Label lblModules = new Label();
            lblModules.Text = "Accès rapide";
            lblModules.Font = new Font("Segoe UI", 12f);
            lblModules.ForeColor = Color.FromArgb(60, 52, 137);
            lblModules.AutoSize = true;
            lblModules.Location = new Point(24, 110);
            accueil.Controls.Add(lblModules);

            // Cartes selon le rôle
            List<(string nom, EventHandler action)> modules = new List<(string, EventHandler)>();

            if (_role == "Admin")
            {
                modules.Add(("Matiere", (s, e) => menuMatiere_Click(s, e)));
                modules.Add(("Classe", (s, e) => menuClasse_Click(s, e)));
                modules.Add(("Annee Academique", (s, e) => menuAnneeAcademique_Click(s, e)));
                modules.Add(("Cahier Texte", (s, e) => menuCahierTexte_Click(s, e)));
                modules.Add(("Utilisateur", (s, e) => menuUtilisateur_Click(s, e)));
                modules.Add(("Syllabus", (s, e) => menuSyllabus_Click(s, e)));
                modules.Add(("Details Syllabus", (s, e) => menuDetailsSyllabus_Click(s, e)));
                modules.Add(("Details Cahier", (s, e) => menuDetailsCahierDeTexte_Click(s, e)));
            }
            else if (_role == "Responsable")
            {
                modules.Add(("Cahier Texte", (s, e) => menuCahierTexte_Click(s, e)));
                modules.Add(("Details Cahier", (s, e) => menuDetailsCahierDeTexte_Click(s, e)));
            }
            else if (_role == "Professeur")
            {
                modules.Add(("Matiere", (s, e) => menuMatiere_Click(s, e)));
                modules.Add(("Syllabus", (s, e) => menuSyllabus_Click(s, e)));
                modules.Add(("Details Syllabus", (s, e) => menuDetailsSyllabus_Click(s, e)));
            }

            // Créer les cartes
            int col = 0, row = 0;
            foreach (var module in modules)
            {
                Panel card = new Panel();
                card.Size = new Size(160, 100);
                card.Location = new Point(24 + col * 180, 140 + row * 120);
                card.BackColor = Color.White;
                card.Cursor = Cursors.Hand;

                // ✅ Barre Purple en haut
                Panel bar = new Panel();
                bar.BackColor = Color.Purple;
                bar.Height = 4;
                bar.Dock = DockStyle.Top;
                card.Controls.Add(bar);

                Label lbl = new Label();
                lbl.Text = module.nom;
                lbl.Font = new Font("Segoe UI", 10f);
                lbl.ForeColor = Color.FromArgb(60, 52, 137);
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Dock = DockStyle.Fill;
                card.Controls.Add(lbl);

                card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(238, 237, 254);
                card.MouseLeave += (s, e) => card.BackColor = Color.White;
                lbl.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(238, 237, 254);
                lbl.MouseLeave += (s, e) => card.BackColor = Color.White;

                card.Click += module.action;
                lbl.Click += module.action;

                accueil.Controls.Add(card);

                col++;
                if (col >= 4) { col = 0; row++; }
            }

            this.Controls.Add(accueil);
            accueil.BringToFront();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }
    }
}