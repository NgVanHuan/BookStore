using AutoMapper;
using BookStore.Data.Context;
using BookStore.Data.Entities;
using BookStore.DataAccessLayer.Infrastructure;
using BookStore.VModels.BookAuthor;
using BookStore.Web.Area.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Web.Areas.Admin.Controllers
{
    public class BookAuthorController : BaseAdminController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BookDbContext _bookDbContext;
        private readonly IMapper _mapper;

        public BookAuthorController(IUnitOfWork unitOfWork, BookDbContext bookDbContext, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _bookDbContext = bookDbContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var bookAuthors = await _unitOfWork.BookAuthorRepository.GetAll()
                .Include(ba => ba.Book)
                .Include(ba => ba.Author)
                .ToListAsync();
            var listbookAuthor = _mapper.Map<IList<BookAuthor>, IList<BookAuthorViewModel>>(bookAuthors);
            return View(listbookAuthor);
        }

        public IActionResult Create()
        {
            ViewBag.AuthorList = _unitOfWork.AuthorRepository.GetAll().Select(c => new SelectListItem
            {
                Text = c.AuthorName,
                Value = c.AuthorId.ToString(),
            });
            ViewBag.BookList = _unitOfWork.BookRepository.GetAll().Select(c => new SelectListItem
            {
                Text = c.Title,
                Value = c.BookId.ToString(),
            });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookAuthorViewModel bookAuthor)
        {
            if (ModelState.IsValid)
            {
                var tmpBookAuthor = _mapper.Map<BookAuthorViewModel, BookAuthor>(bookAuthor);
                _unitOfWork.BookAuthorRepository.Add(tmpBookAuthor);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Data is not valid");
            return View(bookAuthor);
        }

        public IActionResult Delete(Guid bookId, Guid authorId)
        {
            var bookAuthor = _unitOfWork.BookAuthorRepository.GetAll().Where(ba => ba.AuthorId == authorId).Where(ba => ba.BookId == bookId).FirstOrDefault();
            //var bookAuthor = _unitOfWork.BookAuthorRepository.GetById(bookId, authorId);
            if (bookAuthor == null)
            {
                return NotFound();
            }
            _unitOfWork.BookAuthorRepository.Remove(bookAuthor);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
