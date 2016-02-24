using Mango.Common.General;

namespace Mango.Entities.Domain
{
    public class Entity<T> : IIdentifier<T>
    {
        public virtual T Id { get; set; }
        public bool IsMain { get; set; }
        public int Order { get; set; }
    }
}
