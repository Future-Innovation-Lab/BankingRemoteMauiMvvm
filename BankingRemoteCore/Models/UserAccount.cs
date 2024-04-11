using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingRemoteApi.Models
{
    public class UserAccount
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserAccountId { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? EmailAddress { get; set; }

    }
}
