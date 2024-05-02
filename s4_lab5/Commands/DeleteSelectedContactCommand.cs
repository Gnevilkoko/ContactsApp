using s4_lab5.Models;
using s4_lab5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s4_lab5.Commands
{
    internal class DeleteSelectedContactCommand : CommandBase
    {
        private ContactListViewModel _contactListViewModel;

        public DeleteSelectedContactCommand(ContactListViewModel contactListViewModel)
        {
            _contactListViewModel = contactListViewModel;
        }

        public override void Execute(object parameter)
        {
            Contact selectedContact = _contactListViewModel.SelectedContact;
            ContactBook contactBook = _contactListViewModel.ContactBook;

            contactBook.DeleteContact(selectedContact);
            _contactListViewModel.LoadContactsCommand.Execute(null);

        }
    }
}
