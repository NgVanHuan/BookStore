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
    public class CustomerAddressConfig : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.HasKey(ca => new { ca.AddressId, ca.StatusId });

            builder.HasOne(ca => ca.Customer)
            .WithMany(c => c.CustomerAddresses)
            .HasForeignKey(ca => ca.CustomerId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ca => ca.AddressStatus)
                .WithMany(ads => ads.CustomerAddresses)
                .HasForeignKey(ca => ca.StatusId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ca => ca.Address)
                .WithMany(a => a.CustomerAddresses)
                .HasForeignKey(ca => ca.AddressId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
