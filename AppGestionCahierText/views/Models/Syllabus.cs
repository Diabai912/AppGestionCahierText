using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCahierText.views.Models
{
    public class Syllabus
    {
        [Key]
        public int IdSyllabus { get; set; }


        [Required, MaxLength(100)]
        public string LibelleSyllabus { get; set; }


        [Required, MaxLength(500)]
        public string DescriptionSyllabus { get; set; }


        [Required]
        public int? VolumeHoraireSyllabus { get; set; }


        [Required,MaxLength(10)]
        public string NiveauSyllabus { get; set; }
    }


    public class printSyllabus
    {
        public string LibelleSyllabus { get; set; }
        public string DescriptionSyllabus { get; set; }
        public string VolumeHoraireSyllabus { get; set; }
        public string NiveauSyllabus { get; set; }
    }
}
