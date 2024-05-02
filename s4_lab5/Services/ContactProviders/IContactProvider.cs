using s4_lab5.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s4_lab5.Services.ContactProviders
{
    public interface IContactProvider
    {
        Task<IEnumerable<Contact>> GetAllContacts();
        Task<IEnumerable<Contact>> GetContactsByName(string name);
        Task<IEnumerable<Contact>> GetContactsBySurname(string surname);

        Task<IEnumerable<Phone>> GetAllPhones();
        Task<IEnumerable<Contact>> GetContactByPhoneNumber(string number);
    }
}
