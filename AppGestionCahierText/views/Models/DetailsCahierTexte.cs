using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppGestionCahierText.views.Models
{
    public class DetailsCahierTexte
    {
        [Key]
        public int IdDetailsCahierTexte { get; set; }

        // Relation vers le cahier de texte parent
        public int? IdCahierTexte { get; set; }
        [ForeignKey("IdCahierTexte")]
        public virtual CahierTexte CahierTexte { get; set; }

        // Matière concernée par ce détail
        public int? IdMatiere { get; set; } // ✅ clé étrangère
        [ForeignKey("IdMatiere")]
        public virtual Matiere Matiere { get; set; }

        // Date et description de la séance
        public DateTime DateDetail { get; set; } = DateTime.Now;

        [Required, MaxLength(2000)]
        public string Description { get; set; }
    }

    public class printDetailsCahierTexte
    {
        public string LibelleMatiere { get; set; }
        public string DateDetail { get; set; }    
        public string Description { get; set; }
    }
}