using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingApp.Model;
using BookingApp.Repository;
using BookingApp.DTO;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace BookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository clientRepository;
        private readonly IMapper mapper;

        public ClientsController(IClientRepository context, IMapper _mapper)
        {
            clientRepository = context;
            mapper = _mapper;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClient()
        {
            var clients = await clientRepository.GetClientsAsync();
            if (clients == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<IEnumerable<ClientDto>>(clients));
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await clientRepository.GetClientAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ClientDto>(client));
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> PutClient(ClientDto client)
        {
            Client clientToUpdate = mapper.Map<Client>(client);
            bool result = await clientRepository.UpdateClientAsync(clientToUpdate);
            if (result)
                return NoContent();
            return NotFound();
        }

        // Client: api/Clients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(ClientDto client)
        {
            if (ModelState.IsValid)
            {
                Client newClient = mapper.Map<Client>(client);
                var clientId = await clientRepository.AddClientAsync(newClient);
                if (clientId > 0)
                {
                    return Ok(clientId);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }

        //DELETE: api/Clients/5
        [HttpDelete]
        public async Task<ActionResult> DeleteClient(int id)
        {
            int result = 0;

            if (id == 0)
            {
                return BadRequest();
            }
            result = await clientRepository.DeleteClientAsync(id);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}

