using BookStore.Data.Entities;
using BookStore.VModels.BookAuthor;
using BookStore.VModels.BookLanguage;
using BookStore.VModels.Category;
using BookStore.VModels.OrderLine;
using BookStore.VModels.Publisher;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.VModels.Books
{
    public class BookViewModel : ModelBase
    {
        public Guid BookId { get; set; }
        public virtual List<BookAuthorViewModel>? BookAuthors { get; set; }
        [Display(Name = "Title")]
        public string? Title { get; set; }
        [Display(Name = "IBSN13")]
        public string? IBSN13 { get; set; }
        public string? ImageName { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? ImageFile { get; set; }
        public Guid LanguageId { get; set; }
        public virtual BookLanguageViewModel? BookLanguage { get; set; }
        public int NumPages { get; set; }
        public decimal Price { get; set; }
        public string? AuthorNames { get; set; }
        public DateTime PublicationDate { get; set; }
        public Guid CategoryId { get; set; }
        public virtual CategoryViewModel? Category { get; set; }
        public Guid PublisherId { get; set; }
        public virtual PublisherViewModel? Publisher { get; set; }
        public virtual List<OrderLineViewModel>? OrderLines { get; set; }
    }
}
