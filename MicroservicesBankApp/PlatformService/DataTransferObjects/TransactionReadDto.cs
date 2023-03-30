using PlatformService.Models;
using System.ComponentModel.DataAnnotations;

namespace PlatformService.DataTransferObjects
{
    public class TransactionReadDto
    {
        public string TransactionId { get; set; }

        public Account FromAccount { get; set; }

        public Account ToAccount { get; set; }

        public decimal Amount { get; set; }
    }
}
