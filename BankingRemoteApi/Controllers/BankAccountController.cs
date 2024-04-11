using BankingRemoteApi.Data;
using BankingRemoteApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingRemoteApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankAccountController : ControllerBase
    {

        private readonly BankingContext _context;

        public BankAccountController(BankingContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<BankAccount>>> GetBankAccountsByClientId(int clientId)
        {
            var accounts = await _context.BankAccounts.Include(b => b.Transactions).Where(b => b.ClientId == clientId).ToListAsync();
            
            if (accounts == null || accounts.Count == 0) { return NotFound(); }

            return accounts;

        }
    }
}
