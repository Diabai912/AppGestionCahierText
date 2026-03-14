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
    public partial class frmAnneeAcademique : Form
    {
        private BdCahierTexteContext db = new BdCahierTexteContext();

        public frmAnneeAcademique()
        {
            InitializeComponent();
        }

        private void frmAnneeAcademique_Load(object sender, EventArgs e)
        {
            try { 
                AppliquerStyle();
                AfficherAnneeAcademique();
            }
            catch (Exception ex)
            {
                Logger.WriteFileError($"Erreur chargement frmAnneeAcademique : {ex.Message}");
                MessageBox.Show("Impossible de charger les données.");
            }
        }

        // ✅ Style uniforme
        private void AppliquerStyle()
        {
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(245, 245, 250);

            Color purple = Color.Purple;
            Color white = Color.White;
            Font fontBtn = new Font("Segoe UI", 10f);

            foreach (Control ctrl in this.Controls)
                StyleControle(ctrl, purple, white, fontBtn);

            DgAnneeAcademique.BackgroundColor = Color.White;
            DgAnneeAcademique.BorderStyle = BorderStyle.FixedSingle;
            DgAnneeAcademique.ColumnHeadersDefaultCellStyle.BackColor = Color.Purple;
            DgAnneeAcademique.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DgAnneeAcademique.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f);
            DgAnneeAcademique.EnableHeadersVisualStyles = false;
            DgAnneeAcademique.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 240, 255);
            DgAnneeAcademique.DefaultCellStyle.SelectionBackColor = Color.FromArgb(83, 74, 183);
            DgAnneeAcademique.DefaultCellStyle.SelectionForeColor = Color.White;
            DgAnneeAcademique.GridColor = Color.FromArgb(200, 190, 230);
            DgAnneeAcademique.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            btnSupprimer.Click -= btnSupprimer_Click;
            btnSupprimer.Click += btnSupprimer_Click;
        }

        private void StyleControle(Control ctrl, Color purple, Color white, Font fontBtn)
        {
            if (ctrl is Button btn)
            {
                btn.BackColor = purple;
                btn.ForeColor = white;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = fontBtn;
                btn.Cursor = Cursors.Hand;
            }
            else if (ctrl is TextBox txt)
            {
                txt.BackColor = Color.FromArgb(240, 235, 255);
                txt.ForeColor = Color.FromArgb(60, 52, 137);
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.Font = new Font("Segoe UI", 10f);
            }
            else if (ctrl is ComboBox cmb)
            {
                cmb.BackColor = Color.FromArgb(240, 235, 255);
                cmb.ForeColor = Color.FromArgb(60, 52, 137);
                cmb.Font = new Font("Segoe UI", 10f);
            }
            else if (ctrl is Label lbl)
            {
                lbl.ForeColor = Color.FromArgb(60, 52, 137);
                lbl.Font = new Font("Segoe UI", 10f);
                lbl.BackColor = Color.Transparent;
            }

            foreach (Control child in ctrl.Controls)
                StyleControle(child, purple, white, fontBtn);
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

        private void ViderChamps()
        {
            txtLibelle.Clear();
            txtValue.Clear();
        }

        private void DgAnneeAcademique_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtLibelle.Text = DgAnneeAcademique.Rows[e.RowIndex].Cells["LibelleAnneeAcademique"].Value.ToString();
                txtValue.Text = DgAnneeAcademique.Rows[e.RowIndex].Cells["ValueAnneeAcademique"].Value.ToString();
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try {
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
            catch (Exception ex)
            {
                Logger.WriteFileError($"Erreur ajout année académique: {ex.Message}");
                MessageBox.Show("Impossible d'ajouter l'année académique.");
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Logger.WriteFileError($"Erreur modification l'année académique  : {ex.Message}");
                MessageBox.Show("Impossible de modifier l'année académique.");
            }
        }
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                if (DgAnneeAcademique.CurrentRow == null)
                {
                    MessageBox.Show("Veuillez sélectionner une ligne avant de supprimer.");
                    return;
                }

                var row = DgAnneeAcademique.CurrentRow;
                id = Convert.ToInt32(row.Cells[0].Value);

                var annee = db.AnneeAcademiques.Find(id);
                if (annee == null)
                {
                    MessageBox.Show("Année académique introuvable !");
                    return;
                }

                // ✅ Vérifier si utilisée dans Classe
                bool utiliseeClasse = db.Classes.Any(c => c.AnneeAcademiqueId == id);
                if (utiliseeClasse)
                {
                    MessageBox.Show("Impossible de supprimer : cette année est utilisée par une ou plusieurs classes !");
                    return;
                }

                // ✅ Vérifier si utilisée dans CahierTexte
                bool utiliséeCahier = db.CahierTextes.Any(c => c.IdAnnee == id);
                if (utiliséeCahier)
                {
                    MessageBox.Show("Impossible de supprimer : cette année est utilisée par un cahier de texte !");
                    return;
                }

                var confirmation = MessageBox.Show(
                    "Voulez-vous vraiment supprimer cette année académique ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmation == DialogResult.Yes)
                {
                    db.AnneeAcademiques.Remove(annee);
                    db.SaveChanges();
                    AfficherAnneeAcademique();
                    ViderChamps();
                    MessageBox.Show("Année académique supprimée avec succès !");
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileError($"Erreur suppression année académique ID {id} : {ex.Message}");
                MessageBox.Show("Impossible de supprimer l'année académique.");
            }
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
                MessageBox.Show("Aucune année académique trouvée.");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPrintAnnee f = new frmPrintAnnee();
            f.ShowDialog();
        }
    }
}