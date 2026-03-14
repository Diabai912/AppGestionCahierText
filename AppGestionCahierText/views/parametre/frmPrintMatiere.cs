using AppGestionCahierText.views.Models;
using Microsoft.Reporting.WinForms;
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
    public partial class frmPrintMatiere : Form
    {
        public frmPrintMatiere()
        {
            InitializeComponent();
        }

            BdCahierTexteContext db = new BdCahierTexteContext();

        private void frmPrintMatiere_Load(object sender, EventArgs e)
        {

            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "Report\\rptListeMatier.rdlc";
            var data = db.Matieres
             .Include("Professeur")
             .ToList()
             .Select(m => new printMatiere
             {
                 LibelleMatiere = m.LibelleMatiere,
                 VolumeHoraireMatiere = m.VolumeHoraireMatiere.ToString(), 
                 Niveau = m.Niveau,
                 NomProfesseur = m.Professeur.NomUtilisateur + " " + m.Professeur.PrenomUtilisateur
             })
             .ToList();
            ReportDataSource rds = new ReportDataSource("DataSet1", data);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }
    }
}
