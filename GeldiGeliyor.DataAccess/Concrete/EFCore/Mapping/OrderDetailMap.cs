using GeldiGeliyor.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeldiGeliyor.DataAccess.Concrete.EFCore.Mapping
{
    public class OrderDetailMap : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
           builder.HasKey(x => new {x.OrderId,x.ProductId});
            builder.Property(x => x.Price).HasColumnName("money");
        }
    }
}
