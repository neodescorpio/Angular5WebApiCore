using Angular5WebApiCore.Data.EntityConfigurations;
using Angular5WebApiCore.Models.Domain;
using Angular5WebApiCore.Models.Domain.Accounts;
using Angular5WebApiCore.Models.Domain.Locations;
using Angular5WebApiCore.Models.Domain.Vouchers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Angular5WebApiCore.Data
{
    public class AppDataContext : DbContext
    {
        IHttpContextAccessor httpContextAccessor;

        public AppDataContext(DbContextOptions<AppDataContext> options, IHttpContextAccessor _httpContextAccessor) : base(options)
        {
            httpContextAccessor = _httpContextAccessor;
        }

        private string Username
        {
            get
            {
                var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (userId != null)
                {
                    return userId.Value;
                }
                else
                {
                    return "Anonymous";
                }
            }
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<AccountGroup> AccountGroups { get; set; }
        public DbSet<AccountSubGroup> AccountSubGroups { get; set; }
        public DbSet<AccountTitle> AccountTitles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<LineOfBusiness> LineOfBusinesses { get; set; }
        public DbSet<JournalVoucher> JournalVouchers { get; set; }
        public DbSet<JournalVoucherDetail> JournalVoucherDetails { get; set; }
        public DbSet<ReceiptVoucher> ReceiptVouchers { get; set; }
        public DbSet<ReceiptVoucherDetail> ReceiptVoucherDetails { get; set; }
        public DbSet<PaymentVoucher> PaymentVouchers { get; set; }
        public DbSet<PaymentVoucherDetail> PaymentVoucherDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typesToMap = (from x in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                              where x.IsClass && typeof(IEntityTypeConfiguration<>).IsAssignableFrom(x)
                              select x).ToList();
            
            foreach (var mappingType in typesToMap)
            {
                dynamic mapperClass = Activator.CreateInstance(mappingType);
                modelBuilder.ApplyConfiguration(mapperClass);
            }
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                ChangeTracker.DetectChanges();
                var modifiedEntries = ChangeTracker.Entries().Where(x => x.Entity is AuditableEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

                foreach (var entry in modifiedEntries)
                {
                    if (((AuditableEntity)entry.Entity) != null)
                    {
                        var entity = entry.Entity as AuditableEntity;

                        if (entry.State == EntityState.Added)
                        {
                            entity.CreatedBy = Username;
                            entity.DateCreated = DateTime.Now;
                        }
                        else
                        {
                            entity.ModifiedBy = Username;
                            entity.DateModified = DateTime.Now;
                            Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                            Entry(entity).Property(x => x.DateCreated).IsModified = false;
                        }
                    }
                }
                return base.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                ChangeTracker.DetectChanges();
                var modifiedEntries = ChangeTracker.Entries().Where(x => x.Entity is AuditableEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

                foreach (var entry in modifiedEntries)
                {
                    if (((AuditableEntity)entry.Entity) != null)
                    {
                        var entity = entry.Entity as AuditableEntity;

                        if (entry.State == EntityState.Added)
                        {
                            entity.CreatedBy = Username;
                            entity.DateCreated = DateTime.Now;
                        }
                        else
                        {
                            entity.ModifiedBy = Username;
                            entity.DateModified = DateTime.Now;
                            Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                            Entry(entity).Property(x => x.DateCreated).IsModified = false;
                        }
                    }
                }
                return base.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;

            }
        }
    }
}