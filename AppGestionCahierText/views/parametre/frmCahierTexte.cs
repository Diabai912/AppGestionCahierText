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
    public partial class frmCahierTexte : Form
    {
        private BdCahierTexteContext db = new BdCahierTexteContext();
        public frmCahierTexte()
        {
            InitializeComponent();
        }

        private void CahierTexte_Load(object sender, EventArgs e)
        {
            // Charger les classes
            cbbClasse.DataSource = db.Classes.ToList();
            cbbClasse.DisplayMember = "LibelleClasse";
            cbbClasse.ValueMember = "ClasseId";

            // Charger les années académiques
            cbbAnneeAcademique.DataSource = db.AnneeAcademiques.ToList();
            cbbAnneeAcademique.DisplayMember = "LibelleAnneeAcademique";
            cbbAnneeAcademique.ValueMember = "AnneeAcademiqueId";

            // Charger les responsables
            cbbResponsable.DataSource = db.Utilisateurs
                .Where(u => u.Role == "Responsable")
                .ToList();
            cbbResponsable.DisplayMember = "NomUtilisateur";
            cbbResponsable.ValueMember = "IdUtilisateur";

            // ✅ Charger le DataGridView dès l’ouverture
            AfficherCahierTexte();

            var classes = db.Classes.ToList();
            classes.Insert(0, new Classe { ClasseId = 0, LibelleClasse = "-- Choisir une classe --" });
            cbbClasse.DataSource = classes;
            cbbClasse.DisplayMember = "LibelleClasse";
            cbbClasse.ValueMember = "ClasseId";
            cbbClasse.SelectedIndex = 0;

        }






        private void AfficherCahierTexte()
        {
            DgCahierTexte.DataSource = db.CahierTextes
                .Select(c => new
                {
                    c.IdCahierTexte,
                    c.IdClasse,   // ✅ ajouté
                    c.IdAnnee,    // ✅ ajouté
                    c.IdResponsable, // ✅ ajouté
                    Classe = c.Classe.LibelleClasse,
                    c.DescriptionCahierTexte,
                    c.DateCahierTexte,
                    Annee = c.AnneeAcademique.LibelleAnneeAcademique,
                    Responsable = c.Responsable.NomUtilisateur,
                    VoirDetails = "Voir détails"
                })
                .ToList();

            DgCahierTexte.Columns["IdClasse"].Visible = false; 
            DgCahierTexte.Columns["IdAnnee"].Visible = false; 
            DgCahierTexte.Columns["IdResponsable"].Visible = false;
        }




        private void btnRechercher_Click(object sender, EventArgs e)
        {
            string critere = txtRecherche.Text.Trim();

            var resultats = db.CahierTextes
                .Where(c =>
                    c.Classe.LibelleClasse.Contains(critere) ||
                    c.DescriptionCahierTexte.Contains(critere) ||
                    c.DateCahierTexte.ToString().Contains(critere) ||
                    c.AnneeAcademique.LibelleAnneeAcademique.Contains(critere) ||
                    c.Responsable.NomUtilisateur.Contains(critere)
                )
                .Select(c => new
                {
                    c.IdCahierTexte,
                    Classe = c.Classe.LibelleClasse,
                    c.DescriptionCahierTexte,
                    c.DateCahierTexte,
                    Annee = c.AnneeAcademique.LibelleAnneeAcademique,
                    Responsable = c.Responsable.NomUtilisateur
                })
                .ToList();

            DgCahierTexte.DataSource = resultats;

            if (resultats.Count == 0)
            {
                MessageBox.Show("Aucun cahier de texte trouvé.");
            }
        }


        private void btnAjouter_Click(object sender, EventArgs e)
        {
            int idClasse = (int)cbbClasse.SelectedValue;
            int idResponsable = (int)cbbResponsable.SelectedValue;

            // Vérifier si la classe a déjà un responsable
            bool classeDejaResponsable = db.CahierTextes.Any(c => c.IdClasse == idClasse && c.IdResponsable != null);
            if (classeDejaResponsable)
            {
                MessageBox.Show("Impossible : cette classe a déjà un responsable !");
                return;
            }

            // Vérifier si le responsable est déjà lié à une autre classe
            bool responsableDejaAffecte = db.CahierTextes.Any(c => c.IdResponsable == idResponsable);
            if (responsableDejaAffecte)
            {
                MessageBox.Show("Impossible : ce responsable est déjà affecté à une autre classe !");
                return;
            }

            // Si tout est bon, créer le cahier de texte
            var cahier = new AppGestionCahierText.views.Models.CahierTexte
            {
                IdClasse = idClasse,
                DescriptionCahierTexte = txtDescription.Text,
                DateCahierTexte = dateTimePicker.Value,
                IdAnnee = (int)cbbAnneeAcademique.SelectedValue,
                IdResponsable = idResponsable
            };

            db.CahierTextes.Add(cahier);
            db.SaveChanges();
            AfficherCahierTexte();
            ViderChamps();
            MessageBox.Show("Cahier de texte ajouté avec succès !");
        }


        private void ViderChamps()
        {
            txtDescription.Clear();
            dateTimePicker.Value = DateTime.Now;
            cbbClasse.SelectedIndex = -1;
            cbbAnneeAcademique.SelectedIndex = -1;
            cbbResponsable.SelectedIndex = -1;


        }






        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            if (DgCahierTexte.CurrentRow == null) return;

            // Remplir la description
            txtDescription.Text = DgCahierTexte.CurrentRow.Cells["DescriptionCahierTexte"].Value.ToString();

            // Remplir la date
            dateTimePicker.Value = Convert.ToDateTime(DgCahierTexte.CurrentRow.Cells["DateCahierTexte"].Value);

            // Sélectionner la classe via Id
            cbbClasse.SelectedValue = Convert.ToInt32(DgCahierTexte.CurrentRow.Cells["IdClasse"].Value);

            // Sélectionner l’année académique via Id
            cbbAnneeAcademique.SelectedValue = Convert.ToInt32(DgCahierTexte.CurrentRow.Cells["IdAnnee"].Value);

            // Sélectionner le responsable via Id
            cbbResponsable.SelectedValue = Convert.ToInt32(DgCahierTexte.CurrentRow.Cells["IdResponsable"].Value);
        }




        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (DgCahierTexte.CurrentRow == null) return;

            int id = (int)DgCahierTexte.CurrentRow.Cells["IdCahierTexte"].Value;
            var cahier = db.CahierTextes.Find(id);

            if (cahier != null)
            {
                int idClasse = (int)cbbClasse.SelectedValue;
                int idResponsable = (int)cbbResponsable.SelectedValue;

                // Vérifier si la classe a déjà un responsable (autre que celui en cours)
                bool classeDejaResponsable = db.CahierTextes.Any(c => c.IdClasse == idClasse && c.IdResponsable != null && c.IdCahierTexte != id);
                if (classeDejaResponsable)
                {
                    MessageBox.Show("Impossible : cette classe a déjà un responsable !");
                    return;
                }

                // Vérifier si le responsable est déjà lié à une autre classe (autre que celle en cours)
                bool responsableDejaAffecte = db.CahierTextes.Any(c => c.IdResponsable == idResponsable && c.IdCahierTexte != id);
                if (responsableDejaAffecte)
                {
                    MessageBox.Show("Impossible : ce responsable est déjà affecté à une autre classe !");
                    return;
                }

                // Mise à jour
                cahier.IdClasse = idClasse;
                cahier.DescriptionCahierTexte = txtDescription.Text;
                cahier.DateCahierTexte = dateTimePicker.Value;
                cahier.IdAnnee = (int)cbbAnneeAcademique.SelectedValue;
                cahier.IdResponsable = idResponsable;

                db.SaveChanges();
                AfficherCahierTexte();
                ViderChamps();
                MessageBox.Show("Cahier de texte modifié avec succès !");
            }
        }



        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (DgCahierTexte.CurrentRow == null) return;

            int id = (int)DgCahierTexte.CurrentRow.Cells["IdCahierTexte"].Value;
            var cahier = db.CahierTextes.Find(id);

            if (cahier != null)
            {
                db.CahierTextes.Remove(cahier);
                db.SaveChanges();
                AfficherCahierTexte();
                ViderChamps();
                MessageBox.Show("Cahier de texte supprimé avec succès !");
            }
        }

        private void DgCahierTexte_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DgCahierTexte.Columns[e.ColumnIndex].Name == "VoirDetails")
            {
                int idCahierTexte = Convert.ToInt32(DgCahierTexte.Rows[e.RowIndex].Cells["IdCahierTexte"].Value);
                
                frmDetailsCahierTexte frmDetails = new frmDetailsCahierTexte();
                frmDetails.SetCahierTexteId(idCahierTexte);
                frmDetails.ShowDialog();
            }
        }

       
    }
}


