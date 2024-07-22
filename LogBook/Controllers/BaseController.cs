using LogBook.BusinessLogic.Interface.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LogBook.Controllers
{
    public class BaseController : Controller
    {
        //public BaseController(IProjectService projectService)
        //{
        //    _projectService = projectService;
        //}

        public string UserId
        {
            get
            {
                return this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }
    }
}
