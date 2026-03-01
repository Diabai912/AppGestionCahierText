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
    
    public partial class frmAnneeAcademique : Form
    {
        private BdCahierTexteContext db = new BdCahierTexteContext();
        public frmAnneeAcademique()
        {
            InitializeComponent();
        }

        private void DgAnneeAcademique_CellClick(object sender, DataGridViewCellEventArgs e)
        {
       
            if (e.RowIndex >= 0)
            {
                txtLibelle.Text = DgAnneeAcademique.Rows[e.RowIndex].Cells["LibelleAnneeAcademique"].Value.ToString();
                txtValue.Text = DgAnneeAcademique.Rows[e.RowIndex].Cells["ValueAnneeAcademique"].Value.ToString();
            }
        }

        
        private void AfficherAnneeAcademique()
        {
            DgAnneeAcademique.DataSource = db.AnneeAcademiques
                .Select(a => new
                {
                    a.AnneeAcademiqueId,
                    a.LibelleAnneeAcademique,
                    a.ValueAnneeAcademique
                })
                .ToList();
        }

        private void frmAnneeAcademique_Load(object sender, EventArgs e)
        {
            AfficherAnneeAcademique();
        }

       
       

       
            private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (DgAnneeAcademique.CurrentRow == null) return;

            int id = (int)DgAnneeAcademique.CurrentRow.Cells["AnneeAcademiqueId"].Value;
            var annee = db.AnneeAcademiques.Find(id);

            if (annee != null)
            {
                db.AnneeAcademiques.Remove(annee);
                db.SaveChanges();
                AfficherAnneeAcademique();
                ViderChamps();
                MessageBox.Show("Année académique supprimée avec succès !");
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (DgAnneeAcademique.CurrentRow == null) return;

            int id = (int)DgAnneeAcademique.CurrentRow.Cells["AnneeAcademiqueId"].Value;
            var annee = db.AnneeAcademiques.Find(id);

            if (annee != null)
            {
                int value;
                if (!int.TryParse(txtValue.Text, out value))
                {
                    MessageBox.Show("Veuillez saisir une valeur numérique valide.");
                    return;
                }

                annee.LibelleAnneeAcademique = txtLibelle.Text;
                annee.ValueAnneeAcademique = value;

                db.SaveChanges();
                AfficherAnneeAcademique();
                ViderChamps();
                MessageBox.Show("Année académique modifiée avec succès !");
            }
        }


        private void btnAjouter_Click(object sender, EventArgs e)
        {
       
            if (string.IsNullOrWhiteSpace(txtLibelle.Text))
            {
                MessageBox.Show("Veuillez saisir un libellé.");
                return;
            }

            int value;
            if (!int.TryParse(txtValue.Text, out value))
            {
                MessageBox.Show("Veuillez saisir une valeur numérique valide.");
                return;
            }

            var annee = new AnneeAcademique
            {
                LibelleAnneeAcademique = txtLibelle.Text,
                ValueAnneeAcademique = value
            };

            db.AnneeAcademiques.Add(annee);
            db.SaveChanges();
            AfficherAnneeAcademique();
            ViderChamps();
            MessageBox.Show("Année académique ajoutée avec succès !");
        }

        private void ViderChamps()
        {
            txtLibelle.Clear();
            txtValue.Clear();
     
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
       
            string critere = txtRecherche.Text.Trim();

            var resultats = db.AnneeAcademiques
                .Where(a => a.LibelleAnneeAcademique.Contains(critere)
                         || a.ValueAnneeAcademique.ToString().Contains(critere))
                .Select(a => new
                {
                    a.AnneeAcademiqueId,
                    a.LibelleAnneeAcademique,
                    a.ValueAnneeAcademique
                })
                .ToList();

            DgAnneeAcademique.DataSource = resultats;

            if (resultats.Count == 0)
            {
                MessageBox.Show("Aucune année académique trouvée.");
            }
        }

    }
}




