using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCahierText.views.Models
{
    public class ResponsableClasse : Utilisateur
    {
        [Required, MaxLength(20)]
        public string MatriculeResponsable { get; set; }

      
    }
}
