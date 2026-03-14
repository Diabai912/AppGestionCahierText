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

        public frmClasse()
        {
            InitializeComponent();
        }

        private void frmClasse_Load(object sender, EventArgs e)
        {
            AppliquerStyle();
            DgClasse.AutoGenerateColumns = true;
            Effacer();
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

            // DataGridView
            DgClasse.BackgroundColor = Color.White;
            DgClasse.BorderStyle = BorderStyle.FixedSingle;
            DgClasse.ColumnHeadersDefaultCellStyle.BackColor = Color.Purple;
            DgClasse.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DgClasse.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f);
            DgClasse.EnableHeadersVisualStyles = false;
            DgClasse.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 240, 255);
            DgClasse.DefaultCellStyle.SelectionBackColor = Color.FromArgb(83, 74, 183);
            DgClasse.DefaultCellStyle.SelectionForeColor = Color.White;
            DgClasse.GridColor = Color.FromArgb(200, 190, 230);
            DgClasse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void Effacer()
        {
            txtLibelle.Text = string.Empty;

            var annees = db.AnneeAcademiques.ToList();
            cbbAnneeAcademique.DataSource = annees;
            cbbAnneeAcademique.DisplayMember = "LibelleAnneeAcademique";
            cbbAnneeAcademique.ValueMember = "AnneeAcademiqueId";
            cbbAnneeAcademique.SelectedIndex = -1;

            DgClasse.DataSource = db.Classes
                .Select(c => new
                {
                    c.ClasseId,
                    c.LibelleClasse,
                    AnneeAcademique = c.AnneeAcademique.LibelleAnneeAcademique,
                    Annee = c.AnneeAcademique.ValueAnneeAcademique
                })
                .ToList();

            txtLibelle.Focus();
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
                    db.SaveChanges();
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
                    foreach (var ve in eve.ValidationErrors)
                        MessageBox.Show($"Propriété: {ve.PropertyName} Erreur: {ve.ErrorMessage}");
            }
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

                        c.LibelleClasse = txtLibelle.Text;
                        if (cbbAnneeAcademique.SelectedValue != null && cbbAnneeAcademique.SelectedValue is int)
                            c.AnneeAcademiqueId = (int)cbbAnneeAcademique.SelectedValue;

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
                    foreach (var ve in eve.ValidationErrors)
                        MessageBox.Show($"Propriété: {ve.PropertyName} Erreur: {ve.ErrorMessage}");
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (DgClasse.CurrentRow != null)
            {
                int id = Convert.ToInt32(DgClasse.CurrentRow.Cells[0].Value);
                var c = db.Classes.Find(id);
                if (c != null)
                {
                    var confirmation = MessageBox.Show("Voulez-vous vraiment supprimer cette classe ?",
                                                       "Confirmation",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question);
                    if (confirmation == DialogResult.Yes)
                    {
                        db.Classes.Remove(c);
                        db.SaveChanges();
                        Effacer();
                        MessageBox.Show("Classe supprimée avec succès !");
                    }
                }
            }
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            if (DgClasse.CurrentRow != null)
            {
                int id = (int)DgClasse.CurrentRow.Cells["ClasseId"].Value;
                var c = db.Classes.Find(id);

                if (c != null)
                {
                    txtLibelle.Text = c.LibelleClasse;
                    cbbAnneeAcademique.SelectedValue = c.AnneeAcademiqueId;
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne dans le tableau.");
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
                MessageBox.Show("Aucun résultat trouvé.");
        }

        private void cbbAnneeAcademique_SelectedIndexChanged(object sender, EventArgs e)
        {
            var liste = db.Classes.AsQueryable();

            if (cbbAnneeAcademique.SelectedValue != null && cbbAnneeAcademique.SelectedValue is int)
            {
                int anneeId = (int)cbbAnneeAcademique.SelectedValue;
                liste = liste.Where(c => c.AnneeAcademiqueId == anneeId);
            }

            if (!string.IsNullOrWhiteSpace(txtLibelle.Text))
                liste = liste.Where(f => f.LibelleClasse.ToUpper().Contains(txtLibelle.Text.ToUpper()));

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

        private void txtRecherche_Enter(object sender, EventArgs e)
        {
            if (txtRecherche.Text == "Rechercher...")
            {
                txtRecherche.Text = "";
                txtRecherche.ForeColor = Color.FromArgb(60, 52, 137);
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

        private void txtLibelle_TextChanged(object sender, EventArgs e) { }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPrintClasse f = new frmPrintClasse();
            f.ShowDialog();
        }
    }
}