using BookStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.VModels.BookLanguage
{
    public class BookLanguageModel : ModelBase
    {
        public Guid LanguageId { get; set; }
        public string? LanguageCode { get; set; }
        public string? LanguageName { get; set; }
        public virtual List<Book>? Books { get; set; }
    }
}
