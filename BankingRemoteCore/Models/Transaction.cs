using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingRemoteApi.Models
{
    public class Transaction
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TranactionId { get; set; }

        public DateTime TransactionDate { get; set; }

        public string? Reference { get; set; }
        public string? Description { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Value { get; set; }


        [ForeignKey("TransactionType")]
        public int TransactionTypeId { get; set; }

        public TransactionType TransactionType { get; set; }


        [ForeignKey("BankAccount")]
        public int BankAccountId { get; set; }

        public BankAccount BankAccount { get; set; }


    }
}
