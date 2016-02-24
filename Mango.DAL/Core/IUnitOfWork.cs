using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.DAL.Core
{
    public interface IUnitOfWork : IDisposable
    {
        void Register(IRepository repository);
        void Save();
        Task SaveAsync();
    }
}
