using AutoMapper;
using BookStore.Data.Context;
using BookStore.Data.Entities;
using BookStore.DataAccessLayer.Infrastructure;
using BookStore.VModels.CustomerAddress;
using BookStore.VModels.CustomerOrder;
using BookStore.VModels.OrderHistory;
using BookStore.VModels.OrderLine;
using BookStore.Web.Area.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Web.Areas.Admin.Controllers
{
    public class OrderLineController : BaseAdminController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BookDbContext _bookDbContext;
        private readonly IMapper _mapper;

        public OrderLineController(IUnitOfWork unitOfWork, BookDbContext bookDbContext, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _bookDbContext = bookDbContext;
            _mapper = mapper;
        }

        public class OrderManager
        {
            public IList<CustomerOrder> CustomerOrderVModel { get; set; }
            public IList<OrderLine> OrderLineVModel { get; set; }
            public IList<OrderHistory> OrderHistoryVModel { get; set; }
            public IList<CustomerAddress> CustomerAddressVModel { get; set; }

        }
        public async Task<IActionResult> Index(string status = "All")
        {
            var orderLines = await _unitOfWork.OrderLineRepository.GetAll()
                .Include(ol => ol.Book)
                .Include(ol => ol.CustomerOrder)
                .ToListAsync();
            var orderHistories = await _unitOfWork.OrderHistoryRepository.GetAll()
                .Include(oh => oh.OrderStatus)
                .Include(oh => oh.CustomerOrder)
                .ToListAsync();
            var customerOrders = await _unitOfWork.CustomerOrderRepository.GetAll()
                .Include(co => co.Customer)
                .Include(co => co.ShippingMethod)
                .Include(co => co.OrderHistories)
                .Include(co => co.OrderLines)
                .ToListAsync();
            var customerAddresses = await _unitOfWork.CustomerAddressRepository.GetAll()
                .Include(ca => ca.Address)
                .Include(ca => ca.AddressStatus)
                .ToListAsync();

            // Lọc theo status nếu khác "All"
            if (!string.IsNullOrEmpty(status) && status != "All")
            {
                customerOrders = customerOrders
                    .Where(order =>
                    {
                        var latestStatus = order.OrderHistories?
                            .OrderByDescending(h => h.StatusDate)
                            .FirstOrDefault()?.OrderStatus?.StatusValue;
                        return string.Equals(latestStatus, status, StringComparison.OrdinalIgnoreCase);
                    })
                    .ToList();
            }
            else
            {
                // xắp sếp theo thứ tự Pending, Process, Shipped, Returned, Cancelled
                string[] statusOrder = { "Pending", "Processing", "Shipped", "Returned", "Cancelled" };

                customerOrders = customerOrders
                    .OrderBy(order =>
                    {
                        var latestStatus = order.OrderHistories?
                            .OrderByDescending(h => h.StatusDate)
                            .FirstOrDefault()?.OrderStatus?.StatusValue ?? "";
                        int idx = Array.FindIndex(statusOrder, s => s.Equals(latestStatus, StringComparison.OrdinalIgnoreCase));
                        return idx == -1 ? statusOrder.Length : idx;
                    })
                    .ThenByDescending(order => order.OrderDate)
                    .ToList();
            }

            var oderManager = new OrderManager
            {
                CustomerOrderVModel = customerOrders,
                OrderLineVModel = orderLines,
                OrderHistoryVModel = orderHistories,
                CustomerAddressVModel = customerAddresses
            };

            ViewBag.SelectedStatus = status;
            return View(oderManager);
        }

        public async Task<IActionResult> ChangeStatus(Guid orderId, string currentStatus, string newStatus)
        {
            var orderHistory = _unitOfWork.OrderHistoryRepository.GetAll()
                .Include(oh => oh.OrderStatus)
                .Where(oh => oh.OrderId == orderId)
                .FirstOrDefault();

            if (orderHistory != null)
            {
                var tmp = _unitOfWork.OrderStatusRepository.GetAll()
                    .FirstOrDefault(os => os.StatusValue == newStatus);
                if (tmp != null)
                {
                    orderHistory.StatusId = tmp.StatusId;
                }
                orderHistory.StatusDate = DateTime.Now;
                _unitOfWork.OrderHistoryRepository.Update(orderHistory);
                _unitOfWork.SaveChanges();
            }
            return RedirectToAction("Index", "OrderLine");
        }
    }
}