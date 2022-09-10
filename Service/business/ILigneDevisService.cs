using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.business
{
    public interface ILigneDevisService
    {
        IEnumerable<LigneDevisEnt> GetLigneDevisByDevisId(int devisId);
        LigneDevisEnt GetLigneDevis(int ligneDevisId);
        LigneDevisEnt AddLigneDevis(LigneDevisEnt ligneDevis);
        void DeleteLigneDevis(int ligneDevisId);
        LigneDevisEnt EditLigneDevis(LigneDevisEnt ligneDevis);
        bool LigneDevisExists(int id);
    }
}
