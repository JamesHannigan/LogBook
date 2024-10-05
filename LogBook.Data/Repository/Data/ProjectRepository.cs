using LogBook.Data.DTOs.Data;
using LogBook.Data.Interface.Data;
using LogBook.Data.Models;
using LogBook.DataLayer;
using LogBook.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LogBook.Data.Repository.Data
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Project? GetProjectByGuid(Guid projectGuid)
        {
            return _context.Set<Project>().AsQueryable().FirstOrDefault(p => !string.IsNullOrWhiteSpace(p.ApiKey) && p.PublicId == projectGuid);
        }

        public Project? GetProjectByAPIKey(string apiKey)
        {
            return _context.Set<Project>().AsQueryable().FirstOrDefault(p => !string.IsNullOrWhiteSpace(p.ApiKey) && p.ApiKey.ToUpper() == apiKey.ToUpper());
        }

        public List<ProjectDTO> GetAssignedProjects(string userId)
        {
            List<Project?> assignedProjects = 
                _context.Set<ProjectAssignment>().AsQueryable()
                .Include(x => x.Project)
                .Include(x => x.Assignee)
                .Where(a => a.AssigneeId == userId)
                .Select(p => p.Project)
                .ToList();
            return assignedProjects.Select(a => new ProjectDTO() { PublicId = a.PublicId, Name = a.Name }).ToList();
        }

        public List<ProjectDTO> GetAssignedProjectsWithData()
        {
            List<ProjectDTO> projectsDTOs = 
                (from projects in _context.Projects

                join logTypes in _context.LogTypes.DefaultIfEmpty() on projects.Id equals logTypes.ProjectId into lt from subgroupLt in lt.DefaultIfEmpty()

                 join logs in _context.Logs.DefaultIfEmpty() on projects.Id equals logs.ProjectId into gj from subgroup in gj.DefaultIfEmpty()

                 join projectAssignment in _context.ProjectAssignments.DefaultIfEmpty() on projects.Id equals projectAssignment.ProjectId into pa from subgroupPA in pa.DefaultIfEmpty()

                 where projects.Deleted == null
                 group new { 
                    subgroup, 
                    subgroupLt, subgroupPA 
                } by projects into projectGroup
                    select new ProjectDTO
                    {
                        Id = projectGroup.Key.Id,
                        PublicId = projectGroup.Key.PublicId,
                        Name = projectGroup.Key.Name,
                        Created = projectGroup.Key.Created,
                        LogsCount = projectGroup.Select(g => g.subgroup.Id).Distinct().Count(),
                        LogTypesCount = projectGroup.Where(t => t.subgroupLt.Deleted == null).Select(g => g.subgroupLt.Id).Distinct().Count(),
                        AssigneesCount = projectGroup.Select(g => g.subgroupPA.Id).Distinct().Count()
                        //Get tenents
                    }
                ).ToList();

            return projectsDTOs;
        }

        public ProjectDTO GetProjectWithData(Guid projectID)
        {
            ProjectDTO projectsDTOs = 
                (from projects in _context.Projects where projects.PublicId == projectID

                join logTypes in _context.LogTypes.DefaultIfEmpty() on projects.Id equals logTypes.ProjectId into lt from subgroupLt in lt.DefaultIfEmpty()

                 join logs in _context.Logs.DefaultIfEmpty() on projects.Id equals logs.ProjectId into gj from subgroup in gj.DefaultIfEmpty()

                 join projectAssignment in _context.ProjectAssignments.DefaultIfEmpty() on projects.Id equals projectAssignment.ProjectId into pa from subgroupPA in pa.DefaultIfEmpty()

                 where projects.Deleted == null
                 group new { 
                    subgroup, 
                    subgroupLt, subgroupPA 
                } by projects into projectGroup
                    select new ProjectDTO
                    {
                        Id = projectGroup.Key.Id,
                        PublicId = projectGroup.Key.PublicId,
                        Name = projectGroup.Key.Name,
                        Created = projectGroup.Key.Created,
                        LogsCount = projectGroup.Select(g => g.subgroup.Id).Distinct().Count(),
                        LogTypesCount = projectGroup.Where(t => t.subgroupLt.Deleted == null).Select(g => g.subgroupLt.Id).Distinct().Count(),
                        AssigneesCount = projectGroup.Select(g => g.subgroupPA.Id).Distinct().Count()
                        //Get tenents
                    }
                ).ToList().First();

            return projectsDTOs;
        }
    }
}