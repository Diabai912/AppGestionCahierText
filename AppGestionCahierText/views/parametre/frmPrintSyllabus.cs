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
    public partial class frmPrintSyllabus : Form
    {
        public frmPrintSyllabus()
        {
            InitializeComponent();
        }
        BdCahierTexteContext db = new BdCahierTexteContext();
        private void frmPrintSyllabus_Load(object sender, EventArgs e)
        {
        
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "Report\\rptListeSyllabus.rdlc";

            var data = db.Syllabuses
                         .ToList()
                         .Select(s => new printSyllabus
                         {
                             LibelleSyllabus = s.LibelleSyllabus,
                             DescriptionSyllabus = s.DescriptionSyllabus,
                             VolumeHoraireSyllabus = s.VolumeHoraireSyllabus.ToString(), // ✅ ToString() après ToList()
                             NiveauSyllabus = s.NiveauSyllabus
                         })
                         .ToList();

            ReportDataSource rds = new ReportDataSource("DataSet1", data);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }
    }
    
}
