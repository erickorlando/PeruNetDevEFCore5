using System.ComponentModel.DataAnnotations;

namespace PeruNetDev.Entities
{
    public class Person : EntityBase
    {
        [StringLength(200)]
        [Required]
        public string Name { get; set; }
        
        [StringLength(200)]
        [Required]
        public string LastName { get; set; }
        
        [StringLength(500)]
        public string Email { get; set; }
        
        public short Age { get; set; }
    }
}
