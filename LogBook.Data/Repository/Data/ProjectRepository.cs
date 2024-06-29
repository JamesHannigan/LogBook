using LogBook.Data.Interface.Data;
using LogBook.Data.Models;
using LogBook.DataLayer;
using LogBook.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBook.Data.Repository.Data
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Project? GetProjectByAPIKey(string apiKey)
        {
            return _context.Set<Project>().AsQueryable().FirstOrDefault(p => !string.IsNullOrWhiteSpace(p.ApiKey) && p.ApiKey.ToUpper() == apiKey.ToUpper());
        }
    }
}
