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
    public partial class frmPrintAnnee : Form
    {
        public frmPrintAnnee()
        {
            InitializeComponent();
        }

        BdCahierTexteContext db = new BdCahierTexteContext();

        private void frmPrintAnnee_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "Report\\rptListeAnnee.rdlc";
            var data = db.AnneeAcademiques
             .ToList() 
             .Select(a => new printAnnee
             {
                 LibelleAnneeAcademique = a.LibelleAnneeAcademique,
                 ValueAnneeAcademique = a.ValueAnneeAcademique.ToString() 
             })
             .ToList();

            ReportDataSource rds = new ReportDataSource("DataSet1", data);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }
    }
}
