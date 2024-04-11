using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingRemoteApi.Models
{
    public class BankAccount
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BankAccountId { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }

        public Client? Client { get; set; }

        [ForeignKey("BankAccountType")]
        public int BankAccountTypeId { get; set; }
        BankAccountType BankAccountType { get; set; }
        public string? BankAccountNumber { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal AccountBalance { get; set; }

        public virtual ICollection<Transaction>? Transactions { get; set; }

        public void DepositMoney(Transaction transaction)
        {
            AccountBalance = transaction.Value + AccountBalance;
            transaction.TransactionTypeId = 1;

            if (Transactions == null) { Transactions = new List<Transaction>(); };

            Transactions.Add(transaction);

        }

        public void WithdrawMoney(Transaction transaction)
        {
            if (transaction.Value <= AccountBalance)
            {
                AccountBalance -= transaction.Value;
                transaction.TransactionTypeId = 2;

                if (Transactions == null) { Transactions = new List<Transaction>(); };

                Transactions.Add(transaction);

            }
            else
            {
                throw new InvalidOperationException("Insufficient Funds");
            }


        }

    }
}
