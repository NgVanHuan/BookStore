using AutoMapper;
using BookStore.Data.Entities;
using BookStore.DataAccessLayer.Infrastructure;
using BookStore.VModels.Books;
using BookStore.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
{
    public class BookDetailController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<HomeController> _logger;

        public BookDetailController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<HomeController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult Index(Guid bookId)
        {
            var book = _unitOfWork.BookRepository.GetByIdWithAll(bookId);
            if (book == null)
            {
                return NotFound();
            }
            var bookViewModel = _mapper.Map<BookViewModel>(book);
            var bookAuthor = _unitOfWork.BookAuthorRepository.GetAll().Where(ba => ba.BookId == bookViewModel.BookId).FirstOrDefault();
            if (bookAuthor == null)
            {
                return NotFound();
            }
            var author = _unitOfWork.AuthorRepository.GetById(bookAuthor.AuthorId);
            if (author == null)
            {
                return NotFound();
            }
            var bookCategory = _unitOfWork.CategoryRepository.GetById(bookViewModel.CategoryId);
            var releasedBook = _unitOfWork.BookRepository.GetAll().Where(b => b.CategoryId == bookCategory.CategoryId && b.BookId != bookViewModel.BookId).Take(4).ToList();
            var listReleasedBook = _mapper.Map<List<Book>, List<BookViewModel>>(releasedBook);
            var bookDetail = new BookDetailViewModel { BookDetail = bookViewModel, AuthorName = author.AuthorName, RelatedBooks = listReleasedBook };
            return View(bookDetail);
        }
    }
}
