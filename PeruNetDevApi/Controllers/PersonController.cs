using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeruNetDev.DataLayer;
using PeruNetDev.Entities;
using PeruNetDevApi.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeruNetDevApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PeruNetDevDbContext _context;

        public PersonController(PeruNetDevDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Persons
                .AsNoTracking()
                .ToListAsync());
        }

        [HttpGet]
        [Route("{personId:int}")]
        public async Task<IActionResult> Get(int personId)
        {
            var collection = await _context.Addresses.FromSqlRaw("EXEC uspSelectContacts {0}", personId)
                .ToListAsync();

            return Ok(collection);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonDtoRequest request)
        {

            var person = new Person
            {
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                Age = request.Age
            };

            var listContacts = new List<Contact>();

            foreach (var contactsDto in request.Contacts)
            {
                var contact = new Contact
                {
                    Person = person,
                    Direction = contactsDto.Direction,
                    Principal = contactsDto.Principal
                };
                listContacts.Add(contact);
            }
            
            await _context.Persons.AddAsync(person);
            await _context.Contacts.AddRangeAsync(listContacts);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                PersonId = person.Id
            });
        }

    }
}