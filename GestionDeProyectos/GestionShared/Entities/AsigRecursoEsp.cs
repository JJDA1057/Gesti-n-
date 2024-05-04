using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionShared.Entities
{
    public class AsigRecursoEsp
    {
        public int Id { get; set; }

        public int RecursoEspeId { get; set; }
        public RecursoEspe RecursoEspe { get; set; }

        public int ActividadInvId { get; set; }
        public Actividadad Actividad { get; set; }
    }
}
