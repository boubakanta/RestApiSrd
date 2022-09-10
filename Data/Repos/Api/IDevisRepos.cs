using Entities.Entities;
using System;
using System.Collections.Generic;

namespace Data.Repos.Api
{
    public interface IDevisRepos
    {
        IEnumerable<DevisEnt> GetDevis();
        DevisEnt GetDevis(int devisId);
        DevisEnt AddDevis(DevisEnt devis);
        void DeleteDevis(DevisEnt devis);
        DevisEnt EditDevis(DevisEnt devis);
        bool DevisExists(int id);
    }
}
