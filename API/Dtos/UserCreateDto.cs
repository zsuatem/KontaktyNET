using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class UserCreateDto
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(100, ErrorMessage = " Username can't be longer than 100 characters")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;
    }
}
