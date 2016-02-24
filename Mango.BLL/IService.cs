using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mango.Common.Results;

namespace Mango.BLL
{
    public interface IService : IDisposable
    {
    }

    public interface IService<T> : IService where T : class
    {
        IQueryable<T> GetAll(string[] includes = null);

        T Find(Expression<Func<T, bool>> predicate, string[] includes = null);

        Task<T> FindAsync(Expression<Func<T, bool>> predicate, string[] includes = null);

        T GetByKey(object id);

        IQueryable<T> Filter(Expression<Func<T, bool>> predicate, string[] includes = null);

        IQueryable<T> Filter(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 50, string[] includes = null);

        bool Contains(Expression<Func<T, bool>> predicate);

        ServiceResult<T> Create(T entity);

        Task<ServiceResult<T>> CreateAsync(T entity);

        ServiceResult Update(T entity);

        Task<ServiceResult> UpdateAsync(T entity);

        ServiceResult Delete(T entity);

        Task<ServiceResult> DeleteAsync(T entity);

        ServiceResult Delete(object id);

        Task<ServiceResult> DeleteAsync(object id);

        ServiceResult Delete(Expression<Func<T, bool>> predicate);

        Task<ServiceResult> DeleteAsync(Expression<Func<T, bool>> predicate);
    }
}
