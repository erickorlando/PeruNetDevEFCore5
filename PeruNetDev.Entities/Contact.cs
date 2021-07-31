namespace PeruNetDev.Entities
{
    public class Contact : EntityBase
    {
        public Person Person { get; set; }
        public int PersonId { get; set; }
        
        public string Direction { get; set; }
        public bool Principal { get; set; }
    }
}