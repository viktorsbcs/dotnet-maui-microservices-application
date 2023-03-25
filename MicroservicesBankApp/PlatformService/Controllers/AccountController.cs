using Microsoft.AspNetCore.Mvc;

namespace PlatformService.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
