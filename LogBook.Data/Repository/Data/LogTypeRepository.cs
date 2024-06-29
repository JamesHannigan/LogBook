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
    }
}
