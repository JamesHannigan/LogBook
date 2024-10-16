﻿using LogBook.Data.Enum;
using LogBook.Data.Interface.Data;
using LogBook.Data.Models;
using LogBook.DataLayer;
using LogBook.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LogBook.Data.Repository.Data
{
    public class ActivityRepository : BaseRepository<Activity>, IActivityRepository
    {
        public ActivityRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<Activity> GetLogsByFilters(DateTime start, DateTime end, List<Guid>? projectIds, List<TypeLevel>? logTypes)
        {
            return _context.Logs.AsQueryable()
                .Where(t => 
                    (t.Timestamp.HasValue && t.Timestamp.Value > start && t.Timestamp.Value < end) ||
                    (!t.Timestamp.HasValue && t.Created > start && t.Created < end))
                .Where(t => (projectIds == null) || (projectIds != null && projectIds.Contains(t.Project.PublicId)))
                .Where(t => (logTypes == null) || (logTypes != null && t.LogType != null && logTypes.Contains(t.LogType.Level)))
                .Include(x => x.Project)
                .Include(x => x.LogType)
                .ToList();
        }

        public async Task<List<Activity>> GetActiviesByDateRange(DateTime startDate, DateTime endDate, int? activityType = null, string? userName = null, int? userType = null)
        {
            startDate = DateTime.Parse(startDate.ToString("yyyy-MM-dd") + " 00:00:00");
            endDate = DateTime.Parse(endDate.ToString("yyyy-MM-dd") + " 23:59:59");

            List<Activity> result = new List<Activity>();

            try
            {
                result = await _context.Set<Activity>().AsQueryable().Where(t => t.Deleted == null &&
                        startDate <= t.Created && t.Created <= endDate &&
                        (!activityType.HasValue || t.LogTypeId == activityType.Value)
                    )
                    .Where(t => string.IsNullOrWhiteSpace(userName) || t.UserName != null && t.UserName.ToLower().Contains(userName.ToLower())
                    )
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                string h = ex.Message;
            }
            return result;
        }
    }
}
