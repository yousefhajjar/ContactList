using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class ContactsContext : IdentityDbContext
    {
        public ContactsContext(DbContextOptions options) :base(options) { }

        public DbSet<Contact> Contacts { get; set; }
    }
}
