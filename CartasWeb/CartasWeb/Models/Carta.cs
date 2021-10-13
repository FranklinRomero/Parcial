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
