using Angular5WebApiCore.Models.Domain;
using Angular5WebApiCore.Models.Domain.Accounts;
using Angular5WebApiCore.Models.Domain.Locations;
using Angular5WebApiCore.Models.Domain.Vouchers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular5WebApiCore.Data
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        private Dictionary<Type, object> repositories;

        public UnitOfWork(TContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public TContext Context { get; private set; }

        public int Commit()
        {
            int rowsEffected = Context.SaveChanges();
            return rowsEffected;
        }
        public async Task<int> CommitAsync()
        {
            var rowsEffected = await Context.SaveChangesAsync();
            return rowsEffected;
        }

        public IRepository<T> GetRepository<T>() where T : AuditableEntity
        {
            if (repositories == null) repositories = new Dictionary<Type, object>();
            if (!repositories.ContainsKey(typeof(T))) repositories[typeof(T)] = new RepositoryEF<T>(Context);
            return repositories[typeof(T)] as IRepository<T>;
        }

        public void Dispose() => Context.Dispose();

        public IRepository<Country> Countries => GetRepository<Country>();
        public IRepository<State> States => GetRepository<State>();
        public IRepository<City> Cities => GetRepository<City>();
        public IRepository<Area> Areas => GetRepository<Area>();

        public IRepository<AccountType> AccountTypes => GetRepository<AccountType>();
        public IRepository<AccountGroup> AccountGroups => GetRepository<AccountGroup>();
        public IRepository<AccountSubGroup> AccountSubGroups => GetRepository<AccountSubGroup>();
        public IRepository<AccountTitle> AccountTitles => GetRepository<AccountTitle>();

        public IRepository<Address> Addresses => GetRepository<Address>();
        public IRepository<Company> Companies => GetRepository<Company>();
        public IRepository<Customer> Customers => GetRepository<Customer>();
        public IRepository<Employee> Employees => GetRepository<Employee>();
        public IRepository<Supplier> Suppliers => GetRepository<Supplier>();
        public IRepository<LineOfBusiness> LineOfBusinesses => GetRepository<LineOfBusiness>();

        public IRepository<JournalVoucher> JournalVouchers => GetRepository<JournalVoucher>();
        public IRepository<JournalVoucherDetail> JournalVoucherDetails => GetRepository<JournalVoucherDetail>();
        public IRepository<ReceiptVoucher> ReceiptVouchers => GetRepository<ReceiptVoucher>();
        public IRepository<ReceiptVoucherDetail> ReceiptVoucherDetails => GetRepository<ReceiptVoucherDetail>();
        public IRepository<PaymentVoucher> PaymentVouchers => GetRepository<PaymentVoucher>();
        public IRepository<PaymentVoucherDetail> PaymentVoucherDetails => GetRepository<PaymentVoucherDetail>();
    }
}
