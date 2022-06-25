using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ContactsDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactCategory> ContactCategories { get; set; }
        public DbSet<ContactSubCategory> ContactSubCategories { get; set; }

        public ContactsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .HasOne<User>(c => c.User)
                .WithMany(cc => cc.Contacts)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Contact>()
                .HasOne<ContactCategory>(c => c.Category)
                .WithMany(cc => cc.Contacts)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<Contact>()
                .HasOne<ContactSubCategory>(c => c.SubCategory)
                .WithMany(cc => cc.Contacts)
                .HasForeignKey(c => c.SubCategoryId);
        }
    }
}
