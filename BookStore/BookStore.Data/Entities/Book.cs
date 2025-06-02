using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class Book : EntityBase
    {
        public Guid BookId { get; set; }
        public virtual IList<BookAuthor>? BookAuthors { get; set; }
        public string? Title { get; set; }
        public string? IBSN13 { get; set; }
        public string? ImageName { get; set; }
        public string? ImageUrl { get; set; }
        public Guid LanguageId { get; set; }
        public virtual BookLanguage? BookLanguage { get; set; }
        public int NumPages { get; set; }
        public decimal? Price { get; set; }
        public DateTime PublicationDate { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public Guid PublisherId { get; set; }
        public virtual Publisher? Publisher { get; set; }
        public virtual IList<OrderLine>? OrderLines { get; set; }
    }
}
