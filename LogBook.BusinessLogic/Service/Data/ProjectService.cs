using LogBook.BusinessLogic.Interface.Data;
using LogBook.Data.Interface.Data;
using LogBook.Data.Models;

namespace LogBook.BusinessLogic.Service.Data
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ILogTypeRepository _logTypeRepository;
        public ProjectService(IProjectRepository projectRepository, ILogTypeRepository logTypeRepository)
        {
            _projectRepository = projectRepository;
            _logTypeRepository = logTypeRepository;
        }
        public async Task CreateProject(string name) {
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

            Project newProject = new() { Name = name, ApiKey = apiKey };
            int newProjectId = await _projectRepository.InsertAndCommit(newProject);
            //Test if this works
            try
            {
                await _logTypeRepository.Insert(new LogType() { Name = "Page Visit", ProjectId = newProjectId });
                await _logTypeRepository.Insert(new LogType() { Name = "Error Reported", ProjectId = newProjectId });
                await _logTypeRepository.Insert(new LogType() { Name = "Information Log", ProjectId = newProjectId });
                await _logTypeRepository.CommitChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public async Task<string> GetProjectsHTML()
        {
            List<Project> projects = await _projectRepository.GetAll();
            return string.Join("", projects.Select(p => 
                $"<div class='col-4 p-2'><div class='bg-light shadow p-3 rounded'><h5 class='text-center'>{p.Name}</h5><p class='m-0 small'>Number of logs</p><p class='m-0 small'>0 tenants listed</p></div></div>"
            ));
        }
    }
}
