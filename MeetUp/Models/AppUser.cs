using Microsoft.AspNetCore.Identity;

namespace MeetUp.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
