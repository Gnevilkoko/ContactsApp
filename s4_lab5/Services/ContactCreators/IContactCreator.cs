using s4_lab5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s4_lab5.Services.ContactCreators
{
    public interface IContactCreator
    {
        Task CreateContact(Contact contact);
    }
}
