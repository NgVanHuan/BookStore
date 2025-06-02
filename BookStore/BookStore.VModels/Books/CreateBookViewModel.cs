using BookStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.VModels.Books
{
    public class CreateBookViewModel : ModelBase
    {
        public BookViewModel? BookVModel { get; set; }
        public List<Guid>? AuthorIds { get; set; }
    }
}
