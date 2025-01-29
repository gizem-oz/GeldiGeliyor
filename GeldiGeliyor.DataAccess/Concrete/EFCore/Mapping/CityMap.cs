using GeldiGeliyor.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeldiGeliyor.DataAccess.Concrete.EFCore.Mapping
{
    public class CityMap : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
           builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(30);
            builder.HasData(new City()
            {
                Id = 1,
                Name= "İstanbul",
            },
            new City()
            {
                Id = 2,
                Name= "Ankara",
            });
            builder.HasMany(x=>x.Customers).WithOne(x => x.City).HasForeignKey(x => x.CityId);


        }
    }
}
