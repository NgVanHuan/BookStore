using BookStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.VModels.Category
{
    public class CategoryViewModel : ModelBase
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}
