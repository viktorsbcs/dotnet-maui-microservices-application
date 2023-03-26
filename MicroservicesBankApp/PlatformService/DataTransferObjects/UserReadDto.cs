using PlatformService.Models;
using System.ComponentModel.DataAnnotations;

namespace PlatformService.DataTransferObjects
{
    public class UserReadDto
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Email { get; set; }

    }
}
