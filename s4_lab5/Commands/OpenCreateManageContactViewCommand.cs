using s4_lab5.Models;
using s4_lab5.ViewModels;
using s4_lab5.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s4_lab5.Commands
{
    public class OpenCreateManageContactViewCommand : CommandBase
    {
        private ContactListViewModel _contactListViewModel;

        public OpenCreateManageContactViewCommand(ContactListViewModel contactListViewModel)
        {
            _contactListViewModel = contactListViewModel;
        }


        public override void Execute(object parameter)
        {
            ManageContactViewModel viewModel;

            viewModel = new ManageContactViewModel(_contactListViewModel, false);

            MainWindow window = new MainWindow()
            {
                DataContext = new MainViewModel(viewModel)
            };

            window.ShowDialog();
        }
    }
}
