﻿namespace Angular5WebApiCore.Data.EntityConfigurations.Vouchers
{
    using Angular5WebApiCore.Models.Domain.Vouchers;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ReceiptVoucherDetailConfiguration : IEntityTypeConfiguration<ReceiptVoucherDetail>
    {
        public void Configure(EntityTypeBuilder<ReceiptVoucherDetail> entity)
        {
            entity.Property(d => d.AccountID).IsRequired();
            entity.Property(d => d.ReceiptVoucherID).IsRequired();
            entity.Property(d => d.ChequeNo).HasMaxLength(250);
            entity.Property(d => d.Narration).HasMaxLength(500);

            entity.Property(d => d.CreatedBy).IsRequired().HasMaxLength(250);
            entity.Property(d => d.DateCreated).IsRequired();
            entity.Property(d => d.IsDeleted).IsRequired();
            entity.Property(d => d.IsActive).IsRequired();
            entity.Property(d => d.ModifiedBy).HasMaxLength(250);
        }
    }
}