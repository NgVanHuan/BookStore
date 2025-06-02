using AutoMapper;
using BookStore.Data.Entities;
using BookStore.DataAccessLayer.Infrastructure;
using BookStore.VModels.Books;
using BookStore.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Web.Controllers
{
    public class OrderHistoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<HomeController> _logger;

        public OrderHistoryController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<HomeController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        private Guid? GetCurrentCustomerId()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userName = User.Identity.Name;
                var customer = _unitOfWork.CustomerRepository.GetAll().FirstOrDefault(c => c.Email == userName);
                return customer?.CustomerId;
            }
            return null;
        }
        public class OrderHistoryViewModel
        {
            public IList<CustomerOrder> CustomerOrders { get; set; }
            public IList<OrderLine> OrderLines { get; set; }
            public IList<OrderHistory> OrderHistories { get; set; }
        }
        public async Task<IActionResult> Index(Guid bookId)
        {
            var currentCustomerId = GetCurrentCustomerId();
            // Kiểm tra xem người dùng đã đăng nhập hay chưa
            if (currentCustomerId == null)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            var customerOrders = await _unitOfWork.CustomerOrderRepository.GetAll()
            .Where(o => o.CustomerId == currentCustomerId.Value)
            .ToListAsync();

            var orderLines = await _unitOfWork.OrderLineRepository.GetAll()
                .Where(ol => customerOrders.Select(o => o.OrderId).Contains(ol.OrderId))
                .Include(ol => ol.Book)
                .ToListAsync();

            var orderHistories = await _unitOfWork.OrderHistoryRepository.GetAll()
                .Where(oh => customerOrders.Select(o => o.OrderId).Contains(oh.OrderId))
                .Include(oh => oh.OrderStatus)
                .ToListAsync();

            var orderHistoryViewModel = new OrderHistoryViewModel
            {
                CustomerOrders = customerOrders,
                OrderLines = orderLines,
                OrderHistories = orderHistories
            };

            return View(orderHistoryViewModel);
        }
        public async Task<IActionResult> ChangeReturned(Guid orderId)
        {
            var orderHistory = await _unitOfWork.OrderHistoryRepository.GetAll()
                .FirstOrDefaultAsync(oh => oh.OrderId == orderId);
            if (orderHistory != null)
            {
                var tmp = _unitOfWork.OrderStatusRepository.GetAll()
                    .FirstOrDefault(os => os.StatusValue == "Returned");
                if (tmp != null)
                {
                    orderHistory.StatusId = tmp.StatusId;
                }
                orderHistory.StatusDate = DateTime.Now;
                _unitOfWork.OrderHistoryRepository.Update(orderHistory);
                _unitOfWork.SaveChanges();
            }
            return RedirectToAction("Index", "OrderHistory");
        }
        public async Task<IActionResult> ChangeCancelReturned(Guid orderId)
        {
            var orderHistory = await _unitOfWork.OrderHistoryRepository.GetAll()
                .FirstOrDefaultAsync(oh => oh.OrderId == orderId);
            if (orderHistory != null)
            {
                var tmp = _unitOfWork.OrderStatusRepository.GetAll()
                    .FirstOrDefault(os => os.StatusValue == "Shipped");
                if (tmp != null)
                {
                    orderHistory.StatusId = tmp.StatusId;
                }
                orderHistory.StatusDate = DateTime.Now;
                _unitOfWork.OrderHistoryRepository.Update(orderHistory);
                _unitOfWork.SaveChanges();
            }
            return RedirectToAction("Index", "OrderHistory");
        }
        public async Task<IActionResult> ChangeCancelled(Guid orderId)
        {
            var orderHistory = await _unitOfWork.OrderHistoryRepository.GetAll()
                .FirstOrDefaultAsync(oh => oh.OrderId == orderId);
            if (orderHistory != null)
            {
                var tmp = _unitOfWork.OrderStatusRepository.GetAll()
                    .FirstOrDefault(os => os.StatusValue == "Cancelled");
                if (tmp != null)
                {
                    orderHistory.StatusId = tmp.StatusId;
                }
                orderHistory.StatusDate = DateTime.Now;
                _unitOfWork.OrderHistoryRepository.Update(orderHistory);
                _unitOfWork.SaveChanges();
            }
            return RedirectToAction("Index", "OrderHistory");
        }
        public async Task<IActionResult> ChangeContinue(Guid orderId)
        {
            var orderHistory = await _unitOfWork.OrderHistoryRepository.GetAll()
                .FirstOrDefaultAsync(oh => oh.OrderId == orderId);
            if (orderHistory != null)
            {
                var tmp = _unitOfWork.OrderStatusRepository.GetAll()
                    .FirstOrDefault(os => os.StatusValue == "Pending");
                if (tmp != null)
                {
                    orderHistory.StatusId = tmp.StatusId;
                }
                orderHistory.StatusDate = DateTime.Now;
                _unitOfWork.OrderHistoryRepository.Update(orderHistory);
                _unitOfWork.SaveChanges();
            }
            return RedirectToAction("Index", "OrderHistory");
        }
        
    }
}
