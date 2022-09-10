using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiRenovation.Model.Devis;
using Service.business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiRenovation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevisController : ControllerBase
    {
        private readonly IDevisService _devisService;
        private readonly IClientService _clientService;

        public DevisController(IDevisService devisService,
            IClientService clientService
            )
        {
            _devisService = devisService;
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult GetDevis()
        {
           var aa =  _devisService.GetDevis();
            var devisList = HelperAutoMap.MapToDevisModel(_devisService.GetDevis());

            return Ok(devisList);
        }

        [HttpGet("{id}")]
        public IActionResult GetDevis(int id)
        {
            DevisModel devisModel = HelperAutoMap.MapToDevisModel(_devisService.GetDevis(id));

            if (devisModel != null)
            {
                return Ok(devisModel);
            }

            return NotFound($"The devis with id : {id} was not found");
        }

        // POST: api/Devis
        [HttpPost]
        public IActionResult PostDevis(DevisModel devis)
        {
            var date = DateTime.Now;
            devis.NumDevis = DataHelper.NumHelper.GetDevisNumber();
            devis.Status = DevisStatusModel.Encours;
            devis.DateCreatDevis = date;
            devis.DatePaiementDevis = date.AddDays(30);
            //devis.Client = HelperAutoMap.MapToClientModel(_clientService.GetClient(devis.Client.ClientId));
            DevisEnt devisEnt = HelperAutoMap.MapToDevisEnt(devis);

            _devisService.AddDevis(devisEnt);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + devis.DevisId,
                devis);
        }
    }
}
