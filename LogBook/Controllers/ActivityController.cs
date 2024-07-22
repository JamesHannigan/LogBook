using LogBook.BusinessLogic.Interface.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogBook.Controllers
{
    [Authorize]
    public class ActivityController : Controller
    {
        private readonly IActivityService _activityService;
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        public IActionResult Index() => View();

        [HttpGet]
        public async Task<IActionResult> GetFiltersDataAsync() => Json(await _activityService.GetFiltersData());

        [HttpGet]
        public string GetActivitiesAsTableRows(string? start, string? end, string? project = null, string? type = null, string? user = null) => _activityService.GetActivitiesAsTableRows(start, end, project, type);
    }
}
