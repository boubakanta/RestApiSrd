using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class DevisEnt
    {
        [Key]
        public int DevisId { get; set; }
        public long NumDevis { get; set; }
        public ClientEnt Client { get; set; }
        public DateTime DateCreatDevis { get; set; }
        public DateTime DatePaiementDevis { get; set; }
        public DateTime DateModifDevis { get; set; }
        public IEnumerable<LigneDevisEnt> LigneDevis { get; set; }
        public DevisStatusEnt Status { get; set; }

        public DevisEnt()
        {
            LigneDevis = new List<LigneDevisEnt>();
            //Client = new ClientEnt();
        }
    }

    public enum DevisStatusEnt
    {
        Encours,
        Valide
    }
}
