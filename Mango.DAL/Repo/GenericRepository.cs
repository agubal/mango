using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mango.DAL.Core;

namespace Mango.DAL.Repo
{
    public abstract class GenericRepository : IRepository
    {
        protected readonly ContextWrapper Context;
        private bool _disposed;

        protected GenericRepository(IUnitOfWork unitOfWork, IContext context)
        {
            unitOfWork.Register(this);
            Context = context as ContextWrapper;

            if (Context == null)
            {
                throw new NullReferenceException("Context is null");
            }
        }

        public virtual void Save()
        {
            Context.SaveChanges();
        }

        public virtual async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
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
                Context?.Dispose();
            }

            _disposed = true;
        }

    }

    public class GenericRepository<T> : GenericRepository, IRepository<T> where T : class
    {
        protected readonly DbSet<T> DbSet;

        public GenericRepository(IUnitOfWork unitOfWork, IContext context)
            : base(unitOfWork, context)
        {
            DbSet = Context.Set<T>();
        }

        public virtual IQueryable<T> All(string[] includes = null)
        {
            if (includes == null || !includes.Any()) return DbSet.AsQueryable();

            var query = DbSet.Include(includes.First());
            query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));

            var result = query.AsQueryable();
            return result;
        }

        public virtual T Find(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            if (includes == null || !includes.Any()) return DbSet.FirstOrDefault(predicate);

            var query = DbSet.Include(includes.First());
            query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));

            var result = query.FirstOrDefault(predicate);
            return result;
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            if (includes == null || !includes.Any()) return DbSet.FirstOrDefault(predicate);

            var query = DbSet.Include(includes.First());
            query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));

            var result = await query.FirstOrDefaultAsync(predicate);
            return result;
        }

        public virtual T FindByKey(object key)
        {
            return DbSet.Find(key);
        }

        public virtual async Task<T> FindByKeyAsync(object key)
        {
            return await DbSet.FindAsync(key);
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            if (includes == null || !includes.Any()) return DbSet.Where(predicate).AsQueryable();

            var query = DbSet.Include(includes.First());
            query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));

            var result = query.Where(predicate).AsQueryable();
            return result;
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            var skipCount = index * size;
            IQueryable<T> resetSet;

            if (includes != null && includes.Any())
            {
                var query = DbSet.Include(includes.First());
                query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));
                resetSet = predicate != null ? query.Where(predicate).AsQueryable() : query.AsQueryable();
            }
            else
            {
                resetSet = predicate != null ? DbSet.Where(predicate).AsQueryable() : DbSet.AsQueryable();
            }

            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();

            var result = resetSet.AsQueryable();
            return result;
        }

        public bool Contains(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        public virtual T Create(T entity)
        {
            var result = DbSet.Add(entity);
            return result;
        }

        public virtual void AddOrUpdate(T entity)
        {
            DbSet.AddOrUpdate(entity);
        }

        public virtual void Delete(T entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
            {
                DbSet.Remove(obj);
            }
        }

        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
