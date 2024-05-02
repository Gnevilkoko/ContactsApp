using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s4_lab5.DbContexts
{
    public class ContactDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ContactDbContext>
    {
        public ContactDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=contacts.db").Options;

            return new ContactDbContext(options);
        }
    }
}
