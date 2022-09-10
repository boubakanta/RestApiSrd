using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.business
{
    public interface IDevisService
    {
        IEnumerable<DevisEnt> GetDevis();
        DevisEnt GetDevis(int devisId);
        DevisEnt AddDevis(DevisEnt devis);
        void DeleteDevis(DevisEnt devis);
        DevisEnt EditDevis(DevisEnt devis);
        bool DevisExists(int id);
    }
}
