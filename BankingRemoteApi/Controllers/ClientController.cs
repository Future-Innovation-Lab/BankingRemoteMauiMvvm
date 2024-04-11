using BankingRemoteApi.Data;
using BankingRemoteApi.Interfaces;
using BankingRemoteApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingRemoteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IBankingRepository _bankingRepository;

        public ClientController(IBankingRepository repository)
        {
            _bankingRepository = repository;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClient([FromBody] Client client)
        {
            try
            {
                if (client == null || !ModelState.IsValid)
                {
                    return BadRequest("Client Information Required.");
                }
                var existingClient = _bankingRepository.GetClientByIdAsync(client.ClientId);
                if (existingClient == null)
                {
                    return NotFound();
                }
                await _bankingRepository.UpdateClient(client);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return NoContent();
        }


    }
}
