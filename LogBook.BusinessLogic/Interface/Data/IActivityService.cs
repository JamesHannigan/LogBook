using LogBook.BusinessLogic.Service.Data;

namespace LogBook.BusinessLogic.Interface.Data
{
    public interface IActivityService
    {
        string GetActivitiesAsTableRows(string? startDate, string? endDate, string? projectsString, string? logTypesString);
        Task<FiltersData> GetFiltersData();
        Task LogActivity(int? type, string? description, int? userId, string? userName, string? userEmail, string? path);
        Task LogError(int? type, string? description, int? userId, string? userName, string? userEmail, string? path);
    }
}
