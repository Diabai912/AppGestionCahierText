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
    public partial class frmPrintDetailsCahier : Form
    {
        public frmPrintDetailsCahier()
        {
            InitializeComponent();
        }
        BdCahierTexteContext db = new BdCahierTexteContext();

        private void frmPrintDetailsCahier_Load(object sender, EventArgs e)
        {


            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "Report\\rptDetailsCahierTexte.rdlc";
            var data = db.DetailsCahierTextes
              .Include("Matiere")
              .Include("CahierTexte")
              .ToList()
              .Select(d => new printDetailsCahierTexte
              {
                  LibelleMatiere = d.Matiere != null ? d.Matiere.LibelleMatiere : "Aucune",
                  DateDetail = d.DateDetail.ToString("dd/MM/yyyy"),
                  Description = d.Description
              })
              .ToList();

            ReportDataSource rds = new ReportDataSource("DataSet1", data);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }
    }
}
