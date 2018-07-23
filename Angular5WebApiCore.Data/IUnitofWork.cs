namespace Angular5WebApiCore.Data
{
    using Angular5WebApiCore.Models.Domain;
    using Angular5WebApiCore.Models.Domain.Accounts;
    using Angular5WebApiCore.Models.Domain.Locations;
    using Angular5WebApiCore.Models.Domain.Vouchers;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public interface IUnitOfWork : IDisposable
    {
        IRepository<Country> Countries { get; }
        IRepository<State> States { get; }
        IRepository<City> Cities { get; }
        IRepository<Area> Areas { get; }
        IRepository<AccountType> AccountTypes { get; }
        IRepository<AccountGroup> AccountGroups { get; }
        IRepository<AccountSubGroup> AccountSubGroups { get; }
        IRepository<AccountTitle> AccountTitles { get; }
        IRepository<Address> Addresses { get; }
        IRepository<Company> Companies { get; }
        IRepository<Customer> Customers { get; }
        IRepository<Employee> Employees { get; }
        IRepository<Supplier> Suppliers { get; }
        IRepository<LineOfBusiness> LineOfBusinesses { get; }
        IRepository<JournalVoucher> JournalVouchers { get; }
        IRepository<JournalVoucherDetail> JournalVoucherDetails { get; }
        IRepository<ReceiptVoucher> ReceiptVouchers { get; }
        IRepository<ReceiptVoucherDetail> ReceiptVoucherDetails { get; }
        IRepository<PaymentVoucher> PaymentVouchers { get; }
        IRepository<PaymentVoucherDetail> PaymentVoucherDetails { get; }

        IRepository<T> GetRepository<T>() where T : AuditableEntity;

        int Commit();
        Task<int> CommitAsync();
    }
    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext Context { get; }
    }
}
