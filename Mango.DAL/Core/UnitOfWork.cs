using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.DAL.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<string, IRepository> _repositories;
        private readonly ContextWrapper _context;

        public UnitOfWork(IContext context)
        {
            _repositories = new Dictionary<string, IRepository>();
            _context = context as ContextWrapper;
        }

        public void Register(IRepository repository)
        {
            _repositories.Add(repository.GetType().ToString(), repository);
        }

        public void Save()
        {
            _repositories.ToList().ForEach(x => x.Value.Save());
        }

        public async Task SaveAsync()
        {
            var trans = _context.Database.BeginTransaction();

            try
            {
                foreach (var repo in _repositories)
                {
                    await repo.Value.SaveAsync();
                }

                trans.Commit();
            }
            catch
            {
                trans.Rollback();
                throw;
            }

        }

        public void Dispose()
        {
            foreach (var repo in _repositories)
            {
                repo.Value.Dispose();
            }
        }
    }
}
