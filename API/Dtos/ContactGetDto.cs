namespace API.Dtos
{
    public class ContactGetDto
    {
        public uint Id { get; set; }
        public uint UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public uint CategoryId { get; set; }
        public uint? SubCategoryId { get; set; }
        public string? CustomSubCategory { get; set; }
        public uint? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
