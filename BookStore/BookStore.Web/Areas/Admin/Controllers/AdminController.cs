using AutoMapper;
using BookStore.Data.Context;
using BookStore.DataAccessLayer.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Drawing;

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

        [HttpGet]
        public async Task<IActionResult> GenerateReport()
        {
            var orderHistories = await _unitOfWork.OrderHistoryRepository.GetAll()
                .Include(oh => oh.OrderStatus)
                .Include(oh => oh.CustomerOrder)
                    .ThenInclude(co => co.OrderLines)
                        .ThenInclude(ol => ol.Book)
                .Include(oh => oh.CustomerOrder)
                    .ThenInclude(co => co.Customer)
                .ToListAsync();

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

            // Lấy danh sách order history trong tháng hiện tại
            var now = DateTime.Now;
            var currentMonthOrders = orderHistories
                .Where(oh => oh.StatusDate.Year == now.Year && oh.StatusDate.Month == now.Month)
                .OrderBy(oh => oh.OrderStatus != null ? oh.OrderStatus.StatusValue : "")
                .ToList();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var package = new ExcelPackage();

            // Sheet 1: OrderHistory (mỗi dòng là 1 order line)
            var wsOrder = package.Workbook.Worksheets.Add("OrderHistory");
            wsOrder.Cells[1, 1].Value = "OrderId";
            wsOrder.Cells[1, 2].Value = "StatusDate";
            wsOrder.Cells[1, 3].Value = "Customer";
            wsOrder.Cells[1, 4].Value = "Book Title";
            wsOrder.Cells[1, 5].Value = "Quantity";
            wsOrder.Cells[1, 6].Value = "Price";
            wsOrder.Cells[1, 7].Value = "TotalValue";
            wsOrder.Cells[1, 8].Value = "Status";
            using (var range = wsOrder.Cells[1, 1, 1, 8])
            {
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
            }
            int rowOrder = 2;
            foreach (var oh in currentMonthOrders)
            {
                var customer = oh.CustomerOrder?.Customer;
                var customerName = (customer?.FirstName ?? "") + " " + (customer?.LastName ?? "");
                var status = oh.OrderStatus?.StatusValue ?? "";
                var statusDate = oh.StatusDate.ToString("yyyy-MM-dd HH:mm");
                var orderId = oh.CustomerOrder?.OrderId.ToString() ?? "";

                if (oh.CustomerOrder?.OrderLines != null)
                {
                    foreach (var ol in oh.CustomerOrder.OrderLines)
                    {
                        var bookTitle = ol.Book?.Title ?? "";
                        var quantity = ol.Quantity;
                        var price = ol.Price;
                        var totalValue = price * quantity;

                        wsOrder.Cells[rowOrder, 1].Value = orderId;
                        wsOrder.Cells[rowOrder, 2].Value = statusDate;
                        wsOrder.Cells[rowOrder, 3].Value = customerName.Trim();
                        wsOrder.Cells[rowOrder, 4].Value = bookTitle;
                        wsOrder.Cells[rowOrder, 5].Value = quantity;
                        wsOrder.Cells[rowOrder, 6].Value = price;
                        wsOrder.Cells[rowOrder, 6].Style.Numberformat.Format = "#,##0.00";
                        wsOrder.Cells[rowOrder, 7].Value = totalValue;
                        wsOrder.Cells[rowOrder, 7].Style.Numberformat.Format = "#,##0.00";
                        wsOrder.Cells[rowOrder, 8].Value = status;
                        rowOrder++;
                    }
                }
            }
            wsOrder.Cells[wsOrder.Dimension.Address].AutoFitColumns();

            // Sheet 2: EarningsByMonth
            var wsMonth = package.Workbook.Worksheets.Add("EarningsByMonth");
            wsMonth.Cells[1, 1].Value = "Year";
            wsMonth.Cells[1, 2].Value = "Month";
            wsMonth.Cells[1, 3].Value = "Total Earning";
            using (var range = wsMonth.Cells[1, 1, 1, 3])
            {
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
            }
            int row = 2;
            foreach (var item in earningByMonth)
            {
                wsMonth.Cells[row, 1].Value = item.Year;
                wsMonth.Cells[row, 2].Value = item.Month;
                wsMonth.Cells[row, 3].Value = item.TotalEarning;
                wsMonth.Cells[row, 3].Style.Numberformat.Format = "#,##0.00";
                row++;
            }
            wsMonth.Cells[wsMonth.Dimension.Address].AutoFitColumns();

            // Sheet 3: EarningsByYear
            var wsYear = package.Workbook.Worksheets.Add("EarningsByYear");
            wsYear.Cells[1, 1].Value = "Year";
            wsYear.Cells[1, 2].Value = "Total Earning";
            using (var range = wsYear.Cells[1, 1, 1, 2])
            {
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
            }
            int rowYear = 2;
            foreach (var item in earningByYear)
            {
                wsYear.Cells[rowYear, 1].Value = item.Year;
                wsYear.Cells[rowYear, 2].Value = item.TotalEarning;
                wsYear.Cells[rowYear, 2].Style.Numberformat.Format = "#,##0.00";
                rowYear++;
            }
            wsYear.Cells[wsYear.Dimension.Address].AutoFitColumns();

            var stream = new MemoryStream();
            package.SaveAs(stream);
            stream.Position = 0;

            string fileName = $"EarningsReport_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}
