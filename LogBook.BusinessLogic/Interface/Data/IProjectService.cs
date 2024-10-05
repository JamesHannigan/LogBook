using LogBook.Data.DTOs.Data;
using LogBook.Data.Enum;
using LogBook.Data.Models;

namespace LogBook.BusinessLogic.Interface.Data
{
    public interface IProjectService
    {
        void CreateLogType(string name, TypeLevel level, Guid projectGuid);
        Task CreateProject(string name, string userId);
        List<ProjectDTO> GetAssignedProjects(string id);
        string GetProjectsHTML();
        ProjectDTO GetProjectWithDataAsync(Guid projectGUID);
        Task InviteUserToProject(string applicationUser, string userNameOrEmail, Guid projectGUID);
        void RemoveProject(Guid projectGuid, string userId);
    }
}
