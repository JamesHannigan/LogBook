using LogBook.BusinessLogic.Interface.Data;
using Microsoft.AspNetCore.Mvc;

namespace LogBook.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService) => _projectService = projectService;
        
        public IActionResult Index() => View();
        public async Task CreateProject(string name) => await _projectService.CreateProject(name);
        public async Task<string> GetProjects() => await _projectService.GetProjectsHTML();
        //public async Task CreateLogType(string name) => await _projectService.CreateLogType(name);
    }
}
