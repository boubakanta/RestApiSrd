using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos.Api
{
    public class LigneDevisRepos : ILigneDevisRepos
    {
        private readonly RenovationDbContext _context;

        public LigneDevisRepos(RenovationDbContext context)
        {
            _context = context;
        }

        public LigneDevisEnt AddLigneDevis(LigneDevisEnt ligneDevis)
        {
            var devis = _context.Deviss.Find(ligneDevis.Devis.DevisId);
            ligneDevis.Devis = devis;
            _context.LignesDeviss.Add(ligneDevis);

            _context.SaveChanges();
            return ligneDevis;
        }

        public void DeleteLigneDevis(int ligneDevisId)
        {
            var ligneDevisEnt = _context.LignesDeviss.Find(ligneDevisId);
            if (ligneDevisEnt != null)
            {
                _context.LignesDeviss.Remove(ligneDevisEnt);
                _context.SaveChanges(); 
            }
        }

        public LigneDevisEnt EditLigneDevis(LigneDevisEnt ligneDevis)
        {
            _context.Entry(ligneDevis).State = EntityState.Modified;
            _context.SaveChanges();
            return ligneDevis;
        }

        public IEnumerable<LigneDevisEnt> GetLigneDevisByDevisId(int devisId)
        {
            return _context.LignesDeviss.Where(l => l.Devis.DevisId == devisId);
        }

        public LigneDevisEnt GetLigneDevis(int ligneDevisId)
        {
            return _context.LignesDeviss.Include("DevisEnt").SingleOrDefault(l => l.LigneDevisId == ligneDevisId);
        }

        public bool LigneDevisExists(int id)
        {
            return _context.LignesDeviss.Any(e => e.LigneDevisId == id);
        }
    }
}
