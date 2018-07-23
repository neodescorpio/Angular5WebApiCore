namespace Angular5WebApiCore.Data.EntityConfigurations.Vouchers
{
    using Angular5WebApiCore.Models.Domain.Vouchers;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class JournalVoucherConfiguration : IEntityTypeConfiguration<JournalVoucher>
    {
        public void Configure(EntityTypeBuilder<JournalVoucher> entity)
        {
            entity.Property(d => d.Number).IsRequired().HasMaxLength(250);
            entity.Property(d => d.Type).IsRequired().HasMaxLength(100);
            entity.Property(d => d.Date).IsRequired();
            entity.Property(d => d.Description).HasMaxLength(500);

            entity.Property(d => d.CreatedBy).IsRequired().HasMaxLength(250);
            entity.Property(d => d.DateCreated).IsRequired();
            entity.Property(d => d.IsDeleted).IsRequired();
            entity.Property(d => d.IsActive).IsRequired();
            entity.Property(d => d.ModifiedBy).HasMaxLength(250);
        }
    }
}