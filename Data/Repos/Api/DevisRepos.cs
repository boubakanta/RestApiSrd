using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos.Api
{
    public class DevisRepos : IDevisRepos
    {
        private readonly RenovationDbContext _context;

        public DevisRepos(RenovationDbContext context)
        {
            _context = context;
        }

        public DevisEnt AddDevis(DevisEnt devis)
        {
            devis.Client = _context.Clients.Find(devis.Client.ClientId);
            _context.Deviss.Add(devis);
            _context.SaveChanges();
            return devis;
        }

        public void DeleteDevis(DevisEnt devis)
        {
            _context.Deviss.Remove(devis);
            _context.SaveChanges();
        }

        public bool DevisExists(int id)
        {
            return _context.Deviss.Any( e => e.DevisId == id);
        }

        public DevisEnt EditDevis(DevisEnt devis)
        {
            _context.Entry(devis).State = EntityState.Modified;
            _context.SaveChanges();
            return devis;
        }

        public IEnumerable<DevisEnt> GetDevis()
        {
            return _context.Deviss.Include("LigneDevis").Include("Client");
        }

        public DevisEnt GetDevis(int devisId)
        {
            return GetDevis().SingleOrDefault(d => d.DevisId == devisId);
        }
    }
}
