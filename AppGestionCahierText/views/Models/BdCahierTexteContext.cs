using MySql.Data.EntityFramework;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppGestionCahierText.views.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BdCahierTexteContext : DbContext
    {
        public BdCahierTexteContext() : base("connCahiertexte")
        {
        }

        public DbSet<Matiere> Matieres { get; set; }
        public DbSet<AnneeAcademique> AnneeAcademiques { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Professeur> Professeurs { get; set; }
        public DbSet<ResponsableClasse> ResponsableClasses { get; set; }
        public DbSet<Syllabus> Syllabuses { get; set; }
        public DbSet<CahierTexte> CahierTextes { get; set; }
        public DbSet<DetailsCahierTexte> DetailsCahierTextes { get; set;}
        public DbSet<DetailsSyllabus> DetailsSyllabuses { get; set; }

        

    }
}

