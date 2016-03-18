using System.Data.Entity;
using Mango.Entities.Domain;

namespace Mango.DAL.Core
{
    public interface IContext
    {
        IDbSet<Client> Clients { get; set; }
        IDbSet<Technology> Technologies { get; set; }
        IDbSet<Service> Services { get; set; }
        IDbSet<EmailItem> Emails { get; set; }

    }
}
