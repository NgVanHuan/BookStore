using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Config
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.AddressId);

            builder.HasMany(a => a.CustomerOrders)
               .WithOne(co => co.DestAddress)
               .HasForeignKey(co => co.DestAddressId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(a => a.CustomerAddresses)
               .WithOne(ca => ca.Address)
               .HasForeignKey(ca => ca.AddressId)
               .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(c => c.Country)
            //    .WithMany(a => a.Addresses)
            //    .HasForeignKey(a => a.CountryId)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
