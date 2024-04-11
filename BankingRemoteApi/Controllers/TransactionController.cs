using BankingRemoteApi.Data;
using BankingRemoteApi.Interfaces;
using BankingRemoteApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingRemoteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IBankingRepository _repository;

        public TransactionController(IBankingRepository repo)
        {
            _repository = repo;
        }

        [HttpGet("{bankAccountId}")]
        public async Task<ActionResult<List<Transaction>>> GetTransactionsByBankAccountId(int bankAccountId)
        {
            var transactions = await _repository.GetTransactionsByBankAccountIdAsync(bankAccountId);


            if (transactions == null || transactions.Count == 0) { return NotFound(); }

            return transactions;

        }
    }
}

