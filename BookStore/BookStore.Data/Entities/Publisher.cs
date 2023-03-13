using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class Publisher : EntityBase
    {
        public int PublisherId { get; set; }
        public string? PublisherName { get; set; }
        public IList<Book>? Books { get; set; }
    }
}
