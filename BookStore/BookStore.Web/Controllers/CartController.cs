using BookStore.Data.Context;
using BookStore.Data.Entities;
using BookStore.DataAccessLayer.Infrastructure;
using BookStore.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookStore.Web.Controllers
{
    public class CartController : Controller
    {
        private const string CartSessionKey = "Cart";
        private readonly IUnitOfWork _unitOfWork;
        private readonly BookDbContext _dbContext;

        public CartController(IUnitOfWork unitOfWork, BookDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
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

        // Hiển thị giỏ hàng
        public IActionResult Index()
        {
            List<CartItem> cartList = new List<CartItem>();
            var cart = HttpContext.Session.GetString(CartSessionKey);
            var cartItems = string.IsNullOrEmpty(cart) ? new List<Guid>() : JsonConvert.DeserializeObject<List<Guid>>(cart);

            // Đếm số lượng theo từng bookId
            var quantityMap = cartItems
                .GroupBy(id => id)
                .ToDictionary(g => g.Key, g => g.Count());

            var books = _unitOfWork.BookRepository.GetAll()
                .Where(b => cartItems.Contains(b.BookId))
                .ToList();

            // Tạo danh sách Cart với số lượng
            cartList = books.Select(book => new CartItem
            {
                Books = book,
                Quantity = quantityMap[book.BookId]
            }).ToList();

            // Tính tổng tiền
            decimal total = cartList.Sum(b => (b.Books.Price ?? 0) * b.Quantity);

            // Tính giảm giá
            decimal discountPercent = 0;
            if (total >= 30)
            {
                discountPercent = Math.Min(10, 5 + (int)((total - 30) / 10) * 1);
            }
            decimal discountAmount = total * (discountPercent / 100);
            decimal totalAfterDiscount = total - discountAmount;

            ViewBag.Total = total;
            ViewBag.DiscountPercent = discountPercent;
            ViewBag.DiscountAmount = discountAmount;
            ViewBag.TotalAfterDiscount = totalAfterDiscount;

            return View(cartList);
        }

        // Thêm vào giỏ hàng
        public IActionResult AddToCart(Guid bookId)
        {
            var cart = HttpContext.Session.GetString(CartSessionKey);
            var cartItems = string.IsNullOrEmpty(cart) ? new List<Guid>() : JsonConvert.DeserializeObject<List<Guid>>(cart);

            cartItems.Add(bookId);

            HttpContext.Session.SetString(CartSessionKey, JsonConvert.SerializeObject(cartItems));

            return RedirectToAction("Index");
        }

        // Xoa SP khoi gio hang
        public IActionResult RemoveFromCart(Guid bookId)
        {
            var cart = HttpContext.Session.GetString(CartSessionKey);
            var cartItems = string.IsNullOrEmpty(cart) ? new List<Guid>() : JsonConvert.DeserializeObject<List<Guid>>(cart);
            cartItems.Remove(bookId);

            HttpContext.Session.SetString(CartSessionKey, JsonConvert.SerializeObject(cartItems));

            return RedirectToAction("Index");
        }

        public IActionResult CheckOutAndClear()
        {
            List<CartItem> cartList = new List<CartItem>();
            var cart = HttpContext.Session.GetString(CartSessionKey);
            var cartItems = string.IsNullOrEmpty(cart) ? new List<Guid>() : JsonConvert.DeserializeObject<List<Guid>>(cart);

            // Đếm số lượng theo từng bookId
            var quantityMap = cartItems
                .GroupBy(id => id)
                .ToDictionary(g => g.Key, g => g.Count());

            var books = _unitOfWork.BookRepository.GetAll()
                .Where(b => cartItems.Contains(b.BookId))
                .ToList();

            // Tạo danh sách Cart với số lượng
            cartList = books.Select(book => new CartItem
            {
                Books = book,
                Quantity = quantityMap[book.BookId]
            }).ToList();

            var customerId = GetCurrentCustomerId();
            if (customerId != null)
            {
                var customerAddress = _unitOfWork.CustomerAddressRepository.GetAll()
                    .FirstOrDefault(c => c.CustomerId == customerId.Value);
                if (customerAddress == null)
                {
                    return RedirectToPage("/Account/Manage/Index", new { area = "Identity" });
                }
                var shippingMethodId = _dbContext.ShippingMethods.FirstOrDefault(sm => sm.Code == 1).MethodId;
                var customer = _unitOfWork.CustomerRepository.GetById(customerId.Value);
                var customerOrder = new CustomerOrder
                {
                    OrderId = Guid.NewGuid(),
                    CustomerId = customer.CustomerId,
                    OrderDate = DateTime.Now,
                    ShippingMethodId = shippingMethodId,
                    DestAddressId = customerAddress.AddressId,
                    CreatedTime = DateTime.Now,
                };
                _unitOfWork.CustomerOrderRepository.Add(customerOrder);
                _unitOfWork.SaveChanges();

                var orderLines = new List<OrderLine>();
                foreach (var item in cartList)
                {
                    var orderLine = new OrderLine
                    {
                        LineId = Guid.NewGuid(),
                        OrderId = customerOrder.OrderId,
                        BookId = item.Books.BookId,
                        Quantity = item.Quantity,
                        Price = item.Books.Price ?? 0,
                        CreatedTime = DateTime.Now
                    };
                    orderLines.Add(orderLine);
                    _unitOfWork.OrderLineRepository.Add(orderLine);
                }
                _unitOfWork.SaveChanges();

                var orderHistory = new OrderHistory
                {
                    HistoryId = new Guid(),
                    OrderId = customerOrder.OrderId,
                    StatusDate = DateTime.Now,
                    CreatedTime = DateTime.Now,
                    StatusId = _unitOfWork.OrderStatusRepository.GetAll().FirstOrDefault(os => os.StatusValue == "Pending").StatusId,
                };
                _unitOfWork.OrderHistoryRepository.Add(orderHistory);
                _unitOfWork.SaveChanges();

                // Xóa giỏ hàng sau khi đặt hàng thành công
                HttpContext.Session.Remove(CartSessionKey);
                TempData["SuccessMessage"] = "Your order has been placed successfully! Thank you for your purchase.";
                return RedirectToAction("Index", "OrderHistory");
            }
            else
            {
                // Nếu không có customerId, có thể redirect đến trang đăng nhập hoặc thông báo lỗi
                TempData["ErrorMessage"] = "You need to log in to place an order.";
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
        }
    }
}
