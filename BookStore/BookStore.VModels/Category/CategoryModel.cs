using BookStore.Data.Entities;
using BookStore.VModels.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.VModels.Category
{
    public class CategoryModel : ModelBase
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual List<BookModel> Books { get; set; }
    }
}
