namespace Angular5WebApiCore.Data.EntityConfigurations.Masters
{
    using Angular5WebApiCore.Models.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class LineOfBusinessConfiguration : IEntityTypeConfiguration<LineOfBusiness>
    {
        public void Configure(EntityTypeBuilder<LineOfBusiness> entity)
        {
            entity.Property(d => d.Name).IsRequired().HasMaxLength(250);
            entity.Property(d => d.Code).IsRequired().HasMaxLength(250);
            entity.Property(d => d.ManagerName).IsRequired().HasMaxLength(250);
            entity.Property(d => d.Description).HasMaxLength(500);

            entity.Property(d => d.CreatedBy).IsRequired().HasMaxLength(250);
            entity.Property(d => d.DateCreated).IsRequired();
            entity.Property(d => d.IsDeleted).IsRequired();
            entity.Property(d => d.IsActive).IsRequired();
            entity.Property(d => d.ModifiedBy).HasMaxLength(250);
        }
    }
}