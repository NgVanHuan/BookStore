using AutoMapper;
using BookStore.Data.Context;
using BookStore.Data.Entities;
using BookStore.DataAccessLayer.Infrastructure;
using BookStore.VModels.Country;
using BookStore.Web.Area.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Web.Areas.Admin.Controllers
{
    public class CountryController : BaseAdminController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BookDbContext _bookDbContext;
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWork unitOfWork, BookDbContext bookDbContext, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _bookDbContext = bookDbContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var countries = await _unitOfWork.CountryRepository.GetAll().ToListAsync();
            var listCountry = _mapper.Map<IList<Country>, IList<CountryViewModel>>(countries);
            return View(listCountry);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                country.CountryId = Guid.NewGuid();
                _unitOfWork.CountryRepository.Add(country);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Data is not valid");
            return View(country);
        }

        public IActionResult Edit(Guid countryId)
        {
            var tmpCountry = _unitOfWork.CountryRepository.GetById(countryId);
            var country = _mapper.Map<Country, CountryViewModel>(tmpCountry);
            if (country == null)
            {
                return RedirectToAction("Index");
            }
            return View(country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Country country)
        {
            _unitOfWork.CountryRepository.Update(country);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid countryId) 
        {
            var country = _unitOfWork.CountryRepository.GetById(countryId);
            if (country == null) 
            {
                return NotFound();
            }
            _unitOfWork.CountryRepository.Remove(country);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}