using Entities.Entities;
using RestApiRenovation.Model.Client;
using RestApiRenovation.Model.Devis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiRenovation.Controllers
{
    public static class HelperAutoMap
    {
        public static ClientModel MapToClientModel(ClientEnt clientEnt)
        {
            return new ClientModel
            {
                ClientId = clientEnt.ClientId,
                FirstName = clientEnt.FirstName,
                LastName = clientEnt.LastName,
                Address = clientEnt.Address,
                //DateOfBirth = clientEnt.DateOfBirth,
                TelephoneNumber = clientEnt.TelephoneNumber,
                Email = clientEnt.Email,
                Status = (StatusClientModel) clientEnt.Status
            };
        }

        public static List<ClientModel> MapToClientModel(IEnumerable<ClientEnt> listClientEnt)
        {
            List<ClientModel> list = new List<ClientModel>();
            foreach (var client in listClientEnt)
            {
                list.Add(MapToClientModel(client));
            }
            return list;
        }

        public static ClientEnt MapToClientEnt(ClientModel client)
        {
            return new ClientEnt
            {
                ClientId = client.ClientId,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Address = client.Address,
                //DateOfBirth = client.DateOfBirth,
                TelephoneNumber = client.TelephoneNumber,
                Email = client.Email,
                Status = (StatusClient) client.Status
            };
        }









        
        



        public static DevisModel MapToDevisModel(DevisEnt devisEnt)
        {
            DevisModel devisModel = new DevisModel
            {
                DevisId = devisEnt.DevisId,
                NumDevis = devisEnt.NumDevis,
                Client = MapToClientModel(devisEnt.Client),
                DateCreatDevis = devisEnt.DateCreatDevis,
                DateModifDevis = devisEnt.DateModifDevis,
                DatePaiementDevis = devisEnt.DatePaiementDevis,
                LigneDevis = MapToLigneDevisModel(devisEnt.LigneDevis),
                Status = (DevisStatusModel)devisEnt.Status,
                Tva = devisEnt.Tva
            };
            return devisModel;
        }


        public static List<DevisModel> MapToDevisModel(IEnumerable<DevisEnt> listeDevis)
        {
            List<DevisModel> listeDevisModel = new List<DevisModel>();

            foreach (var devis in listeDevis)
            {
                listeDevisModel.Add(MapToDevisModel(devis));
            }
            return listeDevisModel;
        }

        public static LigneDevisModel MapToLigneDevisModel(LigneDevisEnt ligneDevisEnt)
        {
            LigneDevisModel ligneDevisModel = new LigneDevisModel
            {
                LigneDevisId = ligneDevisEnt.LigneDevisId,
                Designation = ligneDevisEnt.Designation,
                PrixUnit = ligneDevisEnt.PrixUnit,
                Quantite = ligneDevisEnt.Quantite,
                Categorie = ligneDevisEnt.Categorie
                //Devis = MapToDevisModel(ligneDevisEnt.Devis)
            };

            //ligneDevisModel.Devis = MapToDevisModel(ligneDevisEnt.Devis)

            return ligneDevisModel;
        }

        public static List<LigneDevisModel> MapToLigneDevisModel(IEnumerable<LigneDevisEnt> listeLigneDevisEnt)
        {
            List<LigneDevisModel> listeLigneDevisModel = new List<LigneDevisModel>();

            foreach (var devis in listeLigneDevisEnt)
            {
                listeLigneDevisModel.Add(MapToLigneDevisModel(devis));
            }
            return listeLigneDevisModel;
        }

        public static DevisEnt MapToDevisEnt(DevisModel devisModel)
        {
            //var clientEnt = _clientService.Get(devisModel.ClientId);
            //var ligneDevis = new List<LigneDevisModel>();

            DevisEnt devisEnt = new DevisEnt
            {
                DevisId = devisModel.DevisId,
                NumDevis = devisModel.NumDevis,
                Client = HelperAutoMap.MapToClientEnt(devisModel.Client),
                DateCreatDevis = devisModel.DateCreatDevis,
                DateModifDevis = devisModel.DateModifDevis,
                DatePaiementDevis = devisModel.DatePaiementDevis,
                LigneDevis = devisModel.LigneDevis.Select(l => new LigneDevisEnt
                {
                    LigneDevisId = l.LigneDevisId,
                    Designation = l.Designation,
                    Quantite = l.Quantite,
                    PrixUnit = l.PrixUnit,
                    Devis = MapToDevisEnt(l.Devis)
                }).ToList(),
                Status = (DevisStatusEnt) devisModel.Status,
                Tva = devisModel.Tva
            };

            return devisEnt;
        }

        public static LigneDevisEnt MapToLigneDevisEnt(LigneDevisModel ligneDevisModel)
        {
            LigneDevisEnt ligneDevisEnt = new LigneDevisEnt
            {
                LigneDevisId = ligneDevisModel.LigneDevisId,
                Designation = ligneDevisModel.Designation,
                Quantite = ligneDevisModel.Quantite,
                PrixUnit = ligneDevisModel.PrixUnit,
                Devis = HelperAutoMap.MapToDevisEnt(ligneDevisModel.Devis),
                Categorie = ligneDevisModel.Categorie
            };

            return ligneDevisEnt;
        }

        //public static LigneDevisModel MapToLigneDevisModel(LigneDevisEnt ligneDevisEnt)
        //{
        //    LigneDevisModel ligneDevisModel = new LigneDevisModel
        //    {
        //        LigneDevisId = 
        //    };

        //    return ligneDevisModel;
        //}
    }
}
