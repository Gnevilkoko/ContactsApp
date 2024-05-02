using s4_lab5.Models;
using s4_lab5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s4_lab5.Commands
{
    public class LoadContactsCommand : AsyncCommandBase
    {
        private readonly ContactListViewModel _viewModel;
        private readonly ContactBook _contactBook;

        public LoadContactsCommand(ContactListViewModel viewModel)
        {
            _viewModel = viewModel;
            _contactBook = viewModel.ContactBook;
        }

        public override async Task ExecuteAsync(object parameter)
        {

            try
            {
                _viewModel.UpdateContacts(await _contactBook.GetAllContacts());
            }
            catch (Exception)
            {
            }
        }
    }
}
