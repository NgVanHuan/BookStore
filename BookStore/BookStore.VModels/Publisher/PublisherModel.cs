using BookStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.VModels.Publisher
{
    public class PublisherModel
    {
        public Guid PublisherId { get; set; }
        public string PublisherName { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}
