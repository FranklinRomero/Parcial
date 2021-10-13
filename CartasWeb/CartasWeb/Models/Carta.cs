using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CartasWeb.Models
{
    public class Carta
    {
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} es requerido")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "La longitud de {0} debe estar entre {2} y {1}")]
        public string NaipeId { get; set; }


        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Nombre de la carta")]
        public string Nombre { get; set; }


        [Required]
        [Url]
        [Display(Name = "Link de la imagen")]
        public string Imagen { get; set; }
    }
}
