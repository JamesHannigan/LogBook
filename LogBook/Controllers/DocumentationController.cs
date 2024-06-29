using Microsoft.AspNetCore.Mvc;

namespace LogBook.Controllers
{
    public class DocumentationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
