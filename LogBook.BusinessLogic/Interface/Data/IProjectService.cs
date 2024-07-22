using LogBook.Data.DTOs.Data;
using LogBook.Data.Models;

namespace LogBook.BusinessLogic.Interface.Data
{
    public interface IProjectService
    {
        Task CreateProject(string name, string userId);
        List<ProjectDTO> GetAssignedProjects(string id);
        string GetProjectsHTML();
        void RemoveProject(Guid projectGuid, string userId);
    }
}
