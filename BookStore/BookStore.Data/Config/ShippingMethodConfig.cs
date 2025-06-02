using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Config
{
    public class ShippingMethodConfig : IEntityTypeConfiguration<ShippingMethod>
    {
        public void Configure(EntityTypeBuilder<ShippingMethod> builder)
        {
            builder.HasKey(sm => sm.MethodId);

            builder.HasMany(sm => sm.CustomerOrders)
                .WithOne(co => co.ShippingMethod)
                .HasForeignKey(co => co.ShippingMethodId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

}
