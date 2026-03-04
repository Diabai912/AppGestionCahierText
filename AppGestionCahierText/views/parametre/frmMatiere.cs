using AppGestionCahierText.views.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGestionCahierText.views.parametre
{
    public partial class frmMatiere : Form
    {
        private BdCahierTexteContext db = new BdCahierTexteContext();
        public frmMatiere()
        {
            InitializeComponent();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            int volume;
            if (!int.TryParse(txtVolumeHoraire.Text, out volume))
            {
                MessageBox.Show("Veuillez saisir un nombre valide pour le volume horaire.");
                return;
            }

            var matiere = new Matiere
            {
                LibelleMatiere = txtLibelleMatiere.Text,
                VolumeHoraireMatiere = volume,
                Niveau = txtNiveau.Text,
                IdProfesseur = (int)cbbProfesseur.SelectedValue // lien avec Utilisateur
            };

            db.Matieres.Add(matiere);
            db.SaveChanges();
            AfficherMatiere();
            ViderChamps();
            MessageBox.Show("Matière ajoutée avec succès !");
        }





        private void AfficherMatiere()
        {
            var matieres = db.Matieres
                .Include(m => m.Professeur) 
                .ToList();

            DgMatiere.DataSource = matieres
                .Select(m => new
                {
                    m.IdMatiere,
                    m.LibelleMatiere,
                    m.VolumeHoraireMatiere,
                    m.Niveau,
                    m.IdProfesseur,
                    Professeur = m.Professeur != null ? m.Professeur.NomUtilisateur : ""
                })
                .ToList();

            DgMatiere.Columns["IdProfesseur"].Visible = false;
        }




        private void frmMatiere_Load(object sender, EventArgs e)
        {
            AfficherMatiere();

            // Charger les professeurs depuis Utilisateurs
            cbbProfesseur.DataSource = db.Utilisateurs
                .Where(u => u.Role == "Professeur")
                .ToList();
            cbbProfesseur.DisplayMember = "NomUtilisateur";   // ce qui s’affiche
            cbbProfesseur.ValueMember = "IdUtilisateur";      // valeur réelle
        }


        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (DgMatiere.CurrentRow == null)
            {
                MessageBox.Show("Veuillez sélectionner une matière à modifier.");
                return;
            }

            int id = (int)DgMatiere.CurrentRow.Cells["IdMatiere"].Value;
            var matiere = db.Matieres.Find(id);

            if (matiere != null)
            {
                int volume;
                if (!int.TryParse(txtVolumeHoraire.Text, out volume))
                {
                    MessageBox.Show("Veuillez saisir un nombre valide pour le volume horaire.");
                    return;
                }

                matiere.LibelleMatiere = txtLibelleMatiere.Text;
                matiere.VolumeHoraireMatiere = volume;
                matiere.Niveau = txtNiveau.Text;

                matiere.IdProfesseur = (int)cbbProfesseur.SelectedValue;

                db.SaveChanges();
                AfficherMatiere();
                ViderChamps(); // <-- vide les champs après modification
                MessageBox.Show("Matière modifiée avec succès !");
            }
        }



        private void ViderChamps()
        {
            txtLibelleMatiere.Clear();
            txtVolumeHoraire.Clear();
            txtNiveau.Clear();

            
            if (cbbProfesseur.Items.Count > 0)
                cbbProfesseur.SelectedIndex = -1;
        }



        private void btnSupprimer_Click(object sender, EventArgs e)
        {
        
            if (DgMatiere.CurrentRow == null)
            {
                MessageBox.Show("Veuillez sélectionner une matière à supprimer.");
                return;
            }

            int id = (int)DgMatiere.CurrentRow.Cells["IdMatiere"].Value;
            var matiere = db.Matieres.Find(id);

            if (matiere != null)
            {
                var confirmation = MessageBox.Show("Voulez-vous vraiment supprimer cette matière ?",
                                                   "Confirmation",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);

                if (confirmation == DialogResult.Yes)
                {
                    db.Matieres.Remove(matiere);
                    db.SaveChanges();
                    AfficherMatiere();
                    MessageBox.Show("Matière supprimée avec succès !");
                }
            }
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            if (DgMatiere.CurrentRow != null)
            {
                txtLibelleMatiere.Text = DgMatiere.CurrentRow.Cells["LibelleMatiere"].Value.ToString();
                txtVolumeHoraire.Text = DgMatiere.CurrentRow.Cells["VolumeHoraireMatiere"].Value.ToString();
                txtNiveau.Text = DgMatiere.CurrentRow.Cells["Niveau"].Value.ToString();

                // Sélectionner le professeur lié
                int idProf = (int)DgMatiere.CurrentRow.Cells["IdProfesseur"].Value;
                cbbProfesseur.SelectedValue = idProf;
            }
        }







        private void btnRechercher_Click(object sender, EventArgs e)
        {
       
            string critere = txtRecherche.Text.Trim();

            var resultats = db.Matieres
                .Where(m => m.LibelleMatiere.Contains(critere)
                         || m.VolumeHoraireMatiere.ToString().Contains(critere)
                         || m.Niveau.Contains(critere))
                .Select(m => new
                {
                    m.IdMatiere,
                    m.LibelleMatiere,
                    m.VolumeHoraireMatiere,
                    m.Niveau
                })
                .ToList();

            DgMatiere.DataSource = resultats;

            if (resultats.Count == 0)
            {
                MessageBox.Show("Aucune matière trouvée.");
            }
        }

        private void DgMatiere_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtLibelleMatiere.Text = DgMatiere.Rows[e.RowIndex].Cells["LibelleMatiere"].Value.ToString();
                txtVolumeHoraire.Text = DgMatiere.Rows[e.RowIndex].Cells["VolumeHoraireMatiere"].Value.ToString();
                txtNiveau.Text = DgMatiere.Rows[e.RowIndex].Cells["Niveau"].Value.ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtLibelleMatiere_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtVolumeHoraire_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtNiveau_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {

        }

        private void DgMatiere_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
        private void cbbNiveauSyllabus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}







