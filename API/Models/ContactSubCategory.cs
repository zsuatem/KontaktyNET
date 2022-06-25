using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ContactSubCategory
    {
        public uint Id { get; set; }

        [Required(ErrorMessage = "SubCategoryName is required")]
        [StringLength(100, ErrorMessage = "SubCategoryName can't be longer than 100 characters")]
        public string SubCategoryName { get; set; } = null!;

        public ICollection<Contact> Contacts { get; set; } = null!;
    }
}
