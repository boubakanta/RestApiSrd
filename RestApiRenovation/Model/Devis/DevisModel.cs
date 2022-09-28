 using RestApiRenovation.Model.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiRenovation.Model.Devis
{
    public class DevisModel
    {
        public int DevisId { get; set; }

        [DisplayName("Numéro Devis")]
        public long NumDevis { get; set; }
        public ClientModel Client { get; set; }

        [DisplayName("Date de devis")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreatDevis { get; set; }

        [DisplayName("Date de Paiement")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DatePaiementDevis { get; set; }

        [DisplayName("Date de modification")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateModifDevis { get; set; }

        public IEnumerable<LigneDevisModel> LigneDevis { get; set; }
        public DevisStatusModel Status { get; set; }
        public double Tva { get; set; }

        public double Total
        {
            get
            {
                double t = 0;
                if (LigneDevis != null)
                {
                    foreach (var devis in LigneDevis)
                    {
                        t += devis.PrixUnit * devis.Quantite;
                    }
                }

                return t;
            }
        }

        public double Ttc 
        { 
            get
            {
                return this.Total * (1 + Tva/100);
            }
        }


        public int? ClientId { get; set; }

        public DevisModel()
        {
            LigneDevis = new List<LigneDevisModel>();
            Client = new ClientModel();
        }
    }

    public enum DevisStatusModel
    {
        Encours,
        Valide
    }
}
