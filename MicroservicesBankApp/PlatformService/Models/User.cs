using System.ComponentModel.DataAnnotations;

namespace PlatformService.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }    

        public string FirstName { get; set; }   

        public string SecondName { get; set; }  

        public List<Account> Accounts { get; set; }
    }
}
