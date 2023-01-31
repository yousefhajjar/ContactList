using Domain.Interface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ContactsInFileRepository : IContactsRepository
    {
        public void AddContact(Contact c)
        {
            
        }

        public IQueryable<Contact> GetContacts()
        {
            return null;
        }
    }
}
