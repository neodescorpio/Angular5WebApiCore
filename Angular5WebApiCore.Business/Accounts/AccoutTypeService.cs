using Angular5WebApiCore.Data;
using Angular5WebApiCore.Models.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular5WebApiCore.Service.Accounts
{
    public interface IAccountTypeService 
	{
		AccountType Get(string code);
		IEnumerable<AccountType> GetAll(string code);

		Task<AccountType> GetAsync(string code);
		Task<IEnumerable<AccountType>> GetAllAsync(string code);
	}
	internal class AccountTypeService : IAccountTypeService
	{
		private readonly IUnitOfWork unitofWork;

		public AccountTypeService(IUnitOfWork unitofWork)
		{
			this.unitofWork = unitofWork;
		}

		public AccountType Get(string code)
		{
			var entity = unitofWork.AccountTypes.Get(d => d.Code.Equals(code));
			return entity;
		}
		public IEnumerable<AccountType> GetAll(string code)
		{
			var entities = unitofWork.AccountTypes.GetAll(d => d.Code.Equals(code)).ToList();
			return entities;
		}

		public async Task<AccountType> GetAsync(string code)
		{
			var entity = await unitofWork.AccountTypes.GetAsync(d => d.Code.Equals(code));
			return entity;
		}
		public async Task<IEnumerable<AccountType>> GetAllAsync(string code)
		{
			var entities = await unitofWork.AccountTypes.GetAll(d => d.Code.Equals(code)).ToListAsync();
			return entities;
		}
	}
}
