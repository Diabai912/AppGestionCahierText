using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppGestionCahierText.views.parametre;

namespace AppGestionCahierText
{
    public partial class frmMDI : Form
    {
        private string _role;

        public frmMDI(string role)
        {
            InitializeComponent();
            _role = role;
        }

        private void fermer()
        {
            if (this.MdiChildren.Length == 0)
                return;

            foreach (Form chform in this.MdiChildren)
            {
                if (!chform.IsDisposed)
                {
                    chform.Close();
                }
            }
        }


        private void menuMatiere_Click(object sender, EventArgs e)
        {
            fermer();
            frmMatiere f = new frmMatiere();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void menuClasse_Click(object sender, EventArgs e)
        {
            fermer();
            frmClasse f = new frmClasse();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void menuAnneeAcademique_Click(object sender, EventArgs e)
        { // Nous permet de fermer tous ce qui a été ouvert
            fermer();
            frmAnneeAcademique f = new frmAnneeAcademique();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void menuCahierTexte_Click(object sender, EventArgs e)
        {
            fermer(); // ferme les autres formulaires ouverts
            frmCahierTexte f = new frmCahierTexte();
            f.MdiParent = this; // rattache au MDI parent
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void menuUtilisateur_Click(object sender, EventArgs e)
        {
            fermer();
            frmUtilisateur f = new frmUtilisateur();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void menuSyllabus_Click(object sender, EventArgs e)
        {
            fermer();
            frmSyllabus f = new frmSyllabus();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

       

       


        private void seDeconnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConnexion f = new frmConnexion();
            f.Show();
            this.Close();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // lorsque l'application se lance, prend tout l'écran
        private void frmMDI_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Location = new Point(0, 0);

           

            if (_role == "Admin")
            {
                // Admin voit tout
                menuMatiere.Visible = true;
                menuClasse.Visible = true;
                MenuAnneeAcademique.Visible = true;
                menuCahierTexte.Visible = true;
                MenuUtilisateur.Visible = true;
                menuSyllabus.Visible = true;
                menuDetailsSyllabus.Visible = true;
            }
            else if (_role == "Responsable")
            {
                // Responsable voit CahierTexte + DetailsSyllabus
                menuCahierTexte.Visible = true;
                menuDetailsSyllabus.Visible = true;
            }
            else if (_role == "Professeur")
            {
                // Professeur voit Matiere + Syllabus + DetailsSyllabus
                menuMatiere.Visible = true;
                menuSyllabus.Visible = true;
                menuDetailsSyllabus.Visible = true;
            }
        }




        private void menuDetailsSyllabus_Click(object sender, EventArgs e)
        {
           
            frmDetailsSyllabus frm = new frmDetailsSyllabus();
            frm.MdiParent = this; // pour qu’il s’ouvre dans le MDI
            frm.Show();
       

    }
}
}
