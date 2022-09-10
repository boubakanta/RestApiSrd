using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class FactureEnt
    {
        [Key]
        public int FactureId { get; set; }
        public long NumFacture { get; set; }
        public DevisEnt Devis { get; set; }
        public ICollection<LigneFactureEnt> LigneFactures { get; set; }
        public ICollection<AcompteEnt> Acomptes { get; set; }
        public DateTime DateFact { get; set; }
        public Status Status { get; set; }

        public FactureEnt()
        {
            LigneFactures = new List<LigneFactureEnt>();
            Acomptes = new List<AcompteEnt>();
        }
    }

    public enum Status
    {
        Impaye = 0,
        Accompte = 1,
        Paye = 2
    }
}
