using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogBook.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public IActionResult Index() => View();
    }
}
