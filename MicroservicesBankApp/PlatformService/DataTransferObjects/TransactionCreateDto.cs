using PlatformService.Models;
using System.ComponentModel.DataAnnotations;

namespace PlatformService.DataTransferObjects
{
    public class TransactionCreateDto
    {
        [Required]
        public Account FromAccount { get; set; }

        [Required]
        public Account ToAccount { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
