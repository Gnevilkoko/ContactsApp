using Microsoft.EntityFrameworkCore;
using s4_lab5.Models;

namespace s4_lab5.DbContexts
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Phone> Phones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
            .HasOne(c => c.Phone)
            .WithOne(p => p.Contact)
            .HasForeignKey<Phone>(p => p.ContactId);
        }
    }
}
