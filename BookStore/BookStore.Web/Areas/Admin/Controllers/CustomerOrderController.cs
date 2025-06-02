using AutoMapper;
using BookStore.Data.Context;
using BookStore.Data.Entities;
using BookStore.DataAccessLayer.Infrastructure;
using BookStore.VModels.CustomerOrder;
using BookStore.Web.Area.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Web.Areas.Admin.Controllers
{
    public class CustomerOrderController : BaseAdminController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BookDbContext _bookDbContext;
        private readonly IMapper _mapper;

        public CustomerOrderController(IUnitOfWork unitOfWork, BookDbContext bookDbContext, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _bookDbContext = bookDbContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var orderLines = await _unitOfWork.CustomerOrderRepository.GetAll()
                .Include(co => co.Customer)
                .Include(co => co.OrderLines)
                .ToListAsync();
            var listOrderLines = _mapper.Map<IList<CustomerOrder>, IList<CustomerOrderViewModel>>(orderLines);
            return View(listOrderLines);
        }

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(OrderStatus orderStatus)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.OrderStatusRepository.Add(orderStatus);
        //        _unitOfWork.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ModelState.AddModelError("", "Data is not valid");
        //    return View(orderStatus);
        //}

        //public IActionResult Edit(int statusId)
        //{
        //    var orderStatus = _unitOfWork.OrderStatusRepository.GetById(statusId);
        //    if (orderStatus == null)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View(orderStatus);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(OrderStatus orderStatus)
        //{
        //    _unitOfWork.OrderStatusRepository.Update(orderStatus);
        //    _unitOfWork.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //public IActionResult Delete(int statusId)
        //{
        //    var orderStatus = _unitOfWork.OrderStatusRepository.GetById(statusId);
        //    if (orderStatus == null)
        //    {
        //        return NotFound();
        //    }
        //    _unitOfWork.OrderStatusRepository.Remove(orderStatus);
        //    _unitOfWork.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}