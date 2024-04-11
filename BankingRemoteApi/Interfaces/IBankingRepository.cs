using BankingRemoteApi.Models;

namespace BankingRemoteApi.Interfaces
{
    public interface IBankingRepository
    {
        Task<bool> VerifyLoginAsync(string userName, string password);

        Task<List<Client>> GetAllClientsAsync();
        Task<Client> GetClientByIdAsync(int id);
        Task<Client> GetClientBySurnameAsync(string lastName);
        Task<List<Transaction>> GetTransactionsByBankAccountIdAsync(int bankAccountId);
        Task UpdateClient(Client client);
    }
}
