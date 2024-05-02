using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s4_lab5.DbContexts
{
    public class ContactDbContextFactory
    {
        private readonly string _connectionString;

        public ContactDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ContactDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            return new ContactDbContext(options);
        }
    }
}
