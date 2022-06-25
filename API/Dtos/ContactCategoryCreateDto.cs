using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class ContactCategoryCreateDto
    {
        [Required(ErrorMessage = "CategoryName is required")]
        [StringLength(100, ErrorMessage = "CategoryName can't be longer than 100 characters")]
        public string CategoryName { get; set; } = null!;
    }
}
