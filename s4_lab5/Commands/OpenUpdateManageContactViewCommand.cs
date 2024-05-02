using s4_lab5.Models;
using s4_lab5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace s4_lab5.Commands
{
    internal class OpenUpdateManageContactViewCommand : CommandBase
    {
        private ContactListViewModel _contactListViewModel;

        public OpenUpdateManageContactViewCommand(ContactListViewModel contactListViewModel)
        {
            _contactListViewModel = contactListViewModel;
        }

        public override void Execute(object parameter)
        {
            ManageContactViewModel viewModel;
            viewModel = new ManageContactViewModel(_contactListViewModel, true);

            MainWindow window = new MainWindow()
            {
                DataContext = new MainViewModel(viewModel)
            };

            window.ShowDialog();
        }
    }
}
