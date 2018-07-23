namespace Angular5WebApiCore.Data.EntityConfigurations.Vouchers
{
    using Angular5WebApiCore.Models.Domain.Vouchers;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class JournalVoucherDetailConfiguration : IEntityTypeConfiguration<JournalVoucherDetail>
    {
        public void Configure(EntityTypeBuilder<JournalVoucherDetail> entity)
        {
            entity.Property(d => d.AccountID).IsRequired();
            entity.Property(d => d.JournalVoucherID).IsRequired();
            entity.Property(d => d.Narration).HasMaxLength(500);

            entity.Property(d => d.CreatedBy).IsRequired().HasMaxLength(250);
            entity.Property(d => d.DateCreated).IsRequired();
            entity.Property(d => d.IsDeleted).IsRequired();
            entity.Property(d => d.IsActive).IsRequired();
            entity.Property(d => d.ModifiedBy).HasMaxLength(250);
        }
    }
}