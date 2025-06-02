using AutoMapper;
using BookStore.Data.Context;
using BookStore.Data.Entities;
using BookStore.DataAccessLayer.Infrastructure;
using BookStore.VModels.Publisher;
using BookStore.Web.Area.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Web.Areas.Admin.Controllers
{
    public class PublisherController : BaseAdminController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BookDbContext _bookDbContext;
        private readonly IMapper _mapper;

        public PublisherController(IUnitOfWork unitOfWork, BookDbContext bookDbContext, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _bookDbContext = bookDbContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var publishers = await _unitOfWork.PublisherRepository.GetAll().ToListAsync();
            var listPublisher = _mapper.Map<IList<Publisher>, IList<PublisherViewModel>>(publishers);
            return View(listPublisher);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                publisher.PublisherId = Guid.NewGuid();
                _unitOfWork.PublisherRepository.Add(publisher);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Data is not valid");
            return View(publisher);
        }

        public IActionResult Edit(Guid publisherId)
        {
            var tmpPublisher = _unitOfWork.PublisherRepository.GetById(publisherId);
            var publisher = _mapper.Map<Publisher, PublisherViewModel>(tmpPublisher);
            if (publisher == null)
            {
                return RedirectToAction("Index");
            }
            return View(publisher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Publisher publisher)
        {
            _unitOfWork.PublisherRepository.Update(publisher);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid publisherId) 
        {
            var publisher = _unitOfWork.PublisherRepository.GetById(publisherId);
            if (publisher == null) 
            {
                return NotFound();
            }
            _unitOfWork.PublisherRepository.Remove(publisher);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}