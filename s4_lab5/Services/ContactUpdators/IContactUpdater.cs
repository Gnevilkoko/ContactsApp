using s4_lab5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s4_lab5.Services.ContactUpdators
{
    public interface IContactUpdater
    {
        Task UpdateContact(Contact contact);
    }
}
