using LogBook.BusinessLogic.DTO.API;
using LogBook.BusinessLogic.Interface.API;
using Microsoft.AspNetCore.Mvc;

namespace LogBook.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogsController : ControllerBase
    {
        public IClientActivityService _activityService { get; set; }
        public LogsController(IClientActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpPost("Insert")]
        public async Task Insert([FromForm] LogModelDTO data) => await _activityService.LogActivity(data);
    }
}
