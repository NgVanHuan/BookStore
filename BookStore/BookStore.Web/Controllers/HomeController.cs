using AutoMapper;
using BookStore.Data.Context;
using BookStore.Data.Entities;
using BookStore.DataAccessLayer.Infrastructure;
using BookStore.VModels.Books;
using BookStore.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BookStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private const string CartSessionKey = "Cart";
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<HomeController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public class FeatureCategory
        {
            public int Number { get; set; }
            public Guid CategoryId { get; set; }
            public string CategoryName { get; set; }
        }

        public async Task<IActionResult> Index(int page = 1, Guid? categoryId = null)
        {
            const int pageSize = 4;

            // Lấy toàn bộ category
            var allCategories = await _unitOfWork.CategoryRepository
                .GetAll()
                .ToListAsync();

            var featureCategories = new List<FeatureCategory>();

            // Tính số lượng sách theo từng category
            foreach (var category in allCategories)
            {
                int bookCount = await _unitOfWork.BookRepository
                    .GetAll()
                    .CountAsync(b => b.CategoryId == category.CategoryId);

                if (bookCount > 0)
                {
                    featureCategories.Add(new FeatureCategory
                    {
                        CategoryId = category.CategoryId,
                        CategoryName = category.CategoryName,
                        Number = bookCount
                    });
                }
            }

            // Sắp xếp giảm dần theo số lượng sách
            var sortedCategories = featureCategories
                .OrderByDescending(fc => fc.Number)
                .ToList();

            // Phân trang
            int totalCategories = sortedCategories.Count;
            int totalPages = (int)Math.Ceiling(totalCategories / (double)pageSize);
            var pagedCategories = sortedCategories
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Lấy danh sách sách theo category nếu có
            var booksQuery = _unitOfWork.BookRepository.GetAll()
                .Include(b => b.Category)
                .Include(b => b.BookLanguage)
                .Include(b => b.Publisher)
                .Include(b => b.BookAuthors)
                .Where(b => b.IsDeleted == false);

            if (categoryId.HasValue && categoryId.Value != Guid.Empty)
            {
                booksQuery = booksQuery.Where(b => b.CategoryId == categoryId.Value);
            }

            var books = await booksQuery
                .OrderBy(b => Guid.NewGuid())
                .Take(24)
                .ToListAsync();

            var listBook = _mapper.Map<IList<Book>, IList<BookViewModel>>(books);

            var viewModel = new HomePageViewModel
            {
                Books = listBook,
                FeatureCategories = pagedCategories,
                CurrentPage = page,
                TotalPages = totalPages
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult SearchBooks(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                // Trả về tất cả sách nếu không có query
                var allBooks = _unitOfWork.BookRepository
                    .GetAll()
                    .Where(b => !b.IsDeleted)
                    .OrderBy(b => Guid.NewGuid())
                    .Take(24)
                    .Select(b => new
                    {
                        b.BookId,
                        b.Title,
                        b.ImageName,
                        b.Price
                    })
                    .ToList();
                return Json(allBooks);
            }

            query = query.ToLower();

            var booksQuery = _unitOfWork.BookRepository
                .GetAll()
                .Include(b => b.Category)
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                .Where(b => !b.IsDeleted);

            var books = booksQuery
                .Where(b =>
                    b.Title.ToLower().Contains(query) ||
                    b.Category.CategoryName.ToLower().Contains(query) ||
                    b.BookAuthors.Any(ba => ba.Author.AuthorName.ToLower().Contains(query))
                )
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.ImageName,
                    b.Price
                })
                .Take(24)
                .ToList();

            return Json(books);
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedCategories(int page = 1)
        {
            const int pageSize = 4;

            var allCategories = await _unitOfWork.CategoryRepository
                .GetAll()
                .ToListAsync();

            var featureCategories = new List<FeatureCategory>();

            foreach (var category in allCategories)
            {
                int bookCount = await _unitOfWork.BookRepository
                    .GetAll()
                    .CountAsync(b => b.CategoryId == category.CategoryId);

                if (bookCount > 0)
                {
                    featureCategories.Add(new FeatureCategory
                    {
                        CategoryId = category.CategoryId,
                        CategoryName = category.CategoryName,
                        Number = bookCount
                    });
                }
            }

            var sortedCategories = featureCategories
                .OrderByDescending(fc => fc.Number)
                .ToList();

            int totalCategories = sortedCategories.Count;
            int totalPages = (int)Math.Ceiling(totalCategories / (double)pageSize);
            var pagedCategories = sortedCategories
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Json(new
            {
                categories = pagedCategories,
                currentPage = page,
                totalPages = totalPages
            });
        }

        [HttpGet]
        public IActionResult GetBooksByCategory(Guid categoryId)
        {
            var books = _unitOfWork.BookRepository
                .GetAll()
                .Where(b => b.CategoryId == categoryId && !b.IsDeleted)
                .OrderBy(b => Guid.NewGuid())
                .Take(24)
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.ImageName,
                    b.Price
                })
                .ToList();

            return Json(books);
        }

        // Thêm sản phẩm vào giỏ hàng
        [HttpPost]
        public IActionResult AddToCart(Guid bookId)
        {
            var cart = HttpContext.Session.GetString(CartSessionKey);
            var cartItems = string.IsNullOrEmpty(cart) ? new List<Guid>() : JsonConvert.DeserializeObject<List<Guid>>(cart);

            if (!cartItems.Contains(bookId))
            {
                cartItems.Add(bookId);
                HttpContext.Session.SetString(CartSessionKey, JsonConvert.SerializeObject(cartItems));
            }

            return Json(new { success = true, count = cartItems.Count });
        }

        // Lấy số lượng sản phẩm trong giỏ hàng
        public IActionResult GetCartCount()
        {
            var cart = HttpContext.Session.GetString(CartSessionKey);
            var cartItems = string.IsNullOrEmpty(cart) ? new List<Guid>() : JsonConvert.DeserializeObject<List<Guid>>(cart);
            return Json(new { count = cartItems.Count });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}