using Data.Repos.Api;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.business
{
    public class DevisService : IDevisService
    {
        private IDevisRepos _devisRepos;

        public DevisService(IDevisRepos devisRepos)
        {
            _devisRepos = devisRepos;
        }
        public DevisEnt AddDevis(DevisEnt devis)
        {
            return _devisRepos.AddDevis(devis);
        }

        public void DeleteDevis(DevisEnt devis)
        {
            _devisRepos.DeleteDevis(devis);
        }

        public bool DevisExists(int id)
        {
            return _devisRepos.DevisExists(id);
        }

        public DevisEnt EditDevis(DevisEnt devis)
        {
            return _devisRepos.EditDevis(devis);
        }

        public IEnumerable<DevisEnt> GetDevis()
        {
            return _devisRepos.GetDevis().OrderByDescending(d => d.DevisId);
        }

        public DevisEnt GetDevis(int devisId)
        {
            return _devisRepos.GetDevis(devisId);
        }
    }
}
