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
    public partial class frmDetailsCahierTexte : Form
    {
        BdCahierTexteContext db = new BdCahierTexteContext();
        int idDetails = 0;
        int idCahierTexteFiltre = 0;
        
        public frmDetailsCahierTexte()
        {
            InitializeComponent();
            
            // Set DateTimePicker range to accept reasonable dates
            dateTimePicker.MinDate = new DateTime(2000, 1, 1);
            dateTimePicker.MaxDate = new DateTime(2100, 12, 31);
            
            // Charger les matières
            cbbMatiere.DataSource = db.Matieres.ToList();
            cbbMatiere.DisplayMember = "LibelleMatiere";
            cbbMatiere.ValueMember = "IdMatiere";
        }

        private void cbbAnnee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmDetailsCahierTexte_Load(object sender, EventArgs e)
        {
            AfficherDetails();
        }

        private void AfficherDetails()
        {
            var query = db.DetailsCahierTextes.AsQueryable();
            
            // Filtrer uniquement par ID de cahier de texte si défini
            if (idCahierTexteFiltre > 0)
            {
                query = query.Where(d => d.IdCahierTexte == idCahierTexteFiltre);
            }
            
            var result = query.Select(d => new
            {
                d.IdDetailsCahierTexte,
                d.IdCahierTexte,
                d.IdMatiere,
                Matiere = d.Matiere.LibelleMatiere,
                d.DateDetail,
                d.Description
            }).ToList();
            
            DgDetails.DataSource = result;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDescription.Text) || cbbMatiere.SelectedValue == null)
                {
                    MessageBox.Show("Veuillez remplir tous les champs obligatoires.", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nouveauDetail = new DetailsCahierTexte
                {
                    IdCahierTexte = idCahierTexteFiltre > 0 ? idCahierTexteFiltre : (int?)null,
                    IdMatiere = (int)cbbMatiere.SelectedValue,
                    DateDetail = dateTimePicker.Value,
                    Description = txtDescription.Text.Trim()
                };

                db.DetailsCahierTextes.Add(nouveauDetail);
                db.SaveChanges();
                
                AfficherDetails();
                ViderChamps();
                MessageBox.Show("Détail ajouté avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (idDetails == 0)
                {
                    MessageBox.Show("Veuillez d'abord sélectionner un détail à modifier.", "Sélection requise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDescription.Text) || cbbMatiere.SelectedValue == null)
                {
                    MessageBox.Show("Veuillez remplir tous les champs obligatoires.", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var detailAModifier = db.DetailsCahierTextes.Find(idDetails);
                if (detailAModifier != null)
                {
                    detailAModifier.IdMatiere = (int)cbbMatiere.SelectedValue;
                    detailAModifier.DateDetail = dateTimePicker.Value;
                    detailAModifier.Description = txtDescription.Text.Trim();
                    
                    db.SaveChanges();
                    AfficherDetails();
                    ViderChamps();
                    MessageBox.Show("Détail modifié avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (idDetails == 0)
                {
                    MessageBox.Show("Veuillez d'abord sélectionner un détail à supprimer.", "Sélection requise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var resultat = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce détail?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (resultat == DialogResult.Yes)
                {
                    var detailASupprimer = db.DetailsCahierTextes.Find(idDetails);
                    if (detailASupprimer != null)
                    {
                        db.DetailsCahierTextes.Remove(detailASupprimer);
                        db.SaveChanges();
                        AfficherDetails();
                        ViderChamps();
                        MessageBox.Show("Détail supprimé avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            if (DgDetails.CurrentRow == null) return;
            
            idDetails = (int)DgDetails.CurrentRow.Cells["IdDetailsCahierTexte"].Value;
            cbbMatiere.SelectedValue = (int)DgDetails.CurrentRow.Cells["IdMatiere"].Value;
            txtDescription.Text = DgDetails.CurrentRow.Cells["Description"].Value.ToString();
            
            // Safe date conversion with fallback
            try
            {
                var dateValue = Convert.ToDateTime(DgDetails.CurrentRow.Cells["DateDetail"].Value);
                if (dateValue >= dateTimePicker.MinDate && dateValue <= dateTimePicker.MaxDate)
                {
                    dateTimePicker.Value = dateValue;
                }
                else
                {
                    dateTimePicker.Value = DateTime.Now;
                }
            }
            catch
            {
                dateTimePicker.Value = DateTime.Now;
            }
        }

        private void ViderChamps()
        {
            txtDescription.Clear();
            dateTimePicker.Value = DateTime.Now;
            cbbMatiere.SelectedIndex = -1;
            idDetails = 0;
        }

        public void SetCahierTexteId(int id)
        {
            idCahierTexteFiltre = id;
            // Rafraîchir l'affichage avec le filtre
            AfficherDetails();
        }
    }
}
