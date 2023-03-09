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
    public class OrderStatusConfig : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasKey(os => os.StatusId);

            builder.HasMany(os => os.Histories)
                .WithOne(oh => oh.OrderStatus)
                .HasForeignKey(oh => oh.StatusId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
