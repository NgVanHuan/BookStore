using BookStore.Data.Entities;
using BookStore.VModels.Author;
using BookStore.VModels.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.VModels.BookAuthor
{
    public class BookAuthorViewModel : ModelBase
    {
        public Guid BookId { get; set; }
        public virtual BookViewModel? Book { get; set; }
        public Guid AuthorId { get; set; }
        public virtual AuthorViewModel? Author { get; set; }
    }
}
