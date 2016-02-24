using Mango.Common.General;

namespace Mango.Entities.Models
{
    public class ClientModel : IIdentifier<int>
    {
        public string Name { get; set; }
        public string Photo { get; set; }
        public int Id { get; set; }
        public bool IsMain { get; set; }
        public int Order { get; set; }
    }
}
