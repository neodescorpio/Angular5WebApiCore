using Angular5WebApiCore.Data;
using Angular5WebApiCore.Models.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular5WebApiCore.Service.Accounts
{
	public interface IAccountSubGroupService
	{
		AccountSubGroup Get(string code);
		IEnumerable<AccountSubGroup> GetAll(string code);
		AccountSubGroup GetByAccountSubGroup(long accountTypeID);
		IEnumerable<AccountSubGroup> GetAllByAccountSubGroup(long accountTypeID);

		Task<AccountSubGroup> GetAsync(string code);
		Task<IEnumerable<AccountSubGroup>> GetAllAsync(string code);
		Task<AccountSubGroup> GetByAccountSubGroupAsync(long accountTypeID);
		Task<IEnumerable<AccountSubGroup>> GetAllByAccountSubGroupAsync(long accountTypeID);
	}
	internal class AccountSubGroupService : IAccountSubGroupService
	{
		private readonly IUnitOfWork unitofWork;

		public AccountSubGroupService(IUnitOfWork unitofWork)
		{
			this.unitofWork = unitofWork;
		}

		public AccountSubGroup Get(string code)
		{
			var entity = unitofWork.AccountSubGroups.Get(d => d.Code == code);
			return entity;
		}
		public IEnumerable<AccountSubGroup> GetAll(string code)
		{
			var list = unitofWork.AccountSubGroups.GetAll(d => d.Code == code).ToList();
			return list;
		}
		public AccountSubGroup GetByAccountSubGroup(long accountTypeID)
		{
			var entity = unitofWork.AccountSubGroups.Get(d => d.AccountGroupID == accountTypeID);
			return entity;
		}
		public IEnumerable<AccountSubGroup> GetAllByAccountSubGroup(long accountTypeID)
		{
			var list = unitofWork.AccountSubGroups.GetAll(d => d.AccountGroupID == accountTypeID).ToList();
			return list;
		}

		public async Task<AccountSubGroup> GetAsync(string code)
		{
			var entity = await unitofWork.AccountSubGroups.GetAsync(d => d.Code == code);
			return entity;
		}
		public async Task<IEnumerable<AccountSubGroup>> GetAllAsync(string code)
		{
			var list = await unitofWork.AccountSubGroups.GetAll(d => d.Code == code).ToListAsync();
			return list;
		}
		public async Task<AccountSubGroup> GetByAccountSubGroupAsync(long accountTypeID)
		{
			var entity = await unitofWork.AccountSubGroups.GetAsync(d => d.AccountGroupID == accountTypeID);
			return entity;
		}
		public async Task<IEnumerable<AccountSubGroup>> GetAllByAccountSubGroupAsync(long accountTypeID)
		{
			var list = await unitofWork.AccountSubGroups.GetAll(d => d.AccountGroupID == accountTypeID).ToListAsync();
			return list;
		}
	}
}
