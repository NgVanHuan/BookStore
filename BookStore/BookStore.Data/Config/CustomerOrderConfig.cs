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
    public class CustomerOrderConfig : IEntityTypeConfiguration<CustomerOrder>
    {
        public void Configure(EntityTypeBuilder<CustomerOrder> builder)
        {
            builder.HasKey(co => co.OrderId);

            builder.HasMany(co=>co.OrderLines)
                .WithOne(ol=>ol.CustomerOrder)
                .HasForeignKey(co=>co.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(co => co.OrderHistories)
                .WithOne(oh => oh.CustomerOrder)
                .HasForeignKey(co => co.OrderId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
