using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionShared.Entities
{
    public class PartInvestigador
    {
        public int Id { get; set; }

        public int InvestigadorId { get; set; }
        public Investigador Investigador { get; set; }

        public int InvestigacionId { get; set; }
        public Investigacion Investigacion { get; set; }
    }
}
