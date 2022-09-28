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
            IEnumerable<ClientEnt> listClients = _context.Clients;
            ClientEnt clientExist = new ClientEnt();

            // On vérifie si le client existe déjà
            foreach (var item in listClients)
            {
                if (client == item)
                    clientExist = item;
            }

            // Si le client est désactivé on l'active 
            
            if (clientExist.LastName != null  /*&& clientExist.Status != StatusClient.Active*/)
            {
                clientExist.Status = StatusClient.Active; client.Status = StatusClient.Active;
                return EditClient(clientExist);
                //return clientExist;
            }
            
            // Sinon on ajoute le client
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

        //private ClientEnt CheckExistClient(ClientEnt clientEnt)
        //{
        //    IEnumerable<ClientEnt> listClients = GetClient();
        //    foreach (var client in listClients)
        //    {
        //        bool repo = client == clientEnt;

        //        //ClientModel c1 = new ClientModel(); c1.LastName = "KANTA"; c1.FirstName = "Jules"; c1.TelephoneNumber = "0606060606"; c1.ClientId = 20;
        //        //ClientModel c2 = new ClientModel(); c2.LastName = "KANTA"; c2.FirstName = "Jules"; c2.TelephoneNumber = "0606060606"; c2.Address = "auauauau";
        //        //bool resp = c1 == c2;

        //        if (clientEnt == client)
        //        {
        //            return client;
        //        }
        //    }
        //    return null;
        //}
    }
}
