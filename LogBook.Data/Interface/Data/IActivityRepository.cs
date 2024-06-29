using LogBook.Data.Models;
using LogBook.DataLayer.Interfaces;

namespace LogBook.Data.Interface.Data
{
    public interface IActivityRepository : IBaseRepository<Activity>
    {
        Task<List<Activity>> GetActiviesByDateRange(DateTime startDate, DateTime endDate, int? activityType = null, string userName = "", int? userType = null);
        List<Activity> GetLogsByProjectID(int projectId, List<int>? logTypes);
    }
}
