namespace Mango.Entities.Domain
{
    public class Client : Entity<int>
    {
        public string Name { get; set; }
        public string Photo { get; set; }
    }
}
