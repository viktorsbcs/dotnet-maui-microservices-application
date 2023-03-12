using System.ComponentModel.DataAnnotations;

namespace PlatformService.Models
{
    public class Transaction
    {
        [Key]
        public string TransactionId { get; set; }

        public Account FromAccount { get; set; }

        public Account ToAccount { get; set; }

        public decimal Amount { get; set; }   
    }
}
