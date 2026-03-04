using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCahierText.views.Models
{
    public class CahierTexte
    {
        [Key]
        public int IdCahierTexte { get; set; }

        [Required]
        public int IdClasse { get; set; }   
        [ForeignKey("IdClasse")]
        public virtual Classe Classe { get; set; }

        public string DescriptionCahierTexte { get; set; }

        public DateTime DateCahierTexte { get; set; } = DateTime.Now;

        [Required]
        public int IdAnnee { get; set; }   
        [ForeignKey("IdAnnee")]
        public virtual AnneeAcademique AnneeAcademique { get; set; }

        [Required]
        public int IdResponsable { get; set; }  
        [ForeignKey("IdResponsable")]
        public virtual Utilisateur Responsable { get; set; }
    }

}
