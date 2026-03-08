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
            try
            {
                using (var db = new BdCahierTexteContext())
                {
                    // Test simple : compter les utilisateurs
                    int count = db.Utilisateurs.Count();
                    MessageBox.Show($"Connexion réussie ! Utilisateurs trouvés : {count}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion : " + ex.Message);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

                // Récupérer l'utilisateur par identifiant
                var user = db.Utilisateurs.FirstOrDefault(u => u.Identifiant == identifiant);

                if (user != null)
                {
                    // Recalculer le hash avec le mot de passe saisi + le sel stocké
                    string hashTest = Crypto.HashWithSalt(motDePasseSaisi, user.Salt);

                    if (hashTest == user.PasswordHash)
                    {
                        // Connexion réussie → ouvrir frmMDI avec le rôle
                        frmMDI mdi = new frmMDI(user.Role); // on passe le rôle au constructeur
                        mdi.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Mot de passe incorrect !");
                    }


                }
                else
                {
                    MessageBox.Show("Utilisateur introuvable !");
                }
            }
        }



    }

}
