using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class LigneFactureEnt
    {
        [Key]
        public int LigneFactureId { get; set; }
        public string Designation { get; set; }
        public int Quantite { get; set; }
        public double PrixUnit { get; set; }
        public FactureEnt Facture { get; set; }
    }
}
