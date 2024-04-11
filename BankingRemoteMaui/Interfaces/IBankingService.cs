using BankingRemoteApi.Models;
using BankingRemoteCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingRemoteMaui.Interfaces
{
    public interface IBankingService

    {
        Task<List<Client>> GetAllClients();
        Task<Client> GetClientById(int id);
        Task<List<Transaction>> GetTransactionsByBankAccountId(int bankAccountId);
        Task<Client> UpdateClient(Client client);
        Task<Client> VerifyLogin(Auth auth);
    }
}
