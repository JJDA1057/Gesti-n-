using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionShared.Entities
{

    public class Publicacion
    {
        public int Id { get; set; }

        [Display(Name = "Título")]
        [MaxLength(20, ErrorMessage = "No se permiten más de 20 Caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Titulo { get; set; }

        [Display(Name = "Autor(es)")]
        [MaxLength(100, ErrorMessage = "No se permiten más de 100z Caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Autores { get; set; }

        [Display(Name = "Fecha de publicación(yyyy-MM-dd)")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaPublicacion { get; set; }

        public Investigacion Investigacion { get; set; }

    }
}
