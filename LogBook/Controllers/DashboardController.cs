using Microsoft.AspNetCore.Mvc;

namespace LogBook.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
