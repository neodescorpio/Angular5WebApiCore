namespace Angular5WebApiCore.Data.EntityConfigurations.Masters
{
    using Angular5WebApiCore.Models.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> entity)
        {
            entity.Property(d => d.Name).IsRequired().HasMaxLength(250);
            entity.Property(d => d.Code).IsRequired().HasMaxLength(250);
            entity.Property(d => d.OwnerName).IsRequired().HasMaxLength(250);
            entity.Property(d => d.Description).HasMaxLength(500);

            entity.Property(d => d.CreatedBy).IsRequired().HasMaxLength(250);
            entity.Property(d => d.DateCreated).IsRequired();
            entity.Property(d => d.IsDeleted).IsRequired();
            entity.Property(d => d.IsActive).IsRequired();
            entity.Property(d => d.ModifiedBy).HasMaxLength(250);
        }
    }
}