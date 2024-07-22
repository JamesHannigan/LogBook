using LogBook.BusinessLogic.Interface.Data;
using Microsoft.AspNetCore.Mvc;

namespace LogBook.Controllers
{
    public class ConfigurationController : BaseController
    {
        public IProjectService _projectService { get; set; }
        public ConfigurationController(IProjectService projectService) => _projectService = projectService;
        
        public IActionResult Index() => View();
        public IActionResult Project() => View();

        [HttpPost]
        public async Task CreateProject(string name) => await _projectService.CreateProject(name, UserId);

        [HttpGet]
        public string GetProjects() => _projectService.GetProjectsHTML();
        //public async Task CreateLogType(string name) => await _projectService.CreateLogType(name);

        [HttpGet]
        public IActionResult GetUsersProjects() => Json(_projectService.GetAssignedProjects(UserId));

        [HttpPost]
        public void RemoveProject(Guid projectId) => _projectService.RemoveProject(projectId, UserId);
    }
}
