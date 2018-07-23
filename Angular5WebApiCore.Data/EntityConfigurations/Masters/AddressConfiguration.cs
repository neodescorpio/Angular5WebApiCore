namespace Angular5WebApiCore.Data.EntityConfigurations.Masters
{
    using Angular5WebApiCore.Models.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> entity)
        {
            entity.Property(d => d.Building).HasMaxLength(250);
            entity.Property(d => d.FlatNo).HasMaxLength(250);
            entity.Property(d => d.Floor).HasMaxLength(250);
            entity.Property(d => d.HouseNo).HasMaxLength(250);
            entity.Property(d => d.OfficeNo).HasMaxLength(250);
            entity.Property(d => d.POBoxNo).HasMaxLength(250);
            entity.Property(d => d.Street).HasMaxLength(250);
            
            entity.Property(d => d.CreatedBy).IsRequired().HasMaxLength(250);
            entity.Property(d => d.DateCreated).IsRequired();
            entity.Property(d => d.IsDeleted).IsRequired();
            entity.Property(d => d.IsActive).IsRequired();
            entity.Property(d => d.ModifiedBy).HasMaxLength(250);
        }
    }
}