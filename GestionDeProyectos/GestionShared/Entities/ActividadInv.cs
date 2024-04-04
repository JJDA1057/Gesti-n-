using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionShared.Entities
{
    public class Actividadad
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "No se permiten más de 50 Caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(100, ErrorMessage = "No se permiten más de 100 Caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha de Inicio(yyyy-MM-dd)")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Fecha Estimada de Finalización(yyyy-MM-dd)")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaFinalizacion { get; set; }

        public Investigacion investigacion { get; set; }

        // Relación con Recursos Especializados
        public ICollection<RecursoEspe> RecursosEspecializados { get; set; }
    }
}
