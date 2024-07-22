using LogBook.Data.DTOs.Data;
using LogBook.Data.Models;
using LogBook.DataLayer.Interfaces;

namespace LogBook.Data.Interface.Data
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        List<ProjectDTO> GetAssignedProjects(string userId);
        List<ProjectDTO> GetAssignedProjectsWithData();
        Project? GetProjectByAPIKey(string apiKey);
        Project? GetProjectByGuid(Guid projectGuid);
    }
}
