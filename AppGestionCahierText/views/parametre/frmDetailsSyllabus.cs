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
        public frmDetailsSyllabus()
        {
            InitializeComponent();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            var detail = db.DetailsSyllabuses.Find(idDetails); 
            if (detail != null) 
            {
                db.DetailsSyllabuses.Remove(detail);
                db.SaveChanges(); 
                AfficherDetails(); 
                ViderChamps(); }
        }

        private void frmDetailsSyllabus_Load(object sender, EventArgs e)
        {
            // Charger les syllabus disponibles
            cbbSyllabus.DataSource = db.Syllabuses.ToList(); 
            cbbSyllabus.DisplayMember = "LibelleSyllabus";
            cbbSyllabus.ValueMember = "IdSyllabus"; 
            AfficherDetails();
        }

        private void AfficherDetails() 
        { 
            DgDetailsSyllabus.DataSource = db.DetailsSyllabuses
                .Select(d => new { 
                    d.IdDetailsSyllabus, 
                    d.SeanceSyllabus, 
                    d.ContenuSyllabus, 
                    d.IdSyllabus 
                })
                .ToList(); 
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
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
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            var detail = db.DetailsSyllabuses.Find(idDetails); 
            if (detail != null) 
            {
                detail.SeanceSyllabus = txtSeance.Text; 
                detail.ContenuSyllabus = txtContenu.Text; 
                detail.IdSyllabus = (int)cbbSyllabus.SelectedValue; 
                db.SaveChanges(); 
                AfficherDetails();
                ViderChamps(); }
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
            string motCle = txtRecherche.Text; 
            DgDetailsSyllabus.DataSource = db.DetailsSyllabuses
                .Where(d => d.SeanceSyllabus.Contains(motCle) || d.ContenuSyllabus.Contains(motCle))
                .ToList();
        }


        private void ViderChamps() 
        {
            txtSeance.Clear(); 
            txtContenu.Clear(); 
            cbbSyllabus.SelectedIndex = -1; 
            idDetails = 0; 
        }
    }
    
}
