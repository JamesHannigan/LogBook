using LogBook.Data.DTOs.Data;
using LogBook.Data.Models;
using LogBook.DataLayer.Interfaces;

namespace LogBook.Data.Interface.Data
{
    public interface IProjectAssignmentRepository : IBaseRepository<ProjectAssignment>
    {
        List<AssigneeDTO> GetAssignedUsersByProject(int projectId);
    }
}
