using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mango.Common.Results;
using Mango.DAL.Core;

namespace Mango.BLL
{
    public abstract class GenericService : IService
    {
        private readonly IUnitOfWork _work;
        private bool _disposed;

        protected GenericService(IUnitOfWork work)
        {
            _work = work;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _work?.Dispose();
            }
            _disposed = true;
        }
    }

    public class GenericService<T> : GenericService, IService<T> where T : class
    {
        private readonly IRepository<T> _entityRepo;
        private readonly IUnitOfWork _work;
        private bool _disposed;

        public GenericService(IRepository<T> entityRepo, IUnitOfWork work)
            : base(work)
        {
            _entityRepo = entityRepo;
            _work = work;
        }

        public virtual IQueryable<T> GetAll(string[] includes = null)
        {
            var result = _entityRepo.All(includes);
            return result;
        }

        public virtual T Find(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            var result = _entityRepo.Find(predicate, includes);
            return result;
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            var result = await _entityRepo.FindAsync(predicate, includes);
            return result;
        }

        public virtual T GetByKey(object id)
        {
            var result = _entityRepo.FindByKey(id);
            return result;
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            var result = _entityRepo.Filter(predicate, includes);
            return result;
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            var result = _entityRepo.Filter(predicate, out total, index, size, includes);
            return result;
        }

        public virtual bool Contains(Expression<Func<T, bool>> predicate)
        {
            var result = _entityRepo.Contains(predicate);
            return result;
        }

        public virtual ServiceResult<T> Create(T entity)
        {
            var result = new ServiceResult<T>();

            try
            {
                var queryResult = _entityRepo.Create(entity);
                _work.Save();
                result.Result = queryResult;
            }
            catch (Exception e)
            {
                result.Errors = new[] { e.Message };
            }

            return result;
        }

        public virtual async Task<ServiceResult<T>> CreateAsync(T entity)
        {
            var result = new ServiceResult<T>();

            try
            {
                var queryResult = _entityRepo.Create(entity);
                await _work.SaveAsync();
                result.Result = queryResult;
            }
            catch (Exception e)
            {
                result.Errors = new[] { e.Message };
            }

            return result;
        }

        public virtual ServiceResult Update(T entity)
        {
            try
            {
                _entityRepo.Update(entity);
                _work.Save();
                return new ServiceResult();
            }
            catch (Exception e)
            {
                return new ServiceResult(e.Message);
            }
        }

        public virtual async Task<ServiceResult> UpdateAsync(T entity)
        {
            try
            {
                _entityRepo.Update(entity);
                await _work.SaveAsync();
                return new ServiceResult();
            }
            catch (Exception e)
            {
                return new ServiceResult(e.Message);
            }
        }

        public virtual ServiceResult Delete(T entity)
        {
            try
            {
                _entityRepo.Delete(entity);
                _work.Save();
                return new ServiceResult();
            }
            catch (Exception e)
            {
                return new ServiceResult(e.Message);
            }
        }

        public virtual async Task<ServiceResult> DeleteAsync(T entity)
        {
            try
            {
                _entityRepo.Delete(entity);
                await _work.SaveAsync();
                return new ServiceResult();
            }
            catch (Exception e)
            {
                return new ServiceResult(e.Message);
            }
        }

        public virtual ServiceResult Delete(object id)
        {
            var queryResult = _entityRepo.FindByKey(id);

            if (queryResult == null)
            {
                return new ServiceResult("Entity Not Found");
            }

            try
            {
                _entityRepo.Delete(queryResult);
                _work.Save();
                return new ServiceResult();
            }
            catch (Exception e)
            {
                return new ServiceResult(e.Message);
            }
        }

        public virtual async Task<ServiceResult> DeleteAsync(object id)
        {
            var result = _entityRepo.FindByKey(id);

            if (result == null)
            {
                return new ServiceResult("Entity Not Found");
            }

            try
            {
                _entityRepo.Delete(result);
                await _work.SaveAsync();
                return new ServiceResult();
            }
            catch (Exception e)
            {
                return new ServiceResult(e.Message);
            }
        }

        public virtual ServiceResult Delete(Expression<Func<T, bool>> predicate)
        {
            try
            {
                _entityRepo.Delete(predicate);
                _work.Save();
                return new ServiceResult();
            }
            catch (Exception e)
            {
                return new ServiceResult(e.Message);
            }
        }

        public virtual async Task<ServiceResult> DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                _entityRepo.Delete(predicate);
                await _work.SaveAsync();
                return new ServiceResult();
            }
            catch (Exception e)
            {
                return new ServiceResult(e.Message);
            }
        }

        protected new void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (_disposed) return;

            if (disposing)
            {
                _entityRepo?.Dispose();
            }

            _disposed = true;
        }

    }
}
