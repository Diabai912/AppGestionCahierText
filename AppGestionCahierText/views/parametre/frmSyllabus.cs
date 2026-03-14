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
            AppliquerStyle();
            cbbNiveauSyllabus.DataSource = new string[] { "L1", "L2", "L3", "M1", "M2" };
            AfficherSyllabus();
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

            DgSyllabus.BackgroundColor = Color.White;
            DgSyllabus.BorderStyle = BorderStyle.FixedSingle;
            DgSyllabus.ColumnHeadersDefaultCellStyle.BackColor = Color.Purple;
            DgSyllabus.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DgSyllabus.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f);
            DgSyllabus.EnableHeadersVisualStyles = false;
            DgSyllabus.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 240, 255);
            DgSyllabus.DefaultCellStyle.SelectionBackColor = Color.FromArgb(83, 74, 183);
            DgSyllabus.DefaultCellStyle.SelectionForeColor = Color.White;
            DgSyllabus.GridColor = Color.FromArgb(200, 190, 230);
            DgSyllabus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void AfficherSyllabus()
        {
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

        private void ViderChamps()
        {
            txtLibelle.Clear();
            txtDescription.Clear();
            txtVolumeHoraire.Clear();
            cbbNiveauSyllabus.SelectedIndex = -1;
            idSyllabus = 0;
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

                if (syllabus.LibelleSyllabus == txtLibelle.Text &&
                    syllabus.DescriptionSyllabus == txtDescription.Text &&
                    syllabus.VolumeHoraireSyllabus == volume &&
                    syllabus.NiveauSyllabus == cbbNiveauSyllabus.SelectedItem.ToString())
                {
                    MessageBox.Show("Aucune modification détectée.");
                    return;
                }

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

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (DgSyllabus.CurrentRow == null) return;

            int id = (int)DgSyllabus.CurrentRow.Cells["IdSyllabus"].Value;
            var syllabus = db.Syllabuses.Find(id);

            if (syllabus != null)
            {
                var confirmation = MessageBox.Show("Voulez-vous vraiment supprimer ce syllabus ?",
                                                   "Confirmation",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);
                if (confirmation == DialogResult.Yes)
                {
                    db.Syllabuses.Remove(syllabus);
                    db.SaveChanges();
                    AfficherSyllabus();
                    ViderChamps();
                    MessageBox.Show("Syllabus supprimé avec succès !");
                }
            }
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            if (DgSyllabus.CurrentRow == null) return;

            txtLibelle.Text = DgSyllabus.CurrentRow.Cells["LibelleSyllabus"].Value.ToString();
            txtDescription.Text = DgSyllabus.CurrentRow.Cells["DescriptionSyllabus"].Value.ToString();
            txtVolumeHoraire.Text = DgSyllabus.CurrentRow.Cells["VolumeHoraireSyllabus"].Value.ToString();
            cbbNiveauSyllabus.SelectedItem = DgSyllabus.CurrentRow.Cells["NiveauSyllabus"].Value.ToString();
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            string motCle = txtRecherche.Text.Trim();
            DgSyllabus.DataSource = db.Syllabuses
                .Where(s => s.LibelleSyllabus.Contains(motCle) || s.DescriptionSyllabus.Contains(motCle))
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

            if (DgSyllabus.Rows.Count == 0)
                MessageBox.Show("Aucun résultat trouvé.");
        }

        private void DgSyllabus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DgSyllabus.Columns[e.ColumnIndex].Name == "VoirDetails")
            {
                int id = Convert.ToInt32(DgSyllabus.Rows[e.RowIndex].Cells["IdSyllabus"].Value);
                frmDetailsSyllabus frmDetails = new frmDetailsSyllabus();
                frmDetails.SetSyllabusId(id);
                frmDetails.ShowDialog();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPrintSyllabus f = new frmPrintSyllabus();
            f.ShowDialog();
        }
    }
}