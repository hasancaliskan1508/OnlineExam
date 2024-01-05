using Microsoft.AspNetCore.Identity;

namespace OnlineExam.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
