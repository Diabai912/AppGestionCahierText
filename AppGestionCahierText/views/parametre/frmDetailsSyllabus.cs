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
    public partial class frmDetailsSyllabus : Form
    {
        BdCahierTexteContext db = new BdCahierTexteContext();
        int idDetails = 0;
        int idSyllabusFiltre = 0;

        public frmDetailsSyllabus()
        {
            InitializeComponent();
        }

        private void frmDetailsSyllabus_Load(object sender, EventArgs e)
        {
            AppliquerStyle();

            if (idSyllabusFiltre > 0)
                cbbSyllabus.DataSource = db.Syllabuses.Where(s => s.IdSyllabus == idSyllabusFiltre).ToList();
            else
                cbbSyllabus.DataSource = db.Syllabuses.ToList();

            cbbSyllabus.DisplayMember = "LibelleSyllabus";
            cbbSyllabus.ValueMember = "IdSyllabus";

            if (idSyllabusFiltre > 0)
                cbbSyllabus.SelectedValue = idSyllabusFiltre;

            AfficherDetails();
        }

        private void AppliquerStyle()
        {
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(245, 245, 250);

            Color purple = Color.Purple;
            Color white = Color.White;
            Font fontBtn = new Font("Segoe UI", 10f);

            foreach (Control ctrl in this.Controls)
                StyleControle(ctrl, purple, white, fontBtn);

            DgDetailsSyllabus.BackgroundColor = Color.White;
            DgDetailsSyllabus.BorderStyle = BorderStyle.FixedSingle;
            DgDetailsSyllabus.ColumnHeadersDefaultCellStyle.BackColor = Color.Purple;
            DgDetailsSyllabus.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DgDetailsSyllabus.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f);
            DgDetailsSyllabus.EnableHeadersVisualStyles = false;
            DgDetailsSyllabus.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 240, 255);
            DgDetailsSyllabus.DefaultCellStyle.SelectionBackColor = Color.FromArgb(83, 74, 183);
            DgDetailsSyllabus.DefaultCellStyle.SelectionForeColor = Color.White;
            DgDetailsSyllabus.GridColor = Color.FromArgb(200, 190, 230);
            DgDetailsSyllabus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void AfficherDetails()
        {
            var query = db.DetailsSyllabuses.AsQueryable();

            if (idSyllabusFiltre > 0)
                query = query.Where(d => d.IdSyllabus == idSyllabusFiltre);

            DgDetailsSyllabus.DataSource = query
                .Select(d => new
                {
                    d.IdDetailsSyllabus,
                    d.SeanceSyllabus,
                    d.ContenuSyllabus,
                    d.IdSyllabus
                })
                .ToList();

            if (DgDetailsSyllabus.Columns["IdDetailsSyllabus"] != null)
                DgDetailsSyllabus.Columns["IdDetailsSyllabus"].Visible = false;
            if (DgDetailsSyllabus.Columns["IdSyllabus"] != null)
                DgDetailsSyllabus.Columns["IdSyllabus"].Visible = false;
        }

        private void ViderChamps()
        {
            txtSeance.Clear();
            txtContenu.Clear();
            cbbSyllabus.SelectedIndex = -1;
            idDetails = 0;
        }

        public void SetSyllabusId(int id)
        {
            idSyllabusFiltre = id;
            if (cbbSyllabus.Items.Count > 0)
            {
                cbbSyllabus.SelectedValue = id;
                AfficherDetails();
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSeance.Text) || string.IsNullOrWhiteSpace(txtContenu.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires.");
                return;
            }

            var detail = new DetailsSyllabus
            {
                SeanceSyllabus = txtSeance.Text,
                ContenuSyllabus = txtContenu.Text,
                IdSyllabus = (int)cbbSyllabus.SelectedValue
            };

            db.DetailsSyllabuses.Add(detail);
            db.SaveChanges();
            AfficherDetails();
            ViderChamps();
            MessageBox.Show("Détail ajouté avec succès !");
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (idDetails == 0)
            {
                MessageBox.Show("Veuillez sélectionner un détail à modifier.");
                return;
            }

            var detail = db.DetailsSyllabuses.Find(idDetails);
            if (detail != null)
            {
                detail.SeanceSyllabus = txtSeance.Text;
                detail.ContenuSyllabus = txtContenu.Text;
                detail.IdSyllabus = (int)cbbSyllabus.SelectedValue;

                db.SaveChanges();
                AfficherDetails();
                ViderChamps();
                MessageBox.Show("Détail modifié avec succès !");
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (idDetails == 0)
            {
                MessageBox.Show("Veuillez sélectionner un détail à supprimer.");
                return;
            }

            var confirmation = MessageBox.Show("Voulez-vous vraiment supprimer ce détail ?",
                                               "Confirmation",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);
            if (confirmation == DialogResult.Yes)
            {
                var detail = db.DetailsSyllabuses.Find(idDetails);
                if (detail != null)
                {
                    db.DetailsSyllabuses.Remove(detail);
                    db.SaveChanges();
                    AfficherDetails();
                    ViderChamps();
                    MessageBox.Show("Détail supprimé avec succès !");
                }
            }
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            if (DgDetailsSyllabus.CurrentRow == null) return;

            idDetails = Convert.ToInt32(DgDetailsSyllabus.CurrentRow.Cells["IdDetailsSyllabus"].Value);
            txtSeance.Text = DgDetailsSyllabus.CurrentRow.Cells["SeanceSyllabus"].Value.ToString();
            txtContenu.Text = DgDetailsSyllabus.CurrentRow.Cells["ContenuSyllabus"].Value.ToString();
            cbbSyllabus.SelectedValue = Convert.ToInt32(DgDetailsSyllabus.CurrentRow.Cells["IdSyllabus"].Value);
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            string motCle = txtRecherche.Text.Trim();

            var query = db.DetailsSyllabuses.AsQueryable();

            if (idSyllabusFiltre > 0)
                query = query.Where(d => d.IdSyllabus == idSyllabusFiltre);

            DgDetailsSyllabus.DataSource = query
                .Where(d => d.SeanceSyllabus.Contains(motCle) || d.ContenuSyllabus.Contains(motCle))
                .Select(d => new
                {
                    d.IdDetailsSyllabus,
                    d.SeanceSyllabus,
                    d.ContenuSyllabus,
                    d.IdSyllabus
                })
                .ToList();

            if (DgDetailsSyllabus.Rows.Count == 0)
                MessageBox.Show("Aucun résultat trouvé.");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPrintDetailsSyllabus f = new frmPrintDetailsSyllabus();
            f.ShowDialog();
        }

        private void DgDetailsSyllabus_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}