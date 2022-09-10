using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiRenovation.Model.Client;
using Service.business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiRenovation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult GetClient()
        {
            return Ok(HelperAutoMap.MapToClientModel(_clientService.GetClient()));
        }

        [HttpGet("{id}")]
        public IActionResult GetClient(int id)
        {
            var clientModel = HelperAutoMap.MapToClientModel(_clientService.GetClient(id));

            if(clientModel != null)
            {
                return Ok(clientModel);
            }

            return NotFound($"The client with id : {id} was not found");
        }

        [HttpPost]
        public IActionResult PostClient(ClientModel clientModel)
        {
            var clientEnt = HelperAutoMap.MapToClientEnt(clientModel);

            _clientService.AddClient(clientEnt);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + clientEnt.ClientId,
                clientEnt);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            _clientService.DeleteClient(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult EditClient(int id, ClientModel clientModel)
        {
            if (_clientService.ClientExists(id))
            {
                ClientEnt clientEnt = HelperAutoMap.MapToClientEnt(clientModel);
                return Ok(_clientService.EditClient(clientEnt));
            }
            return NotFound($"The client with id : {id} was not found");
        }
    }
}
