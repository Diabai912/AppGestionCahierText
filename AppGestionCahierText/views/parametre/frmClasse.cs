using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppGestionCahierText.views.Models;

namespace AppGestionCahierText.views.parametre
{
    public partial class frmClasse : Form
    {
        BdCahierTexteContext db = new BdCahierTexteContext();



        private void Effacer()
        {
            // Vider le champ texte
            txtLibelle.Text = string.Empty;

            var annees = db.AnneeAcademiques.ToList();
            cbbAnneeAcademique.DataSource = annees;
            cbbAnneeAcademique.DisplayMember = "LibelleAnneeAcademique"; // ce que l’utilisateur voit
            cbbAnneeAcademique.ValueMember = "AnneeAcademiqueId";        // ce qui est stocké en base

            // Laisser vide au départ
            cbbAnneeAcademique.SelectedIndex = -1;


            // Recharger les classes dans le DataGridView
            DgClasse.DataSource = db.Classes
                .Select(c => new
                {
                    c.ClasseId,
                    c.LibelleClasse,
                    AnneeAcademique = c.AnneeAcademique.LibelleAnneeAcademique, // affiche 2024-2025 ou 2025-2026
                    Annee = c.AnneeAcademique.ValueAnneeAcademique               // affiche 2025 ou 2026
                })
                .ToList();


            // Remettre le focus sur le champ texte
            txtLibelle.Focus();
        }


        public frmClasse()
        {
            InitializeComponent();
        }

        private string GetS()
        {
            return cbbAnneeAcademique.SelectedValue.ToString();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtLibelle.Text))
                {
                    MessageBox.Show("Veuillez saisir un libellé.");
                    return;
                }

                if (cbbAnneeAcademique.SelectedItem is AnneeAcademique anneeObj)
                {
                    Classe c = new Classe
                    {
                        LibelleClasse = txtLibelle.Text,
                        AnneeAcademiqueId = anneeObj.AnneeAcademiqueId
                    };

                    db.Classes.Add(c);
                    db.SaveChanges(); // <-- c’est ici que l’erreur peut arriver

                    Effacer();
                    MessageBox.Show("Classe ajoutée avec succès !");
                }
                else
                {
                    MessageBox.Show("Veuillez choisir une année académique valide.");
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        MessageBox.Show($"Propriété: {ve.PropertyName} Erreur: {ve.ErrorMessage}");
                    }
                }
            }
        }







        private void frmClasse_Load(object sender, EventArgs e)
        {

            DgClasse.AutoGenerateColumns = true;
            Effacer();

        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgClasse.CurrentRow != null)
                {
                    int id = (int)DgClasse.CurrentRow.Cells["ClasseId"].Value;
                    var c = db.Classes.Find(id);

                    if (c != null)
                    {
                        if (string.IsNullOrWhiteSpace(txtLibelle.Text))
                        {
                            MessageBox.Show("Veuillez saisir un libellé.");
                            return;
                        }

                        // Mettre à jour avec les nouvelles valeurs
                        c.LibelleClasse = txtLibelle.Text;
                        if (cbbAnneeAcademique.SelectedValue != null && cbbAnneeAcademique.SelectedValue is int)
                        {
                            c.AnneeAcademiqueId = (int)cbbAnneeAcademique.SelectedValue;
                        }

                        db.SaveChanges();
                        Effacer();
                        MessageBox.Show("Classe modifiée avec succès !");
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner une ligne avant de modifier.");
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        MessageBox.Show($"Propriété: {ve.PropertyName} Erreur: {ve.ErrorMessage}");
                    }
                }
            }
        }







        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            var value = DgClasse.CurrentRow.Cells[0].Value;
            MessageBox.Show($"Type: {value.GetType().ToString()}\nValeur: {value.ToString()}");

            if (DgClasse.CurrentRow != null)
            {
                int id = Convert.ToInt32(DgClasse.CurrentRow.Cells[0].Value);
                var c = db.Classes.Find(id);
                if (c != null)
                {
                    db.Classes.Remove(c);
                    db.SaveChanges();
                    Effacer();
                }
            }
        }


        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            if (DgClasse.CurrentRow != null)
            {
                // Récupérer l'ID de la classe sélectionnée
                int id = (int)DgClasse.CurrentRow.Cells["ClasseId"].Value;
                var c = db.Classes.Find(id);

                if (c != null)
                {
                    // Charger les données dans les champs
                    txtLibelle.Text = c.LibelleClasse;
                    cbbAnneeAcademique.SelectedValue = c.AnneeAcademiqueId;
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne dans le tableau.");
            }
        }


        private void cbbAnneeAcademique_SelectedIndexChanged(object sender, EventArgs e)
        {
            var liste = db.Classes.AsQueryable();

            // Filtrer par année académique (ComboBox)
            if (cbbAnneeAcademique.SelectedValue != null && cbbAnneeAcademique.SelectedValue is int) {
                int anneeId = (int)cbbAnneeAcademique.SelectedValue; 
                liste = liste.Where(c => c.AnneeAcademiqueId == anneeId); 
            }

            // Filtrer par champ texte "txtAnneeAcademique"
            if (!string.IsNullOrWhiteSpace(txtAnneeAcademique.Text) && int.TryParse(txtAnneeAcademique.Text, out int annee))
            {
                liste = liste.Where(c => c.AnneeAcademiqueId == annee);
            }

            // Filtrer par libellé de classe "txtLibelle"
            if (!string.IsNullOrWhiteSpace(txtLibelle.Text))
            {
                liste = liste.Where(f => f.LibelleClasse.ToUpper().Contains(txtLibelle.Text.ToUpper()));
            }

            // Mettre à jour le DataGridView
            DgClasse.DataSource = liste
                .Select(c => new
                {
                    c.ClasseId,
                    c.LibelleClasse,
                    c.AnneeAcademiqueId,
                    Annee = c.AnneeAcademique.LibelleAnneeAcademique
                })
                .Take(100)
                .ToList();
        }

        private void txtLibelle_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRecherche_Enter(object sender, EventArgs e)
        {
            if (txtRecherche.Text == "Rechercher...")
            {
                txtRecherche.Text = "";
                txtRecherche.ForeColor = Color.Black;
            }
        }


        private void txtRecherche_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRecherche.Text))
            {
                txtRecherche.Text = "Rechercher...";
                txtRecherche.ForeColor = Color.Gray;
            }
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            string critere = txtRecherche.Text.Trim();

            var resultats = db.Classes
                .Where(c => c.LibelleClasse.Contains(critere)
                         || c.AnneeAcademique.LibelleAnneeAcademique.Contains(critere)
                         || c.AnneeAcademique.ValueAnneeAcademique.ToString().Contains(critere))
                .Select(c => new
                {
                    c.ClasseId,
                    c.LibelleClasse,
                    AnneeAcademique = c.AnneeAcademique.LibelleAnneeAcademique,
                    Annee = c.AnneeAcademique.ValueAnneeAcademique
                })
                .ToList();

            DgClasse.DataSource = resultats;

            if (resultats.Count == 0)
            {
                MessageBox.Show("Aucun résultat trouvé.");
            }
        }

    }

}

