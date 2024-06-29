using LogBook.BusinessLogic.Interface.Data;
using Microsoft.AspNetCore.Mvc;

namespace LogBook.Controllers
{
    public class SystemController : Controller
    {
        private readonly IActivityService _activityService;
        public SystemController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        public IActionResult Index() => View();

        [HttpPost]
        public Task RecordPageLoad(string path) => _activityService.LogActivity(1, $"{path} visited by Developer", null, "Developer", null, path);

        [HttpPost]
        public Task RecordError() => _activityService.LogActivity(2, $"Error reported", null, "Developer", null, "/System/Error");
    }
}
