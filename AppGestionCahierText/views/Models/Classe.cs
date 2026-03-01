using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCahierText.views.Models
{
    public class Classe
    {
        [Key]
        public int ClasseId { get; set; }  

        [Required, MaxLength(100)]
        public string LibelleClasse { get; set; }

        public int AnneeAcademiqueId { get; set; }

        [ForeignKey("AnneeAcademiqueId")]
        public virtual AnneeAcademique AnneeAcademique { get; set; }
    }

}
