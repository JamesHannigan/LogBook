using LogBook.Data.DTOs.Data;
using LogBook.Data.Interface.Data;
using LogBook.Data.Models;
using LogBook.DataLayer;
using LogBook.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LogBook.Data.Repository.Data
{
    public class ProjectAssignmentRepository : BaseRepository<ProjectAssignment>, IProjectAssignmentRepository
    {
        public ProjectAssignmentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<AssigneeDTO> GetAssignedUsersByProject(int projectId)
        {
            //List<ApplicationUser?> assignedProjects =
                return _context.Set<ProjectAssignment>().AsQueryable()
                .Include(x => x.Assignee)
                .Where(a => a.ProjectId == projectId)
                .Select(p => new AssigneeDTO()
                {
                    FirstName = p.Assignee.FirstName,
                    LastName = p.Assignee.LastName,
                    UserName = p.Assignee.UserName,
                    Email = p.Assignee.Email,
                    RoleType = p.RoleType,
                    InviteAccepted = p.InviteAccepted,
                })
                .OrderByDescending(p => p.RoleType)
                .ToList();
            //return assignedProjects.Select(a => new AssigneeDTO() { FirstName = a.FirstName, LastName = a.LastName, Email = a.Email, UserName = a.UserName, RoleType = a. }).ToList();
        }
    }
}
