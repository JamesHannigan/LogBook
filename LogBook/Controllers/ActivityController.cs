using LogBook.BusinessLogic.Interface.Data;
using Microsoft.AspNetCore.Mvc;

namespace LogBook.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IActivityService _activityService;
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }
        public IActionResult Index() => View();

        [HttpGet]
        public string GetActivitiesAsTableRowsAsync(string? type = null) => _activityService.GetActivitiesAsTableRows(type);
    }
}
