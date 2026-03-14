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
    public partial class frmPrintDetailsSyllabus : Form
    {
        public frmPrintDetailsSyllabus()
        {
            InitializeComponent();
        }

        BdCahierTexteContext db = new BdCahierTexteContext();

        private void frmPrintDetailsSyllabus_Load(object sender, EventArgs e)
        {

      
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "Report\\rptListeDetailsSyllabus.rdlc";

            var data = db.DetailsSyllabuses
                         .Include("Syllabus")
                         .ToList()
                         .Select(d => new printDetailsSyllabus
                         {
                             SeanceSyllabus = d.SeanceSyllabus,
                             ContenuSyllabus = d.ContenuSyllabus,
                             Syllabus = d.Syllabus != null ? d.Syllabus.LibelleSyllabus : "Aucun"
                             // ✅ remplace LibelleSyllabus par le vrai nom de la propriété
                         })
                         .ToList();

            ReportDataSource rds = new ReportDataSource("DataSet1", data);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
    
}
