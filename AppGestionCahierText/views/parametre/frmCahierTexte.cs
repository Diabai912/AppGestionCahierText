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
                    Responsable = c.Responsable.NomUtilisateur
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
            var cahier = new AppGestionCahierText.views.Models.CahierTexte
            {
                IdClasse = (int)cbbClasse.SelectedValue,   // ✅ correspond au modèle
                DescriptionCahierTexte = txtDescription.Text,
                DateCahierTexte = dateTimePicker.Value,
                IdAnnee = (int)cbbAnneeAcademique.SelectedValue,
                IdResponsable = (int)cbbResponsable.SelectedValue
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
                cahier.IdClasse = (int)cbbClasse.SelectedValue;
                cahier.DescriptionCahierTexte = txtDescription.Text;
                cahier.DateCahierTexte = dateTimePicker.Value;
                cahier.IdAnnee = (int)cbbAnneeAcademique.SelectedValue;
                cahier.IdResponsable = (int)cbbResponsable.SelectedValue;

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

       
    }
}


