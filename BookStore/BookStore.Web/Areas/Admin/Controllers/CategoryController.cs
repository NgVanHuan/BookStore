using AutoMapper;
using BookStore.Data.Context;
using BookStore.Data.Entities;
using BookStore.DataAccessLayer.Infrastructure;
using BookStore.VModels.Category;
using BookStore.Web.Area.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Web.Areas.Admin.Controllers
{
    public class CategoryController : BaseAdminController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BookDbContext _bookDbContext;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unitOfWork, BookDbContext bookDbContext, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _bookDbContext = bookDbContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _unitOfWork.CategoryRepository.GetAll().ToListAsync();
            var listCategory = _mapper.Map<IList<Category>, IList<CategoryViewModel>>(categories);
            return View(listCategory);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                category.CategoryId = Guid.NewGuid();
                _unitOfWork.CategoryRepository.Add(category);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Data is not valid");
            return View(category);
        }

        public IActionResult Edit(Guid categoryId)
        {
            var tmpCategory = _unitOfWork.CategoryRepository.GetById(categoryId);
            var category = _mapper.Map<Category, CategoryViewModel>(tmpCategory);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            _unitOfWork.CategoryRepository.Update(category);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid categoryId) 
        {
            var category = _unitOfWork.CategoryRepository.GetById(categoryId);
            if (category == null) 
            {
                return NotFound();
            }
            _unitOfWork.CategoryRepository.Remove(category);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}