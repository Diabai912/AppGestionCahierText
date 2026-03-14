using AppGestionCahierText.Shared;
using AppGestionCahierText.views.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGestionCahierText.views.parametre
{
    public partial class frmUtilisateur : Form
    {
        BdCahierTexteContext db = new BdCahierTexteContext();
        int idUtilisateur = 0;

        public frmUtilisateur()
        {
            InitializeComponent();
        }

        private void frmUtilisateur_Load(object sender, EventArgs e)
        {
            AppliquerStyle();
            cbbRole.DataSource = new string[] { "Responsable", "Professeur", "Admin" };
            AfficherUtilisateurs();
        }

        // ✅ Style uniforme
        private void AppliquerStyle()
        {
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(245, 245, 250);

            Color purple = Color.Purple;
            Color white = Color.White;
            Font fontBtn = new Font("Segoe UI", 10f);

            foreach (Control ctrl in this.Controls)
                StyleControle(ctrl, purple, white, fontBtn);

            DgUtilisateurs.BackgroundColor = Color.White;
            DgUtilisateurs.BorderStyle = BorderStyle.FixedSingle;
            DgUtilisateurs.ColumnHeadersDefaultCellStyle.BackColor = Color.Purple;
            DgUtilisateurs.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DgUtilisateurs.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f);
            DgUtilisateurs.EnableHeadersVisualStyles = false;
            DgUtilisateurs.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 240, 255);
            DgUtilisateurs.DefaultCellStyle.SelectionBackColor = Color.FromArgb(83, 74, 183);
            DgUtilisateurs.DefaultCellStyle.SelectionForeColor = Color.White;
            DgUtilisateurs.GridColor = Color.FromArgb(200, 190, 230);
            DgUtilisateurs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void StyleControle(Control ctrl, Color purple, Color white, Font fontBtn)
        {
            if (ctrl is Button btn)
            {
                btn.BackColor = purple;
                btn.ForeColor = white;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = fontBtn;
                btn.Cursor = Cursors.Hand;
            }
            else if (ctrl is TextBox txt)
            {
                txt.BackColor = Color.FromArgb(240, 235, 255);
                txt.ForeColor = Color.FromArgb(60, 52, 137);
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.Font = new Font("Segoe UI", 10f);
            }
            else if (ctrl is ComboBox cmb)
            {
                cmb.BackColor = Color.FromArgb(240, 235, 255);
                cmb.ForeColor = Color.FromArgb(60, 52, 137);
                cmb.Font = new Font("Segoe UI", 10f);
            }
            else if (ctrl is Label lbl)
            {
                lbl.ForeColor = Color.FromArgb(60, 52, 137);
                lbl.Font = new Font("Segoe UI", 10f);
                lbl.BackColor = Color.Transparent;
            }

            foreach (Control child in ctrl.Controls)
                StyleControle(child, purple, white, fontBtn);
        }

        private void AfficherUtilisateurs()
        {
            DgUtilisateurs.DataSource = db.Utilisateurs
                .Select(u => new {
                    u.IdUtilisateur,
                    u.NomUtilisateur,
                    u.PrenomUtilisateur,
                    u.AdresseUtilisateur,
                    u.EmailUtilisateur,
                    u.TelephoneUtilisateur,
                    u.Identifiant,
                    u.Role
                })
                .ToList();
        }

        private void ViderChamps()
        {
            txtNom.Clear();
            txtPrenom.Clear();
            txtAdresse.Clear();
            txtEmail.Clear();
            txtTelephone.Clear();
            txtIdentifiant.Clear();
            txtMotDePasse.Clear();
            cbbRole.SelectedIndex = -1;
            idUtilisateur = 0;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text) || string.IsNullOrWhiteSpace(txtMotDePasse.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires.");
                return;
            }

            string salt = Crypto.GenerateSalt();
            string hash = Crypto.HashWithSalt(txtMotDePasse.Text, salt);

            var utilisateur = new Utilisateur
            {
                NomUtilisateur = txtNom.Text,
                PrenomUtilisateur = txtPrenom.Text,
                AdresseUtilisateur = txtAdresse.Text,
                EmailUtilisateur = txtEmail.Text,
                TelephoneUtilisateur = txtTelephone.Text,
                Identifiant = txtIdentifiant.Text,
                PasswordHash = hash,
                Salt = salt,
                Role = cbbRole.SelectedItem.ToString()
            };

            db.Utilisateurs.Add(utilisateur);
            db.SaveChanges();
            AfficherUtilisateurs();
            ViderChamps();
            MessageBox.Show("Utilisateur ajouté avec succès !");
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            var utilisateur = db.Utilisateurs.Find(idUtilisateur);
            if (utilisateur != null)
            {
                utilisateur.NomUtilisateur = txtNom.Text;
                utilisateur.PrenomUtilisateur = txtPrenom.Text;
                utilisateur.AdresseUtilisateur = txtAdresse.Text;
                utilisateur.EmailUtilisateur = txtEmail.Text;
                utilisateur.TelephoneUtilisateur = txtTelephone.Text;
                utilisateur.Identifiant = txtIdentifiant.Text;
                utilisateur.Role = cbbRole.SelectedItem.ToString();

                if (!string.IsNullOrWhiteSpace(txtMotDePasse.Text))
                {
                    string salt = Crypto.GenerateSalt();
                    string hash = Crypto.HashWithSalt(txtMotDePasse.Text, salt);
                    utilisateur.PasswordHash = hash;
                    utilisateur.Salt = salt;
                }

                db.SaveChanges();
                AfficherUtilisateurs();
                ViderChamps();
                MessageBox.Show("Utilisateur modifié avec succès !");
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (idUtilisateur == 0)
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur avant de supprimer !");
                return;
            }

            var confirmation = MessageBox.Show("Voulez-vous vraiment supprimer cet utilisateur ?",
                                               "Confirmation",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);
            if (confirmation == DialogResult.Yes)
            {
                var utilisateur = db.Utilisateurs.Find(idUtilisateur);
                if (utilisateur != null)
                {
                    db.Utilisateurs.Remove(utilisateur);
                    db.SaveChanges();
                    AfficherUtilisateurs();
                    ViderChamps();
                    MessageBox.Show("Utilisateur supprimé avec succès !");
                }
            }
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            if (DgUtilisateurs.CurrentRow == null) return;

            idUtilisateur = Convert.ToInt32(DgUtilisateurs.CurrentRow.Cells[0].Value);
            txtNom.Text = DgUtilisateurs.CurrentRow.Cells["NomUtilisateur"].Value.ToString();
            txtPrenom.Text = DgUtilisateurs.CurrentRow.Cells["PrenomUtilisateur"].Value.ToString();
            txtAdresse.Text = DgUtilisateurs.CurrentRow.Cells["AdresseUtilisateur"].Value.ToString();
            txtEmail.Text = DgUtilisateurs.CurrentRow.Cells["EmailUtilisateur"].Value.ToString();
            txtTelephone.Text = DgUtilisateurs.CurrentRow.Cells["TelephoneUtilisateur"].Value.ToString();
            txtIdentifiant.Text = DgUtilisateurs.CurrentRow.Cells["Identifiant"].Value.ToString();
            cbbRole.SelectedItem = DgUtilisateurs.CurrentRow.Cells["Role"].Value.ToString();
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            string motCle = txtRecherche.Text.Trim();

            DgUtilisateurs.DataSource = db.Utilisateurs
                .Where(u => u.NomUtilisateur.Contains(motCle)
                         || u.PrenomUtilisateur.Contains(motCle)
                         || u.EmailUtilisateur.Contains(motCle)
                         || u.Identifiant.Contains(motCle))
                .Select(u => new {
                    u.IdUtilisateur,
                    u.NomUtilisateur,
                    u.PrenomUtilisateur,
                    u.AdresseUtilisateur,
                    u.EmailUtilisateur,
                    u.TelephoneUtilisateur,
                    u.Identifiant,
                    u.Role
                })
                .ToList();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPrintUtilisateur f = new frmPrintUtilisateur();
            f.ShowDialog();
        }

        private void txtNom_TextChanged(object sender, EventArgs e) { }
    }
}