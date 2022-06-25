using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ContactCategory
    {
        public uint Id { get; set; }

        [Required(ErrorMessage = "CategoryName is required")]
        [StringLength(100, ErrorMessage = "CategoryName can't be longer than 100 characters")]
        public string CategoryName { get; set; } = null!;

        public ICollection<Contact> Contacts { get; set; } = null!;
    }
}
