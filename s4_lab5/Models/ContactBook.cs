using s4_lab5.Services.ContactCreators;
using s4_lab5.Services.ContactDeletors;
using s4_lab5.Services.ContactProviders;
using s4_lab5.Services.ContactUpdators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace s4_lab5.Models
{
    public class ContactBook
    {
        private readonly IContactProvider _contactProvider;
        private readonly IContactCreator _contactCreator;
        private readonly IContactUpdater _contactUpdater;
        private readonly IContactDeleter _contactDeleter;

        public ContactBook(IContactProvider contactProvider, IContactCreator contactCreator, IContactUpdater contactUpdater, IContactDeleter contactDeleter)
        {
            _contactProvider = contactProvider;
            _contactCreator = contactCreator;
            _contactUpdater = contactUpdater;
            _contactDeleter = contactDeleter;
        }

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            return await _contactProvider.GetAllContacts();
        }

        public async Task<IEnumerable<Contact>> GetContactsByName(string name)
        {
            return await _contactProvider.GetContactsByName(name);
        }

        public async Task<IEnumerable<Contact>> GetContactsBySurname(string surname)
        {
            return await _contactProvider.GetContactsBySurname(surname);
        }

        public async Task<IEnumerable<Contact>> GetContactByPhoneNumber(string phoneNumber)
        {
            return await _contactProvider.GetContactByPhoneNumber(phoneNumber);
        }

        public async Task<IEnumerable<Phone>> GetAllPhones()
        {
            return await _contactProvider.GetAllPhones();
        }

        public async Task AddContact(Contact contact)
        {
            await _contactCreator.CreateContact(contact);
        }

        public void UpdateContact(Contact contact)
        {
            _contactUpdater.UpdateContact(contact);
        }

        public void DeleteContact(Contact contact)
        {
            _contactDeleter.DeleteContact(contact);
        }
    }
}
