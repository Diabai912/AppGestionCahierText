using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCahierText.views.Models
{
    public class DetailsSyllabus
    {
        [Key] // ✅ majuscule obligatoire
        public int IdDetailsSyllabus { get; set; }

        [Required, MaxLength(15)]
        public string SeanceSyllabus { get; set; }

        [Required, MaxLength(500)]
        public string ContenuSyllabus { get; set; }

        [Required]
        public int? IdSyllabus { get; set; }   // ✅ clé étrangère

        [ForeignKey("IdSyllabus")]             // ✅ même nom exact
        public virtual Syllabus Syllabus { get; set; }
    }

    public class printDetailsSyllabus
        {
            public string SeanceSyllabus { get; set; }
            public string ContenuSyllabus { get; set; }
            public string Syllabus { get; set; }
    }
}
