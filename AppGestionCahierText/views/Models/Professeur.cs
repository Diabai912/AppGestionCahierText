using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCahierText.views.Models
{
    public class Professeur : Utilisateur
    {
        [Required, MaxLength(85)]
        public string SpecialiteProfesseur { get; set; }
    }
}
