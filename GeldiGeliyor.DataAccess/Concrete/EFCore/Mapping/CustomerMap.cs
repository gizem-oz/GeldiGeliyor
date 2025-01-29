using GeldiGeliyor.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeldiGeliyor.DataAccess.Concrete.EFCore.Mapping
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.FirstName).IsRequired();
            builder.Property(x=>x.FirstName).HasMaxLength(50);
            builder.Property(x=>x.LastName).HasMaxLength(50);
            builder.Property(x=>x.LastName).IsRequired();
            builder.Property(x=>x.Address).HasMaxLength(150);

            builder.HasMany(x=> x.Orders).WithOne(x=>x.Customer).HasForeignKey(x=>x.CustomerId);

        }
    }
}
