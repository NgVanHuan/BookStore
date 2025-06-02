using AutoMapper;
using BookStore.Data.Context;
using BookStore.Data.Entities;
using BookStore.DataAccessLayer.Infrastructure;
using BookStore.VModels.Address;
using BookStore.VModels.Books;
using BookStore.Web.Area.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookStore.Web.Areas.Admin.Controllers
{
    public class BookController : BaseAdminController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BookDbContext _bookDbContext;
        private readonly IMapper _mapper;

        public BookController(IUnitOfWork unitOfWork, BookDbContext bookDbContext, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _bookDbContext = bookDbContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _unitOfWork.BookRepository.GetAll()
                .Include(b => b.Category)
                .Include(b => b.BookLanguage)
                .Include(b => b.Publisher)
                .Where(b => b.IsDeleted == false)
                .ToListAsync();
            var listBooks = _mapper.Map<IList<Book>, IList<BookViewModel>>(books);

            foreach (var book in listBooks)
            {
                var bookAuthors = _unitOfWork.BookAuthorRepository.GetAll()
                    .Include(ba => ba.Author)
                    .Where(ba => ba.BookId == book.BookId)
                    .ToList();
                var authorNames = string.Join(", ", bookAuthors.Select(ba => ba.Author.AuthorName));
                book.AuthorNames = authorNames;
            }
            return View(listBooks);
        }

        public IActionResult Create()
        {
            ViewBag.CategoryList = _unitOfWork.CategoryRepository.GetAll().Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.CategoryId.ToString(),
            });
            ViewBag.BookLanguageList = _unitOfWork.BookLanguageRepository.GetAll().Select(c => new SelectListItem
            {
                Text = c.LanguageName,
                Value = c.LanguageId.ToString(),
            });
            ViewBag.PublisherList = _unitOfWork.PublisherRepository.GetAll().Select(c => new SelectListItem
            {
                Text = c.PublisherName,
                Value = c.PublisherId.ToString(),
            });
            ViewBag.AuthorList = _unitOfWork.AuthorRepository.GetAll().Select(c => new SelectListItem
            {
                Text = c.AuthorName,
                Value = c.AuthorId.ToString(),
            });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateBookViewModel createBook)
        {
            if (!ModelState.IsValid)
            {
                var tmpBook = _mapper.Map<BookViewModel, Book>(createBook.BookVModel);
                // Xử lý lưu ảnh
                if (createBook.BookVModel.ImageFile != null)
                {
                    var fileName = Path.GetFileName(createBook.BookVModel.ImageFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/book", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        createBook.BookVModel.ImageFile.CopyTo(stream);
                    }
                    tmpBook.ImageName = fileName;
                    tmpBook.ImageUrl = $"/img/book/{fileName}";
                }
                tmpBook.BookId = Guid.NewGuid();
                _unitOfWork.BookRepository.Add(tmpBook);
                _unitOfWork.SaveChanges();

                // Save book authors
                if (createBook.AuthorIds != null && createBook.AuthorIds.Count > 0)
                {
                    foreach (var authorId in createBook.AuthorIds)
                    {
                        var bookAuthor = new BookAuthor
                        {
                            BookId = tmpBook.BookId,
                            AuthorId = authorId
                        };
                        _unitOfWork.BookAuthorRepository.Add(bookAuthor);
                    }
                    _unitOfWork.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            // Repopulate dropdowns if validation fails
            ViewBag.CategoryList = _unitOfWork.CategoryRepository.GetAll().Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.CategoryId.ToString(),
            });
            ViewBag.BookLanguageList = _unitOfWork.BookLanguageRepository.GetAll().Select(c => new SelectListItem
            {
                Text = c.LanguageName,
                Value = c.LanguageId.ToString(),
            });
            ViewBag.PublisherList = _unitOfWork.PublisherRepository.GetAll().Select(c => new SelectListItem
            {
                Text = c.PublisherName,
                Value = c.PublisherId.ToString(),
            });
            ViewBag.AuthorList = _unitOfWork.AuthorRepository.GetAll().Select(c => new SelectListItem
            {
                Text = c.AuthorName,
                Value = c.AuthorId.ToString(),
            });
            return View(createBook);
        }

        public IActionResult Edit(Guid bookId)
        {
            var _book = _unitOfWork.BookRepository.GetById(bookId);
            var bookViewModel = _mapper.Map<Book, BookViewModel>(_book);
            bookViewModel.ImageUrl = "/img/book/" + bookViewModel.ImageName; 
            // List Country to Select
            ViewBag.CategoryList = _unitOfWork.CategoryRepository.GetAll().Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.CategoryId.ToString(),
            });
            ViewBag.BookLanguageList = _unitOfWork.BookLanguageRepository.GetAll().Select(c => new SelectListItem
            {
                Text = c.LanguageName,
                Value = c.LanguageId.ToString(),
            });
            ViewBag.PublisherList = _unitOfWork.PublisherRepository.GetAll().Select(c => new SelectListItem
            {
                Text = c.PublisherName,
                Value = c.PublisherId.ToString(),
            });
            ViewBag.AuthorList = _unitOfWork.AuthorRepository.GetAll().Select(c => new SelectListItem
            {
                Text = c.AuthorName,
                Value = c.AuthorId.ToString(),
            });

            if (bookViewModel == null)
            {
                return RedirectToAction("Index");
            }

            var authorIds = _unitOfWork.BookAuthorRepository.GetAll().Where(ba => ba.BookId == bookViewModel.BookId).Select(ba => ba.AuthorId).ToList();
            var updateBook = new CreateBookViewModel { BookVModel = bookViewModel, AuthorIds = authorIds };
            return View(updateBook);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CreateBookViewModel updateBook)
        {
            var book = updateBook.BookVModel;
            var tmpBook = _mapper.Map<BookViewModel, Book>(book);
            // Xử lý lưu ảnh
            if (book.ImageFile != null)
            {
                var fileName = Path.GetFileName(book.ImageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/book", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    book.ImageFile.CopyTo(stream);
                }
                tmpBook.ImageName = fileName;
                tmpBook.ImageUrl = $"/img/book/{fileName}";
            }

            foreach (var authorId in updateBook.AuthorIds)
            {
                var bookAuthor = _unitOfWork.BookAuthorRepository.GetAll().Where(ba => ba.AuthorId == authorId).Where(ba => ba.BookId == updateBook.BookVModel.BookId).FirstOrDefault();
                if (bookAuthor != null) 
                {
                    // Nếu đã tồn tại thì không thêm mới
                    continue;
                }
                else
                {
                    // Nếu chưa tồn tại thì thêm mới
                    var newBookAuthor = new BookAuthor
                    {
                        BookId = tmpBook.BookId,
                        AuthorId = authorId
                    };
                    _unitOfWork.BookAuthorRepository.Add(newBookAuthor);
                }
            }
            // Xóa các tác giả không còn liên quan đến sách
            var existingBookAuthors = _unitOfWork.BookAuthorRepository.GetAll().Where(ba => ba.BookId == tmpBook.BookId).ToList();
            foreach (var existingBookAuthor in existingBookAuthors)
            {
                if (!updateBook.AuthorIds.Contains(existingBookAuthor.AuthorId))
                {
                    _unitOfWork.BookAuthorRepository.Remove(existingBookAuthor);
                }
            }

            _unitOfWork.BookRepository.Update(tmpBook);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid bookId)
        {
            var book = _unitOfWork.BookRepository.GetById(bookId);
            if (book == null)
            {
                return NotFound();
            }
            //_unitOfWork.BookRepository.Remove(book);
            book.IsDeleted = true;
            _unitOfWork.BookRepository.Update(book);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
