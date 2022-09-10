using Data.Repos.Api;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.business
{
    public class LigneDevisService : ILigneDevisService
    {
        private ILigneDevisRepos _ligneDevisRepos;

        public LigneDevisService(ILigneDevisRepos ligneDevisRepos)
        {
            _ligneDevisRepos = ligneDevisRepos;
        }

        public LigneDevisEnt AddLigneDevis(LigneDevisEnt ligneDevis)
        {
            return _ligneDevisRepos.AddLigneDevis(ligneDevis);
        }

        public void DeleteLigneDevis(int ligneDevisId)
        {
            _ligneDevisRepos.DeleteLigneDevis(ligneDevisId);
        }

        public LigneDevisEnt EditLigneDevis(LigneDevisEnt ligneDevis)
        {
            return _ligneDevisRepos.EditLigneDevis(ligneDevis);
        }

        public IEnumerable<LigneDevisEnt> GetLigneDevisByDevisId(int devisId)
        {
            return _ligneDevisRepos.GetLigneDevisByDevisId(devisId);
        }

        public LigneDevisEnt GetLigneDevis(int ligneDevisId)
        {
            return _ligneDevisRepos.GetLigneDevis(ligneDevisId);
        }

        public bool LigneDevisExists(int id)
        {
            return _ligneDevisRepos.LigneDevisExists(id);
        }
    }
}
