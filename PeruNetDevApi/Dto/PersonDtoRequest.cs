using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PeruNetDevApi.Dto
{
    public class PersonDtoRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public short Age { get; set; }

        public ICollection<ContactsDto> Contacts { get; set; }
    }

    public class ContactsDto
    {
        [Required]
        public string Direction { get; set; }
        
        public bool Principal { get; set; }
    }
}