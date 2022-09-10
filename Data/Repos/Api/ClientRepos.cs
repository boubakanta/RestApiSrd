using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repos.Api
{
    public class ClientRepos : IClientRepos
    {
        private readonly RenovationDbContext _context;

        public ClientRepos(RenovationDbContext context)
        {
            _context = context;
        }

        public ClientEnt AddClient(ClientEnt client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
            return client;
        }

        public void DeleteClient(int clientId)
        {
            var clientEnt = _context.Clients.Find(clientId);
            _context.Clients.Remove(clientEnt);
            _context.SaveChanges();
        }

        public ClientEnt EditClient(ClientEnt client)
        {
            _context.Entry(client).State = EntityState.Modified;
            _context.SaveChanges();

            return client;
        }

        public IEnumerable<ClientEnt> GetClient()
        {
            return _context.Clients;
        }

        public ClientEnt GetClient(int clientId)
        {
            return GetClient().SingleOrDefault(c => c.ClientId == clientId);
        }

        public bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.ClientId == id);
        }
    }
}
