using Angular5WebApiCore.Data;
using Angular5WebApiCore.Models.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular5WebApiCore.Service.Accounts
{
    public interface IAccountTitleService 
	{
		AccountTitle Get(string code);
		IEnumerable<AccountTitle> GetAll(string code);
		AccountTitle GetByAccountSubGroup(long accountSubGroupID);
		IEnumerable<AccountTitle> GetAllByAccountSubGroup(long accountSubGroupID);

		Task<AccountTitle> GetAsync(string code);
		Task<IEnumerable<AccountTitle>> GetAllAsync(string code);
		Task<AccountTitle> GetByAccountSubGroupAsync(long accountSubGroupID);
		Task<IEnumerable<AccountTitle>> GetAllByAccountSubGroupAsync(long accountSubGroupID);
	}
	internal class AccountTitleService : IAccountTitleService
	{
		private readonly IUnitOfWork unitofWork;

		public AccountTitleService(IUnitOfWork unitofWork)
		{
			this.unitofWork = unitofWork;
		}

		public AccountTitle Get(string code)
		{
			var entity = unitofWork.AccountTitles.Get(d => d.Code == code);
			return entity;
		}
		public IEnumerable<AccountTitle> GetAll(string code)
		{
			var list = unitofWork.AccountTitles.GetAll(d => d.Code == code).ToList();
			return list;
		}
		public AccountTitle GetByAccountSubGroup(long accountSubGroupID)
		{
			var entity = unitofWork.AccountTitles.Get(d => d.AccountSubGroupID == accountSubGroupID);
			return entity;
		}
		public IEnumerable<AccountTitle> GetAllByAccountSubGroup(long accountSubGroupID)
		{
			var list = unitofWork.AccountTitles.GetAll(d => d.AccountSubGroupID == accountSubGroupID).ToList();
            return list;
		}

		public async Task<AccountTitle> GetAsync(string code)
		{
			var entity = await unitofWork.AccountTitles.GetAsync(d => d.Code == code);
			return entity;
		}
		public async Task<IEnumerable<AccountTitle>> GetAllAsync(string code)
		{
			var list = await unitofWork.AccountTitles.GetAll(d => d.Code == code).ToListAsync();
			return list;
		}
		public async Task<AccountTitle> GetByAccountSubGroupAsync(long accountSubGroupID)
		{
			var entity = await unitofWork.AccountTitles.GetAsync(d => d.AccountSubGroupID == accountSubGroupID);
			return entity;
		}
		public async Task<IEnumerable<AccountTitle>> GetAllByAccountSubGroupAsync(long accountSubGroupID)
		{
			var list = await unitofWork.AccountTitles.GetAll(d => d.AccountSubGroupID == accountSubGroupID).ToListAsync();
            return list;
		}
	}
}
