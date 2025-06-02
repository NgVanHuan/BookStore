using AutoMapper;
using BookStore.Data.Context;
using BookStore.Data.Entities;
using BookStore.DataAccessLayer.Infrastructure;
using BookStore.VModels.AddressStatus;
using BookStore.VModels.Publisher;
using BookStore.Web.Area.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Web.Areas.Admin.Controllers
{
    public class AddressStatusController : BaseAdminController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BookDbContext _bookDbContext;
        private readonly IMapper _mapper;

        public AddressStatusController(IUnitOfWork unitOfWork, BookDbContext bookDbContext, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _bookDbContext = bookDbContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var addressStatuses = await _unitOfWork.AddressStatusRepository.GetAll().ToListAsync();
            var listAddressStatus = _mapper.Map<IList<AddressStatus>, IList<AddressStatusViewModel>>(addressStatuses);
            return View(listAddressStatus);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddressStatusViewModel addressStatus)
        {
            if (ModelState.IsValid)
            {
                addressStatus.StatusId = Guid.NewGuid();
                var tmpAddressStatus = _mapper.Map<AddressStatusViewModel, AddressStatus>(addressStatus);
                _unitOfWork.AddressStatusRepository.Add(tmpAddressStatus);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Data is not valid");
            return View(addressStatus);
        }

        public IActionResult Edit(Guid statusId)
        {
            var tmpAddressStatus = _unitOfWork.AddressStatusRepository.GetById(statusId);
            var addressStatus = _mapper.Map<AddressStatus, AddressStatusViewModel>(tmpAddressStatus);
            if (tmpAddressStatus == null)
            {
                return RedirectToAction("Index");
            }
            return View(addressStatus);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AddressStatusViewModel addressStatus)
        {
            var tmpAddressStatus = _mapper.Map<AddressStatusViewModel, AddressStatus>(addressStatus);
            _unitOfWork.AddressStatusRepository.Update(tmpAddressStatus);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid statusId) 
        {
            var addressStatus = _unitOfWork.AddressStatusRepository.GetById(statusId);
            if (addressStatus == null) 
            {
                return NotFound();
            }
            _unitOfWork.AddressStatusRepository.Remove(addressStatus);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}