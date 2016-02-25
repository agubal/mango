namespace Mango.Entities.Domain
{
    public class Message : Entity<int>
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string MessageBody { get; set; }
    }
}
