using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankingRemoteApi.Models
{
    public class BankAccountType
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int BankAccountTypeId { get; set; }

        public string BankAccountTypeDescription { get; set; }
    }

}
