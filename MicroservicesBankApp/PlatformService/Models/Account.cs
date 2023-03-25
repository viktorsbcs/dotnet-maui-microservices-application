using System.ComponentModel.DataAnnotations;

namespace PlatformService.Models
{
    public class Account
    {
        [Key]
        public string AccountId { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public decimal Balance { get; set; }    

    }
}
