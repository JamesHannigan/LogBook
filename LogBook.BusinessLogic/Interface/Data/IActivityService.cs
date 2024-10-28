using LogBook.BusinessLogic.Service.Data;
using LogBook.Data.Models;

namespace LogBook.BusinessLogic.Interface.Data
{
    public interface IActivityService
    {
        string GetActivitiesAsTableRows(string? startDate, string? endDate, string? projectsString, string? logTypesString);
        Task<FiltersData> GetFiltersData();
        Task LogActivity(int? type, string? description, int? userId, string? userName, string? userEmail, string? path);
        Task LogActivity(Activity activity);
        Task LogActivities(List<Activity> activities);
        Task LogError(int? type, string? description, int? userId, string? userName, string? userEmail, string? path);
        int GetNumberOfActivites(int presetId, string userId);
    }
}
