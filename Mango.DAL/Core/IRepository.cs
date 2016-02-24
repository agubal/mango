using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mango.DAL.Core
{
    public interface IRepository : IDisposable
    {
        void Save();
        Task SaveAsync();
    }

    public interface IRepository<T> : IRepository where T : class
    {
        IQueryable<T> All(string[] includes = null);

        T Find(Expression<Func<T, bool>> expression, string[] includes = null);

        Task<T> FindAsync(Expression<Func<T, bool>> expression, string[] includes = null);

        T FindByKey(object key);

        IQueryable<T> Filter(Expression<Func<T, bool>> predicate, string[] includes = null);

        IQueryable<T> Filter(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        bool Contains(Expression<Func<T, bool>> predicate);

        T Create(T entity);

        void Delete(T entity);

        void Delete(Expression<Func<T, bool>> predicate);

        void Update(T entity);
    }
}
