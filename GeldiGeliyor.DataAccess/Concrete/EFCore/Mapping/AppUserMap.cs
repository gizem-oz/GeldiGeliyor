

using GeldiGeliyor.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeldiGeliyor.DataAccess.Concrete.EFCore.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Seller).WithOne(x => x.AppUser).HasForeignKey<Seller>(x => x.Id);
            builder.HasOne(x => x.Customer).WithOne(x => x.AppUser).HasForeignKey<Customer>(x => x.Id);
        }
    }
}
