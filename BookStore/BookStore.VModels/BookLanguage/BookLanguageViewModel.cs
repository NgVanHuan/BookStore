using BookStore.Data.Entities;
using BookStore.VModels.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.VModels.BookLanguage
{
    public class BookLanguageViewModel : ModelBase
    {
        public Guid LanguageId { get; set; }
        [Display(Name = "Language Code")]
        public string? LanguageCode { get; set; }
        [Display(Name = "Language Name")]
        public string? LanguageName { get; set; }
        public virtual List<BookViewModel>? Books { get; set; }
    }
}
