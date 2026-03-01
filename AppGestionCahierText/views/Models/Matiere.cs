using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCahierText.views.Models
{
    public class Matiere
    {
        [Key]
        public int IdMatiere { get; set; }

        [Required, MaxLength(200)]
        public string LibelleMatiere { get; set; }

        [Required]
        public int? VolumeHoraireMatiere { get; set; }

        [Required, MaxLength(80)]
        //chaque fois c string il faut mettre  MaxLength
        public string Niveau { get; set; }
    }

}
