
using GeldiGeliyor.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeldiGeliyor.DataAccess.Concrete.EFCore.Mapping
{
    public class SellerMap : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CompanyName).HasMaxLength(30);
            builder.Property(x => x.CompanyName).IsRequired();
            builder.Property(x => x.CompanyAddress).IsRequired();
            builder.Property(x => x.CompanyAddress).HasMaxLength(150);

            builder.HasMany(x => x.Products).WithOne(x => x.Seller).HasForeignKey(x => x.SellerId);
        }
    }
}
