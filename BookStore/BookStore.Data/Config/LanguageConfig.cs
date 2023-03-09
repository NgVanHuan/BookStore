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
    public class LanguageConfig : IEntityTypeConfiguration<BookLanguage>
    {
        public void Configure(EntityTypeBuilder<BookLanguage> builder)
        {
            builder.HasKey(bl => bl.LanguageId);

            builder.HasMany(bl => bl.Books)
                .WithOne(b => b.BookLanguage)
                .HasForeignKey(b => b.LanguageId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
