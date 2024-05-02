using Microsoft.EntityFrameworkCore;
using s4_lab5.DbContexts;
using s4_lab5.Models;
using s4_lab5.Services.ContactCreators;
using s4_lab5.Services.ContactDeletors;
using s4_lab5.Services.ContactProviders;
using s4_lab5.Services.ContactUpdators;
using s4_lab5.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace s4_lab5
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Data Source=contacts.db";
        private readonly ContactDbContextFactory _contactDbContextFactory;
        private readonly ContactBook _contactBook;

        public App()
        {
            _contactDbContextFactory = new ContactDbContextFactory(CONNECTION_STRING);
            DatabaseContactProvider contactProvider = new DatabaseContactProvider(_contactDbContextFactory);
            DatabaseContactCreator contactCreator = new DatabaseContactCreator(_contactDbContextFactory);
            DatabaseContactUpdater contactUpdater = new DatabaseContactUpdater(_contactDbContextFactory);
            DatabaseContactDeleter contactDeleter = new DatabaseContactDeleter(_contactDbContextFactory);

            _contactBook = new ContactBook(contactProvider, contactCreator, contactUpdater, contactDeleter);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using (ContactDbContext dbContext = _contactDbContextFactory.CreateDbContext()) 
            { 
                dbContext.Database.Migrate();
            }


            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(new ContactListViewModel(_contactBook))
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
