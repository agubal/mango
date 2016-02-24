namespace Mango.Entities.Domain
{
    public class Service : Entity<int>
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
    }
}
