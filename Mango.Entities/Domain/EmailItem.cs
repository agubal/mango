namespace Mango.Entities.Domain
{
    public class EmailItem
    {
        public int Id { get; set; }
        public string SenderName { get; set; }
        public string SenderContactDetails { get; set; }
        public string Message { get; set; }
    }
}
