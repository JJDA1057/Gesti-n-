using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionShared.Entities
{
    public class RecursoEspe
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "No se permiten más de 50 Caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Nombre { get; set; }


        [Display(Name = "Proveedor")]
        [MaxLength(50, ErrorMessage = "No se permiten más de 50 Caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Proveedor { get; set; }

        [Display(Name = "Cantidad Requerida")]
        [Required(ErrorMessage = "El campo Cantidad Requerida es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "La Cantidad Requerida debe ser mayor que cero")]
        public int CantidadRequerida { get; set; }

        [Display(Name = "Fecha de entrega estimada(yyyy-MM-dd)")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaEntrega { get; set; }




    }
}
