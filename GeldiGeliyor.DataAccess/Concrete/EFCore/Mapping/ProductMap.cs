using GeldiGeliyor.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeldiGeliyor.DataAccess.Concrete.EFCore.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Description).IsRequired();
            builder.Property(x=>x.Description).HasMaxLength(500);
            builder.Property(x=>x.Name).IsRequired();
            builder.Property(x=>x.Name).HasMaxLength(100);
            builder.Property(x=>x.Price).HasColumnType("money");

            builder.HasMany(x => x.OrderDetails).WithOne(x => x.Product).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Pictures).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);

        }
    }
}
