using PlatformService.Models;
using System.ComponentModel.DataAnnotations;

namespace PlatformService.DataTransferObjects
{
    public class AccountCreateDto
    {
        [Required]
        public User User { get; set; }

        [Required]
        public decimal Balance { get; set; }
    }
}
