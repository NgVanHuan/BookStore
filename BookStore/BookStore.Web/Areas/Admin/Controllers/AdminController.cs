using AutoMapper;
using BookStore.Data.Context;
using BookStore.DataAccessLayer.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Web.Area.Admin.Controllers
{
    public class AdminController : BaseAdminController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BookDbContext _bookDbContext;
        private readonly IMapper _mapper;

        public AdminController(IUnitOfWork unitOfWork, BookDbContext bookDbContext, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _bookDbContext = bookDbContext;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var orderHistories = await _unitOfWork.OrderHistoryRepository.GetAll()
                .Include(oh => oh.OrderStatus)
                .Include(oh => oh.CustomerOrder)
                    .ThenInclude(co => co.OrderLines)
                        .ThenInclude(ol => ol.Book)
                .ToListAsync();

            var totalPending = orderHistories.Count(oh => oh.OrderStatus?.StatusValue == "Pending");
            ViewBag.TotalPending = totalPending;

            var totalProcessing = orderHistories.Count(oh => oh.OrderStatus?.StatusValue == "Processing");
            ViewBag.TotalProcessing = totalProcessing;

            //var customerOrders = await _unitOfWork.CustomerOrderRepository.GetAll()
            //    .Include(co => co.OrderLines)
            //    .Include(co => co.OrderHistories)
            //    .Include(co => co.OrderHistories.FirstOrDefault().OrderStatus)
            //    .ToListAsync();

            // Doanh thu theo tháng (Year-Month)
            var earningByMonth = orderHistories
                .Where(oh => oh.OrderStatus?.StatusValue == "Shipped")
                .GroupBy(oh => new { oh.StatusDate.Year, oh.StatusDate.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    TotalEarning = g.Sum(oh => oh.CustomerOrder.OrderLines.Sum(ol => (ol.Book.Price ?? 0) * ol.Quantity))
                })
                .OrderBy(x => x.Year).ThenBy(x => x.Month)
                .ToList();

            // Doanh thu theo năm
            var earningByYear = orderHistories
                .Where(oh => oh.OrderStatus?.StatusValue == "Shipped")
                .GroupBy(oh => oh.StatusDate.Year)
                .Select(g => new
                {
                    Year = g.Key,
                    TotalEarning = g.Sum(oh => oh.CustomerOrder.OrderLines.Sum(ol => (ol.Book.Price ?? 0) * ol.Quantity))
                })
                .OrderBy(x => x.Year)
                .ToList();

            ViewBag.EarningByMonth = earningByMonth;
            ViewBag.EarningByYear = earningByYear;

            return View();
        }
    }
}
