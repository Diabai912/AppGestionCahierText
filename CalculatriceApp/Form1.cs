using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatriceApp
{
    public partial class Calculatrice : Form
    {
        double valeur = 0;
        string operateur = "";
        bool operationEnCours = false;
        bool chiffreEnCours = true;
        

        public Calculatrice()
        {
            InitializeComponent();
        }

        private void Calculatrice_Load(object sender, EventArgs e)
        {

        }
        private void btnChiffre_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (txtAffichage.Text == "0" || operationEnCours)
                txtAffichage.Text = b.Text;
            else
                txtAffichage.Text += b.Text;

            operationEnCours = false;
        }
        

        private void btnOperation_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (operateur != "" && !operationEnCours)
            {
                // calcul immédiat
                switch (operateur)
                {
                    case "+": valeur = valeur + double.Parse(txtAffichage.Text); break;
                    case "-": valeur = valeur - double.Parse(txtAffichage.Text); break;
                    case "×": valeur = valeur * double.Parse(txtAffichage.Text); break;
                    case "÷": valeur = valeur / double.Parse(txtAffichage.Text); break;
                }

                txtAffichage.Text = valeur.ToString();
            }
            else
            {
                // première opération
                valeur = double.Parse(txtAffichage.Text);
            }

            operateur = b.Text;
            operationEnCours = true;
            chiffreEnCours = false;
        }
        private void btnCre_Click(object sender, EventArgs e)
        {
            valeur = double.Parse(txtAffichage.Text);

            double result = valeur * valeur;

            txtAffichage.Text = result.ToString();

            // Prépare un nouveau calcul après le résultat
            valeur = result;
            operateur = "";
            operationEnCours = true;
            chiffreEnCours = false;
        }
        private void btnCbe_Click(object sender, EventArgs e)
        {
            valeur = double.Parse(txtAffichage.Text);

            double result = valeur * valeur * valeur;

            txtAffichage.Text = result.ToString();

            // Prépare un nouveau calcul après le résultat
            valeur = result;
            operateur = "";
            operationEnCours = true;
            chiffreEnCours = false;
        }
        private void btnPct_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtAffichage.Text, out double val))
            {
               
                double pourcentage = valeur * (val / 100);
                txtAffichage.Text = pourcentage.ToString();
                chiffreEnCours = false;
            }
        }
        private void btnFlt(object sender, EventArgs e)
        {
            if (!chiffreEnCours) { 
                txtAffichage.Text = "0";
            }
            if (!txtAffichage.Text.Contains("."))
            {
                txtAffichage.Text += ".";
            }
        }

        private void btnRst_Click(object sender, EventArgs e)
        {
            double valEnCours = double.Parse(txtAffichage.Text);

            switch (operateur)
            {
                case "+": valEnCours = valeur + valEnCours; break;
                case "-": valEnCours = valeur - valEnCours; break;
                case "×": valEnCours = valeur * valEnCours; break;
                case "÷": valEnCours = valeur / valEnCours; break;
            }

            txtAffichage.Text = valEnCours.ToString();

            // prépare un nouveau calcul
            valeur = valEnCours;
            operationEnCours = true;
            operateur = "";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtAffichage.Text.Length <= 1)
            {
                txtAffichage.Text = "0";
            }
            else
            {
                txtAffichage.Text = txtAffichage.Text.Substring(0, txtAffichage.Text.Length - 1);
            }

        }
        private void btnClr_Click(object sender, EventArgs e)
        {
            txtAffichage.Text = "0";
            valeur = 0;
            operateur = "";
        }
        private void btnRcn_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtAffichage.Text, out double val))
            {
                if (val < 0)
                {
                    txtAffichage.Text = "Erreur";  // Racine impossible
                }
                else
                {
                    txtAffichage.Text = Math.Sqrt(val).ToString();
                }
            }

            // On reset l’état pour éviter des bugs après la racine
            operateur = "";
            operationEnCours = false;
            chiffreEnCours = false;
        }

        
    }
}
