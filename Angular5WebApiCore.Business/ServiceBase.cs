using Angular5WebApiCore.Data;
using Angular5WebApiCore.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Angular5WebApiCore.Service
{
    public interface IService<T> where T : AuditableEntity
    {

    }

    public class ServiceBase<T> : IService<T> where T : AuditableEntity
    {
        //private IRepository<T> repo;
        //private IUnitofWork unitOfWork;

        //public int AffectedRows { get; private set; }

        //      //public ServiceBase(IRepository<T> repo, IUnitofWork unitOfWork)
        //      //{
        //      //	this.repo = repo;
        //      //	this.unitOfWork = unitOfWork;
        //      //	AffectedRows = 0;
        //      //}
        //      public ServiceBase(IUnitofWork unitOfWork)
        //      {
        //          this.unitOfWork = unitOfWork;
        //          repo = unitOfWork.GetRepo<T>();
        //          AffectedRows = 0;
        //      }

        //      public virtual void Add(params T[] entities) => repo.Add(entities);
        //      public virtual void Update(params T[] entities) => repo.Update(entities);
        //      public virtual void AddOrUpdate(params T[] entities) => repo.AddOrUpdate(entities);
        //      public virtual void AddOrUpdate(List<T> entities) => repo.AddOrUpdate(entities);

        //      public virtual void Remove(params T[] entities) => repo.Remove(entities);
        //      public virtual void Remove(List<T> entities) => repo.Remove(entities);

        //      public virtual void RemoveByKey(params string[] Keys) => repo.RemoveByKey(Keys);
        //      public virtual void RemoveByKey(List<string> Keys) => repo.RemoveByKey(Keys);

        //      public virtual int Delete(params T[] entities)
        //      {
        //          return repo.Delete(entities);
        //      }
        //      public virtual int Delete(List<T> entities) => repo.Delete(entities);

        //      public virtual int DeleteByKey(params string[] Keys)
        //      {
        //          return repo.DeleteByKey(Keys);
        //      }
        //      public virtual int DeleteByKey(List<string> Keys) => repo.DeleteByKey(Keys);

        //      public virtual async Task<int> DeleteAsync(params T[] entities)
        //      {
        //          return await repo.DeleteAsync(entities);
        //      }
        //      public virtual async Task<int> DeleteAsync(List<T> entities) => await repo.DeleteAsync(entities);

        //      public virtual async Task<int> DeleteByKeyAsync(params string[] Keys)
        //      {
        //          return await repo.DeleteByKeyAsync(Keys);
        //      }
        //      public virtual async Task<int> DeleteByKeyAsync(List<string> Keys) => await repo.DeleteByKeyAsync(Keys);

        //      public virtual int Save(params T[] entities)
        //      {
        //          return repo.Save(entities);
        //      }
        //      public virtual int Save(List<T> entities) => repo.Save(entities);
        //      public virtual async Task<int> SaveAsync(params T[] entities)
        //      {
        //          return await repo.SaveAsync(entities); 
        //      }
        //      public virtual async Task<int> SaveAsync(List<T> entities) => await repo.SaveAsync(entities);

        //      public virtual int CommitChanges() => repo.CommitChanges();
        //      public virtual async Task<int> CommitChangesAsync() => await repo.CommitChangesAsync();

        //      public virtual void Reload(params T[] entities) => repo.Reload(entities);
        //      public virtual void Reload(List<T> entities) => repo.Reload(entities);
        //      public virtual async Task ReloadAsync(params T[] entities)
        //      {
        //          await repo.ReloadAsync(entities);
        //      }
        //      public virtual async Task ReloadAsync(List<T> entities) => await repo.ReloadAsync(entities);

        //      public virtual bool HasData() => repo.HasData();
        //      public virtual bool HasData(Expression<Func<T, bool>> filter) => repo.HasData(filter);
        //      public virtual async Task<bool> HasDataAsync() => await repo.HasDataAsync();
        //      public virtual async Task<bool> HasDataAsync(Expression<Func<T, bool>> filter) => await repo.HasDataAsync(filter);

        //      public virtual int Count() => repo.Count();
        //      public virtual int Count(Expression<Func<T, bool>> filter) => repo.Count(filter);

        //      public virtual async Task<int> CountAsync() => await repo.CountAsync();
        //      public virtual async Task<int> CountAsync(Expression<Func<T, bool>> filter) => await repo.CountAsync(filter);

        //      public virtual long CountLong() => repo.CountLong();
        //      public virtual long CountLong(Expression<Func<T, bool>> filter) => repo.CountLong(filter);

        //      public virtual async Task<long> CountLongAsync() => await repo.CountLongAsync();
        //      public virtual async Task<long> CountLongAsync(Expression<Func<T, bool>> filter) => await repo.CountLongAsync(filter);

        //      public virtual T Max() => repo.Max();
        //      public virtual async Task<T> MaxAsync() => await repo.MaxAsync();

        //      public virtual T GetByKey(string key) => repo.GetByKey(key);
        //      public async virtual Task<T> GetByKeyAsync(string key) => await repo.GetByKeyAsync(key);

        //      public virtual T Get(Expression<Func<T, bool>> filter, params string[] includeProperties) => repo.Get(filter: filter, includeProperties: includeProperties);
        //      public async virtual Task<T> GetAsync(Expression<Func<T, bool>> filter, params string[] includeProperties) => await repo.GetAsync(filter: filter, includeProperties: includeProperties);
        //      public virtual T GetReadOnly(Expression<Func<T, bool>> filter, params string[] includeProperties) => repo.GetReadOnly(filter: filter, includeProperties: includeProperties);
        //      public async virtual Task<T> GetReadOnlyAsync(Expression<Func<T, bool>> filter, params string[] includeProperties) => await repo.GetReadOnlyAsync(filter: filter, includeProperties: includeProperties);

        //      public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int? skip = null, int? take = null, params string[] includeProperties)
        //      {
        //          return repo.GetAll(filter, orderBy,skip, take, includeProperties);
        //      }
        //      public virtual IQueryable<T> GetAllReadOnly(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int? skip = null, int? take = null, params string[] includeProperties)
        //      {
        //          return repo.GetAllReadOnly(filter, orderBy, skip, take, includeProperties);
        //      }
    }
}