using DataAccess.Context;
using Domain.Interface;
using Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ContactsInFileRepository : IContactsRepository
    {
        private string _fPath;

        public ContactsInFileRepository(string fPath)
        {
            _fPath = fPath;
        }

        public void AddContact(Contact c)
        {
            var contacts = GetContacts().ToList();
            if(contacts.Count == 0)
            {
                c.Id = 1;
            }
            else
            {
                c.Id = contacts.Max(x => x.Id) + 1;
            }

            contacts.Add(c);
            var json = JsonConvert.SerializeObject(contacts);
            File.WriteAllText(_fPath, json);
        }

        public IQueryable<Contact> GetContacts()
        {
            
            if (!File.Exists(_fPath))
            {
                File.WriteAllText(_fPath, "[]");
                return new List<Contact>().AsQueryable();
            }
            
            var json = File.ReadAllText(_fPath);
            var contacts = JsonConvert.DeserializeObject<List<Contact>>(json);
            return contacts.AsQueryable();
            
        }
    }
}
