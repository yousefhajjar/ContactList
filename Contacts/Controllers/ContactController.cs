using BusinessLogic.Services;
using BusinessLogic.ViewModels;
using Domain.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace Contacts.Controllers
{
    public class ContactController : Controller
    {
        private ContactsService _cs;
        private IContactsRepository _cr;
        private IWebHostEnvironment host;
        public ContactController(IContactsRepository cr, IWebHostEnvironment _host, ContactsService cs) 
        {
            _cr = cr;
            host = _host;
            _cs = cs;
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddContactsViewModel model = new AddContactsViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AddContactsViewModel data, IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    Console.WriteLine("file is not null");
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string absolutePath = host.WebRootPath;

                    using (FileStream fsOut = new(absolutePath + "\\Images\\" + fileName, FileMode.CreateNew))
                    {
                        file.CopyTo(fsOut);
                    }

                    data.Picture = "/Images/" + fileName;
                }

                _cs.AddContact(data);

                ViewBag.Message = "Item successfully created!";
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Item wasn't inserted. Please verify inputs!";

            }
            return View(data);
        }

        [HttpGet]
        public IActionResult List() 
        {
            var list = _cr.GetContacts();
            return View(list);
        }
    }
}
