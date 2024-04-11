using BankingRemoteApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net.NetworkInformation;

namespace BankingRemoteApi.Data
{
    public class DbInitialiser
    {
        private readonly BankingContext _context;

        public DbInitialiser(BankingContext context)
        {
            _context = context;
        }

        public void Run()
        {
            if (!_context.TransactionTypes.Any())
            {
                TransactionType transactionType = new TransactionType()
                {
                    TransactionTypeDescription = "Deposit"
                };

                _context.TransactionTypes.Add(transactionType);

                transactionType = new TransactionType()
                {
                    TransactionTypeDescription = "Withdraw"
                };

                _context.TransactionTypes.Add(transactionType);

                _context.SaveChanges();
            }

            if (!_context.ClientTypes.Any())
            {
                ClientType clientType = new ClientType()
                {
                    ClientTypeDescription = "Private"
                };

                _context.ClientTypes.Add(clientType);

                clientType = new ClientType()
                {
                    ClientTypeDescription = "MVP"
                };
                _context.ClientTypes.Add(clientType);

                clientType = new ClientType()
                {
                    ClientTypeDescription = "Standard"
                };

                _context.ClientTypes.Add(clientType);

                _context.SaveChanges();
            }

            if (!_context.BankAccountTypes.Any())
            {
                BankAccountType bankAccountType = new BankAccountType()
                {
                    BankAccountTypeDescription = "Credit"
                };

                _context.BankAccountTypes.Add(bankAccountType);

                bankAccountType = new BankAccountType()
                {
                    BankAccountTypeDescription = "Savings"
                };


                _context.BankAccountTypes.Add(bankAccountType);

                bankAccountType = new BankAccountType()
                {
                    BankAccountTypeDescription = "Cheque"
                };


                _context.BankAccountTypes.Add(bankAccountType);

                _context.SaveChanges();
            }



            if (!_context.Clients.Any())
            {

                var customer = new Client();
                customer.FirstName = "Brandon";
                customer.Surname = "Mack";
                customer.SaIdNumber = "1843877687";
                customer.ContactNumber = "0825551234";
                customer.ResidentialAddress = "Swellendam";



                var bankAccount = new BankAccount();
                bankAccount.BankAccountNumber = "0001";
                bankAccount.BankAccountTypeId = 1;

                Transaction transaction = new Transaction();
                transaction.TransactionDate = DateTime.Now;
                transaction.Reference = "Deposited Money for lunch";
                transaction.Value = 1000;

                bankAccount.DepositMoney(transaction);
                _context.Transactions.Add(transaction);

                transaction = new Transaction();
                transaction.TransactionDate = DateTime.Now;
                transaction.Reference = "Withdraw for lunch";
                transaction.Value = 10;

                bankAccount.WithdrawMoney(transaction);
                _context.Transactions.Add(transaction);


                var userAccount = new UserAccount();
                userAccount.EmailAddress = "me@computer.com";
                userAccount.UserName = "Bob";
                userAccount.Password = "12345";
                
              
                
                customer.BankAccounts = new List<BankAccount>();
                customer.BankAccounts.Add(bankAccount);

                customer.UserAccount = userAccount;

                _context.Clients.Add(customer);
                _context.BankAccounts.Add(bankAccount);
                _context.UserAccounts.Add(userAccount);
                _context.SaveChanges();

                customer.UserAccount = userAccount;

                _context.SaveChanges();
            }
        }
    }
}
