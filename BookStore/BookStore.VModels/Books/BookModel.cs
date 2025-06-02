using BookStore.Data.Entities;
using BookStore.VModels.BookAuthor;
using BookStore.VModels.BookLanguage;
using BookStore.VModels.Category;
using BookStore.VModels.OrderLine;
using BookStore.VModels.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.VModels.Books
{
    public class BookModel : ModelBase
    {
        public Guid BookId { get; set; }
        public virtual List<BookAuthorViewModel>? BookAuthors { get; set; }
        public string? Title { get; set; }
        public string? IBSN13 { get; set; }
        public string? ImageName { get; set; }
        public string? ImageUrl { get; set; }
        public Guid LanguageId { get; set; }
        public virtual BookLanguageModel? BookLanguage { get; set; }
        public int NumPages { get; set; }
        public decimal Price { get; set; }
        public DateTime PublicationDate { get; set; }
        public Guid CategoryId { get; set; }
        public virtual CategoryModel? Category { get; set; }
        public Guid PublisherId { get; set; }
        public virtual PublisherModel? Publisher { get; set; }
        public virtual List<OrderLineModel>? OrderLines { get; set; }
    }
}
