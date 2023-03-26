using PlatformService.Models;
using System.ComponentModel.DataAnnotations;

namespace PlatformService.DataTransferObjects
{
    public class UserCreateDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Email { get; set; }
   
    }
}
