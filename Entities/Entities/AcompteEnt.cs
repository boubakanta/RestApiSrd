using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class AcompteEnt
    {
        [Key]
        public int AcompteId { get; set; }
        public DateTime DateVersement { get; set; }
        public double Montant { get; set; }
        public ModePaiement ModePaiement { get; set; }
        public FactureEnt Facture { get; set; }
    }

    public enum ModePaiement
    {
        Espece = 1,
        Cheque = 2,
        Carte = 3
    }
}
