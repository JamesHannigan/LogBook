using LogBook.BusinessLogic.Interface.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogBook.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {
        private readonly IActivityService _activityService;
        public DashboardController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        public IActionResult Index() => View();

        public int GetNumber(int preset) => _activityService.GetNumberOfActivites(preset, UserId);

        //Get Graph Dataset


        //Get Logs Dataset

    }
}
