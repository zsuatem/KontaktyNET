using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class ContactSubCategoryCreateDto
    {
        [Required(ErrorMessage = "SubCategoryName is required")]
        [StringLength(100, ErrorMessage = "SubCategoryName can't be longer than 100 characters")]
        public string SubCategoryName { get; set; } = null!;
    }
}
