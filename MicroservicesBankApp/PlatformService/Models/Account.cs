using System.ComponentModel.DataAnnotations;

namespace PlatformService.Models
{
    public class Account
    {
        [Key]
        public string AccountId { get; set; }

        public User User { get; set; }  

        public decimal Balance { get; set; }    

    }
}
