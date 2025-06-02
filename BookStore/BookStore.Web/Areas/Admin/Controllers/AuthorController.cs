using AutoMapper;
using BookStore.Data.Context;
using BookStore.Data.Entities;
using BookStore.DataAccessLayer.Infrastructure;
using BookStore.VModels.Author;
using BookStore.Web.Area.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Web.Areas.Admin.Controllers
{
    public class AuthorController : BaseAdminController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BookDbContext _bookDbContext;
        private readonly IMapper _mapper;

        public AuthorController(IUnitOfWork unitOfWork, BookDbContext bookDbContext, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _bookDbContext = bookDbContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _unitOfWork.AuthorRepository.GetAll().ToListAsync();
            var listAuthor = _mapper.Map<IList<Author>, IList<AuthorViewModel>>(authors);
            return View(listAuthor);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                //author.CreatedTime = DateTime.UtcNow();
                author.AuthorId = Guid.NewGuid();
                _unitOfWork.AuthorRepository.Add(author);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Data is not valid");
            return View(author);
        }

        public IActionResult Edit(Guid authorId)
        {
            var tmpAuthor = _unitOfWork.AuthorRepository.GetById(authorId);
            var author = _mapper.Map<Author, AuthorViewModel>(tmpAuthor);
            if (author == null)
            {
                return RedirectToAction("Index");
            }
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Author author)
        {
            _unitOfWork.AuthorRepository.Update(author);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid authorId)
        {
            var author = _unitOfWork.AuthorRepository.GetById(authorId);
            if (author == null)
            {
                return NotFound();
            }
            _unitOfWork.AuthorRepository.Remove(author);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}