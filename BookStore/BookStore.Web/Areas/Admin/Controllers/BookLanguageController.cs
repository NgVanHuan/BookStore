using AutoMapper;
using BookStore.Data.Context;
using BookStore.Data.Entities;
using BookStore.DataAccessLayer.Infrastructure;
using BookStore.VModels.BookLanguage;
using BookStore.Web.Area.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Web.Areas.Admin.Controllers
{
    public class BookLanguageController : BaseAdminController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BookDbContext _bookDbContext;
        private readonly IMapper _mapper;

        public BookLanguageController(IUnitOfWork unitOfWork, BookDbContext bookDbContext, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _bookDbContext = bookDbContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var bookLanguages = await _unitOfWork.BookLanguageRepository.GetAll().ToListAsync();
            var listBookLanguage = _mapper.Map<IList<BookLanguage>, IList<BookLanguageViewModel>>(bookLanguages);
            return View(listBookLanguage);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookLanguage bookLanguage)
        {
            if (ModelState.IsValid)
            {
                bookLanguage.LanguageId = Guid.NewGuid();
                _unitOfWork.BookLanguageRepository.Add(bookLanguage);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Data is not valid");
            return View(bookLanguage);
        }

        public IActionResult Edit(Guid bookLanguageId)
        {
            var tmpbookLanguages = _unitOfWork.BookLanguageRepository.GetById(bookLanguageId);
            var bookLanguages = _mapper.Map<BookLanguage, BookLanguageViewModel>(tmpbookLanguages);
            if (bookLanguages == null)
            {
                return RedirectToAction("Index");
            }
            return View(bookLanguages);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BookLanguage bookLanguage)
        {
            _unitOfWork.BookLanguageRepository.Update(bookLanguage);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid bookLanguageId) 
        {
            var bookLanguage = _unitOfWork.BookLanguageRepository.GetById(bookLanguageId);
            if (bookLanguage == null) 
            {
                return NotFound();
            }
            _unitOfWork.BookLanguageRepository.Remove(bookLanguage);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}