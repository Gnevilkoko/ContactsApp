using s4_lab5.DbContexts;
using s4_lab5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace s4_lab5.Services.ContactUpdators
{
    public class DatabaseContactUpdater : IContactUpdater
    {
        private readonly ContactDbContextFactory _dbContextFactory;

        public DatabaseContactUpdater(ContactDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task UpdateContact(Contact contact)
        {
            using (ContactDbContext context = _dbContextFactory.CreateDbContext())
            {
                Contact contactToUpdate = context.Contacts.SingleOrDefault(findContact => findContact.Id == contact.Id);


                contactToUpdate.Name = contact.Name;
                contactToUpdate.Surname = contact.Surname;
                contactToUpdate.Phone = contact.Phone;


                await context.SaveChangesAsync();
            }
        }
    }
}
