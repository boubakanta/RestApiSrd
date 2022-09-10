using RestApiRenovation.Model.Devis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiRenovation.Model.Facture
{
    public class FactureModel
    {
        public int FactureId { get; set; }
        public long NumFacture { get; set; }
        public DevisModel Devis { get; set; }
        public IEnumerable<LigneFactureModel> LigneFactures { get; set; }
        public IEnumerable<AcompteModel> Acomptes { get; set; }

        [DisplayName("Date Création")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateFact { get; set; }
        //public Status Status { get; set; }

        [DisplayName("Reste à payer")]
        public double ResteAPaye
        {
            get
            {
                return Total - TotalAcompte;
            }
        }

        [DisplayName("Total Facture")]
        public double Total
        {
            get
            {
                double t = 0;
                if (LigneFactures != null)
                {
                    foreach (var facture in LigneFactures)
                    {
                        t += facture.PrixUnit * facture.Quantite;
                    }
                }

                return t;
            }
        }

        [DisplayName("Total Acomptes")]
        public double TotalAcompte
        {
            get
            {
                double t = 0;
                if (Acomptes != null)
                {
                    foreach (var item in Acomptes)
                    {
                        t += item.Montant;
                    }
                }

                return t;
            }
        }
    }
}
