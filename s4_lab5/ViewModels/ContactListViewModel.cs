using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using Microsoft.VisualBasic.ApplicationServices;
using s4_lab5.Commands;
using s4_lab5.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace s4_lab5.ViewModels
{
    public class ContactListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<Contact> _contacts;
        public IEnumerable<Contact> Contacts => _contacts;


        public ContactBook ContactBook;

        private Contact _selectedContact;
        public Contact SelectedContact
        {
            get
            {
                return _selectedContact;
            }
            set
            {
                _selectedContact = value;
                OnPropertyChanged(nameof(_selectedContact));
            }
        }

        private string _selectedSeacrhByItem;
        public string SelectedSeacrhByItem
        {
            get
            {
                return _selectedSeacrhByItem;
            }
            set
            {
                _selectedSeacrhByItem = value;
                OnPropertyChanged(nameof(SelectedSeacrhByItem));
            }
        }

        private string _searchValue;
        public string SearchValue
        {
            get
            {
                return _searchValue;
            }
            set
            {
                _searchValue = value;
                OnPropertyChanged(nameof(SearchValue));
            }
        }

        private string _selectedSortByItem;
        public string SelectedSortByItem
        {
            get
            {
                return _selectedSortByItem;
            }
            set
            {
                _selectedSortByItem = value;
                OnPropertyChanged(nameof(SelectedSortByItem));
            }
        }

        private string _selectedTransformByItem;
        public string SelectedTransformByItem
        {
            get
            {
                return _selectedTransformByItem;
            }
            set
            {
                _selectedTransformByItem = value;
                OnPropertyChanged(nameof(SelectedTransformByItem));
            }
        }

        private string _selectedCheckByItem;
        public string SelectedCheckByItem
        {
            get
            {
                return _selectedCheckByItem;
            }
            set
            {
                _selectedCheckByItem = value;
                OnPropertyChanged(nameof(SelectedCheckByItem));
            }
        }

        private string _selectedAgregateByItem;
        public string SelectedAgregateByItem
        {
            get
            {
                return _selectedAgregateByItem;
            }
            set
            {
                _selectedAgregateByItem = value;
                OnPropertyChanged(nameof(SelectedAgregateByItem));
            }
        }

        private SnackbarMessageQueue _contactSnackbarMessageQueue;
        public SnackbarMessageQueue ContactSnackbarMessageQueue
        {
            get
            {
                return _contactSnackbarMessageQueue;
            }
            set
            {
                _contactSnackbarMessageQueue = value;
                OnPropertyChanged(nameof(ContactSnackbarMessageQueue));
            }
        }


        public ICommand LoadContactsCommand { get; }
        public ICommand OpenCreateManageContactViewCommand { get; }
        public ICommand OpenUpdateManageContactViewCommand { get; }
        public ICommand DeleteSelectedContactCommand { get; }

        public RelayCommand SearchContactsCommand { get; }
        public RelayCommand SortContactsCommand { get; }
        public RelayCommand TransformContactsCommand { get; }
        public RelayCommand CheckContactsCommand { get; }
        public RelayCommand AgregateContactsCommand { get; }


        public ContactListViewModel(ContactBook contactBook)
        {
            ContactBook = contactBook;
            _contacts = new ObservableCollection<Contact>();

            ContactSnackbarMessageQueue = new SnackbarMessageQueue(TimeSpan.FromMilliseconds(400));

            LoadContactsCommand = new LoadContactsCommand(this);
            OpenCreateManageContactViewCommand = new OpenCreateManageContactViewCommand(this);
            OpenUpdateManageContactViewCommand = new OpenUpdateManageContactViewCommand(this);
            DeleteSelectedContactCommand = new DeleteSelectedContactCommand(this);

            SearchContactsCommand = new RelayCommand(this.SeacrhContacts);
            SortContactsCommand = new RelayCommand(this.SortContacts);
            TransformContactsCommand = new RelayCommand(this.TransformContacts);
            CheckContactsCommand = new RelayCommand(this.CheckContacts);
            AgregateContactsCommand = new RelayCommand(this.AgregateContacts);

            LoadContactsCommand.Execute(null);
        }

        public void UpdateContacts(IEnumerable<Contact> contacts)
        {
            _contacts.Clear();

            foreach (Contact contact in contacts)
            {
                _contacts.Add(contact);
            }
        }

        public async void SeacrhContacts()
        {
            if (SelectedSeacrhByItem == null) return;

            if (SearchValue == null || SearchValue.Trim().Length == 0)
            {
                UpdateContacts(await ContactBook.GetAllContacts());
                return;
            }

            switch (SelectedSeacrhByItem)
            {
                case "Name":
                    UpdateContacts(await ContactBook.GetContactsByName(SearchValue));
                    break;

                case "Surname":
                    UpdateContacts(await ContactBook.GetContactsBySurname(SearchValue));
                    break;

                case "Phone":
                    UpdateContacts(await ContactBook.GetContactByPhoneNumber(SearchValue));
                    break;
            }
        }

        public void SortContacts()
        {
            if(SelectedSortByItem == null) return;

            List<Contact> sorted = Contacts.ToList();
            switch (SelectedSortByItem)
            {
                case "Ascending":
                    sorted = Contacts.OrderBy(c => c.Name).ToList();
                    break;
                case "Descending":
                    sorted = Contacts.OrderByDescending(c => c.Name).ToList();
                    break;
            }

            UpdateContacts(sorted);
        }

        public void TransformContacts()
        {
            if(SelectedTransformByItem == null) return;

            List<Contact> transformed = Contacts.ToList();
            switch(SelectedTransformByItem)
            {
                case "To Upper":
                    transformed = Contacts
                        .Select(cont => new Contact(
                            cont.Id, cont.Name.ToUpper(),
                            cont.Surname.ToUpper(),
                            cont.Phone)
                        ).ToList();
                    break;

                case "BiGsMaLl":
                    transformed = Contacts
                        .Select(cont => new Contact(
                            cont.Id,
                            string.Concat(cont.Name.Select((ch, index) => index % 2 == 0 ? ch.ToString().ToUpper() : ch.ToString().ToLower())),
                            string.Concat(cont.Surname.Select((ch, index) => index % 2 == 0 ? ch.ToString().ToUpper() : ch.ToString().ToLower())),
                            cont.Phone
                            )
                        ).ToList();
                    break;

                case "Delete Vowels":
                    string vowels = "aeiouAEIOU";

                    transformed = Contacts
                        .Select(cont => new Contact(
                            cont.Id,
                            string.Concat(cont.Name.Where(ch => !vowels.Contains(ch))),
                            string.Concat(cont.Surname.Where(ch => !vowels.Contains(ch))),
                            cont.Phone
                            )
                        ).ToList();
                    break;
            }

            UpdateContacts(transformed);
        }

        public void CheckContacts()
        {
            if(SelectedCheckByItem == null) return;

            bool result = false;
            switch(SelectedCheckByItem)
            {
                case "Any Contact Name Length > 5":
                    result = Contacts.Where(cont => cont.Name.Length > 5).Count() > 0;
                    break;

                case "Any Contact Name Length < 5":
                    result = Contacts.Where(cont => cont.Name.Length < 5).Count() > 0;
                    break;

                case "Any Contact Name Length == 5":
                    result = Contacts.Where(cont => cont.Name.Length == 5).Count() > 0;
                    break;
            }

            SendSnackbarMessage(result.ToString());
        }

        public void AgregateContacts()
        {
            if(SelectedAgregateByItem == null) return;

            double averageValue = 0.0D;
            switch(SelectedAgregateByItem)
            {
                case "Average Name Length":
                    averageValue = Contacts.Select(cont => cont.Name.Length).Average();
                    break;

                case "Average Surname Length":
                    averageValue = Contacts.Select(cont => cont.Surname.Length).Average();
                    break;

                case "Average Phone Length":
                    averageValue = Contacts.Select(cont => cont.Phone.Number.Length).Average();
                    break;
            }

            SendSnackbarMessage(averageValue.ToString());
        }

        private void SendSnackbarMessage(string message)
        {
            ContactSnackbarMessageQueue.Enqueue(message);
        }
    }
}
