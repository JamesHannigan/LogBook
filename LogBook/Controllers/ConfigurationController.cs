using LogBook.BusinessLogic.Interface.Data;
using LogBook.Data.Enum;
using Microsoft.AspNetCore.Mvc;

namespace LogBook.Controllers
{
    public class ConfigurationController : BaseController
    {
        public IProjectService _projectService { get; set; }
        public ConfigurationController(IProjectService projectService) => _projectService = projectService;
        
        //Pages
        public IActionResult Index() => View();
        public IActionResult Project() => View();

        //Project Related Functions
        [HttpGet]
        public IActionResult GetProjectWithData(Guid projectGUID) => Json(_projectService.GetProjectWithDataAsync(projectGUID));

        [HttpGet]
        public string GetProjects() => _projectService.GetProjectsHTML();

        [HttpPost]
        public async Task CreateProject(string name) => await _projectService.CreateProject(name, UserId);

        [HttpPost]
        public async Task InviteUser(string username, Guid projectGUID) => await _projectService.InviteUserToProject(UserId, username, projectGUID);

        [HttpGet]
        public IActionResult GetUsersProjects() => Json(_projectService.GetAssignedProjects(UserId));

        [HttpPost]
        public void RemoveProject(Guid projectId) => _projectService.RemoveProject(projectId, UserId);

        //Log Type
        [HttpPost]
        public void CreateLogType(string name, Guid projectGUID, TypeLevel typeLevel = TypeLevel.Unassigned) => _projectService.CreateLogType(name, typeLevel, projectGUID);
    }
}
