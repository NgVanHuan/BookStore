using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class BookAuthor : EntityBase
    {
        public Guid BookId { get; set; }
        public virtual Book? Book { get; set; }
        public Guid AuthorId { get; set; }
        public virtual Author? Author { get; set; }
    }
}
