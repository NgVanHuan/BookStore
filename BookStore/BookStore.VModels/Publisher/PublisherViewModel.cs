using BookStore.Data.Entities;
using BookStore.VModels.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.VModels.Publisher
{
    public class PublisherViewModel
    {
        public Guid PublisherId { get; set; }
        [Display(Name = "Publisher Name")]
        public string PublisherName { get; set; }
        public virtual List<BookViewModel> Books { get; set; }
    }
}
