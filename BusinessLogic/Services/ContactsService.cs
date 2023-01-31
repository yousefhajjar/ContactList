using BusinessLogic.ViewModels;
using DataAccess.Context;
using DataAccess.Repositories;
using Domain.Interface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ContactsService
    {
        private IContactsRepository _cr;

        public ContactsService(IContactsRepository cr)
        {
            _cr = cr;
        }

        public void AddContact(AddContactsViewModel c)
        {
            if (_cr.GetContacts().Any(i => i.PhoneNumber == c.PhoneNumber))
                throw new Exception("Contact with the same Phone Number already exists");
            else
            {
                _cr.AddContact(new Contact()
                {
                    Name = c.Name,
                    Surname = c.Surname,
                    PhoneNumber = c.PhoneNumber,
                    Picture = c.Picture,
                });
            }
        }

        public IQueryable<ContactViewModel> GetContacts()
        {
            var list = from i in _cr.GetContacts()
                       select new ContactViewModel()
                       {
                           Name = i.Name,
                           Surname = i.Surname,
                           PhoneNumber = i.PhoneNumber,
                           Picture = i.Picture,
                           Id = i.Id,
                       };
            return list;
        }
    }
}
