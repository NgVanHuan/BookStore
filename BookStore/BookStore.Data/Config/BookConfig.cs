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
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.BookId);

            builder.HasMany(b => b.BookAuthors)
                .WithOne(ba => ba.Book)
                .HasForeignKey(ba => ba.BookId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(b => b.OrderLines)
                .WithOne(ol => ol.Book)
                .HasForeignKey(ol => ol.BookId)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(b => b.Publisher)
            //    .WithMany(p => p.Books)
            //    .HasForeignKey(b => b.PublisherId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(b => b.BookLanguage)
            //    .WithMany(p => p.Books)
            //    .HasForeignKey(b => b.LanguageId)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
