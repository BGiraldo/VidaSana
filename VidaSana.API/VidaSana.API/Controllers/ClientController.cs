using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VidaSana.API.Application.Models;
using VidaSana.API.Infrastructure.IRepository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VidaSana.API.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpPost ("register")]
        public IActionResult ClientRegister(ClientData clientData)
        {
            _clientRepository.Add(clientData);

            return (IActionResult)Ok();
        }

        [HttpPost("update")]
        public IActionResult UpdateClient(ClientData clientData)
        {
            _clientRepository.Update(clientData);

            return (IActionResult)Ok();
        }

        [HttpPost("remove")]
        public IActionResult RemoveClient(string clientId)
        {
            _clientRepository.Delete(clientId);

            return (IActionResult)Ok();
        }

        [HttpPost("search")]
        public IActionResult SearchClient(string clientId)
        {
            ClientData client = _clientRepository.FindAsync(clientId).Result;

            if (client != null)
                return (IActionResult)Ok();

            return (IActionResult)BadRequest();

        }



    }
}
