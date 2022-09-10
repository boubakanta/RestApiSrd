using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class LigneDevisEnt
    {
        [Key]
        public int LigneDevisId { get; set; }
        public string Designation { get; set; }
        public int Quantite { get; set; }
        public double PrixUnit { get; set; }
        public DevisEnt Devis { get; set; }
    }
}
