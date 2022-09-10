using Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiRenovation.Model.Facture
{
    public class AcompteModel
    {
        public int AcompteId { get; set; }

        [DisplayName("Date Paiement")]
        public DateTime DateVersement { get; set; }

        [DisplayName("Montant")]
        public double Montant { get; set; }

        [DisplayName("Mode de Paiement")]
        public ModePaiement ModePaiement { get; set; }
        public FactureModel Facture { get; set; }
        public int FactureId { get; set; }
        public int ModePaiementId { get; set; }

        //public List<SelectListItem> ModePaiementOptions { get; set; }

        public AcompteModel()
        {
            Facture = new FactureModel();
        }
    }
}
