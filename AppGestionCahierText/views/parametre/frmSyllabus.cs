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
    public partial class frmSyllabus : Form
    {
        BdCahierTexteContext db = new BdCahierTexteContext(); 
        int idSyllabus = 0;
        public frmSyllabus()
        {
            InitializeComponent();
        }

        private void frmSyllabus_Load(object sender, EventArgs e)
        {
            // Charger les niveaux possibles
            cbbNiveauSyllabus.DataSource = new string[] { "L1", "L2", "L3", "M1", "M2" }; 
            //Afficher les syllabus existants
            AfficherSyllabus();
        }

        private void AfficherSyllabus() {
            DgSyllabus.DataSource = db.Syllabuses
                .Select(s => new
                { 
                    s.IdSyllabus, 
                    s.LibelleSyllabus,
                    s.DescriptionSyllabus, 
                    s.VolumeHoraireSyllabus, 
                    s.NiveauSyllabus,
                    VoirDetails = "Voir détails"
                })
                .ToList();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLibelle.Text) ||
                string.IsNullOrWhiteSpace(txtDescription.Text) ||
                string.IsNullOrWhiteSpace(txtVolumeHoraire.Text) ||
                cbbNiveauSyllabus.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires.");
                return;
            }

            int volume;
            if (!int.TryParse(txtVolumeHoraire.Text, out volume))
            {
                MessageBox.Show("Le volume horaire doit être un nombre.");
                return;
            }

            var syllabus = new Syllabus
            {
                LibelleSyllabus = txtLibelle.Text,
                DescriptionSyllabus = txtDescription.Text,
                VolumeHoraireSyllabus = volume,
                NiveauSyllabus = cbbNiveauSyllabus.SelectedItem.ToString()
            };

            db.Syllabuses.Add(syllabus);
            db.SaveChanges();
            AfficherSyllabus();
            ViderChamps();
            MessageBox.Show("Syllabus ajouté avec succès !");
        }



        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (DgSyllabus.CurrentRow == null) return;

            int id = (int)DgSyllabus.CurrentRow.Cells["IdSyllabus"].Value;
            var syllabus = db.Syllabuses.Find(id);

            if (syllabus != null)
            {
                // Vérifier que les champs ne sont pas vides
                if (string.IsNullOrWhiteSpace(txtLibelle.Text) ||
                    string.IsNullOrWhiteSpace(txtDescription.Text) ||
                    string.IsNullOrWhiteSpace(txtVolumeHoraire.Text) ||
                    cbbNiveauSyllabus.SelectedIndex == -1)
                {
                    MessageBox.Show("Veuillez sélectionner et modifier les données avant de valider.");
                    return;
                }

                int volume;
                if (!int.TryParse(txtVolumeHoraire.Text, out volume))
                {
                    MessageBox.Show("Le volume horaire doit être un nombre valide.");
                    return;
                }

                // Vérifier si les données ont changé
                if (syllabus.LibelleSyllabus == txtLibelle.Text &&
                    syllabus.DescriptionSyllabus == txtDescription.Text &&
                    syllabus.VolumeHoraireSyllabus == volume &&
                    syllabus.NiveauSyllabus == cbbNiveauSyllabus.SelectedItem.ToString())
                {
                    MessageBox.Show("Aucune modification détectée.");
                    return;
                }

                // Appliquer les modifications
                syllabus.LibelleSyllabus = txtLibelle.Text;
                syllabus.DescriptionSyllabus = txtDescription.Text;
                syllabus.VolumeHoraireSyllabus = volume;
                syllabus.NiveauSyllabus = cbbNiveauSyllabus.SelectedItem.ToString();

                db.SaveChanges();
                AfficherSyllabus();
                ViderChamps();
                MessageBox.Show("Syllabus modifié avec succès !");
            }
        }




        private void ViderChamps() 
        {
            txtLibelle.Clear(); 
            txtDescription.Clear();
            txtVolumeHoraire.Clear(); 
            cbbNiveauSyllabus.SelectedIndex = -1; 
            idSyllabus = 0;
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (DgSyllabus.CurrentRow == null) return;

            int id = (int)DgSyllabus.CurrentRow.Cells["IdSyllabus"].Value;
            var syllabus = db.Syllabuses.Find(id);

            if (syllabus != null)
            {
                db.Syllabuses.Remove(syllabus);
                db.SaveChanges();
                AfficherSyllabus();
                ViderChamps();
                MessageBox.Show("Syllabus supprimé avec succès !");
            }
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            if (DgSyllabus.CurrentRow == null) return;

            // Remplir les champs avec les données de la ligne sélectionnée
            txtLibelle.Text = DgSyllabus.CurrentRow.Cells["LibelleSyllabus"].Value.ToString();
            txtDescription.Text = DgSyllabus.CurrentRow.Cells["DescriptionSyllabus"].Value.ToString();
            txtVolumeHoraire.Text = DgSyllabus.CurrentRow.Cells["VolumeHoraireSyllabus"].Value.ToString();
            cbbNiveauSyllabus.SelectedItem = DgSyllabus.CurrentRow.Cells["NiveauSyllabus"].Value.ToString();
        }


        private void btnRechercher_Click(object sender, EventArgs e)
        {
            string motCle = txtRecherche.Text; 
            DgSyllabus.DataSource = db.Syllabuses
                .Where(s => s.LibelleSyllabus.Contains(motCle) || s.DescriptionSyllabus.Contains(motCle))
                .ToList();
        }

        private void DgSyllabus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DgSyllabus.Columns[e.ColumnIndex].Name == "VoirDetails")
            {
                int idSyllabus = Convert.ToInt32(DgSyllabus.Rows[e.RowIndex].Cells["IdSyllabus"].Value);
                
                frmDetailsSyllabus frmDetails = new frmDetailsSyllabus();
                frmDetails.SetSyllabusId(idSyllabus);
                frmDetails.ShowDialog();
            }
        }
    }
    
}
