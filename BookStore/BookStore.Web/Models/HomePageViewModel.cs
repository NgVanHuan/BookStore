using BookStore.VModels.Books;
using static BookStore.Web.Controllers.HomeController;

namespace BookStore.Web.Models
{
    public class HomePageViewModel
    {
        public IList<BookViewModel> Books { get; set; }
        public IList<FeatureCategory> FeatureCategories { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
