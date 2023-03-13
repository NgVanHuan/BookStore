using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Area.Admin.Controllers
{
    public class AdminController : BaseAdminController
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
