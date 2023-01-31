using DataAccess.Context;
using Domain.Interface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        private ContactsContext _context;
        public ContactsRepository(ContactsContext context)
        {
            _context = context;
        }

        public void AddContact(Contact c)
        {
            _context.Contacts.Add(c);
            _context.SaveChanges();
        }

        public IQueryable<Contact> GetContacts()
        {
            return _context.Contacts;
        }
    }
}
