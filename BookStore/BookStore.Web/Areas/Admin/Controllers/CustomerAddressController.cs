using AutoMapper;
using BookStore.Data.Context;
using BookStore.Data.Entities;
using BookStore.DataAccessLayer.Infrastructure;
using BookStore.VModels.CustomerAddress;
using BookStore.Web.Area.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Web.Areas.Admin.Controllers
{
    public class CustomerAddressController : BaseAdminController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BookDbContext _bookDbContext;
        private readonly IMapper _mapper;

        public CustomerAddressController(IUnitOfWork unitOfWork, BookDbContext bookDbContext, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _bookDbContext = bookDbContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var customerAddresses = await _unitOfWork.CustomerAddressRepository.GetAll()
                .Include(c => c.Customer)
                .Include(ad => ad.Address)
                .Include(ads => ads.AddressStatus)
                .ToListAsync();
            var listCustomerAddresses = _mapper.Map<IList<CustomerAddress>, IList<CustomerAddressViewModel>>(customerAddresses);
            return View(listCustomerAddresses);
        }
    }
}