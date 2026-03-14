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
    public partial class frmPrintUtilisateur : Form
    {
        public frmPrintUtilisateur()
        {
            InitializeComponent();
        }

        BdCahierTexteContext db = new BdCahierTexteContext();
        private void frmPrintUtilisateur_Load(object sender, EventArgs e)
        {

            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "Report\\rptListeUtilisateur.rdlc";
            var data = db.Utilisateurs
             .Include("Classe")
             .ToList()
             .Select(u => new printUtilisateur
             {
                 NomUtilisateur = u.NomUtilisateur,
                 PrenomUtilisateur = u.PrenomUtilisateur,
                 AdresseUtilisateur = u.AdresseUtilisateur,
                 EmailUtilisateur = u.EmailUtilisateur,
                 TelephoneUtilisateur = u.TelephoneUtilisateur,
                 Identifiant = u.Identifiant,
                 Role = u.Role,
                 Classe = u.Classe != null ? u.Classe.LibelleClasse : "Aucune" 
             })
             .ToList();

            ReportDataSource rds = new ReportDataSource("DataSet1", data);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }
    }
}
