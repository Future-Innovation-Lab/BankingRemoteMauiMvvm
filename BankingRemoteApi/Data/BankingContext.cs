using BankingRemoteApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BankingRemoteApi.Data
{

    public class BankingContext
        : DbContext
    {
        public BankingContext(DbContextOptions options)
            : base(options)
        {

        }


        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<BankAccountType> BankAccountTypes { get; set; }

        public DbSet<ClientType> ClientTypes { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
}
