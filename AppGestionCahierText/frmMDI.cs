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
        public frmMDI()
        {
            InitializeComponent();
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


        private void matiereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmMatiere f = new frmMatiere();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void classeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmClasse f = new frmClasse();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void anneeToolStripMenuItem_Click(object sender, EventArgs e)
        { // Nous permet de fermer tous ce qui a été ouvert
            fermer();
            frmAnneeAcademique f = new frmAnneeAcademique();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void cahierTexteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer(); // ferme les autres formulaires ouverts
            frmCahierTexte f = new frmCahierTexte();
            f.MdiParent = this; // rattache au MDI parent
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void utilisateurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmUtilisateur f = new frmUtilisateur();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void syllabusToolStripMenuItem_Click(object sender, EventArgs e)
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
            // Utiliser WindowState pour maximiser proprement la MDI parent
            this.WindowState = FormWindowState.Maximized;
            this.Location = new Point(0, 0);
        }
    }
}
