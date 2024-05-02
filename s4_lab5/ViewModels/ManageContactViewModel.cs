using GalaSoft.MvvmLight.Command;
using s4_lab5.Commands;
using s4_lab5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace s4_lab5.ViewModels
{
    public class ManageContactViewModel : ViewModelBase
    {
        private ContactBook _contactBook;
        private Contact _editContact;
        private ContactListViewModel _contactListViewModel;


        private int _contactId;
        private int _phoneId;

        public RelayCommand<Window> SubmitCommand { get; private set; }


        public ManageContactViewModel(ContactListViewModel contactListViewModel, bool editing)
        {
            _contactBook = contactListViewModel.ContactBook;
            _contactListViewModel = contactListViewModel;

            if (editing)
            {
                _editContact = contactListViewModel.SelectedContact;

                _contactId = _editContact.Id;
                _phoneId = _editContact.Phone.Id;
                Name = _editContact.Name;
                Surname = _editContact.Surname;
                Phone = _editContact.Phone.Number;
            }

            this.SubmitCommand = new RelayCommand<Window>(this.SubmitButtonClicked);
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(_name));
            }
        }

        private string _surname;
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(_surname));
            }
        }

        private string _phone;
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(_phone));
            }
        }

        private async void SubmitButtonClicked(Window window)
        {
            if (_editContact != null)
            {
                _contactBook.UpdateContact(CollectContact());
            } else
            {
                await _contactBook.AddContact(CollectContact());
            }

            if (window != null)
            {
                window.Close();
            }

            _contactListViewModel.LoadContactsCommand.Execute(null);
        }

        private Contact CollectContact()
        {
            return new Contact(_contactId, Name, Surname, new Models.Phone()
            {
                Id = _phoneId,
                Number = Phone
            });
        }
    }
}
