using BankingRemoteApi.Data;
using BankingRemoteApi.Models;
using BankingRemoteCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingRemoteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly BankingContext _context;

        public AuthController(BankingContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult<Client>> Authorize(Auth auth)
        {
            string userName = auth.Username;
            string password = auth.Password;

            var account =  await _context.UserAccounts.Where(x => x.UserName == userName && x.Password == password).FirstOrDefaultAsync();

            if (account == null)
                return Unauthorized();

            var client = await _context.Clients.Include(client => client.BankAccounts).Where(x => x.UserAccountId == account.UserAccountId).FirstOrDefaultAsync();

             if (client == null)
                return Unauthorized();

            //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(Authorize), client);
        }


    }
}
