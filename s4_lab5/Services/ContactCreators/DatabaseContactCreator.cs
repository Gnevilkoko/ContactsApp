using s4_lab5.DbContexts;
using s4_lab5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s4_lab5.Services.ContactCreators
{
    public class DatabaseContactCreator : IContactCreator
    {
        private readonly ContactDbContextFactory _dbContextFactory;

        public DatabaseContactCreator(ContactDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateContact(Contact contact)
        {
            using(ContactDbContext context = _dbContextFactory.CreateDbContext())
            {
                context.Contacts.Add(contact);
                await context.SaveChangesAsync();
            }
        }
    }
}
