using BookStore.Data.Entities;
using BookStore.VModels.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.VModels.Category
{
    public class CategoryViewModel : ModelBase
    {
        public Guid CategoryId { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        public virtual List<BookViewModel> Books { get; set; }
    }
}
