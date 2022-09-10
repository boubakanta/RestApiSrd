using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiRenovation.Model.Facture
{
    public class LigneFactureModel
    {
        public int LigneFactureId { get; set; }
        public string Designation { get; set; }
        public int Quantite { get; set; }
        public double PrixUnit { get; set; }
        public FactureModel Facture { get; set; }
        public double Total
        {
            get { return PrixUnit * Quantite; }
        }
    }
}
