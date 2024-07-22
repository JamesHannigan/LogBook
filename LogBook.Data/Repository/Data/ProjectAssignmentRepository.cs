using LogBook.Data.Interface.Data;
using LogBook.Data.Models;
using LogBook.DataLayer;
using LogBook.DataLayer.Repositories;

namespace LogBook.Data.Repository.Data
{
    public class ProjectAssignmentRepository : BaseRepository<ProjectAssignment>, IProjectAssignmentRepository
    {
        public ProjectAssignmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
