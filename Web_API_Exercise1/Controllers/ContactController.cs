using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_Exercise1.Models;
using Web_API_Exercise1.Services;

namespace Web_API_Exercise1.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private ContactRepository contactRepository;

        public ContactController()
        {
            this.contactRepository = new ContactRepository();
        }


        [HttpGet("api/[controller]")]
        public List<Contact> GetAll()
        {///api/contact
            return contactRepository.GetAllContacts();
        }//[{"id":1,"name":"Glenn Block"},{"id":2,"name":"Dan Roth"}]

        [HttpGet("api/[controller]/{id}")]
        public Contact Get(int id)
        {///api/contact/2
            return contactRepository.GetContactById(id);

        }//{"id":2,"name":"Dan Roth"}

        [HttpPost("api/[controller]/{name}")]
        public bool Post(string name)
        {
            return contactRepository.SaveContact(name);

        }

        [HttpPut("api/[controller]/{id}/{value}")]
        public bool Put(int id, string value)
        {
            return contactRepository.ChangeContact(id, value);

        }

    }
}
