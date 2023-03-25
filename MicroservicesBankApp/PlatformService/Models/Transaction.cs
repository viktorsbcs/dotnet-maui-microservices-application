using System.ComponentModel.DataAnnotations;

namespace PlatformService.Models
{
    public class Transaction
    {
        [Key]
        public string TransactionId { get; set; }

        [Required]
        public Account FromAccount { get; set; }

        [Required]
        public Account ToAccount { get; set; }

        [Required]
        public decimal Amount { get; set; }   
    }
}
