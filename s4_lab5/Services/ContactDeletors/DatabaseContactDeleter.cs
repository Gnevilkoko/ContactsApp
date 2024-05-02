using s4_lab5.DbContexts;
using s4_lab5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s4_lab5.Services.ContactDeletors
{
    public class DatabaseContactDeleter : IContactDeleter
    {
        private readonly ContactDbContextFactory _dbContextFactory;

        public DatabaseContactDeleter(ContactDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task DeleteContact(Contact contact)
        {
            using (ContactDbContext context = _dbContextFactory.CreateDbContext())
            {
                context.Contacts.Remove(contact);

                await context.SaveChangesAsync();
            }
        }
    }
}
