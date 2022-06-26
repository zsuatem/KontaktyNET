using Microsoft.AspNetCore.Identity;

namespace API.Models
{
    public class LoginModel : IdentityUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
