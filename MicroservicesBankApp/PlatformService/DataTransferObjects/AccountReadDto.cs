using PlatformService.Models;
using System.ComponentModel.DataAnnotations;

namespace PlatformService.DataTransferObjects
{
    public class AccountReadDto
    {
        public string AccountId { get; set; }

        public User User { get; set; }

        public decimal Balance { get; set; }
    }
}
