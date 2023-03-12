using System.ComponentModel.DataAnnotations;

namespace PlatformService.Models
{
    public class Account
    {
        [Key]
        public User User { get; set; }  

        public Guid AccountId { get; set; } 

        public decimal Bilance { get; set; }    

    }
}
