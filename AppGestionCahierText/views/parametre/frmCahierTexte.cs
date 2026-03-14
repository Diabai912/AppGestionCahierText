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
        private string _role;
        private int idClasseConnectee;

        public frmCahierTexte()
        {
            InitializeComponent();
        }

        private void CahierTexte_Load(object sender, EventArgs e)
        {
            AppliquerStyle();

            // Charger les responsables
            cbbResponsable.DataSource = db.Utilisateurs
                .Where(u => u.Role == "Responsable")
                .ToList();
            cbbResponsable.DisplayMember = "NomUtilisateur";
            cbbResponsable.ValueMember = "IdUtilisateur";

            // Charger les années académiques
            cbbAnneeAcademique.DataSource = db.AnneeAcademiques.ToList();
            cbbAnneeAcademique.DisplayMember = "LibelleAnneeAcademique";
            cbbAnneeAcademique.ValueMember = "AnneeAcademiqueId";

            // Charger les classes avec option vide
            var classes = db.Classes.ToList();
            classes.Insert(0, new Classe { ClasseId = 0, LibelleClasse = "-- Choisir une classe --" });
            cbbClasse.DataSource = classes;
            cbbClasse.DisplayMember = "LibelleClasse";
            cbbClasse.ValueMember = "ClasseId";
            cbbClasse.SelectedIndex = 0;

            AfficherCahierTexte();
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

            DgCahierTexte.BackgroundColor = Color.White;
            DgCahierTexte.BorderStyle = BorderStyle.FixedSingle;
            DgCahierTexte.ColumnHeadersDefaultCellStyle.BackColor = Color.Purple;
            DgCahierTexte.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DgCahierTexte.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f);
            DgCahierTexte.EnableHeadersVisualStyles = false;
            DgCahierTexte.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 240, 255);
            DgCahierTexte.DefaultCellStyle.SelectionBackColor = Color.FromArgb(83, 74, 183);
            DgCahierTexte.DefaultCellStyle.SelectionForeColor = Color.White;
            DgCahierTexte.GridColor = Color.FromArgb(200, 190, 230);
            DgCahierTexte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void AfficherCahierTexte()
        {
            var query = db.CahierTextes.AsQueryable();

            if (_role == "Responsable" && idClasseConnectee > 0)
                query = query.Where(c => c.IdClasse == idClasseConnectee);

            DgCahierTexte.DataSource = query
                .Select(c => new
                {
                    c.IdCahierTexte,
                    c.IdClasse,
                    c.IdAnnee,
                    c.IdResponsable,
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

        private void ViderChamps()
        {
            txtDescription.Clear();
            dateTimePicker.Value = DateTime.Now;
            cbbClasse.SelectedIndex = 0;
            cbbAnneeAcademique.SelectedIndex = -1;
            cbbResponsable.SelectedIndex = -1;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            int idClasse = (int)cbbClasse.SelectedValue;
            int idResponsable = (int)cbbResponsable.SelectedValue;

            bool classeDejaResponsable = db.CahierTextes.Any(c => c.IdClasse == idClasse && c.IdResponsable != null);
            if (classeDejaResponsable)
            {
                MessageBox.Show("Impossible : cette classe a déjà un responsable !");
                return;
            }

            bool responsableDejaAffecte = db.CahierTextes.Any(c => c.IdResponsable == idResponsable);
            if (responsableDejaAffecte)
            {
                MessageBox.Show("Impossible : ce responsable est déjà affecté à une autre classe !");
                return;
            }

            var cahier = new CahierTexte
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

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (DgCahierTexte.CurrentRow == null) return;

            int id = (int)DgCahierTexte.CurrentRow.Cells["IdCahierTexte"].Value;
            var cahier = db.CahierTextes.Find(id);

            if (cahier != null)
            {
                int idClasse = (int)cbbClasse.SelectedValue;
                int idResponsable = (int)cbbResponsable.SelectedValue;

                bool classeDejaResponsable = db.CahierTextes.Any(c => c.IdClasse == idClasse && c.IdResponsable != null && c.IdCahierTexte != id);
                if (classeDejaResponsable)
                {
                    MessageBox.Show("Impossible : cette classe a déjà un responsable !");
                    return;
                }

                bool responsableDejaAffecte = db.CahierTextes.Any(c => c.IdResponsable == idResponsable && c.IdCahierTexte != id);
                if (responsableDejaAffecte)
                {
                    MessageBox.Show("Impossible : ce responsable est déjà affecté à une autre classe !");
                    return;
                }

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
                var confirmation = MessageBox.Show("Voulez-vous vraiment supprimer ce cahier de texte ?",
                                                   "Confirmation",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);
                if (confirmation == DialogResult.Yes)
                {
                    db.CahierTextes.Remove(cahier);
                    db.SaveChanges();
                    AfficherCahierTexte();
                    ViderChamps();
                    MessageBox.Show("Cahier de texte supprimé avec succès !");
                }
            }
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            if (DgCahierTexte.CurrentRow == null) return;

            txtDescription.Text = DgCahierTexte.CurrentRow.Cells["DescriptionCahierTexte"].Value.ToString();
            dateTimePicker.Value = Convert.ToDateTime(DgCahierTexte.CurrentRow.Cells["DateCahierTexte"].Value);
            cbbClasse.SelectedValue = Convert.ToInt32(DgCahierTexte.CurrentRow.Cells["IdClasse"].Value);
            cbbAnneeAcademique.SelectedValue = Convert.ToInt32(DgCahierTexte.CurrentRow.Cells["IdAnnee"].Value);
            cbbResponsable.SelectedValue = Convert.ToInt32(DgCahierTexte.CurrentRow.Cells["IdResponsable"].Value);
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            string critere = txtRecherche.Text.Trim();

            var resultats = db.CahierTextes
                .Where(c =>
                    c.Classe.LibelleClasse.Contains(critere) ||
                    c.DescriptionCahierTexte.Contains(critere) ||
                    c.AnneeAcademique.LibelleAnneeAcademique.Contains(critere) ||
                    c.Responsable.NomUtilisateur.Contains(critere))
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
                MessageBox.Show("Aucun cahier de texte trouvé.");
        }

        private void DgCahierTexte_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DgCahierTexte.Columns[e.ColumnIndex].Name == "VoirDetails")
            {
                int idCahierTexte = Convert.ToInt32(DgCahierTexte.Rows[e.RowIndex].Cells["IdCahierTexte"].Value);
                frmDetailsCahierTexte frm = new frmDetailsCahierTexte();
                frm.SetCahierTexteId(idCahierTexte);
                frm.ShowDialog();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPrintCahier f = new frmPrintCahier();
            f.ShowDialog();
        }
    }
}