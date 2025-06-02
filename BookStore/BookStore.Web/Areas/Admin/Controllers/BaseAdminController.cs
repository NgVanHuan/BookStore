using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Area.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")] // Only allow access to users in the "Admin" role
    public class BaseAdminController : Controller
    {
        
    }
}
