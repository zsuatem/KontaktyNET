using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class ContactCreateDto
    {
        [Required(ErrorMessage = "UserId is required")]
        public uint UserId { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(100, ErrorMessage = "FistName can't be longer than 100 characters")]
        public string FirstName { get; set; } = null!;

        [StringLength(100, ErrorMessage = "LastName can't be longer than 100 characters")]
        public string? LastName { get; set; }

        [StringLength(100, ErrorMessage = "Email can't be longer than 100 characters")]
        public string? Email { get; set; }

        public uint CategoryId { get; set; }
        public uint? SubCategoryId { get; set; }

        [StringLength(100, ErrorMessage = "CustomSubCategory can't be longer than 100 characters")]
        public string? CustomSubCategory { get; set; }

        public uint? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
