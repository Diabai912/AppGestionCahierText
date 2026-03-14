using AppGestionCahierText.views.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGestionCahierText.views.parametre
{
    public partial class frmMatiere : Form
    {
        private BdCahierTexteContext db = new BdCahierTexteContext();

        public frmMatiere()
        {
            InitializeComponent();
        }

        private void frmMatiere_Load(object sender, EventArgs e)
        {
            AppliquerStyle();
            AfficherMatiere();

            cbbProfesseur.DataSource = db.Utilisateurs
                .Where(u => u.Role == "Professeur")
                .ToList();
            cbbProfesseur.DisplayMember = "NomUtilisateur";
            cbbProfesseur.ValueMember = "IdUtilisateur";
        }

        // ✅ Méthode de style uniforme
        private void AppliquerStyle()
        {
            this.BackColor = Color.FromArgb(245, 245, 250);

            // Boutons
            Color purple = Color.Purple;
            Color white = Color.White;
            Font fontBtn = new Font("Segoe UI", 10f);

            foreach (Control ctrl in this.Controls)
            {
                StyleControle(ctrl, purple, white, fontBtn);
            }

            // DataGridView
            DgMatiere.BackgroundColor = Color.White;
            DgMatiere.BorderStyle = BorderStyle.FixedSingle;
            DgMatiere.ColumnHeadersDefaultCellStyle.BackColor = Color.Purple;
            DgMatiere.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DgMatiere.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
            DgMatiere.EnableHeadersVisualStyles = false;
            DgMatiere.RowHeadersVisible = true;
            DgMatiere.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 240, 255);
            DgMatiere.DefaultCellStyle.SelectionBackColor = Color.FromArgb(83, 74, 183);
            DgMatiere.DefaultCellStyle.SelectionForeColor = Color.White;
            DgMatiere.GridColor = Color.FromArgb(200, 190, 230);
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
            else if (ctrl is Panel panel)
            {
                panel.BackColor = Color.FromArgb(245, 245, 250);
                foreach (Control child in panel.Controls)
                    StyleControle(child, purple, white, fontBtn);
            }

            // Appliquer récursivement
            foreach (Control child in ctrl.Controls)
                StyleControle(child, purple, white, fontBtn);
        }

        private void AfficherMatiere()
        {
            var matieres = db.Matieres
                .Include(m => m.Professeur)
                .ToList();

            DgMatiere.DataSource = matieres
                .Select(m => new
                {
                    m.IdMatiere,
                    m.LibelleMatiere,
                    m.VolumeHoraireMatiere,
                    m.Niveau,
                    m.IdProfesseur,
                    Professeur = m.Professeur != null ? m.Professeur.NomUtilisateur : ""
                })
                .ToList();

            DgMatiere.Columns["IdProfesseur"].Visible = false;
        }

        private void ViderChamps()
        {
            txtLibelleMatiere.Clear();
            txtVolumeHoraire.Clear();
            txtNiveau.Clear();
            if (cbbProfesseur.Items.Count > 0)
                cbbProfesseur.SelectedIndex = -1;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            int volume;
            if (!int.TryParse(txtVolumeHoraire.Text, out volume))
            {
                MessageBox.Show("Veuillez saisir un nombre valide pour le volume horaire.");
                return;
            }

            var matiere = new Matiere
            {
                LibelleMatiere = txtLibelleMatiere.Text,
                VolumeHoraireMatiere = volume,
                Niveau = txtNiveau.Text,
                IdProfesseur = (int)cbbProfesseur.SelectedValue
            };

            db.Matieres.Add(matiere);
            db.SaveChanges();
            AfficherMatiere();
            ViderChamps();
            MessageBox.Show("Matière ajoutée avec succès !");
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (DgMatiere.CurrentRow == null)
            {
                MessageBox.Show("Veuillez sélectionner une matière à modifier.");
                return;
            }

            int id = (int)DgMatiere.CurrentRow.Cells["IdMatiere"].Value;
            var matiere = db.Matieres.Find(id);

            if (matiere != null)
            {
                int volume;
                if (!int.TryParse(txtVolumeHoraire.Text, out volume))
                {
                    MessageBox.Show("Veuillez saisir un nombre valide pour le volume horaire.");
                    return;
                }

                matiere.LibelleMatiere = txtLibelleMatiere.Text;
                matiere.VolumeHoraireMatiere = volume;
                matiere.Niveau = txtNiveau.Text;
                matiere.IdProfesseur = (int)cbbProfesseur.SelectedValue;

                db.SaveChanges();
                AfficherMatiere();
                ViderChamps();
                MessageBox.Show("Matière modifiée avec succès !");
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (DgMatiere.CurrentRow == null)
            {
                MessageBox.Show("Veuillez sélectionner une matière à supprimer.");
                return;
            }

            int id = (int)DgMatiere.CurrentRow.Cells["IdMatiere"].Value;
            var matiere = db.Matieres.Find(id);

            if (matiere != null)
            {
                var confirmation = MessageBox.Show("Voulez-vous vraiment supprimer cette matière ?",
                                                   "Confirmation",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);

                if (confirmation == DialogResult.Yes)
                {
                    db.Matieres.Remove(matiere);
                    db.SaveChanges();
                    AfficherMatiere();
                    MessageBox.Show("Matière supprimée avec succès !");
                }
            }
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            if (DgMatiere.CurrentRow != null)
            {
                txtLibelleMatiere.Text = DgMatiere.CurrentRow.Cells["LibelleMatiere"].Value.ToString();
                txtVolumeHoraire.Text = DgMatiere.CurrentRow.Cells["VolumeHoraireMatiere"].Value.ToString();
                txtNiveau.Text = DgMatiere.CurrentRow.Cells["Niveau"].Value.ToString();

                int idProf = (int)DgMatiere.CurrentRow.Cells["IdProfesseur"].Value;
                cbbProfesseur.SelectedValue = idProf;
            }
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            string critere = txtRecherche.Text.Trim();

            var resultats = db.Matieres
                .Where(m => m.LibelleMatiere.Contains(critere)
                         || m.VolumeHoraireMatiere.ToString().Contains(critere)
                         || m.Niveau.Contains(critere))
                .Select(m => new
                {
                    m.IdMatiere,
                    m.LibelleMatiere,
                    m.VolumeHoraireMatiere,
                    m.Niveau
                })
                .ToList();

            DgMatiere.DataSource = resultats;

            if (resultats.Count == 0)
                MessageBox.Show("Aucune matière trouvée.");
        }

        private void DgMatiere_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtLibelleMatiere.Text = DgMatiere.Rows[e.RowIndex].Cells["LibelleMatiere"].Value.ToString();
                txtVolumeHoraire.Text = DgMatiere.Rows[e.RowIndex].Cells["VolumeHoraireMatiere"].Value.ToString();
                txtNiveau.Text = DgMatiere.Rows[e.RowIndex].Cells["Niveau"].Value.ToString();
            }
        }

        private void DgMatiere_CellContentClick(object sender, DataGridViewCellEventArgs e) 
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {
        
        }
        private void txtLibelleMatiere_TextChanged(object sender, EventArgs e) 
        {
        
        }
        private void label2_Click(object sender, EventArgs e)
        {
        
        }
        private void txtVolumeHoraire_TextChanged(object sender, EventArgs e)
        {
        
        }
        private void label3_Click(object sender, EventArgs e)
        {
        
        }
        private void txtNiveau_TextChanged(object sender, EventArgs e) 
        {
        
        }
        private void txtRecherche_TextChanged(object sender, EventArgs e) 
        {
        
        }
        private void cbbNiveauSyllabus_SelectedIndexChanged(object sender, EventArgs e) 
        {
        
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPrintMatiere f = new frmPrintMatiere();
            f.ShowDialog();
        }
    }
}