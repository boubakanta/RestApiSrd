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
    public class LigneDevisController : ControllerBase
    {
        private readonly ILigneDevisService _ligneDevisService;
        //private readonly ILigneDevisService _clientService;

        public LigneDevisController(ILigneDevisService ligneDevisService)
        {
            _ligneDevisService = ligneDevisService;
        }

        [HttpGet("{devisId}")]
        public IActionResult GetLigneDevis(int devisId)
        {
            //var devisList = HelperAutoMap.MapToDevisModel(_ligneDevisService.GetLigneDevis());
            var devisList = _ligneDevisService.GetLigneDevisByDevisId(devisId);

            return Ok(devisList);
        }

        [HttpPost]
        public IActionResult PostLigneDevis(LigneDevisModel ligneDevisModel)
        {
            LigneDevisEnt ligneDevisEnt = HelperAutoMap.MapToLigneDevisEnt(ligneDevisModel);
            _ligneDevisService.AddLigneDevis(ligneDevisEnt);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + ligneDevisModel.LigneDevisId,
                ligneDevisModel);
        }

        [HttpPut("{id}")]
        public IActionResult PutLigneDevis(int id, LigneDevisModel ligneDevisModel)
        {
            if (_ligneDevisService.LigneDevisExists(id))
            {
                LigneDevisEnt ligneDevisEnt = HelperAutoMap.MapToLigneDevisEnt(ligneDevisModel);
                return Ok(_ligneDevisService.EditLigneDevis(ligneDevisEnt));
            }
            return NotFound($"The client with id : {id} was not found");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLigneDevis(int id)
        {
            //var ligneDevis = _ligneDevisService.GetLigneDevis(id);
            _ligneDevisService.DeleteLigneDevis(id);
            return Ok();

            
        }
    }
}
