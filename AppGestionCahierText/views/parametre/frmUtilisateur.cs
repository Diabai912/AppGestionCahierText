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

        private void txtNom_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmUtilisateur_Load(object sender, EventArgs e)
        {
            // Charger les rôles possibles
            cbbRole.DataSource = new string[] { "Responsable", "Professeur", "Admin" }; 
            // Afficher les utilisateurs existants
            AfficherUtilisateurs();
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



        private void btnAjouter_Click(object sender, EventArgs e)
        {
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
            }
        }


        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (idUtilisateur == 0)
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur avant de supprimer !");
                return;
            }

            var utilisateur = db.Utilisateurs.Find(idUtilisateur);
            if (utilisateur != null)
            {
                db.Utilisateurs.Remove(utilisateur);
                db.SaveChanges();
                AfficherUtilisateurs();
                ViderChamps();
            }
        }


        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            if (DgUtilisateurs.CurrentRow == null) return;

            idUtilisateur = Convert.ToInt32(DgUtilisateurs.CurrentRow.Cells[0].Value); // première colonne = IdUtilisateur

            txtNom.Text = DgUtilisateurs.CurrentRow.Cells["NomUtilisateur"].Value.ToString();
            txtPrenom.Text = DgUtilisateurs.CurrentRow.Cells["PrenomUtilisateur"].Value.ToString();
            txtAdresse.Text = DgUtilisateurs.CurrentRow.Cells["AdresseUtilisateur"].Value.ToString();
            txtEmail.Text = DgUtilisateurs.CurrentRow.Cells["EmailUtilisateur"].Value.ToString();
            txtTelephone.Text = DgUtilisateurs.CurrentRow.Cells["TelephoneUtilisateur"].Value.ToString();
            txtIdentifiant.Text = DgUtilisateurs.CurrentRow.Cells["Identifiant"].Value.ToString();
            cbbRole.SelectedItem = DgUtilisateurs.CurrentRow.Cells["Role"].Value.ToString();
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

    }
}
