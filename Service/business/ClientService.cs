using Data.Repos.Api;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.business
{
    public class ClientService : IClientService
    {
        private IClientRepos _clientRepos;
        public ClientService(IClientRepos clientRepos)
        {
            this._clientRepos = clientRepos;
        }

        public ClientEnt AddClient(ClientEnt client)
        {
            //client.DateOfBirth = DateTime.Now;
            return _clientRepos.AddClient(client);
        }

        public void DeleteClient(int clientId)
        {
            _clientRepos.DeleteClient(clientId);
        }

        public ClientEnt EditClient(ClientEnt client)
        {
            return _clientRepos.EditClient(client);
        }

        public IEnumerable<ClientEnt> GetClient()
        {
            ClientEnt c1 = new ClientEnt(); c1.LastName = "KANTA"; c1.FirstName = "Jules"; c1.TelephoneNumber = "0606060606";c1.ClientId = 20;
            ClientEnt c2 = new ClientEnt(); c2.LastName = "KANTA"; c2.FirstName = "Jules"; c2.TelephoneNumber = "0606060606"; c2.Address = "auauauau";
            bool resp = c1 == c2;

            return _clientRepos.GetClient().Where(cli => cli.Status == StatusClient.Active).OrderByDescending(c => c.ClientId);
        }

        public ClientEnt GetClient(int clientId)
        {
            return _clientRepos.GetClient(clientId);
        }

        public bool ClientExists(int id)
        {
            return _clientRepos.ClientExists(id);
        }
    }
}
