using LogBook.BusinessLogic.Interface.Data;
using LogBook.Data.DTOs.Data;
using LogBook.Data.Enum;
using LogBook.Data.Interface.Data;
using LogBook.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Web;

namespace LogBook.BusinessLogic.Service.Data
{
    public class ProjectService : IProjectService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogTypeRepository _logTypeRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectAssignmentRepository _projectAssignmentRepository;
        public ProjectService(
            UserManager<ApplicationUser> userManager,
            ILogTypeRepository logTypeRepository,
            IProjectRepository projectRepository,
            IProjectAssignmentRepository projectAssignmentRepository)
        {
            _userManager = userManager;
            _logTypeRepository = logTypeRepository;
            _projectRepository = projectRepository;
            _projectAssignmentRepository = projectAssignmentRepository;
        }

        public async Task CreateProject(string name, string userId)
        {
            string apiKey = "";
            bool isApiKeyUnique = true;
            while (isApiKeyUnique)
            {
                Guid apiKeyGuid = Guid.NewGuid();
                string apiKeyTemp = "LB" + apiKeyGuid.ToString().Replace("-", "").ToUpper();
                Project? existingProject = _projectRepository.GetProjectByAPIKey(apiKey);
                if (existingProject == null)
                {
                    apiKey = apiKeyTemp;
                    isApiKeyUnique = false;
                }
            }

            ApplicationUser? currentUser = await _userManager.FindByIdAsync(userId);

            Project newProject = new() { Name = name, ApiKey = apiKey };
            int newProjectId = await _projectRepository.InsertAndCommit(newProject);
            //Test if this works
            try
            {
                await _logTypeRepository.Insert(new LogType() { Name = "Page Visit", ProjectId = newProjectId, Level = TypeLevel.Information });
                await _logTypeRepository.Insert(new LogType() { Name = "Information Log", ProjectId = newProjectId, Level = TypeLevel.Information });
                await _logTypeRepository.Insert(new LogType() { Name = "Error Reported", ProjectId = newProjectId, Level = TypeLevel.Severe });
                await _logTypeRepository.Insert(new LogType() { Name = "Warning", ProjectId = newProjectId, Level = TypeLevel.Warning });
                await _logTypeRepository.Insert(new LogType() { Name = "Completed Tasks", ProjectId = newProjectId, Level = TypeLevel.Success });
                await _logTypeRepository.CommitChanges();

                await _projectAssignmentRepository.InsertAndCommit(new ProjectAssignment()
                {
                    InviteAccepted = DateTime.UtcNow,
                    ProjectId = newProject.Id,
                    RoleType = ProjectRole.Creator,
                    AssigneeId = userId
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public string GetProjectsHTML()
        {
            //, \"{HttpUtility.HtmlEncode(p.Name)}\", \"{p.LogsCount}\", \"{p.LogTypesCount}\", \"{p.AssigneesCount}\"

            List<ProjectDTO> projects = _projectRepository.GetAssignedProjectsWithData();
            return string.Join("", projects.Select(p =>
                $"<div onclick='openProjectPage(\"{p.PublicId}\")' class='col-4 p-2 cursor-pointer'><div class='border border-1 border-light bg-secondary bg-opacity-50 shadow p-3 rounded'><h5 class='text-center'>{p.Name}</h5>" +

                $"<div class='row'><div class='col text-center'><i class='fa-solid fa-list-ul'></i> <b>{p.LogsCount}</b></div><div class='col text-center'><i class='fa-regular fa-square-caret-down'></i> <b>{p.LogTypesCount}</b></div><div class='col text-center'><i class='fa-solid fa-user{(p.LogsCount > 1 ? "s" : "")}'></i> <b>{p.AssigneesCount}</b></div></div> " +

                $"</div></div>"
            ));
        }

        public List<ProjectDTO> GetAssignedProjects(string userId) => _projectRepository.GetAssignedProjects(userId);

        public void RemoveProject(Guid projectGuid, string userId)
        {
            //Get project
            Project? project = _projectRepository.GetProjectByGuid(projectGuid);

            //Is user assigned as admin (second check)
            //else - error

            if (project != null)
            {
                _projectRepository.SoftDelete(project);
                _projectRepository.CommitChanges();
            }

            //delete
            //_projectRepository.SoftDelete(userId);
            
            //update
        }
    }
}
