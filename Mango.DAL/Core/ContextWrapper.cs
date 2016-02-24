using System.Data.Entity;
using Mango.Entities.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Mango.DAL.Core
{
    public class ContextWrapper : IdentityDbContext<User>, IContext
    {
        public ContextWrapper()
        {
        }

        public ContextWrapper(string connectionString)
            : base(connectionString)
        {
        }

        public IDbSet<Client> Clients { get; set; }
        public IDbSet<Technology> Technologies { get; set; }
        public IDbSet<Service> Services { get; set; }
    }
}
