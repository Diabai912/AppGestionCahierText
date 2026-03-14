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

            dateTimePicker.MinDate = new DateTime(2000, 1, 1);
            dateTimePicker.MaxDate = new DateTime(2100, 12, 31);

            cbbMatiere.DataSource = db.Matieres.ToList();
            cbbMatiere.DisplayMember = "LibelleMatiere";
            cbbMatiere.ValueMember = "IdMatiere";
        }

        private void frmDetailsCahierTexte_Load(object sender, EventArgs e)
        {
            AppliquerStyle();
            AfficherDetails();
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

            DgDetails.BackgroundColor = Color.White;
            DgDetails.BorderStyle = BorderStyle.FixedSingle;
            DgDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.Purple;
            DgDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DgDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f);
            DgDetails.EnableHeadersVisualStyles = false;
            DgDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 240, 255);
            DgDetails.DefaultCellStyle.SelectionBackColor = Color.FromArgb(83, 74, 183);
            DgDetails.DefaultCellStyle.SelectionForeColor = Color.White;
            DgDetails.GridColor = Color.FromArgb(200, 190, 230);
            DgDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            else if (ctrl is DateTimePicker dtp)
            {
                dtp.CalendarMonthBackground = Color.FromArgb(240, 235, 255);
                dtp.CalendarForeColor = Color.FromArgb(60, 52, 137);
                dtp.Font = new Font("Segoe UI", 10f);
            }

            foreach (Control child in ctrl.Controls)
                StyleControle(child, purple, white, fontBtn);
        }

        private void AfficherDetails()
        {
            var query = db.DetailsCahierTextes.AsQueryable();

            if (idCahierTexteFiltre > 0)
                query = query.Where(d => d.IdCahierTexte == idCahierTexteFiltre);

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

            if (DgDetails.Columns["IdDetailsCahierTexte"] != null)
                DgDetails.Columns["IdDetailsCahierTexte"].Visible = false;
            if (DgDetails.Columns["IdCahierTexte"] != null)
                DgDetails.Columns["IdCahierTexte"].Visible = false;
            if (DgDetails.Columns["IdMatiere"] != null)
                DgDetails.Columns["IdMatiere"].Visible = false;
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
            AfficherDetails();
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
                MessageBox.Show("Détail ajouté avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Détail modifié avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                var resultat = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce détail ?",
                                               "Confirmation",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);

                if (resultat == DialogResult.Yes)
                {
                    var detailASupprimer = db.DetailsCahierTextes.Find(idDetails);
                    if (detailASupprimer != null)
                    {
                        db.DetailsCahierTextes.Remove(detailASupprimer);
                        db.SaveChanges();
                        AfficherDetails();
                        ViderChamps();
                        MessageBox.Show("Détail supprimé avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            try
            {
                var dateValue = Convert.ToDateTime(DgDetails.CurrentRow.Cells["DateDetail"].Value);
                dateTimePicker.Value = (dateValue >= dateTimePicker.MinDate && dateValue <= dateTimePicker.MaxDate)
                    ? dateValue : DateTime.Now;
            }
            catch
            {
                dateTimePicker.Value = DateTime.Now;
            }
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            string motCle = txtRecherche.Text.Trim();

            if (string.IsNullOrWhiteSpace(motCle))
            {
                AfficherDetails();
                return;
            }

            var query = db.DetailsCahierTextes.AsQueryable();

            if (idCahierTexteFiltre > 0)
                query = query.Where(d => d.IdCahierTexte == idCahierTexteFiltre);

            var result = query
                .Where(d => d.Description.Contains(motCle) || d.Matiere.LibelleMatiere.Contains(motCle))
                .Select(d => new
                {
                    d.IdDetailsCahierTexte,
                    d.IdCahierTexte,
                    d.IdMatiere,
                    Matiere = d.Matiere.LibelleMatiere,
                    d.DateDetail,
                    d.Description
                })
                .ToList();

            DgDetails.DataSource = result;

            if (result.Count == 0)
                MessageBox.Show("Aucun résultat trouvé.");
        }

        private void DgDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idDetails = Convert.ToInt32(DgDetails.Rows[e.RowIndex].Cells["IdDetailsCahierTexte"].Value);
                cbbMatiere.SelectedValue = Convert.ToInt32(DgDetails.Rows[e.RowIndex].Cells["IdMatiere"].Value);
                txtDescription.Text = DgDetails.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                dateTimePicker.Value = Convert.ToDateTime(DgDetails.Rows[e.RowIndex].Cells["DateDetail"].Value);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPrintDetailsCahier f = new frmPrintDetailsCahier();
            f.ShowDialog();
        }

        private void cbbAnnee_SelectedIndexChanged(object sender, EventArgs e) { }
        private void frmDetailsCahierTexte_Load_1(object sender, EventArgs e) { }
    }
}