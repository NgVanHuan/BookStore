using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Entities;
using BookStore.VModels.BookAuthor;

namespace BookStore.VModels.Author
{
    public class AuthorViewModel : ModelBase
    {
        public Guid AuthorId { get; set; }
        [Display(Name = "Author Name")]
        public string? AuthorName { get; set; }
        public virtual List<BookAuthorViewModel> BookAuthors { get; set; }
    }
}
