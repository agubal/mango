using System.Configuration;
using System.Data.Entity;
using static System.Configuration.ConfigurationManager;

namespace Mango.DAL.Core
{
    public class AppDbContext : ContextWrapper
    {
        static AppDbContext()
        {
            Database.SetInitializer<AppDbContext>(null);
        }

        public AppDbContext() : base(ConnectionStrings["AppDbContext"].ConnectionString) { }

        public AppDbContext(string connectionString) : base(connectionString) { }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}
