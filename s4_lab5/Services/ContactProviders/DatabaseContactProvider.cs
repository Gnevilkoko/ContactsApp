using Microsoft.EntityFrameworkCore;
using s4_lab5.DbContexts;
using s4_lab5.Models;
using System.Xml.Linq;

namespace s4_lab5.Services.ContactProviders
{
    public class DatabaseContactProvider : IContactProvider
    {
        private readonly ContactDbContextFactory _dbContextFactory;

        public DatabaseContactProvider(ContactDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            using(ContactDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<Contact> contactDTOs = await context.Contacts.Include(c => c.Phone).ToListAsync();

                return contactDTOs;
            }
        }

        public async Task<IEnumerable<Contact>> GetContactsByName(string name)
        {
            using (ContactDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<Contact> contactDTOs = await context.Contacts.Include(c => c.Phone)
                    .Where(cont => cont.Name.StartsWith(name)).ToListAsync();

                return contactDTOs;
            }
        }

        public async Task<IEnumerable<Contact>> GetContactsBySurname(string surname)
        {
            using (ContactDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<Contact> contactDTOs = await context.Contacts.Include(c => c.Phone)
                    .Where(cont => cont.Surname.StartsWith(surname)).ToListAsync();

                return contactDTOs;
            }
        }

        public async Task<IEnumerable<Phone>> GetAllPhones()
        {
            using (ContactDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<Phone> phoneDTOs = await context.Phones.ToListAsync();

                return phoneDTOs;
            }
        }

        public async Task<IEnumerable<Contact>> GetContactByPhoneNumber(string number)
        {
            using (ContactDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<Contact> contactDTOs = await context.Contacts.Include(c => c.Phone)
                    .Where(cont => cont.Phone.Number.StartsWith(number)).ToListAsync();

                return contactDTOs;
            }
        }
    }
}
