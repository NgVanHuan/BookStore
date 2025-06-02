using BookStore.VModels.Books;

namespace BookStore.Web.Models
{
    public class BookDetailViewModel
    {
        public BookViewModel BookDetail = new BookViewModel();
        public string AuthorName { get; set; }
        public List<BookViewModel> RelatedBooks { get; set; }
    }
}
