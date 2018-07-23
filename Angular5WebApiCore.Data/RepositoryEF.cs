namespace Angular5WebApiCore.Data
{
    using Angular5WebApiCore.Models.Domain;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class RepositoryEF<T> : IRepository<T> where T : AuditableEntity
    {
        private readonly DbSet<T> dbSet;
        private readonly DbContext dbContext;

        public RepositoryEF(DbContext _dbContext)
        {
            dbContext = _dbContext;
            dbSet = dbContext.Set<T>();
        }

        public virtual void Add(params T[] entities) => dbSet.AddRange(entities);
        public virtual void Update(params T[] entities) => entities.ForEach(d => update(d));
        public virtual void AddOrUpdate(params T[] entities) => save(entities);
        public virtual void AddOrUpdate(List<T> entities) => save(entities.ToArray());

        public virtual void Remove(params T[] entities) => delete(entities);
        public virtual void Remove(List<T> entities) => delete(entities.ToArray());

        public virtual void RemoveByKey(params string[] Keys) => delete(Keys.Select(d => GetByKey(d)).ToArray());
        public virtual void RemoveByKey(List<string> Keys) => delete(Keys.Select(d => GetByKey(d)).ToArray());

        public virtual int Delete(params T[] entities)
        {
            delete(entities);
            var affectedRows = CommitChanges();
            return affectedRows;
        }
        public virtual int Delete(List<T> entities) => Delete(entities.ToArray());

        public virtual int DeleteByKey(params string[] Keys)
        {
            RemoveByKey(Keys);
            var affectedRows = CommitChanges();
            return affectedRows;
        }
        public virtual int DeleteByKey(List<string> Keys) => DeleteByKey(Keys.ToArray());

        public virtual async Task<int> DeleteAsync(params T[] entities)
        {
            delete(entities);
            var affectedRows = await CommitChangesAsync();
            return affectedRows;
        }
        public virtual async Task<int> DeleteAsync(List<T> entities) => await DeleteAsync(entities.ToArray());

        public virtual async Task<int> DeleteByKeyAsync(params string[] Keys)
        {
            RemoveByKey(Keys);
            var affectedRows = await CommitChangesAsync();
            return affectedRows;
        }
        public virtual async Task<int> DeleteByKeyAsync(List<string> Keys) => await DeleteByKeyAsync(Keys.ToArray());

        public virtual int Save(params T[] entities)
        {
            save(entities);
            int output = CommitChanges();
            return output;
        }
        public virtual int Save(List<T> entities) => Save(entities.ToArray());
        public virtual async Task<int> SaveAsync(params T[] entities)
        {
            save(entities);
            int output = await CommitChangesAsync();
            return output;
        }
        public virtual async Task<int> SaveAsync(List<T> entities) => await SaveAsync(entities.ToArray());

        public virtual int CommitChanges() => dbContext.SaveChanges();
        public virtual async Task<int> CommitChangesAsync() => await dbContext.SaveChangesAsync();

        public virtual void Reload(params T[] entities) => entities.ForEach(d => dbContext.Entry(d).Reload());
        public virtual void Reload(List<T> entities) => Reload(entities.ToArray());
        public virtual async Task ReloadAsync(params T[] entities)
        {
            foreach (T item in entities)
            {
                await dbContext.Entry(item).ReloadAsync();
            }
        }
        public virtual async Task ReloadAsync(List<T> entities) => await ReloadAsync(entities.ToArray());

        public virtual bool HasData() => dbSet.Any();
        public virtual bool HasData(Expression<Func<T, bool>> filter) => dbSet.Any(filter);
        public virtual async Task<bool> HasDataAsync() => await dbSet.AnyAsync();
        public virtual async Task<bool> HasDataAsync(Expression<Func<T, bool>> filter) => await dbSet.AnyAsync(filter);

        public virtual int Count() => dbSet.Count();
        public virtual int Count(Expression<Func<T, bool>> filter) => dbSet.Count(filter);

        public virtual async Task<int> CountAsync() => await dbSet.CountAsync();
        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> filter) => await dbSet.CountAsync(filter);

        public virtual long CountLong() => dbSet.LongCount();
        public virtual long CountLong(Expression<Func<T, bool>> filter) => dbSet.LongCount(filter);

        public virtual async Task<long> CountLongAsync() => await dbSet.LongCountAsync();
        public virtual async Task<long> CountLongAsync(Expression<Func<T, bool>> filter) => await dbSet.LongCountAsync(filter);

        public virtual T Max() => dbSet.Max();
        public virtual async Task<T> MaxAsync() => await dbSet.MaxAsync();

        public virtual T GetByKey(string key) => dbSet.Find(key);
        public async virtual Task<T> GetByKeyAsync(string key) => await dbContext.Set<T>().FindAsync(key);

        public virtual T Get(Expression<Func<T, bool>> filter, params string[] includeProperties) => GetAll(filter: filter, includeProperties: includeProperties).FirstOrDefault();
        public async virtual Task<T> GetAsync(Expression<Func<T, bool>> filter, params string[] includeProperties) => await GetAll(filter: filter, includeProperties: includeProperties).FirstOrDefaultAsync();
        public virtual T GetReadOnly(Expression<Func<T, bool>> filter, params string[] includeProperties) => GetAllReadOnly(filter: filter, includeProperties: includeProperties).FirstOrDefault();
        public async virtual Task<T> GetReadOnlyAsync(Expression<Func<T, bool>> filter, params string[] includeProperties) => await GetAllReadOnly(filter: filter, includeProperties: includeProperties).FirstOrDefaultAsync();

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int? skip = null, int? take = null, params string[] includeProperties)
        {
            var query = dbSet.AsQueryable();

            if (filter != null) query = query.Where(filter);

            if (includeProperties != null && includeProperties.Length > 0)
            {
                foreach (var pathType in includeProperties)
                {
                    query = query.Include(pathType);
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query);
                if (skip != null && skip.HasValue) query = query.Skip(skip.Value);
                if (take != null && take.HasValue) query = query.Take(take.Value);
            }
            return query;
        }
        public virtual IQueryable<T> GetAllReadOnly(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int? skip = null, int? take = null, params string[] includeProperties)
        {
            var query = GetAll(filter, orderBy, skip, take, includeProperties).AsNoTracking();
            return query;
        }

        private void save(params T[] entities)
        {
            foreach (var item in entities)
            {
                if (item.ID > 0)
                {
                    update(item);
                }
                else
                    dbSet.Add(item);
            }
        }
        private void delete(params T[] entities)
        {
            dbSet.RemoveRange(entities);
        }
        private void update(T entity)
        {
            /*
             * We query local context first to see if it's there, we need to update.
             * If it's not found locally, we can attach it by setting state to modified.
             * This would result in a SQL update statement for all fields when SaveChanges is called it will update all scalar properties and set them to modified.
             * However, navigation properties would not get the same respect. As of the time writing this code EF does not support of full object graph merging, 
             * and leaves that for you to manage on your own.
            */
            var attachedEntity = dbSet.Local.FirstOrDefault(d => d.ID == entity.ID);

            if (attachedEntity == null)
                dbContext.Entry(entity).State = EntityState.Modified;
            else
                dbContext.Entry(attachedEntity).CurrentValues.SetValues(entity);
        }
    }

    public static class RepositoryHelper
    {
        public enum OrderBy : int
        {
            ASC = 0, DESC = 1
        }

        public static IQueryable<T> SortBy<T>(this IQueryable<T> source, string sortBy, OrderBy sortDirection) where T : class
        {
            var param = Expression.Parameter(typeof(T), "item");

            var sortExpression = Expression.Lambda<Func<T, object>>(Expression.Convert(Expression.Property(param, sortBy), typeof(object)), param);

            switch (sortDirection)
            {
                case OrderBy.ASC:
                    return source.OrderBy(sortExpression);
                case OrderBy.DESC:
                    return source.OrderByDescending(sortExpression);
            }
            return source;
        }
    }
}