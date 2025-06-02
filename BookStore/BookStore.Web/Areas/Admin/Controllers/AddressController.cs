using AutoMapper;
using BookStore.Data.Context;
using BookStore.Data.Entities;
using BookStore.DataAccessLayer.Infrastructure;
using BookStore.VModels.Address;
using BookStore.Web.Area.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Web.Areas.Admin.Controllers
{
    public class AddressController : BaseAdminController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BookDbContext _bookDbContext;
        private readonly IMapper _mapper;

        public AddressController(IUnitOfWork unitOfWork, BookDbContext bookDbContext, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _bookDbContext = bookDbContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var addresses = await _unitOfWork.AddressRepository.GetAll().Include(a => a.Country).ToListAsync();
            var listAddress = _mapper.Map<IList<Address>, IList<AddressViewModel>>(addresses);
            return View(listAddress);
        }

        public IActionResult Create()
        {
            ViewBag.CountryList = _unitOfWork.CountryRepository.GetAll().Select(c => new SelectListItem
            {
                Text = c.CountryName,
                Value = c.CountryId.ToString(),
            });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Address address)
        {
            if (!ModelState.IsValid)
            {
                address.AddressId = Guid.NewGuid();
                _unitOfWork.AddressRepository.Add(address);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Data is not valid");
            return View(address);
        }

        public IActionResult Edit(Guid addressId)
        {
            var _addresses = _unitOfWork.AddressRepository.GetByIdWithCountry(addressId);
            var addresses = _mapper.Map<Address, AddressViewModel>(_addresses);
            // List Country to Select
            ViewBag.CountryList = _unitOfWork.CountryRepository.GetAll().Select(c => new SelectListItem
            {
                Text = c.CountryName,
                Value = c.CountryId.ToString(),
            });
            if (addresses == null)
            {
                return RedirectToAction("Index");
            }
            return View(addresses);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Address address)
        {
            _unitOfWork.AddressRepository.Update(address);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid addressId)
        {
            var address = _unitOfWork.AddressRepository.GetById(addressId);
            if (address == null)
            {
                return NotFound();
            }
            _unitOfWork.AddressRepository.Remove(address);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}