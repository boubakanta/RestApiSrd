using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiRenovation.Model.Devis
{
    public class LigneDevisModel
    {
        public int LigneDevisId { get; set; }
        public string Designation { get; set; }
        public int Quantite { get; set; }
        public double PrixUnit { get; set; }
        public DevisModel Devis { get; set; }
        //public int DevisId { get; set; }

        public LigneDevisModel()
        {
            Devis = new DevisModel();
        }

        public double Total
        {
            get { return PrixUnit * Quantite; }
        }
    }
}
