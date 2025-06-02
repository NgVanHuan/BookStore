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
    public class AddressStatusConfig : IEntityTypeConfiguration<AddressStatus>
    {
        public void Configure(EntityTypeBuilder<AddressStatus> builder)
        {
            builder.HasKey(ads => ads.StatusId);

            builder.HasMany(ads => ads.CustomerAddresses)
                .WithOne(ca => ca.AddressStatus)
                .HasForeignKey(ca => ca.StatusId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
