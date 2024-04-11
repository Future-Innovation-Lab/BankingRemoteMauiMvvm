using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingRemoteApi.Models
{
    public class TransactionType
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int TransactionTypeId { get; set; }

        public string TransactionTypeDescription { get; set; }
    }
}
