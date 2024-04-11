using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingRemoteApi.Models
{
    public class Client
    {

        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }

        public string? SaIdNumber { get; set; }
        public string? ResidentialAddress { get; set; }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }

        public string? ContactNumber { get; set; }

        public string? PhysicalAddress { get; set; }



        [ForeignKey("UserAccount")]
        public int UserAccountId { get; set; }

        public UserAccount? UserAccount { get; set; }

        public virtual ICollection<BankAccount>? BankAccounts { get; set; }
    }
}
