using BookStore.Data.Entities;
using BookStore.VModels.BookAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.VModels.Author
{
    public class AuthorModel : ModelBase
    {
        public Guid AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public virtual IList<BookAuthorViewModel>? BookAuthors { get; set; }
    }
}
