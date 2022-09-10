using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiRenovation
{
    public class RenovationDbContext : DbContext
    {
        public RenovationDbContext(DbContextOptions<RenovationDbContext> options) : base(options)
        {

        }

        public DbSet<ClientEnt> Clients { get; set; }
        //public DbSet<DevisEnt> Deviss { get; set; }
        //public DbSet<LigneDevisEnt> LignesDeviss { get; set; }
        //public DbSet<FactureEnt> Factures { get; set; }
        //public DbSet<LigneFactureEnt> LignesFactures { get; set; }
        //public DbSet<AcompteEnt> Acomptes { get; set; }

    }
}
