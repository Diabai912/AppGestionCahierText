using AppGestionCahierText.Shared;
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
    public partial class frmConnexion : Form
    {
        public frmConnexion()
        {
            InitializeComponent();
        }

        private void frmConnexion_Load(object sender, EventArgs e)
        {
            AppliquerStyle();
        }

        private void AppliquerStyle()
        {
            // ✅ Formulaire centré, taille fixe
            this.BackColor = Color.FromArgb(245, 245, 250);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(420, 500);
            this.Text = "Gestion Cahier de Texte";

            // ✅ Vider tous les contrôles existants
            this.Controls.Clear();

            // ✅ Bandeau violet en haut
            Panel banner = new Panel();
            banner.BackColor = Color.Purple;
            banner.Size = new Size(420, 120);
            banner.Location = new Point(0, 0);

            Label lblAppName = new Label();
            lblAppName.Text = "Gestion Cahier";
            lblAppName.ForeColor = Color.White;
            lblAppName.Font = new Font("Segoe UI", 18f, FontStyle.Regular);
            lblAppName.AutoSize = true;
            lblAppName.Location = new Point(20, 20);

            Label lblSous = new Label();
            lblSous.Text = "de Texte";
            lblSous.ForeColor = Color.FromArgb(206, 203, 246);
            lblSous.Font = new Font("Segoe UI", 12f);
            lblSous.AutoSize = true;
            lblSous.Location = new Point(22, 60);

            banner.Controls.Add(lblAppName);
            banner.Controls.Add(lblSous);
            this.Controls.Add(banner);

            // ✅ Label Identifiant
            Label lblIdentifiant = new Label();
            lblIdentifiant.Text = "Identifiant";
            lblIdentifiant.ForeColor = Color.FromArgb(60, 52, 137);
            lblIdentifiant.Font = new Font("Segoe UI", 10f);
            lblIdentifiant.AutoSize = true;
            lblIdentifiant.Location = new Point(40, 150);
            this.Controls.Add(lblIdentifiant);

            // ✅ TextBox Identifiant
            txtIdentifiant.Location = new Point(40, 175);
            txtIdentifiant.Size = new Size(335, 35);
            txtIdentifiant.BackColor = Color.FromArgb(240, 235, 255);
            txtIdentifiant.ForeColor = Color.FromArgb(60, 52, 137);
            txtIdentifiant.BorderStyle = BorderStyle.FixedSingle;
            txtIdentifiant.Font = new Font("Segoe UI", 11f);
            this.Controls.Add(txtIdentifiant);

            // ✅ Label Mot de passe
            Label lblMotDePasse = new Label();
            lblMotDePasse.Text = "Mot de passe";
            lblMotDePasse.ForeColor = Color.FromArgb(60, 52, 137);
            lblMotDePasse.Font = new Font("Segoe UI", 10f);
            lblMotDePasse.AutoSize = true;
            lblMotDePasse.Location = new Point(40, 230);
            this.Controls.Add(lblMotDePasse);

            // ✅ TextBox Mot de passe
            txtMotDePasse.Location = new Point(40, 255);
            txtMotDePasse.Size = new Size(335, 35);
            txtMotDePasse.BackColor = Color.FromArgb(240, 235, 255);
            txtMotDePasse.ForeColor = Color.FromArgb(60, 52, 137);
            txtMotDePasse.BorderStyle = BorderStyle.FixedSingle;
            txtMotDePasse.Font = new Font("Segoe UI", 11f);
            txtMotDePasse.PasswordChar = '●';
            this.Controls.Add(txtMotDePasse);

            // ✅ Bouton Se connecter
            btnSeConnecter.Text = "Se connecter";
            btnSeConnecter.Location = new Point(40, 330);
            btnSeConnecter.Size = new Size(335, 45);
            btnSeConnecter.BackColor = Color.Purple;
            btnSeConnecter.ForeColor = Color.White;
            btnSeConnecter.FlatStyle = FlatStyle.Flat;
            btnSeConnecter.FlatAppearance.BorderSize = 0;
            btnSeConnecter.Font = new Font("Segoe UI", 11f);
            btnSeConnecter.Cursor = Cursors.Hand;
            this.Controls.Add(btnSeConnecter);

            // ✅ Bouton Quitter
            btnQuitter.Text = "Quitter";
            btnQuitter.Location = new Point(40, 390);
            btnQuitter.Size = new Size(335, 40);
            btnQuitter.BackColor = Color.FromArgb(240, 235, 255);
            btnQuitter.ForeColor = Color.FromArgb(60, 52, 137);
            btnQuitter.FlatStyle = FlatStyle.Flat;
            btnQuitter.FlatAppearance.BorderSize = 1;
            btnQuitter.FlatAppearance.BorderColor = Color.Purple;
            btnQuitter.Font = new Font("Segoe UI", 10f);
            btnQuitter.Cursor = Cursors.Hand;
            this.Controls.Add(btnQuitter);

            // ✅ Remettre les événements
            btnSeConnecter.Click += btnSeConnecter_Click;
            btnQuitter.Click += btnQuitter_Click;
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSeConnecter_Click(object sender, EventArgs e)
        {
            using (var db = new BdCahierTexteContext())
            {
                string identifiant = txtIdentifiant.Text.Trim();
                string motDePasseSaisi = txtMotDePasse.Text.Trim();

                var user = db.Utilisateurs
                    .Where(u => u.Identifiant == identifiant)
                    .FirstOrDefault();

                if (user != null)
                {
                    string hashTest = Crypto.HashWithSalt(motDePasseSaisi, user.Salt);
                    if (hashTest == user.PasswordHash)
                    {
                        frmMDI mdi = new frmMDI(user.Role, user.IdClasse);
                        mdi.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Mot de passe incorrect !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMotDePasse.Clear();
                        txtMotDePasse.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Utilisateur introuvable !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIdentifiant.Focus();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }
}