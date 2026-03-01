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
                string motDePasse = txtMotDePasse.Text.Trim();

                // Vérification dans la table AUtilisateurs
                var user = db.Utilisateurs
                             .FirstOrDefault(u => u.Identifiant == identifiant
                                               && u.MotDePasse == motDePasse);

                if (user != null)
                {
                    // Connexion réussie → ouvrir le menu principal
                    frmMDI mdi = new frmMDI();
                    mdi.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Identifiant ou mot de passe incorrect !");
                }
            }
        }


    }

}
