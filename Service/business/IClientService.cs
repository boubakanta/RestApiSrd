using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.business
{
    public interface IClientService
    {
        IEnumerable<ClientEnt> GetClient();
        ClientEnt GetClient(int clientId);
        ClientEnt AddClient(ClientEnt client);
        void DeleteClient(int clientId);
        ClientEnt EditClient(ClientEnt client);
        bool ClientExists(int id);
    }
}
