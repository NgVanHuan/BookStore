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
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.AccountId);
            builder.HasOne(a => a.Customer)
                .WithOne(c => c.Account)
                .HasForeignKey<Account>(a => a.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
