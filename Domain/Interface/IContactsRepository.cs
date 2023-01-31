using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IContactsRepository
    {
        IQueryable<Contact> GetContacts();

        void AddContact(Contact c);
    }
}
