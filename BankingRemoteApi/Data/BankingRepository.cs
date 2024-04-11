using BankingRemoteApi.Interfaces;
using BankingRemoteApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingRemoteApi.Data
{
    public class BankingRepository : IBankingRepository
    {

        private BankingContext _bankingContext;

        public BankingRepository(BankingContext bankingContext)
        {
            _bankingContext = bankingContext;
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            var customers = await _bankingContext.Clients.Include(c => c.BankAccounts).ToListAsync();
            return customers;
        }

        public async Task<List<Transaction>> GetTransactionsByBankAccountIdAsync(int bankAccountId)
        {
            var transactions = await _bankingContext.Transactions.Where(t => t.BankAccountId == bankAccountId).ToListAsync();
            return transactions;
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            var customer = await _bankingContext.Clients.Where(x => x.ClientId == id).FirstOrDefaultAsync();
            return customer;
        }

        public async Task<Client> GetClientBySurnameAsync(string surname)
        {
            var customer = await _bankingContext.Clients.Where(x => x.Surname == surname).FirstOrDefaultAsync();
            return customer;
        }

        public async Task UpdateClient(Client client)
        {
            _bankingContext.Entry(client).State = EntityState.Modified;
            await _bankingContext.SaveChangesAsync();
        }

        public async Task<bool> VerifyLoginAsync(string userName, string password)
        {
            var user = await _bankingContext.UserAccounts.Where(u => u.UserName == userName && u.Password == password).FirstOrDefaultAsync();

            if (user != null)
            {
                return true;
            }

            return false;
        }
    }
}
