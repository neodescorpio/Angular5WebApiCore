using Angular5WebApiCore.Data;
using Angular5WebApiCore.Models.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular5WebApiCore.Service.Accounts
{
    public interface IAccountGroupService 
    {
        AccountGroup Get(string code);
        IEnumerable<AccountGroup> GetAll(string code);
        AccountGroup GetByAccountType(long accountTypeID);
        IEnumerable<AccountGroup> GetAllByAccountType(long accountTypeID);

        Task<AccountGroup> GetAsync(string code);
        Task<IEnumerable<AccountGroup>> GetAllAsync(string code);
        Task<AccountGroup> GetByAccountTypeAsync(long accountTypeID);
        Task<IEnumerable<AccountGroup>> GetAllByAccountTypeAsync(long accountTypeID);
    }
    internal class AccountGroupService : IAccountGroupService
    {
        private readonly IUnitOfWork unitofWork;

        public AccountGroupService(IUnitOfWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }

        public AccountGroup GetByAccountType(long accountTypeID)
        {
            var entity = unitofWork.AccountGroups.Get(d => d.AccountTypeID == accountTypeID);
            return entity;
        }
        public IEnumerable<AccountGroup> GetAllByAccountType(long accountTypeID)
        {
            var entities = unitofWork.AccountGroups.GetAll(d => d.AccountTypeID == accountTypeID).ToList();
            return entities;
        }
        public AccountGroup Get(string code)
        {
            var entity = unitofWork.AccountGroups.Get(d => d.Code.Equals(code));
            return entity;
        }
        public IEnumerable<AccountGroup> GetAll(string code)
        {
            var entities = unitofWork.AccountGroups.GetAll(d => d.Code.Equals(code)).ToList();
            return entities;
        }

        public async Task<AccountGroup> GetAsync(string code)
        {
            var entity = await unitofWork.AccountGroups.GetAsync(d => d.Code.Equals(code));
            return entity;
        }
        public async Task<IEnumerable<AccountGroup>> GetAllAsync(string code)
        {
            var entities = await unitofWork.AccountGroups.GetAll(d => d.Code.Equals(code)).ToListAsync();
            return entities;
        }
        public async Task<AccountGroup> GetByAccountTypeAsync(long accountTypeID)
        {
            var entity = await unitofWork.AccountGroups.GetAsync(d => d.AccountTypeID == accountTypeID);
            return entity;
        }
        public async Task<IEnumerable<AccountGroup>> GetAllByAccountTypeAsync(long accountTypeID)
        {
            var entities = await unitofWork.AccountGroups.GetAll(d => d.AccountTypeID == accountTypeID).ToListAsync();
            return entities;
        }
    }
}
