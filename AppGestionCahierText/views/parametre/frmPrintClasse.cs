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
    public partial class frmPrintClasse : Form
    {
        public frmPrintClasse()
        {
            InitializeComponent();
        }

        BdCahierTexteContext db= new BdCahierTexteContext();

        private void frmPrintClasse_Load(object sender, EventArgs e)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "Report\\rptClasse.rdlc";
            var data = db.Classes
             .Include("AnneeAcademique")
             .ToList()  // ✅ D'abord charger en mémoire
             .Select(c => new printClasse
             {
                 LibelleClasse = c.LibelleClasse,
                 AnneeAcademique = c.AnneeAcademique.LibelleAnneeAcademique,
                 Annee = c.AnneeAcademique.ValueAnneeAcademique.ToString() // ✅ Maintenant ça marche
             })
             .ToList();

            ReportDataSource rds = new ReportDataSource("DataSet1", data);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
            

        }
    }
}
