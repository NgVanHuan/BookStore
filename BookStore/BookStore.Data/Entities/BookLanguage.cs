using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class BookLanguage : EntityBase
    {
        public Guid LanguageId { get; set; }
        public string? LanguageCode { get; set; }
        public string? LanguageName { get; set; }
        public virtual IList<Book>? Books { get; set; }
    }
}
