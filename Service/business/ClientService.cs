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
            return _clientRepos.GetClient().OrderByDescending(c => c.ClientId);
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
