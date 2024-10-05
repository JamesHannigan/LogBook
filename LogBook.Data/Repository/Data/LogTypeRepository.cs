using LogBook.Data.Interface.Data;
using LogBook.Data.Models;
using LogBook.DataLayer;
using LogBook.DataLayer.Repositories;

namespace LogBook.Data.Repository.Data
{
    public class LogTypeRepository : BaseRepository<LogType>, ILogTypeRepository
    {
        public LogTypeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<LogType> GetLogTypesByProject(int projectID)
        {
            return _context.Set<LogType>().AsQueryable().Where(p => p.Deleted == null && p.ProjectId == projectID).ToList();
        }
    }
}
