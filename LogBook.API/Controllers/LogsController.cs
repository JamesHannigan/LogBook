using LogBook.API.Models;
using LogBook.BusinessLogic.Interface.Data;
using Microsoft.AspNetCore.Mvc;

namespace LogBook.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogsController : ControllerBase
    {
        public IActivityService _activityService { get; set; }
        public LogsController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpPost("Insert")]
        public async Task Insert([FromForm] LogModel data)
        {
            //BODY

            //await _activityService.LogActivity();
        }
    }
}
