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
    public partial class frmPrintCahier : Form
    {
        public frmPrintCahier()
        {
            InitializeComponent();
        }

        BdCahierTexteContext db = new BdCahierTexteContext();
        private void frmPrintCahier_Load(object sender, EventArgs e)
        {

            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "Report\\rptListeCahierTexte.rdlc";
            var data = db.CahierTextes
              .Include("Classe")
              .Include("AnneeAcademique")
              .Include("Responsable")
              .ToList()
              .Select(c => new printCahierTexte
              {
                  Responsable = c.Responsable.NomUtilisateur + " " + c.Responsable.PrenomUtilisateur,
                  Titre = c.Classe.LibelleClasse,
                  DescriptionCahierTexte = c.DescriptionCahierTexte,
                  DateCahierTexte = c.DateCahierTexte.ToString("dd/MM/yyyy"),
                  AnneeAcademique = c.AnneeAcademique.LibelleAnneeAcademique
              })
              .ToList();

            ReportDataSource rds = new ReportDataSource("DataSet1", data);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }
    }
}
