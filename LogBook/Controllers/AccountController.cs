using Microsoft.AspNetCore.Mvc;

namespace LogBook.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index() => View();
    }
}
