using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankingRemoteApi.Models
{
    public class ClientType
    {

        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientTypeId { get; set; }

        public string ClientTypeDescription { get; set; }

    }
}
