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
            // Si un ID de syllabus est déjà défini, charger seulement ce syllabus
            if (idSyllabusFiltre > 0)
            {
                cbbSyllabus.DataSource = db.Syllabuses.Where(s => s.IdSyllabus == idSyllabusFiltre).ToList(); 
            }
            else
            {
                // Sinon charger tous les syllabus disponibles
                cbbSyllabus.DataSource = db.Syllabuses.ToList(); 
            }
            
            cbbSyllabus.DisplayMember = "LibelleSyllabus";
            cbbSyllabus.ValueMember = "IdSyllabus"; 
            
            // Si un ID de syllabus est déjà défini, le sélectionner
            if (idSyllabusFiltre > 0)
            {
                cbbSyllabus.SelectedValue = idSyllabusFiltre;
            }
            
            AfficherDetails();
        }

        private void AfficherDetails() 
        { 
            var query = db.DetailsSyllabuses.AsQueryable();
            
            if (idSyllabusFiltre > 0)
            {
                query = query.Where(d => d.IdSyllabus == idSyllabusFiltre);
            }
            
            DgDetailsSyllabus.DataSource = query
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

        public void SetSyllabusId(int id)
        {
            idSyllabusFiltre = id;
            
                // Si la combobox est déjà initialisée, sélectionner le syllabus
            if (cbbSyllabus.Items.Count > 0)
            {
                cbbSyllabus.SelectedValue = id;
                // Rafraîchir l'affichage avec le filtre
                AfficherDetails();
            }
        }
    }
    
}
